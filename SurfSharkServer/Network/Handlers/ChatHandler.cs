using JHSNetProtocol;
using SurfSharkServer.com;
using SurfSharkServer.Network.Packets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurfSharkServer.Network.Handlers
{
    public class ChatHandler : IJHSInterface
    {
        UserManager userManager = null;
        ChatManager chatmanager = null;
        public bool Execute(JHSNetworkMessage msg)
        {
            ChatMsg packet = msg.ReadMessage<ChatMsg>();
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
                    chatmanager.SendToAll(user.UserName, packet.msg, JHSTime.TimeStamp);
                }
            }

            return true;
        }
    }
}
