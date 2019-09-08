using JHSNetProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurfSharkServer.NetworkHandlers
{
    public class RegisterHandler : IJHSInterface
    {
        public bool Execute(JHSNetworkMessage netmsg)
        {
            return true;
        }
    }
}
