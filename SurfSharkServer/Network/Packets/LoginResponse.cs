using JHSNetProtocol;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.Network.Enums;

namespace SurfSharkServer.Communication.Packets
{
    public class LoginResponse : JHSMessageBase
    {
        public ErrorCodes Code = ErrorCodes.WRONG_PASSWORD;
        public uint Credits = 0; //Credits
        public uint SurfedSites = 0;
        public UserType MemberType = 0;
        public SiteClass[] sites = new SiteClass[0];

        public override void Deserialize(JHSNetworkReader reader)
        {
            Code = (ErrorCodes)reader.ReadByte();
            if (Code == ErrorCodes.SUCCESS)
            {
                Credits = reader.ReadPackedUInt32();
                SurfedSites = reader.ReadPackedUInt32();
                MemberType = (UserType)reader.ReadByte();
                int count = reader.ReadByte();
                sites = new SiteClass[count];
                for (int i = 0; i < count; i++)
                {
                    sites[i] = new SiteClass()
                    {
                        UID = reader.ReadPackedUInt32(),
                        WebsiteName = reader.ReadString(),
                        Url = reader.ReadString(),
                        Time = reader.ReadPackedUInt32(),
                        ViewCount = reader.ReadPackedUInt32(),
                        IsActive = reader.ReadBoolean(),
                        Region = (CountryList)reader.ReadByte(),
                        Referral = (ReferralType)reader.ReadByte()
                    };
                }
            }
        }

        public override void Serialize(JHSNetworkWriter writer)
        {
            writer.Write((byte)Code);
            if (Code == ErrorCodes.SUCCESS)
            {
                writer.WritePackedUInt32(Credits);
                writer.WritePackedUInt32(SurfedSites);
                writer.Write((byte)MemberType);
                writer.Write((byte)sites.Length);
                for (int i = 0; i < sites.Length; i++)
                {
                    writer.WritePackedUInt32(sites[i].UID);
                    writer.Write(sites[i].WebsiteName);
                    writer.Write(sites[i].Url);
                    writer.WritePackedUInt32(sites[i].Time);
                    writer.WritePackedUInt32(sites[i].ViewCount);
                    writer.Write(sites[i].IsActive);
                    writer.Write((byte)sites[i].Region);
                    writer.Write((byte)sites[i].Referral);
                }
            }
        }
    }
}
