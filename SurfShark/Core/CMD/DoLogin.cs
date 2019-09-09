using CommonDB;
using JHSEngine.Interfaces;
using JHSEngine.Patterns.Command;
using JHUI.Utils;
using SurfShark.Communication.Packets;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark.Core.CMD
{
    public class DoLogin : SimpleCommand
    {
        float LastExecutuion = 0;
        public override void Execute(INotification notification)
        {
            if (LastExecutuion > Time.time)
                return;

            LastExecutuion = Time.time + 1f; // PREVENT SPAM

            if (notification.Body is string[] data)
            {
                string username = data[0];
                string password = data[1];
                MainCache.UserName = username;
                MainCache.PassWord = password;
                string error;
                if (!PasswordUtils.ValidLogin(username))
                {
                    error = "Invalid username.";
                    MainComponent.Core.SendNotification(SHOW_BOX, error);
                    MainComponent.Core.SendNotification(SHOW_PROPMPT, error);
                    return;
                }
                if (!PasswordUtils.ValidPassword(password))
                {
                    error = "Invalid password.";
                    MainComponent.Core.SendNotification(SHOW_BOX, error);
                    MainComponent.Core.SendNotification(SHOW_PROPMPT, error);
                    return;
                }
                MainComponent.Core.SendNotification(SHOW_PROPMPT, "Please wait...");
                if (!NetworkManager.Connected)
                {
                    MainComponent.Core.SendNotification(SHOW_PROPMPT, "Server unreachable, please wait it usualy takes a few seconds to comeback.");
                    return;
                }
                NetworkManager.Send(NetworkConstants.LOGIN, new Login()
                {
                    Code = ErrorCodes.SUCCESS,
                    UserName = username,
                    Password = password,
                });
            }
        }
    }
}
