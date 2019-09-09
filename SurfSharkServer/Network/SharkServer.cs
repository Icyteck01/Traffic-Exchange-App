using JHSNetProtocol;
using SurfSharkServer;
using SurfSharkServer.com;
using SurfSharkServer.Network;
using System.Collections.Generic;

public class SharkServer
{
    static object s_Sync = new object();
    static volatile SharkServer s_Instance;
    public static SharkServer Instance
    {
        get
        {
            if (s_Instance == null)
            {
                lock (s_Sync)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new SharkServer();
                    }
                }
            }
            return s_Instance;
        }
    }
    #region HANDLERS
    private Dictionary<short, IJHSInterface> m_MessageHandlersDict = new Dictionary<short, IJHSInterface>();

    public void RegisterHandeler(short id, IJHSInterface handler)
    {
        if (!m_MessageHandlersDict.ContainsKey(id))
        {
            JHSNetworkServer.RegisterHandler(id, OnNetworkReceive);
            m_MessageHandlersDict[id] = handler;
        }
        else
            LOG.Error("Network Handler " + id + " already exist.");
    }

    public void UnregisterHandler(short id)
    {
        if (m_MessageHandlersDict.ContainsKey(id))
            m_MessageHandlersDict.Remove(id);
        else
            LOG.Error("Network Handler " + id + " already exist.");
    }
    #endregion
    public void Connect()
    {
        JHSNetworkServer.RegisterHandler(InternalMessages.DISCONNECT, OnDisconnect);
    //    JHSNetworkServer.RegisterHandler(InternalMessages.RECIEVE, OnNetworkReceive);
        RegisterHandeler(NetworkConstants.LOGIN, new LoginHandler());
        RegisterHandeler(NetworkConstants.REGISTER, new RegisterHandler());
        string ListenIP = Program.configs.GetValue<string>("HOST");
        int ListenPort = Program.configs.GetValue<int>("PORT");
        int password = Program.configs.GetValue<int>("ServerPassword");
        int Version = Program.configs.GetValue<int>("Version");
        JHSNetworkServer.Start(ListenIP, ListenPort);
    }

    private void OnNetworkReceive(JHSNetworkMessage netMsg)
    {
        if (m_MessageHandlersDict.TryGetValue(netMsg.msgType, out IJHSInterface handler))
        {
            lock (handler)
            {
                handler.Execute(netMsg);
            }
        }
    }

    private void OnDisconnect(JHSNetworkMessage netMsg)
    {
        User user = UserManager.Instance.GetUserByConnectionId(netMsg.conn.connectionId);
        if (user != null)
        {
            lock (user)
            {
                user.OnLogout();
                UserManager.Instance.RemoveOnline(netMsg.conn.connectionId);
            }
        }
    }

    public static void Start()
    {
        Instance.Connect();
    }

}

