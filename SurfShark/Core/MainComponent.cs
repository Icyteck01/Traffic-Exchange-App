using JHSEngine.Interfaces;
using JHSEngine.Patterns.Facade;
using JHSEngine.Patterns.Mediator;
using SurfShark.Core.CMD;
using SurfShark.Core.Constants;
using System;
using System.Windows.Forms;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark.Core
{
    public partial class MainComponent : JMediator
    {
        public static ProgramState state = ProgramState.LOGGED_OUT;
        private LoginDialog loginForm;
        public NotifyIcon notifyIcon1;
        private System.ComponentModel.IContainer components;
        private JHUI.Controls.JContextMenu jContextMenu1;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem tEst2ToolStripMenuItem;
        private CoreSystem mainForm;

        public static IFacade Core { get; set; }
        public MainComponent()
        {
            InitializeComponent();
            Core = Facade.GetInstance("Game");
            Core.RegisterMediator(this);
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            notifyIcon1.Visible = true;
        }

        public override string[] ListNotificationInterests()
        {
            return new string[] {
                SHOW_LOGIN,
                SHOW_MAIN,
                SHOW_REGISTER,
                DO_EXIT_PROGRAM,
                EVENT_RESIZE
            };
        }

        private void HideAll()
        {
            if (loginForm != null)
            {
                loginForm.Hide();
                loginForm.WindowState = FormWindowState.Minimized;
            }

            if (mainForm != null)
            {
                mainForm.Hide();
                mainForm.WindowState = FormWindowState.Minimized;
            }
        }
        public override void HandleNotification(INotification notification)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { HandleNotification(notification); });
                return;
            }
            switch (notification.Name)
            {
                case SHOW_LOGIN:
                    HideAll();
                    loginForm.WindowState = FormWindowState.Normal;
                    loginForm.Show();
                    break;
                case SHOW_REGISTER:

                    break;
                case SHOW_MAIN:
                    HideAll();             
                    mainForm.WindowState = FormWindowState.Normal;
                    mainForm.Show();
                    break;
                case DO_EXIT_PROGRAM:
                    Application.Exit();
                    Environment.Exit(0);
                    break;
                case EVENT_RESIZE:
                    if(MainCache.LoggedIn)
                    {
                        if(mainForm.WindowState == FormWindowState.Minimized)
                        {
                            mainForm.Show();
                            mainForm.WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            mainForm.WindowState = FormWindowState.Minimized;
                            mainForm.Hide();
                        }
                    }
                    break;
            }
        }

        public override void OnRegister()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { OnRegister(); });
                return;
            }
            CoreSystem.CheckForIllegalCrossThreadCalls = false;
            LoginDialog.CheckForIllegalCrossThreadCalls = false;
            loginForm = new LoginDialog();
            mainForm = new CoreSystem();
            Core.RegisterMediator(loginForm);

            Core.RegisterCommand(DO_LOGIN, new DoLogin());
            Core.RegisterCommand(DO_REGISTER, new DoRegister());
            Core.SendNotification(SHOW_LOGIN);

            NetworkManager.Start();
        }

      
        private void TEst2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainComponent.Core.SendNotification(ProgramConst.DO_EXIT_PROGRAM);
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainComponent.Core.SendNotification(ProgramConst.EVENT_RESIZE);
        }
    }
}
