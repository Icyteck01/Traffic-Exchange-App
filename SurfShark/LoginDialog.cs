using JHUI;
using JHUI.Forms;
using JHUI.Utils;
using SurfShark.Communication.Packets;
using SurfShark.program;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace SurfShark
{
    public partial class LoginDialog : JForm
    {
        public static LoginDialog LoginDialogInstance;
        public LoginDialog()
        {
            LoginDialogInstance = this;
            InitializeComponent();
            LoginDialog.CheckForIllegalCrossThreadCalls = false;
            LoginInfo li = Component.getLastLogin();
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
            string username = textBox1.Text;
            string password = textBox2.Text;
            LoginDialog.Username = username;
            LoginDialog.Password = password;
            if (!IsValidEmail(username))
            {
                JMessageBox.Show(this, "Incorrect Input for Username!\nMust contain a valid email address format.");
                return;
            }
            if (username.Length < 4 || username.Length > 30)
            {
                JMessageBox.Show(this, "Incorrect Length for Username!\nMust be bettween 30 and 4 characters");
                return;
            }
            if (password.Length < 4 || password.Length > 20)
            {
                JMessageBox.Show(this, "Incorrect Length for Password!\nMust be bettween 20 and 4 characters");
                return;
            }
            if (!IsAllowed(username))
            {
                JMessageBox.Show(this, "Incorrect Input for Username!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                return;
            }
            if (!IsAllowed(password))
            {
                JMessageBox.Show(this, "Incorrect Input for Password!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                return;
            }
            notice.Text = "Please wait...";
            string loginInfo = "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"hardwereKey\":\"" + Component.getHwKey() + "\",\"country\":\"" + Component.getRegion() + "\"}";

            if (!NetworkManager.Connected)
            {
                notice.Text = "Server unreachable, please wait it usualy takes a few seconds to comeback.";
                return;
            }
            NetworkManager.Send(NetworkConstants.LOGIN, new Login()
            {
                Email = username,
                Passwrod = password,
                HwId = Component.getHwKey(),
                Region = Component.getRegion()
            });
            notice.Text = "Please wait...";
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

            if (!IsValidEmail(username))
            {
                JMessageBox.Show(this, "Incorrect Input for Username!\nMust contain a valid email address format.");
                return;
            }
            if (username.Length < 4 || username.Length > 30)
            {
                JMessageBox.Show(this, "Incorrect Length for Username!\nMust be bettween 30 and 4 characters");
                return;
            }
            if (password.Length < 4 || password.Length > 20)
            {
                JMessageBox.Show(this, "Incorrect Length for Password!\nMust be bettween 20 and 4 characters");
                return;
            }
            if (repassword.Length < 4 || repassword.Length > 20)
            {
                JMessageBox.Show(this, "Incorrect Length for RE-Password!\nMust be bettween 20 and 4 characters");
                return;
            }
            if (!IsAllowed(username))
            {
                JMessageBox.Show(this, "Incorrect Input for Username!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                return;
            }
            if (!IsAllowed(password))
            {
                JMessageBox.Show(this, "Incorrect Input for Password!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                return;
            }
            if (!IsAllowed(repassword))
            {
                JMessageBox.Show(this, "Incorrect Input for RE-Password!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                return;
            }
            if (password != repassword)
            {
                JMessageBox.Show(this, "Password and RE-Password must be the same!");
                return;
            }
            if (!NetworkManager.Connected)
            {
                notice.Text = "Server unreachable, please wait it usualy takes a few seconds to comeback.";
                return;
            }
            NetworkManager.Send(NetworkConstants.REGISTER, new Register()
            {
                Email = username,
                Passwrod = password,
                HwId = Component.getHwKey()
            });
        }


        public static string Username { get; set; }

        public static string Password { get; set; }
    }
}
