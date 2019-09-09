using JHSEngine.Interfaces;
using JHSEngine.Patterns.Mediator;
using JHUI;
using SurfShark.Core;
using System;
using System.Windows.Forms;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark
{
    public partial class LoginDialog : JMediator
    {
        public LoginDialog()
        {
            InitializeComponent();
            notice.Text = "";
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        { 
            MainComponent.Core.SendNotification(DO_LOGIN, new string[] { textBox1.Text, textBox2.Text });
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (!NetworkManager.Connected || !MainCache.LoggedIn)
            {
                e.Cancel = true;
                MainComponent.Core.SendNotification(DO_EXIT_PROGRAM);
            }
        }

        private void LoginDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!NetworkManager.Connected || !MainCache.LoggedIn)
            {
                MainComponent.Core.SendNotification(DO_EXIT_PROGRAM);
            }
        }

        private void BTNRegister_Click(object sender, EventArgs e)
        {
            MainComponent.Core.SendNotification(DO_REGISTER, new string[] { textBox4.Text, textBox3.Text, textBox5.Text });
        }

        private void RegisterTabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RegisterTabPage.SelectedIndex == 0)
            {
                Text = "Welcome back";
            }
            else
            {
                Text = "Join us";
            }
        }

        private void LoginDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (RegisterTabPage.SelectedIndex == 0)
                {
                    ButtonLogin_Click(null, null);
                }
                else
                {
                    BTNRegister_Click(null, null);
                }
            }
        }

        public override string[] ListNotificationInterests()
        {
            return new string[] { SHOW_PROPMPT, SHOW_BOX };
        }

        public override void HandleNotification(INotification notification)
        {
            switch(notification.Name)
            {
                case SHOW_PROPMPT:
                    if (notification.Body is string s)
                        //notice.Invoke(new MethodInvoker(delegate
                       // {
                            notice.Text = s;
                      //  }));
                    break;
                case SHOW_BOX:
                    if (MainComponent.state == Core.Constants.ProgramState.LOGGED_OUT && notification.Body is string msg)
                        JMessageBox.Show(this, msg);
                    break;
            }
        }
    }
}
