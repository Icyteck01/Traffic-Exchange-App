using JHSNetProtocol;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.Network.Enums;

namespace SurfShark.Communication.Packets
{
    public class SubmitDataForUpdate : JHSMessageBase
    {
        public ErrorCodes Code = ErrorCodes.SUCCESS;
        public SiteClass[] Added = new SiteClass[0];
        public SiteClass[] Changed = new SiteClass[0];
        public int[] Deleted = new int[0];

        public override void Deserialize(JHSNetworkReader reader)
        {
            Code = (ErrorCodes)reader.ReadByte();
            if (Code == ErrorCodes.SUCCESS)
            {
                int AddedCount = reader.ReadByte();
                int ChangedCount = reader.ReadByte();
                int DeletedCount = reader.ReadByte();
                Added = new SiteClass[AddedCount];
                Changed = new SiteClass[ChangedCount];
                Deleted = new int[DeletedCount];
                for (int i = 0; i < AddedCount; i++)
                {
                    Added[i] = new SiteClass()
                    {
                        SiteIndex = reader.ReadByte(),
                        WebsiteName = reader.ReadString(),
                        Url = reader.ReadString(),
                        Time = reader.ReadPackedUInt32(),
                        ViewCount = reader.ReadPackedUInt32(),
                        IsActive = reader.ReadBoolean(),
                        Region = (CountryList)reader.ReadByte(),
                        Referral = (ReferralType)reader.ReadByte()
                    };
                }
                for (int i = 0; i < ChangedCount; i++)
                {
                    Changed[i] = new SiteClass()
                    {
                        SiteIndex = reader.ReadByte(),
                        WebsiteName = reader.ReadString(),
                        Url = reader.ReadString(),
                        Time = reader.ReadPackedUInt32(),
                        ViewCount = reader.ReadPackedUInt32(),
                        IsActive = reader.ReadBoolean(),
                        Region = (CountryList)reader.ReadByte(),
                        Referral = (ReferralType)reader.ReadByte()
                    };
                }
                for (int i = 0; i < DeletedCount; i++)
                {
                    Deleted[i] = reader.ReadByte();
                }
            }
            else if (Code == ErrorCodes.JUST_DATA_UPDATE)
            {
                int ChangedCount = reader.ReadByte();
                Changed = new SiteClass[ChangedCount];
                for (int i = 0; i < ChangedCount; i++)
                {
                    Changed[i] = new SiteClass()
                    {
                        SiteIndex = reader.ReadByte(),
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
                writer.Write((byte)Added.Length);
                writer.Write((byte)Changed.Length);
                writer.Write((byte)Deleted.Length);
                for (int i = 0; i < Added.Length; i++)
                {
                    writer.Write((byte)Added[i].SiteIndex);
                    writer.Write(Added[i].WebsiteName);
                    writer.Write(Added[i].Url);
                    writer.WritePackedUInt32(Added[i].Time);
                    writer.WritePackedUInt32(Added[i].ViewCount);
                    writer.Write(Added[i].IsActive);
                    writer.Write((byte)Added[i].Region);
                    writer.Write((byte)Added[i].Referral);
                }
                for (int i = 0; i < Changed.Length; i++)
                {
                    writer.Write((byte)Changed[i].SiteIndex);
                    writer.Write(Changed[i].WebsiteName);
                    writer.Write(Changed[i].Url);
                    writer.WritePackedUInt32(Changed[i].Time);
                    writer.WritePackedUInt32(Changed[i].ViewCount);
                    writer.Write(Changed[i].IsActive);
                    writer.Write((byte)Changed[i].Region);
                    writer.Write((byte)Changed[i].Referral);
                }
                for (int i = 0; i < Deleted.Length; i++)
                {
                    writer.Write((byte)Deleted[i]);
                }
            }
            else if (Code == ErrorCodes.JUST_DATA_UPDATE)
            {
                writer.Write((byte)Changed.Length);
                for (int i = 0; i < Changed.Length; i++)
                {
                    writer.Write((byte)Changed[i].SiteIndex);
                    writer.Write(Changed[i].WebsiteName);
                    writer.Write(Changed[i].Url);
                    writer.WritePackedUInt32(Changed[i].Time);
                    writer.WritePackedUInt32(Changed[i].ViewCount);
                    writer.Write(Changed[i].IsActive);
                    writer.Write((byte)Changed[i].Region);
                    writer.Write((byte)Changed[i].Referral);
                }
            }
        }
    }
}
