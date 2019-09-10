using System.Collections.Generic;
using SurfShark.Communication.Packets;
using SurfSharkServer.Communication.Packets.Data;

public class MainCache
{
    public static string UserName = "";
    public static string PassWord = "";
    public static bool LoggedIn = false;
    public static bool chatEnabled;
    public static uint Credit;
    public static ChatResponse[] chatList { get; set; }
    public static SiteClass[] Urs { get; set; }
}