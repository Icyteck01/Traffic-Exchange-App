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
        private ChatWindow chatWindow;
        private UrlUtilityForm urlEditor;
        private SurfShark surfShark;

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
                EVENT_RESIZE,
                SHOW_CHAT_WINDOW,
                START_SURFING,
                STOP_SURFING,
                SHOW_URL_EDITOR
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
                case STOP_SURFING:
                    if (surfShark != null)
                    {
                        surfShark.WindowState = FormWindowState.Minimized;
                        surfShark.ShowInTaskbar = surfShark.ShowIcon = false;
                    }
                    break;
                case START_SURFING:
                    if (surfShark == null)
                    {
                        surfShark = new SurfShark();
                        Core.RegisterMediator(surfShark);
                        surfShark.Show();
                        MainComponent.Core.SendNotification(ASK_4_NEW_URL);
                        return;
                    }
                    if (surfShark.WindowState != FormWindowState.Normal)
                    {
                        surfShark.WindowState = FormWindowState.Normal;
                        surfShark.ShowInTaskbar = surfShark.ShowIcon = true;
                    }
                    else
                    {
                        surfShark.WindowState = FormWindowState.Normal;
                        surfShark.ShowInTaskbar = surfShark.ShowIcon = true;
                        surfShark.Focus();
                    }
                    break;
                case SHOW_URL_EDITOR:
                    if (urlEditor == null)
                    {
                        urlEditor = new UrlUtilityForm();
                        Core.RegisterMediator(urlEditor);
                        urlEditor.Show();
                        Core.SendNotification(LOAD_URL_EDITOR);
                        return;
                    }
                    if (urlEditor.WindowState != FormWindowState.Normal)
                    {
                        urlEditor.WindowState = FormWindowState.Normal;
                        urlEditor.ShowInTaskbar = urlEditor.ShowIcon = true;
                        Core.SendNotification(LOAD_URL_EDITOR);
                    }
                    else
                    {
                        urlEditor.WindowState = FormWindowState.Minimized;
                        urlEditor.ShowInTaskbar = urlEditor.ShowIcon = false;
                    }
                    break;
                case SHOW_CHAT_WINDOW:
                    if(chatWindow == null)
                    {
                        chatWindow = new ChatWindow();
                        Core.RegisterMediator(chatWindow);
                        chatWindow.Show();
                        return;
                    }
                    if (chatWindow.WindowState != FormWindowState.Normal)
                    {
                        chatWindow.WindowState = FormWindowState.Normal;
                        chatWindow.ShowInTaskbar = chatWindow.ShowIcon = true;
                    }
                    else
                    {
                        chatWindow.WindowState = FormWindowState.Minimized;
                        chatWindow.ShowInTaskbar = chatWindow.ShowIcon = false;
                    }
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
                            mainForm.Hide();
                            mainForm.WindowState = FormWindowState.Minimized;
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
            Core.RegisterMediator(mainForm);
            

            Core.RegisterCommand(DO_LOGIN, new DoLogin());
            Core.RegisterCommand(DO_REGISTER, new DoRegister());
            Core.RegisterCommand(DO_UPDATE_SITES, new DoUpdateSites());
            Core.RegisterCommand(ASK_4_NEW_URL, new DoAskNextUrl());
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
