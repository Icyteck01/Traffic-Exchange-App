using System;

namespace SurfShark
{
    [Serializable]
    public class BaseSocket
    {
        public int module = -1;
        public int cmd = -1;
        public string time = "";
        public object value = -1;
    }
}
