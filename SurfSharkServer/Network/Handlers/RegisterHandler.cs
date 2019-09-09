using CommonDB;
using JHSNetProtocol;
using SurfShark.Network.Packets;
using SurfSharkServer.com;
using SurfSharkServer.MySQL.Tables;
using System;
using static ErrorCodes;

namespace SurfSharkServer.Network
{
    public class RegisterHandler : IJHSInterface
    {
        UserManager userManager = null;
        public bool Execute(JHSNetworkMessage netmsg)
        {
            Register packet = netmsg.ReadMessage<Register>();
            if (packet != null)
            {
                if (userManager == null)
                    userManager = UserManager.Instance;

                if (PasswordUtils.ValidLogin(packet.UserName) && PasswordUtils.ValidPassword(packet.Password))
                {
                    User user = userManager.GetUserByName(packet.UserName);
                    if (user == null)
                    {
                        UserAccounts acc = new UserAccounts
                        {
                            passWord = PasswordUtils.Crypt(packet.Password),
                            userName = packet.UserName,
                            createTime = DateTime.UtcNow,
                            ip = netmsg.conn.IP,
                            credits = 0,
                            MemberType = 0
                        };
                        acc = DbService.CreateEntity(acc);
                        if (acc != null)
                        {
                            netmsg.conn.Send(NetworkConstants.REGISTER, new Register() { Code = SUCCESS });
                        }
                        else
                        {
                            netmsg.conn.Send(NetworkConstants.REGISTER, new Register() { Code = GENERAL_FAILURE });
                        }
                        return true;
                    }
                    else
                    {
                        netmsg.conn.Send(NetworkConstants.REGISTER, new Register() { Code = USER_EXIST });
                    }
                }
                else
                {
                    netmsg.conn.Send(NetworkConstants.REGISTER, new Register() { Code = WRONG_PASSWORD });
                    return true;
                }

                netmsg.conn.Send(NetworkConstants.REGISTER, new Register() { Code = WRONG_PASSWORD });
            }
            return true;
        }
    }
}
