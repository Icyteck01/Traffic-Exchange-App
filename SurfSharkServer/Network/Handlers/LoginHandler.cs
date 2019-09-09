using CommonDB;
using JHSNetProtocol;
using SurfShark.Network.Packets;
using SurfSharkServer.com;
using SurfSharkServer.Communication.Packets;
using System;
using static ErrorCodes;

namespace SurfSharkServer.Network
{
    public class LoginHandler : IJHSInterface
    {
        UserManager userManager = null;
        public bool Execute(JHSNetworkMessage netmsg)
        {
            Login packet = netmsg.ReadMessage<Login>();
            if(packet != null)
            {
                if (userManager == null)
                    userManager = UserManager.Instance;

                if (PasswordUtils.ValidLogin(packet.UserName) && PasswordUtils.ValidPassword(packet.Password))
                {
                    User user = userManager.GetUserByName(packet.UserName);
                    if (user != null)
                    {
                        if (PasswordUtils.ComparePasswords(user.Password, packet.Password))
                        {
                            lock(user)
                            {
                                user._data.loginTime = DateTime.UtcNow;
                                user._data.lastKnownIp = user._data.ip;
                                user._data.ip = netmsg.conn.IP;
                            }
                            DbService.SubmitUpdate2Queue(user.UID, user._data);
                            LoginResponse response = new LoginResponse
                            {
                                Code = SUCCESS,
                                MemberType = user.MemberType,
                                SurfedSites = (uint)user.ViewsToday,
                                Credits = user.Credits
                            };
                            response.sites = user.Sites;
                            netmsg.conn.Send(NetworkConstants.LOGIN, response);
                            return true;
                        }
                    }
                }
                else
                {
                    netmsg.conn.Send(NetworkConstants.LOGIN, new LoginResponse() { Code = WRONG_PASSWORD});
                    return true;
                }

                netmsg.conn.Send(NetworkConstants.LOGIN, new LoginResponse() { Code = WRONG_PASSWORD });
            }
            return true;
        }
    }
}
