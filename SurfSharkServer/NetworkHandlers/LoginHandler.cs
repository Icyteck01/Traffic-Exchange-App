using CommonDB;
using JHSNetProtocol;
using SurfShark.Communication.Packets;
using SurfSharkServer.com;
using static SurfSharkServer.Communication.Constants.ErrorCodes;

namespace SurfSharkServer.NetworkHandlers
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
                            netmsg.conn.Send(NetworkConstants.LOGIN, new Login() { Code = SUCCESS });
                            return true;
                        }
                    }
                }
                else
                {
                    netmsg.conn.Send(NetworkConstants.LOGIN, new Login() { Code = WRONG_PASSWORD});
                    return true;
                }

                netmsg.conn.Send(NetworkConstants.LOGIN, new Login() { Code = WRONG_PASSWORD });
            }
            return true;
        }
    }
}
