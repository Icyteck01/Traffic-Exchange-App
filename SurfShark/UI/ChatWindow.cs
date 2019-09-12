using JHSEngine.Interfaces;
using JHSEngine.Patterns.Mediator;
using JHUI;
using JHUI.Utils;
using SurfShark.Core;
using SurfSharkServer.Network.Packets;
using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark
{
    public partial class ChatWindow : JMediator
    {
        public ChatWindow()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width - 20, scrn.Bounds.Top + 273);
                    return;
                }
            }

            //273
        }
        private string lastMSg = "";
        internal void LoadAll()
        {
            checkBox1.Checked = MainCache.chatEnabled;
            chatTextBox.Text = "";
            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi");
            foreach (ChatMsg chat in MainCache.chatList)
            {
                string msg = chat.msg;
                string UserName = chat.username;
                if (msg.Length > 0 && msg != string.Empty)
                {
                    if (IsNumeric(UserName))
                    {
                        UserName = "Guest";
                    }
                    sb.Append(string.Format(@"\b {0}: \b0 ", UserName).ToString());
                    sb.Append(Uri.UnescapeDataString(msg).Replace('+', ' '));
                    sb.Append(@" \line ");
                }
            }
            sb.Append(@"}");
            chatTextBox.Rtf = sb.ToString();
            chatTextBox.SelectionStart = chatTextBox.Text.Length;
            chatTextBox.ScrollToCaret();
        }
        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        private void OnBtnDownSend(object sender, EventArgs e)
        {
            if(!MainCache.chatEnabled)
            {
                JMessageBox.Show(this, "Please click on enable chat box before you can send a message.");
                return;
            }
                string msg = textBox2.Text;
                string msgx = Regex.Replace(msg, @"\s+", "");
                string xczxc = @"[^a-zA-Z0-9 :;,_!\?@()#$%\^&\*-+= < > ]";
                string xczxcx = @"^[a-zA-Z0-9 :;,_!\?@()#$%\^&\*-+= < > ]+$";
                if (msgx.Length > 0)
                {
                    if (msgx.Length > 40)
                    {
                        JMessageBox.Show(this,"Too many characters! Max 20!");
                        return;
                    }
                    if (lastMSg.Equals(msg))
                    {
                        JMessageBox.Show(this,"You already said that!");
                        return;
                    }
                    if (!Regex.IsMatch(msg, xczxcx))
                    {

                        Regex rgxp = new Regex(xczxc);
                        textBox2.Text = rgxp.Replace(msg, "");
                        JMessageBox.Show(this,"InvalidCharacters");
                        return;
                    }

                    lastMSg = msg;
                    ChatMsg cr = new ChatMsg
                    {
                        msg = textBox2.Text
                    };
                    NetworkManager.Send(NetworkConstants.CHAT, cr);
                    textBox2.Text = "";
                }
                else
                {
                    JMessageBox.Show(this,"Please write somthing!");
                }
            
        }

        private void TextBox2_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                OnBtnDownSend(sender, null);
            }
        }

        float LastOpenChatSentCmd = 0;
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (LastOpenChatSentCmd > Time.time)
            {
                checkBox1.Checked = MainCache.chatEnabled;
                return;
            }
            LastOpenChatSentCmd = Time.time + 1f; // PREVENT SPAM
            MainCache.chatEnabled = checkBox1.Checked;
            NetworkManager.Send(NetworkConstants.OPEN_CHAT, new UserOpenChat() { isopen = MainCache.chatEnabled });
        }

        public override string[] ListNotificationInterests()
        {
            return new string[] { SHOW_CHAT_WINDOW, REFRESH_CHAT_WINDOW };
        }

        public override void HandleNotification(INotification notification)
        {
            switch(notification.Name)
            {
                case SHOW_CHAT_WINDOW:
                case REFRESH_CHAT_WINDOW:
                    LoadAll();
                    break;
            }
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MainComponent.Core.SendNotification(SHOW_CHAT_WINDOW);
        }
    }
}
