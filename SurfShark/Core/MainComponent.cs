using JHSEngine.Interfaces;
using JHSEngine.Patterns.Facade;
using JHSEngine.Patterns.Mediator;
using SurfShark.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication1;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark.Core
{
    public class MainComponent : Mediator
    {
        public static ProgramState state = ProgramState.LOGGED_OUT;
        private LoginDialog login;
        private CoreSystem main;
        private MainProgram surf;
        private UrlUtilityForm util;
        private ChatWindow chat;

        public static IFacade Core { get; set; }
        public MainComponent()
        {
            Core = Facade.GetInstance("Game");
            Core.RegisterMediator(this);
        }

        public override string[] ListNotificationInterests()
        {
            return new string[] {
                SHOW_LOGIN,
                SHOW_MAIN,
                SHOW_REGISTER
            };
        }

        protected void HideAll()
        {
            login.Hide();
            main.Hide();
            surf.Hide();
            util.Hide();
            chat.Hide();
        }

        public override void HandleNotification(INotification notification)
        {
            switch(notification.Name)
            {
                case SHOW_LOGIN:
                    HideAll();
                    login.Show();
                    break;
                case SHOW_REGISTER:

                    break;
                case SHOW_MAIN:

                    break;
            }
        }

        public override void OnRegister()
        {
            login = new LoginDialog();
            main = new CoreSystem();
            surf = new MainProgram();
            util = new UrlUtilityForm();
            chat = new ChatWindow();
            MainComponent.Core.SendNotification(SHOW_LOGIN);
            NetworkManager.Start();
        }

        public override string MediatorName { get => "MainComponent"; set { } }
    }
}
