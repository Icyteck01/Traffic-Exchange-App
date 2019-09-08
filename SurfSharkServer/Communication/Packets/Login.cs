using JHSNetProtocol;
using SurfSharkServer.Communication.Constants;

namespace SurfShark.Communication.Packets
{
    public class Login : JHSMessageBase
    {
        public ErrorCodes Code = 0;
        public string UserName = "";
        public string Password = "";

        public override void Deserialize(JHSNetworkReader reader)
        {
            Code = (ErrorCodes)reader.ReadByte();
            if (Code == 0)
            {
                UserName = reader.ReadString();
                Password = reader.ReadString();
            }
        }

        public override void Serialize(JHSNetworkWriter writer)
        {
            writer.Write((byte)Code);
            if (Code == 0)
            {
                writer.Write(UserName);
                writer.Write(Password);
            }
        }
    }
}
