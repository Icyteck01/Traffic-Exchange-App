using SurfSharkServer.Network.Enums;
using System;
using System.Collections.Generic;

namespace SurfSharkServer.Communication.Packets.Data
{
    [Serializable]
    public class SiteClass
    {
        public string WebsiteName = "New Website"; //This can be user based only
        public string Url = "";
        public uint Time = 60;
        public bool IsActive = false;
        public CountryList Region = CountryList.United_States;
        public ReferralType Referral = ReferralType.DIRECT;
        public uint ViewCount = 0;
        public UpdateOperation operation = UpdateOperation.NOT_CHANGED;

        public override int GetHashCode()
        {
            return SiteIndex.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is SiteClass other)
            {
                if (other.SiteIndex != SiteIndex)
                    return false;
                if (other.WebsiteName != WebsiteName)
                    return false;
                if (other.Url != Url)
                    return false;
                if (other.Time != Time)
                    return false;
                if (other.IsActive != IsActive)
                    return false;
                if (other.Region != Region)
                    return false;
                if (other.Referral != Referral)
                    return false;
                if (other.ViewCount != ViewCount)
                    return false;
            }
            return false;
        }

        public SiteClass Clone()
        {
            return new SiteClass()
            {
                SiteIndex = SiteIndex,
                WebsiteName = WebsiteName,
                Url = Url,
                Time = Time,
                IsActive = IsActive,
                Region = Region,
                Referral = Referral,
                ViewCount = ViewCount,
                operation = operation
            };
        }

        public int SiteIndex = 0;
    }
}
