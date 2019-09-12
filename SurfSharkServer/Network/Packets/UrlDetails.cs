using JHSNetProtocol;


namespace SurfShark.Network.Packets
{
    public class UrlDetails : JHSMessageBase
    {
        public ErrorCodes code = ErrorCodes.SUCCESS;
        public uint Time = 0;
        public string Url = "";

        public override void Deserialize(JHSNetworkReader reader)
        {
            code = (ErrorCodes)reader.ReadByte();
            if (code == ErrorCodes.SUCCESS)
            {
                Time = reader.ReadPackedUInt32();
                Url = reader.ReadString();
            }
        }

        public override void Serialize(JHSNetworkWriter writer)
        {
            writer.Write((byte)code);
            if (code == ErrorCodes.SUCCESS)
            {
                writer.WritePackedUInt32(Time);
                writer.Write(Url);
            }
        }
    }
}
