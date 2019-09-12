using System.Collections.Generic;
using SurfShark.Communication.Packets;
using SurfShark.Core;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.Network.Packets;

public class MainCache
{
    public static bool chatEnabled = false;
    public static List<ChatMsg> chatList = new List<ChatMsg>();
    //Account
    public static string UserName = "";
    public static string PassWord = "";
    public static bool LoggedIn = false;
    public static uint Credit = 0;
    public static uint SurfedSites = 0;
    public static UserType MemberType = UserType.FREE;
    public static int MaxSlots => MemberType == UserType.FREE ? 5 : 10;

    public static uint AddCredit = 0;
}