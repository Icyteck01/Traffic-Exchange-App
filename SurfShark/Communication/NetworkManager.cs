using JHSNetProtocol;
using SurfShark;
using SurfShark.programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

public class NetworkManager
{
    static object s_Sync = new object();
    static volatile NetworkManager s_Instance;
    public static bool Connected = false;
    public static NetworkManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                lock (s_Sync)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new NetworkManager();
                    }
                }
            }
            return s_Instance;
        }
    }
    Timer NetworkUpdate;

    public void Connect()
    {
        JHSNetworkClient.Start("127.0.0.1");
        JHSNetworkClient.RegisterHandler(InternalMessages.CONNECTED, CONNECTED_TO_SERVER);
        JHSNetworkClient.RegisterHandler(InternalMessages.DISCONNECT, DISCONNECTED_PERMANENT);
        JHSNetworkClient.RegisterHandler(InternalMessages.DISCONNECT_BUT_WILL_RECONNECT, DISCONNECTED_FROM_SERVER);
        JHSNetworkClient.RegisterHandler(NetworkConstants.LOGIN, OnLogin);
        NetworkUpdate = new Timer();
        NetworkUpdate.Elapsed += OnTimedEvent;
        NetworkUpdate.Interval = 500; // in miliseconds
        NetworkUpdate.Start();
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        JHSNetworkClient.Update();
    }

    public static void Start()
    {
        Instance.Connect();
    }

    private void DISCONNECTED_FROM_SERVER(JHSNetworkMessage netMsg)
    {
        Connected = false;
    }

    private void DISCONNECTED_PERMANENT(JHSNetworkMessage netMsg)
    {
        Connected = false;
    }

    private void CONNECTED_TO_SERVER(JHSNetworkMessage netMsg)
    {
        Connected = true;
    }

    private void OnLogin(JHSNetworkMessage netMsg)
    {

    }

    public static void Send(short module, JHSMessageBase packet)
    {
        JHSNetworkClient.Send(module, packet);
    }
}

