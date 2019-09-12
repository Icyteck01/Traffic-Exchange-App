using CommonDB;
using FluentNHibernate.Testing.Values;
using JHSNetProtocol;
using NHibernate;
using NHibernate.Cfg;
using SurfSharkServer.com;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.MySQL;
using SurfSharkServer.MySQL.Tables;
using SurfSharkServer.Network.Packets;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ChatManager
{
    static object s_Sync = new object();
    static volatile ChatManager s_Instance;
    public static ChatManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                lock (s_Sync)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new ChatManager();
                    }
                }
            }
            return s_Instance;
        }
    }

    private HashSet<uint> views = new HashSet<uint>();

    public void RegisterOpenUser(uint conectionId)
    {
        lock(views)
            views.Add(conectionId);
    }
    public void RemoveFromView(uint conectionId)
    {
        lock (views)
            views.Remove(conectionId);
    }

    public void SendToAll(string userName, string msg, long timeStamp)
    {
        lock (views)
        {
            ChatMsg packet = new ChatMsg()
            {
                username = userName,
                date = (ulong)timeStamp,
                msg = msg
            };
            uint[] cons = views.ToArray();
            for(int i = 0; i < cons.Length; i++)
                JHSNetworkServer.Send(cons[i], NetworkConstants.CHAT, packet);
            
        }

    }

}

