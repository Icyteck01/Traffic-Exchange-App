using JHSNetProtocol;

namespace SurfShark.Communication.Packets
{
    public class Login : JHSMessageBase
    {
        public string HwId = "";
        public string Email = "";
        public string Passwrod = "";
        public string Region = "";
    }
}
