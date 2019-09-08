using JHSNetProtocol;

namespace SurfShark.Communication.Packets
{
    public class Register : JHSMessageBase
    {
        public string HwId;
        public string Email;
        public string Passwrod;
    }
}
