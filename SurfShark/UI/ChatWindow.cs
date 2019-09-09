using JHSEngine.Patterns.Mediator;
using JHUI.Forms;
using Newtonsoft.Json;
using SurfShark.Communication.Packets;
using SurfShark.Core;
using SurfShark.Core.Constants;
using SurfShark.program;
using SurfShark.programs;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SurfShark
{
    public partial class ChatWindow : JMediator
    {
        public ChatWindow()
        {
            InitializeComponent();
        }
        private string lastMSg = "";
        internal void LoadAll()
        {
            checkBox1.Checked = MainCache.chatEnabled;
            ProgramVars.chatList.Reverse();
            chatTextBox.Text = "";
            var sb = new StringBuilder();
            sb.Append(@"{\rtf1\ansi");
            foreach (ChatResponse chat in ProgramVars.chatList)
            {
                string msg = chat.Message;
                string UserName = chat.UserName;
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

                string msg = textBox2.Text;
                string msgx = Regex.Replace(msg, @"\s+", "");
                string xczxc = @"[^a-zA-Z0-9 :;,_!\?@()#$%\^&\*-+= < > ]";
                string xczxcx = @"^[a-zA-Z0-9 :;,_!\?@()#$%\^&\*-+= < > ]+$";
                if (msgx.Length > 0)
                {
                    if (msgx.Length > 40)
                    {
                        MessageBox.Show("Too many characters! Max 20!");
                        return;
                    }
                    if (lastMSg.Equals(msg))
                    {
                        MessageBox.Show("You already said that!");
                        return;
                    }
                    if (!Regex.IsMatch(msg, xczxcx))
                    {

                        Regex rgxp = new Regex(xczxc);
                        textBox2.Text = rgxp.Replace(msg, "");
                        MessageBox.Show("InvalidCharacters");
                        return;
                    }

                    lastMSg = msg;
                    ChatResponse cr = new ChatResponse
                    {
                        Message = textBox2.Text
                    };
                    NetworkManager.Send(NetworkConstants.CHAT, cr);
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Please write somthing!");
                }
            
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainComponent.Core.SendNotification(ProgramConst.EVENT_RESIZE);      
            this.Hide();
        }

        private void TextBox2_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                OnBtnDownSend(sender, null);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            MainCache.chatEnabled = checkBox1.Checked;
        }
    }
}
