using JHSNetProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurfSharkServer.Network.Packets
{
    public class UserOpenChat : JHSMessageBase
    {
        public bool isopen = false;
        public override void Deserialize(JHSNetworkReader reader)
        {
            isopen = reader.ReadBoolean();
        }

        public override void Serialize(JHSNetworkWriter writer)
        {
            writer.Write(isopen);
        }
    }
}
