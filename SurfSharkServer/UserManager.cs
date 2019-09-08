using NHibernate;
using NHibernate.Cfg;
using SurfSharkServer.com;
using System;
using System.Collections.Concurrent;
using System.IO;

public class UserManager
{
    static object s_Sync = new object();
    static volatile UserManager s_Instance;
    public static UserManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                lock (s_Sync)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new UserManager();
                    }
                }
            }
            return s_Instance;
        }
    }


    protected ConcurrentDictionary<uint, User> Users_ConId = new ConcurrentDictionary<uint, User>();
    protected ConcurrentDictionary<string, uint> Users_UserName = new ConcurrentDictionary<string, uint>();
    protected ConcurrentDictionary<string, uint> Users_HWKEY = new ConcurrentDictionary<string, uint>();
    public UserManager()
    {

    }
    public User GetUserByConnectionId(uint connectionId)
    {
        if (Users_ConId.TryGetValue(connectionId, out User val))
            return val;
        return null;
    }
    public User GetUserByNameId(string UserName)
    {
        if (Users_UserName.TryGetValue(UserName, out uint val))
            return GetUserByConnectionId(val);
        return null;
    }
    public User GetUserHarwereKeyId(string UserName)
    {
        if (Users_HWKEY.TryGetValue(UserName, out uint val))
            return GetUserByConnectionId(val);
        return null;
    }

    public void AddOnline(uint ConnectionId, User user)
    {
        Users_ConId.TryAdd(ConnectionId, user);
        Users_UserName.TryAdd(user.UserName, ConnectionId);
        Users_HWKEY.TryAdd(user.Hwid, ConnectionId);
    }

    public void RemoveOnline(uint connectionId)
    {
        if (Users_ConId.TryGetValue(connectionId, out User u))
        {
            Users_ConId.TryRemove(connectionId, out User x1);
            Users_UserName.TryRemove(u.UserName, out uint x2);
            Users_HWKEY.TryRemove(u.Hwid, out uint x3);
        }
    }

    public User GetUserFromDatabase(string username)
    {
        return null;
    }
}

