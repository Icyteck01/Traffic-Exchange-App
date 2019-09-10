using CommonDB.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurfSharkServer.MySQL.Tables
{
    public class UserUrls
    {
        [TableIndex(true)]
        public virtual uint id { get; set; }
        public virtual uint UID { get; set; }
        public virtual string WebsiteName { get; set; }
        public virtual string url  { get; set; }
        public virtual uint Time { get; set; }
        public virtual int IsActive { get; set; }
        public virtual uint ViewCount { get; set; }
        public virtual int Region { get; set; }
        public virtual int Referral { get; set; }
}
}
