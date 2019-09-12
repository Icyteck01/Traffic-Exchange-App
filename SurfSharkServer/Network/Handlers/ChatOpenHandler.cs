using JHSNetProtocol;
using SurfSharkServer.com;
using SurfSharkServer.Network.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurfSharkServer.Network.Handlers
{
    public class ChatOpenHandler : IJHSInterface
    {
        UserManager userManager = null;
        ChatManager chatmanager = null;
        public bool Execute(JHSNetworkMessage msg)
        {
            UserOpenChat packet = msg.ReadMessage<UserOpenChat>();
            if (packet != null)
            {
                if (userManager == null)
                    userManager = UserManager.Instance;

                if (chatmanager == null)
                    chatmanager = ChatManager.Instance;

                uint connectionId = msg.conn.connectionId;

                User user = userManager.GetUserByConnectionId(connectionId);
                if (user != null)
                {
                    if (packet.isopen)
                        chatmanager.RegisterOpenUser(connectionId);
                    else
                        chatmanager.RemoveFromView(connectionId);
                }
            }

            return true;
        }
    }
}
