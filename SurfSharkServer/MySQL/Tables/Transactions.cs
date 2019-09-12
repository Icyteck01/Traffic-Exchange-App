using CommonDB.model;
using System;

namespace SurfSharkServer.MySQL.Tables
{
    public class Transactions
    {
        [TableIndex(true)]
        public virtual uint id { get; set; }
        public virtual uint UID { get; set; }
        public virtual uint credits { get; set; }
        public virtual int status { get; set; }
    }
}
