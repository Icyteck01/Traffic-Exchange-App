using System;
using System.Collections.Generic;
using System.Text;

namespace SurfShark.program
{
    [Serializable]
    class SiteClass
    {
        public int id = 0;
        public int uid;
        public String name;
        public String url;
        public String refurl;
        public int time;
        public String click;
        public int state;
    }
}
