using System;

namespace SurfShark.program
{
    [Serializable]
    class SiteClass
    {
        public int id = 0;
        public int uid;
        public string name;
        public string url;
        public string refurl;
        public int time;
        public string click;
        public int state;
        public string region = null;
    }
}
