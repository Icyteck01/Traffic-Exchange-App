using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.Network.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurfShark.Core
{
    public class SitesManager
    {
        Dictionary<int, SiteClass> allSites = new Dictionary<int, SiteClass>();
        List<int> addedItems = new List<int>();
        List<int> deletedItems = new List<int>();
        List<int> updateItems = new List<int>();
        public void _Init(SiteClass[] newsites)
        {
            lock (allSites)
            {
                addedItems = new List<int>();
                deletedItems = new List<int>();
                updateItems = new List<int>();
                allSites = new Dictionary<int, SiteClass>();
                for (int i = 0; i < newsites.Length; i++)
                {
                    newsites[i].operation = UpdateOperation.NOT_CHANGED;
                    allSites.Add(newsites[i].SiteIndex, newsites[i]);
                }
            }
        }

        public SiteClass[] _ListSites()
        {
            SiteClass[] response;
            lock (allSites)
            {
                response = allSites.Values.Where(x => x.operation != UpdateOperation.DELETE).ToArray();
            }
            return response;
        }

        public void _AddNew()
        {
            lock (allSites)
            {
                int lastindex = allSites.Count;
                allSites.Add(lastindex, new SiteClass() {
                    WebsiteName = "Enter Name",
                    operation = UpdateOperation.ADD_NEW,
                    Referral = ReferralType.DIRECT,
                    Region = CountryList.International,
                    SiteIndex = lastindex //Will be override by server
                });
                addedItems.Add(lastindex);
            }
        }

        public void _Delete(SiteClass Site)
        {
            lock (allSites)
            {
                if (Site.operation == UpdateOperation.ADD_NEW)
                {
                    allSites.Remove(Site.SiteIndex);                  
                }
                else
                {
                    if (allSites.TryGetValue(Site.SiteIndex, out SiteClass site))
                    {
                        site.operation = UpdateOperation.DELETE;
                        deletedItems.Add(site.SiteIndex);
                    }
                }
                addedItems.Remove(Site.SiteIndex);
            }
        }

        public void _UpdateSite(SiteClass Site)
        {
            lock (allSites)
            {
                if (allSites.TryGetValue(Site.SiteIndex, out SiteClass site))
                {
                    site = Site;
                    if (Site.operation == UpdateOperation.CHANGED)
                        updateItems.Add(site.SiteIndex);
                    else if (Site.operation == UpdateOperation.DELETE)
                        deletedItems.Add(site.SiteIndex);
                }
            }
        }

        public int[] _GetDeleted
        {
            get
            {
                return deletedItems.ToArray();
            }
        }

        public SiteClass[] _GetChanged
        {
            get
            {
                List<SiteClass> ret = new List<SiteClass>();
                lock (allSites)
                {
                    for (int i = 0; i < updateItems.Count; i++)
                    {
                        if (allSites.TryGetValue(updateItems[i], out SiteClass site))
                             ret.Add(site);
                    }
                }
                return ret.ToArray();
            }
        }

        public SiteClass[] _GetAdded
        {
            get
            {
                List<SiteClass> ret = new List<SiteClass>();
                lock (allSites)
                {
                    for (int i = 0; i < addedItems.Count; i++)
                    {
                        if (allSites.TryGetValue(addedItems[i], out SiteClass site))
                            ret.Add(site);
                    }
                }
                return ret.ToArray();
            }
        }

        public SiteClass _GetByIndex(int index)
        {
            SiteClass site;
            lock (allSites)
            {
                allSites.TryGetValue(index, out site);
            }
            return site;
        }

        public void _UpdateSuccess()
        {
            lock (allSites)
            {
                foreach (SiteClass site in allSites.Values.ToArray())
                {
                    if (!deletedItems.Contains(site.SiteIndex))// != UpdateOperation.DELETE)
                    {
                        site.operation = UpdateOperation.NOT_CHANGED;
                    }
                    else
                    {
                        allSites.Remove(site.SiteIndex);
                    }
                }

                addedItems = new List<int>();
                deletedItems = new List<int>();
                updateItems = new List<int>();
            }
        }

        #region LAZY
        static object s_Sync = new object();
        static volatile SitesManager s_Instance;
        public static SitesManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_Sync)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new SitesManager();
                        }
                    }
                }
                return s_Instance;
            }
        }
        public static void Init(SiteClass[] newsites)
        {
            Instance._Init(newsites);
        }
        public static SiteClass GetByIndex(int index)
        {
            return Instance._GetByIndex(index);
        }
        public static SiteClass[] Sites => Instance._ListSites();

        public static void UpdateSite(SiteClass Site)
        {
            Instance._UpdateSite(Site);
        }
        public static void AddNew()
        {
            Instance._AddNew();
        }
        public static void Delete(SiteClass Site)
        {
            Instance._Delete(Site);
        }
        public static int[] Deleted() { return Instance._GetDeleted; }

        public static SiteClass[] Changed() { return Instance._GetChanged; }

        public static SiteClass[] Added() { return Instance._GetAdded; }

        public static void UpdateSuccess() { Instance._UpdateSuccess(); }
        #endregion
    }
}
