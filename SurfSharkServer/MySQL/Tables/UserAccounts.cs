using CommonDB.model;
using System;

namespace SurfSharkServer.MySQL.Tables
{
    public class UserAccounts
    {
        [TableIndex(true)]
        public virtual uint UserId {get;set;}
        public virtual string userName { get; set; }
        public virtual string passWord { get; set; }
        public virtual string hwid { get; set; }
        public virtual byte MemberType { get; set; }
        public virtual uint credits { get; set; }
        public virtual string ip { get; set; }
        public virtual string lastKnownIp { get; set; }
        public virtual DateTime createTime { get; set; }
        public virtual DateTime logoutTime { get; set; }
        public virtual DateTime loginTime { get; set; }
    }
}
