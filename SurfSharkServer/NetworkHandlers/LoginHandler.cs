using JHSNetProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurfSharkServer.NetworkHandlers
{
    public class LoginHandler : IJHSInterface
    {
        public bool Execute(JHSNetworkMessage netmsg)
        {
            return true;
        }
    }
}
