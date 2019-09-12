using JHSNetProtocol;
using SurfSharkServer.Network.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurfSharkServer.Network.Packets
{
    public class ChatMsg : JHSMessageBase
    {
        public string msg = "";
        public string username = "";
        public ulong date = 0;
        public override void Deserialize(JHSNetworkReader reader)
        {
            msg = reader.ReadString();
            username = reader.ReadString();
            date = reader.ReadPackedUInt64();
        }

        public override void Serialize(JHSNetworkWriter writer)
        {
            writer.Write(msg);
            writer.Write(username);
            writer.WritePackedUInt64(date);
        }
    }
}
