using JHSNetProtocol;
using SurfShark;
using SurfShark.Communication.Packets;
using SurfShark.Core;
using SurfShark.Core.Constants;
using SurfSharkServer.Communication.Packets;
using System;
using System.Timers;
using Timer = System.Timers.Timer;

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
        JHSNetworkClient.Start("127.0.0.1", 10000);
        JHSNetworkClient.RegisterHandler(InternalMessages.CONNECTED, CONNECTED_TO_SERVER);
        JHSNetworkClient.RegisterHandler(InternalMessages.DISCONNECT, DISCONNECTED_PERMANENT);
        JHSNetworkClient.RegisterHandler(InternalMessages.DISCONNECT_BUT_WILL_RECONNECT, DISCONNECTED_FROM_SERVER);
        JHSNetworkClient.RegisterHandler(NetworkConstants.LOGIN, OnLogin);
        JHSNetworkClient.RegisterHandler(NetworkConstants.REGISTER, OnRegister);
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
        Connect();
    }

    private void CONNECTED_TO_SERVER(JHSNetworkMessage netMsg)
    {
        Connected = true;
        MainComponent.Core.SendNotification(ProgramConst.SHOW_PROPMPT, "Connected to server.");
    }
    private void OnRegister(JHSNetworkMessage netMsg)
    {
        string msg = "";
        Register packet = netMsg.ReadMessage<Register>();
        if (packet != null)
        {
            switch (packet.Code)
            {
                case ErrorCodes.SUCCESS:
                    msg = "Welcome, your account has been created you may now login.";
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_PROPMPT, msg);
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_BOX, msg);
                    break;
                case ErrorCodes.USER_EXIST:
                    msg = "Username already exists please choose another.";
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_PROPMPT, msg);
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_BOX, msg);
                    break;
                case ErrorCodes.WRONG_PASSWORD:
                case ErrorCodes.GENERAL_FAILURE:

                    break;
            }
        }
    }

    private void OnLogin(JHSNetworkMessage netMsg)
    {
        LoginResponse packet = netMsg.ReadMessage<LoginResponse>();
        if (packet != null)
        {
            switch(packet.Code)
            {
                case ErrorCodes.SUCCESS:
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_MAIN, packet);
                    break;
                case ErrorCodes.WRONG_PASSWORD:
                    string msg = "Wrong username or password!";
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_PROPMPT, msg);
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_BOX, msg);
                    break;
            }
        }
    }



    public static void Send(short module, JHSMessageBase packet)
    {
        JHSNetworkClient.Send(module, packet);
    }
}

