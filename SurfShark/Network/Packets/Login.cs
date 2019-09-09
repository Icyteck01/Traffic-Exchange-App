using JHSNetProtocol;

namespace SurfShark.Communication.Packets
{
    public class Login : JHSMessageBase
    {
        public ErrorCodes Code = ErrorCodes.WRONG_PASSWORD;
        public string UserName = "";
        public string Password = "";

        public override void Deserialize(JHSNetworkReader reader)
        {
            Code = (ErrorCodes)reader.ReadByte();
            if (Code == ErrorCodes.SUCCESS)
            {
                UserName = reader.ReadString();
                Password = reader.ReadString();
            }
        }

        public override void Serialize(JHSNetworkWriter writer)
        {
            writer.Write((byte)Code);
            if (Code == ErrorCodes.SUCCESS)
            {
                writer.Write(UserName);
                writer.Write(Password);
            }
        }
    }
}
