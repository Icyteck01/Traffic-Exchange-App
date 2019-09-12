using SurfSharkServer.MySQL.Tables;
using SurfSharkServer.Network.Enums;

namespace SurfSharkServer.Communication.Packets.Data
{
    public class SiteClass
    {
        public UserUrls _data = new UserUrls();
        public uint UID { get => _data.id; set => _data.id = value; }
        public uint UserId { get => _data.UID; set => _data.UID = value; }
        public string WebsiteName { get => _data.WebsiteName; set => _data.WebsiteName = value; } //This can be user based only
        public string Url { get => _data.url; set => _data.url = value; }
        public uint Time { get => _data.Time; set => _data.Time = value; }
        public uint ViewCount { get => _data.ViewCount; set => _data.ViewCount = value; }
        public bool IsActive { get => _data.IsActive == 1; set => _data.IsActive = value ? 1 : 0; }
        public CountryList Region { get => (CountryList)_data.Region; set => _data.Region = (int)value; }
        public ReferralType Referral { get => (ReferralType)_data.Referral; set => _data.Referral = (int)value; }

        public int SiteIndex = 0;
        public SiteClass() { }
        public SiteClass(UserUrls url)
        {
            _data = url;
        }

        public override bool Equals(object obj)
        {
            if(obj is SiteClass site)
            {
                if (site.UID == UID && site.UserId == UserId)
                    return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (UID + UserId).GetHashCode();
        }
    }
}
