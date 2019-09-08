using JHSNetProtocol;

namespace SurfShark.Communication.Packets
{
    public class Register : JHSMessageBase
    {
        public string HwId;
        public string UserName;
        public string Password;
    }
}
