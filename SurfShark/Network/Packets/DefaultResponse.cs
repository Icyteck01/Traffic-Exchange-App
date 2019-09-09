using JHSNetProtocol;

namespace SurfShark.Communication.Packets
{
    public class DefaultResponse : JHSMessageBase
    {
        public int value = 0;
        public string message = "";
        public int minutes = 0;
        public int surfed = 0;
        public string link = "";
        public string referelink = "";
        public int seconds = 10;
        public int type = 0;
        public int uid = 0;
        public string region = "International";
        public string regions = null;
    }
}
