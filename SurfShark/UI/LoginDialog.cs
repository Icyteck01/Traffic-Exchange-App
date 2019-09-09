using JHSEngine.Interfaces;
using JHSEngine.Patterns.Mediator;
using JHUI;
using JHUI.Forms;
using JHUI.Utils;
using SurfShark.Communication.Packets;
using SurfShark.Core;
using SurfShark.program;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApplication1;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark
{
    public partial class LoginDialog : JMediator
    {
        public static LoginDialog LoginDialogInstance;
        public LoginDialog()
        {
            LoginDialogInstance = this;
            InitializeComponent();
            LoginDialog.CheckForIllegalCrossThreadCalls = false;
            LoginInfo li = Forms.getLastLogin();
            if (li != null)
            {
                Autologin(li);
            }
            notice.Text = "";

        }

        private void Autologin(LoginInfo li)
        {
            if (li != null)
            {
                textBox1.Text = li.username;
                textBox2.Text = li.password;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            // JMessageBox.Show(this, ""+IsValidEmail(this.textBox1.Text));
        }
        private string CleanStr(string strToCheck)
        {
            string newx;
            string[] allowed = new string[] { "=", ".", "-", "_", ",", " ", "[", "]", ":", "+", "|", "!", "%", "&", "@", "/", "*", "?", "#", "'" };
            for (int i = 0; i < allowed.Length; i++)
            {
                strToCheck = strToCheck.Replace(allowed[i].ToString(), "");
            }
            newx = strToCheck;
            return newx;
        }

        private bool IsAllowed(string strToCheck)
        {

            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(CleanStr(strToCheck));
        }

        private bool IsValidEmail(string email)
        {
            if (email == null)
                return false;
            if (email.Length < 3)
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        { 
            MainComponent.Core.SendNotification(DO_LOGIN, new string[] { textBox1.Text, textBox2.Text });
        }

        public void ShowMSG(string v)
        {
            if (notice.InvokeRequired)
            {
                notice.Invoke((MethodInvoker)(() => {
                    ShowMSG(v); 
                }));
                return;
            }
            JMessageBox.Show(this, v);
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "";
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (!NetworkManager.Connected || !CoreSystem.LoggedIn)
            {
                Program.DisposeIcon();
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void LoginDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!NetworkManager.Connected || !CoreSystem.LoggedIn)
            {
                Program.DisposeIcon();
                Application.Exit();
                Environment.Exit(0);
            }
        }

        private void BTNRegister_Click(object sender, EventArgs e)
        {
            string username = textBox4.Text;
            string password = textBox3.Text;
            string repassword = textBox5.Text;
            MainComponent.Core.SendNotification(DO_REGISTER, new string[] { textBox4.Text, textBox3.Text, textBox5.Text });
        }

        public void Error(string msg)
        {
            if(notice.InvokeRequired)
            {
                notice.Invoke((MethodInvoker)(() => { Error(msg); }));
                return;
            }
            notice.Text = msg;
        }

        public static string Username { get; set; }

        public static string Password { get; set; }

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
                    if(notification.Body is string s)
                        Error(s);
                    break;
                case SHOW_BOX:
                    if (MainComponent.state == Core.Constants.ProgramState.LOGGED_OUT && notification.Body is string msg)
                        JMessageBox.Show(this, msg);
                    break;
            }
        }
    }
}
