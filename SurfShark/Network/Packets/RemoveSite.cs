using JHSNetProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurfShark.Communication.Packets
{
    public class RemoveSite : JHSMessageBase
    {
        public uint SiteId = 0;
    }
}
