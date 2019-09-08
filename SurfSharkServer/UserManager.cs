using CommonDB;
using NHibernate;
using NHibernate.Cfg;
using SurfSharkServer.com;
using SurfSharkServer.MySQL.Tables;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;

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


    protected ConcurrentDictionary<uint, User> ConnectedUsers = new ConcurrentDictionary<uint, User>();
    protected ConcurrentDictionary<string, uint> Users_UserName = new ConcurrentDictionary<string, uint>();
    public UserManager()
    {

    }

    public User GetUserByConnectionId(uint connectionId)
    {
        if (ConnectedUsers.TryGetValue(connectionId, out User val))
            return val;
        return null;
    }

    public User GetUserByName(string UserName)
    {
        ISession session = DbService.GetDBSession;
        if(session != null && session.IsConnected)
        {
            UserAccounts account = session.QueryOver<UserAccounts>().Where(x => x.userName == UserName).List().FirstOrDefault();
            if (account != null)
                return new User(account);
        }
        return null;
    }

    public void AddOnline(uint ConnectionId, User user)
    {
        ConnectedUsers.TryAdd(ConnectionId, user);
    }

    public void RemoveOnline(uint connectionId)
    {
        if (ConnectedUsers.TryRemove(connectionId, out User x1))
        {

        }
    }
}

