using SurfShark.Communication.Packets;
using System.Collections.Generic;

namespace SurfShark.program
{
    class ProgramVars
    {
        public static string stat = "Disconected";
        public static int minutes = 0;
        public static string surfed = "0";
        public static string user = "0";
        public static int ratioTxt = 70;
        public static int type = 0;
        public static string typeTxt = "";
        public static List<SiteClass> siteClasses = new List<SiteClass>();
        public static string[] regions = null;
        public static List<ChatResponse> chatList = new List<ChatResponse>();
    }
}
