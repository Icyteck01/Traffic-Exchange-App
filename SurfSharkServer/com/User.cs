using CommonDB;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.MySQL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurfSharkServer.com
{
    public class User 
    {
        public uint UserId => _data.UserId;
        public UserAccounts _data;
        public UserType MemberType { get => (UserType)_data.MemberType; set => _data.MemberType = (byte)value; }
        public string UserName { get => _data.userName; set => _data.userName = value; }
        public string Password { get => _data.passWord; set => _data.passWord = value; }
        public string Hwid { get => _data.hwid; set => _data.hwid = value; }
        public uint Credits { get => _data.credits; set => _data.credits = value; }

        public int ViewsToday => ViewdSites.Count;

        Dictionary<int, SiteClass> _Sites = new Dictionary<int, SiteClass>();

        public HashSet<uint> ViewdSites = new HashSet<uint>();

        public UserUrls LastViedSite = null;

        public User(UserAccounts account)
        {
            _data = account;
            if (_data.viewurls != null && _data.viewurls.Length > 0)
            {
                string[] viewurls = _data.viewurls.Split("_");
                foreach (string d in viewurls)
                {
                    ViewdSites.Add(uint.Parse(d));
                }
            }
        }

        public void AddOrUpdateSite(SiteClass site)
        {
            if(site.SiteIndex > 0 && _Sites.ContainsKey(site.SiteIndex))
            {
                _Sites[site.SiteIndex] = site;
            }
            int lastindex = _Sites.Count;
            site.SiteIndex = lastindex;
            _Sites[site.SiteIndex] = site;
        }

        public void RemoveSite(int site)
        {
            _Sites.Remove(site);

        }

        public void ReorderSites()
        {
            SetSites(_Sites.Values.ToArray());
        }

        public SiteClass GetSite(int site)
        {
            if (_Sites.TryGetValue(site, out SiteClass c))
                return c;
            return null;
        }

        public void SetSites(SiteClass[] sites)
        {
            _Sites = new Dictionary<int, SiteClass>();
            for(int i = 0; i < sites.Length; i++)
            {
                SiteClass site = sites[i];
                if (site != null)
                {
                    site.SiteIndex = 0;
                    AddOrUpdateSite(site);
                }
            }
        }

        public SiteClass[] Sites => _Sites.Values.ToArray();

        public float LastRequestTime { get; set; }

        public object GetEntity()
        {
            return _data;
        }

        public string GetId()
        {
            return _data.UserId + "_User";
        }

        public void OnLogout()
        {
            LastRequestTime = 0;
             LastViedSite = null;
            _data.viewurls = string.Join("_", ViewdSites);
            for (int i = 0; i < Sites.Length; i++)
            {
                SiteClass site = Sites[i];
                if (site != null)
                    DbService.UpdateEntityIntime(site.UID, site._data);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is User site)
            {
                if (site.UserId == UserId)
                    return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return UserId.GetHashCode();
        }

        public string GetViewdSitesString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(uint view in ViewdSites)
            {
                sb.Append("'"+ view +"',");
            }
            string all = sb.ToString();
            if(all.Length > 0)
                return all.Substring(0, all.Length - 1);
            return "'0'";
        }
    }
}
