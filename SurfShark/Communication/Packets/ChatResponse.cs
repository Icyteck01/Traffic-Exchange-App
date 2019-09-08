using JHSNetProtocol;

namespace SurfShark.Communication.Packets
{
    public class ChatResponse : JHSMessageBase
    {
        public uint MessageID = 0;
        public string UserName = "";
        public string Message = "";
        public override void Deserialize(JHSNetworkReader reader)
        {
            MessageID = reader.ReadUInt32();
            UserName = reader.ReadString();
            Message = reader.ReadString();
        }

        public override void Serialize(JHSNetworkWriter writer)
        {
            writer.WritePackedUInt32(MessageID);
            writer.Write(UserName);
            writer.Write(Message);
        }
    }
}
