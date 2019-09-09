using System;

namespace SurfSharkServer.Communication.Packets.Data
{
    [Serializable]
    public class SiteClass
    {
        public uint UID = 0;
        public string WebsiteName = "New Website"; //This can be user based only
        public string Url = "";
        public uint Time = 0;
        public bool IsActive = false;
        public CountryList Region = CountryList.United_States;
    }
}
