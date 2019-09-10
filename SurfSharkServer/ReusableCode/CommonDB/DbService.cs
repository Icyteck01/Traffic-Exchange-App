using System;
using System.Collections.Concurrent;
using System.Timers;
using CommonDB.model;
using NHibernate;

namespace CommonDB
{
    public sealed class DbService : HibernateAdapter<uint>
    {
        #region SINGLETON
        private static object s_Sync = new object();
        static volatile DbService s_Instance;
        public static DbService Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new DbService();
                        }
                    }
                }
                return s_Instance;
            }
        }
        #endregion

        #region VARS
        private static readonly ConcurrentDictionary<string, CacheObject<uint>> ENTITYS = new ConcurrentDictionary<string, CacheObject<uint>>();
        private static readonly ConcurrentQueue<string> UPDATE_QUEUE = new ConcurrentQueue<string>();

        public int UpdateEvery = 100;

        static HibernateAdapter<uint> _HAdapter = null;
        public HibernateAdapter<uint> HAdapter
        {
            get
            {
                if (_HAdapter == null)
                {
                    _HAdapter = new HibernateAdapter<uint>();
                }
                return _HAdapter;
            }
        }
        #endregion

        #region CONSTRUCTOR
        public DbService()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = UpdateEvery * 1000;
            aTimer.Enabled = true;
        }
        #endregion

        #region LOGIC
        void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            RunUpdate();
        }

        string GetKey<T>(uint key)
        {
            return typeof(T).Name + "_" + key;
        }

        T Get<T>(uint key, bool IsGetFromDb = false)
        {
            string StrKey = GetKey<T>(key);
            if (IsGetFromDb)
            {
                T d = HAdapter.Get<T>(key);
                if (d is CacheObject<uint> e)
                {
                    return (T)e.GetEntity();
                }
                else
                {
                    e = CacheObject<uint>.ValueOf(key, d);
                    ENTITYS.TryAdd(StrKey, e);
                    return d;
                }
            }
            else
            {
                if (ENTITYS.TryGetValue(StrKey, out CacheObject<uint> e))
                {
                    return (T)e.GetEntity();
                }
                else
                {
                    return Get<T>(key, true);
                }

            }
        }

        public void RemoveFromDB<T>(uint Id)
        {
            string Key = GetKey<T>(Id);
            if (ENTITYS.TryRemove(Key, out CacheObject<uint> c))
            {
                Delete(c);
            }
            else
            {
                T ent = GetEntity<T>(Id);
                if (ENTITYS.TryRemove(Key, out c))
                {
                    Delete(ent);
                }
            }
        }

        public T GetEntity<T>(uint Key)
        {
            return Get<T>(Key);
        }

        void Put2ObjectMap(CacheObject<uint> x)
        {
            ENTITYS.AddOrUpdate(x.GetKey(), x, (string arg1, CacheObject<uint> arg2) => x);
        }

        public void ISubmitUpdate2Queue<T>(uint Key, T Entity)
        {
            if (Entity is CacheObject<uint> x)
            {
                Put2ObjectMap(x); // UPDATE OBJECT IN LIST
                UPDATE_QUEUE.Enqueue(x.GetKey());
            }
            else
            {
                x = CacheObject<uint>.ValueOf(Key, Entity);
                Put2ObjectMap(x);
                UPDATE_QUEUE.Enqueue(x.GetKey());
            }
        }

        public void IUpdateEntityIntime<T>(uint Key, T Entity)
        {
            if (Entity is CacheObject<uint> x)
            {
                Put2ObjectMap(x); // UPDATE OBJECT IN LIST
                Update(x.GetEntity());
            }
            else
            {
                x = CacheObject<uint>.ValueOf(Key, Entity);
                Put2ObjectMap(x);
                Update(x.GetEntity());
            }
        }

        public T ICreateEntity<T>(T Entity)
        {
            return Save<T>(Entity);
        }

        void RunUpdate()
        {
            if (UPDATE_QUEUE.TryDequeue(out string ekey))
            {
                if (ENTITYS.TryGetValue(ekey, out CacheObject<uint> entity))
                {
                    if (entity.IsValidate())
                    {
                        Update(entity.GetEntity());
                    }
                    else
                    {
                        Update(entity.GetEntity());
                        ENTITYS.TryRemove(ekey, out CacheObject<uint> c);
                    }
                }
            }
        }

        ISession IGetSession()
        {
            return HAdapter.GetSession();
        }
        bool IForceQuit()
        {
            while (UPDATE_QUEUE.TryDequeue(out string ekey))
            {
                if (ENTITYS.TryGetValue(ekey, out CacheObject<uint> entity))
                {
                    if (entity.IsValidate())
                    {
                        Update(entity.GetEntity());
                    }
                    else
                    {
                        Update(entity.GetEntity());
                        ENTITYS.TryRemove(ekey, out CacheObject<uint> c);
                    }
                }
            }
            return true;
        }
        #endregion

        #region LAZY 
        public static void SubmitUpdate2Queue<T>(uint Key, T Entity)
        {
            Instance.ISubmitUpdate2Queue<T>(Key, Entity);
        }

        public static T CreateEntity<T>(T Entity)
        {
            return Instance.ICreateEntity<T>(Entity);
        }

        public static void UpdateEntityIntime<T>(uint Key, T Entity)
        {
            Instance.IUpdateEntityIntime<T>(Key, Entity);
        }

        public static T GetFromCache<T>(uint Key)
        {
            return Instance.GetEntity<T>(Key);
        }

        public static void RemoveEntityFromDatabase<T>(uint Key)
        {
            Instance.RemoveFromDB<T>(Key);
        }

        public static ISession GetDBSession => Instance.IGetSession();

        public static bool ForceQuit()
        {
            return Instance.IForceQuit();
        }
        #endregion
    }
}
