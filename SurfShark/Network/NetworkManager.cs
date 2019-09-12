using JHSNetProtocol;
using SurfShark;
using SurfShark.Communication.Packets;
using SurfShark.Core;
using SurfShark.Core.Constants;
using SurfSharkServer.Communication.Packets;
using SurfSharkServer.Communication.Packets.Data;
using System;
using System.Collections.Generic;
using System.Timers;
using Timer = System.Timers.Timer;
using static SurfShark.Core.Constants.ProgramConst;
using SurfShark.Network.Packets;
using SurfSharkServer.Network.Packets;

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

    public void Connect()
    {
        JHSNetworkClient.Start("86.122.52.0", 7777);
        JHSNetworkClient.RegisterHandler(InternalMessages.CONNECTED, CONNECTED_TO_SERVER);
        JHSNetworkClient.RegisterHandler(InternalMessages.DISCONNECT, DISCONNECTED_PERMANENT);
        JHSNetworkClient.RegisterHandler(InternalMessages.DISCONNECT_BUT_WILL_RECONNECT, DISCONNECTED_FROM_SERVER);
        JHSNetworkClient.RegisterHandler(NetworkConstants.LOGIN, OnLogin);
        JHSNetworkClient.RegisterHandler(NetworkConstants.REGISTER, OnRegister);
        JHSNetworkClient.RegisterHandler(NetworkConstants.UPDATE_SITE_DATA, OnDataUpdatedSuccesfuly);
        JHSNetworkClient.RegisterHandler(NetworkConstants.GET_NEW_URL, OnRecNewSurfSite);
        JHSNetworkClient.RegisterHandler(NetworkConstants.CHAT, OnChatRecieve);
        LateInvoker.InvokeRepeating(OnTimedEvent, 0.1f);
    }

    private void OnChatRecieve(JHSNetworkMessage netMsg)
    {
        ChatMsg packet = netMsg.ReadMessage<ChatMsg>();
        if(packet != null)
        {
            MainCache.chatList.Add(packet);
            MainComponent.Core.SendNotification(REFRESH_CHAT_WINDOW);
        }
    }

    private void OnRecNewSurfSite(JHSNetworkMessage netMsg)
    {
        UrlDetails packet = netMsg.ReadMessage<UrlDetails>();
        if (packet != null)
        {
            MainCache.Credit += MainCache.AddCredit;
            MainCache.SurfedSites += 1;
            MainComponent.Core.SendNotification(SHOW_MAIN);
            MainComponent.Core.SendNotification(GOT_NEW_URL, packet);
        }
    }

    private void OnDataUpdatedSuccesfuly(JHSNetworkMessage netMsg)
    {
        SubmitDataForUpdate data = netMsg.ReadMessage<SubmitDataForUpdate>();
        if(data != null && data.Code == ErrorCodes.JUST_DATA_UPDATE)
        {
            SitesManager.Init(data.Changed);
        }
        else
        {
            SitesManager.UpdateSuccess();
        }
    }

    private void OnTimedEvent()
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
        if(MainComponent.state == ProgramState.LOGGED_IN)
        {
            MainComponent.Core.SendNotification(DO_LOGIN, new string[] { MainCache.UserName, MainCache.PassWord });
        }
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
                    MainCache.Credit = packet.Credits;
                    SitesManager.Init(packet.sites);
                    MainCache.MemberType = packet.MemberType;
                    MainCache.SurfedSites = packet.SurfedSites;
                    MainCache.LoggedIn = true;
                    MainComponent.Core.SendNotification(ProgramConst.SHOW_MAIN);
                    MainComponent.state = ProgramState.LOGGED_IN;
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

