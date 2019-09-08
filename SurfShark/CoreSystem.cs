using JHUI.Forms;
using Newtonsoft.Json;
using SurfShark.Communication.Packets;
using SurfShark.program;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace SurfShark
{
    public partial class CoreSystem : JForm
    {
        public static bool LoggedIn = false;
        public static bool hasPass = false;
        public static CoreSystem main;
        public static bool startedToSurf = false;
        private readonly System.Timers.Timer aTimer;
        private int oldSiteId = 0;
        private int oldSeconds = 0;
        public static int userID = 0;
        public static bool isUtilOpen = false;
        public static bool chatLoaded = false;
        public static bool canSendChat = true;
        public static bool chatEnabled = true;
        public CoreSystem()
        {
            main = this;
            InitializeComponent();
            if (!NetworkManager.Connected)
            {
                NetworkManager.Start();
            }
            if (!CoreSystem.LoggedIn)
            {
                Component.login.Show();
            }

            Statustct.Text = ProgramVars.stat;
            this.Minutes.Text = ProgramVars.minutes / 60 + " ";
            Surfed.Text = ProgramVars.surfed;
            User.Text = ProgramVars.user;
            LoginDialog.CheckForIllegalCrossThreadCalls = false;
            this.aTimer = new System.Timers.Timer();
            this.aTimer.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
            this.aTimer.Enabled = false;
            this.aTimer.Stop();
        }

        public void NetSend(string message, int module, int cmd)
        {


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CoreSystem.Resize_window();
        }

        private void CTimedEvent(int time, string url)
        {
            this.aTimer.Stop();
            if (startedToSurf)
            {
                time = time + 1;
                int totalTIme = 1000 * time;
                this.aTimer.Interval = totalTIme;
                this.aTimer.Enabled = true;
                Component.surf.Navigate_to(url);
            }
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            NetworkManager.Send(NetworkConstants.TRANSIT, new DefaultResponse
            {
                type = (int)TransitOperation.GET_SITE,
                value = oldSiteId,
                seconds = oldSeconds,
                region = Component.getRegion()
            });
        }

        internal static void Resize_window()
        {

            if (Component.main.WindowState == FormWindowState.Minimized)
            {
                if (!NetworkManager.Connected)
                {
                    if (Component.login.IsDisposed)
                    {
                        Component.login = new LoginDialog();
                    }
                    Component.login.Show();
                }
                else
                {
                    Component.main.WindowState = FormWindowState.Normal;
                    Component.main.ShowInTaskbar = true;
                }

            }
            else
            {
                Component.main.WindowState = FormWindowState.Minimized;
                Component.main.ShowInTaskbar = false;
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!startedToSurf)
            {
                if (!Component.surf.IsDisposed)
                {
                    Component.surf.Show();
                }
                else
                {
                    Component.surf = new MainProgram();
                    Component.surf.Show();
                }
                CoreSystem.Resize_window();
                startedToSurf = true;
                CTimedEvent(10, "http://www.autosurf-traffic-exchange.com");
               // this.SendMessage(AskFOrnewSite(0, 0), NetworkConstants.TRANSIT, NetworkCommands.cmd1);
            }
        }

        protected void OnFormClosingx(object sender, EventArgs e)
        {
            if (CloseCancel() == true)
            {
                Program.DisposeIcon();
                Application.Exit();
                Environment.Exit(0);
            }
            else
            {
                CoreSystem.Resize_window();
            }

        }

        public static bool CloseCancel()
        {
            const string message = "Would you like to exit or minimize Surf Shark?\nPress Yes to exit and No to Minimize";
            const string caption = "Question:";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CoreSystem.Resize_window();
        }

        private void ProcessMessage(BaseSocket bs)
        {
            int module = bs.module;
            int cmd = bs.cmd;
            string value = bs.value.ToString().Trim(); // can be json
            switch (module)
            {
                case 0: //Recived login
                    DefaultResponse dr = null;
                    if (value != null && value.Length > 0)
                    {
                        dr = JsonConvert.DeserializeObject<DefaultResponse>(value);
                    }
                    if (dr != null)
                    {
                        if (dr.value == 1)
                        {
                            Statustct.Text = "Connected";
                            this.Minutes.Text = dr.minutes / 60 + " ";
                            Surfed.Text = "" + dr.surfed;
                            User.Text = "" + dr.message;
                            ProgramVars.stat = "Connected";
                            ProgramVars.surfed = "" + dr.surfed;
                            ProgramVars.user = "" + dr.message;
                            ProgramVars.minutes = dr.minutes;
                            ProgramVars.type = dr.type;
                            ProgramVars.regions = dr.regions.Split(',');
                            CoreSystem.userID = dr.uid;
                            ProgramVars.ratioTxt = ProgramVars.type == 0 ? 70 : 100;
                            ProgramVars.typeTxt = ProgramVars.type == 0 ? "Normal Shark" : "Super Shark";
                            MemberTypExd.Text = ProgramVars.typeTxt;
                            CoreSystem.LoggedIn = true;
                            Component.login.Invoke(new MethodInvoker(delegate ()
                            {
                                Component.main.Show();
                                Component.login.Close();
                            }));
                            Component.saveLastLogin(LoginDialog.Username, LoginDialog.Password);
                        }
                        else
                        {
                            CoreSystem.LoggedIn = false;
                            MessageBox.Show(dr.message);
                        }
                    }

                    break;

                case 1: //Recived packet from server
                    DefaultResponse drx = JsonConvert.DeserializeObject<DefaultResponse>(value);
                    if (drx != null)
                    {
                        if (drx.value == 1)
                        {
                            DefaultResponse dry = JsonConvert.DeserializeObject<DefaultResponse>(drx.message.ToString());
                            MainProgram.counter = dry.seconds;
                            MainProgram.counterMax = dry.seconds;
                            MainProgram.Minutes = dry.minutes;
                            MainProgram.reward = dry.seconds;
                            CTimedEvent(dry.seconds, dry.link);
                            this.Minutes.Text = MainProgram.Minutes / 60 + " "; ;
                            Surfed.Text = "" + dry.surfed;
                            oldSiteId = dry.value;
                            oldSeconds = dry.seconds;
                            ProgramVars.stat = "Connected";
                            ProgramVars.minutes = drx.minutes;
                            ProgramVars.surfed = "" + dry.surfed;
                            ProgramVars.type = drx.type;
                            ProgramVars.ratioTxt = ProgramVars.type == 0 ? 70 : 100;
                            ProgramVars.typeTxt = ProgramVars.type == 0 ? "Normal Shark" : "Super Shark";
                            MemberTypExd.Text = ProgramVars.typeTxt;
                        }

                    }
                    break;
                case 2: //Loaded URLS
                    DefaultResponse drexe = JsonConvert.DeserializeObject<DefaultResponse>(value);
                    if (drexe != null)
                    {
                        if (drexe.value == 1)
                        {
                            if (cmd == 1 || cmd == 0)
                            {
                                string jsonString = Encrypt.Decode(drexe.message);
                                if (jsonString.Length > 5)
                                {
                                    ProgramVars.siteClasses = JsonConvert.DeserializeObject<List<SiteClass>>(jsonString);
                                }
                                Component.main.Invoke(new MethodInvoker(delegate ()
                                {
                                    UrlUtilityForm form2 = new UrlUtilityForm();
                                    form2.Show();
                                    CoreSystem.Resize_window();
                                    isUtilOpen = true;
                                }));
                            }
                            else
                            {
                                Component.main.Invoke(new MethodInvoker(delegate ()
                                {
                                    UrlUtilityForm.LoginDialogInstance.PopulateList();
                                }));
                            }
                        }

                    }
                    break;
                case 3:
                    DefaultResponse defRes = JsonConvert.DeserializeObject<DefaultResponse>(value);
                    if (cmd == 3)
                    {
                        string jsonStringx = Encrypt.Decode(defRes.message);
                        if (jsonStringx.Length > 5)
                        {
                           // ProgramVars.chatList = JsonConvert.DeserializeObject<List<ChatResponse>>(jsonStringx);
                        }
                        Component.main.Invoke(new MethodInvoker(delegate ()
                        {
                            if (!Component.chat.IsDisposed)
                            {
                                Component.chat.StartPosition = FormStartPosition.Manual;
                                Component.chat.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Component.chat.Width,
                                                       Screen.PrimaryScreen.WorkingArea.Height - Component.chat.Height);
                                Component.chat.Show();
                            }
                            else
                            {
                                Component.chat = new ChatWindow();
                                Component.chat.StartPosition = FormStartPosition.Manual;
                                Component.chat.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Component.chat.Width,
                                                       Screen.PrimaryScreen.WorkingArea.Height - Component.chat.Height);
                                Component.chat.Show();
                                chatLoaded = false;
                            }
                            Component.chat.LoadAll();
                            if (CoreSystem.startedToSurf)
                            {
                                CoreSystem.Resize_window();
                            }
                        }));
                    }
                    if (cmd == 0)
                    {
                        if (CoreSystem.chatEnabled)
                        {
                            Component.main.Invoke(new MethodInvoker(delegate ()
                            {
                                if (!Component.chat.IsDisposed)
                                {
                                    Component.chat.StartPosition = FormStartPosition.Manual;
                                    Component.chat.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Component.chat.Width,
                                                           Screen.PrimaryScreen.WorkingArea.Height - Component.chat.Height);
                                    Component.chat.Show();
                                }
                                else
                                {
                                    Component.chat = new ChatWindow();
                                    Component.chat.StartPosition = FormStartPosition.Manual;
                                    Component.chat.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Component.chat.Width,
                                                           Screen.PrimaryScreen.WorkingArea.Height - Component.chat.Height);
                                    Component.chat.Show();
                                    chatLoaded = false;
                                }
                                string jsonStringx = Encrypt.Decode(defRes.message);
                                if (jsonStringx.Length > 5)
                                {
                                //    ProgramVars.chatList = JsonConvert.DeserializeObject<List<ChatResponse>>(jsonStringx);
                                }
                                CoreSystem.canSendChat = true;
                                Component.chat.LoadAll();
                            }));
                        }
                    }
                    break;
                default:
                    DefaultResponse drxz = JsonConvert.DeserializeObject<DefaultResponse>(value);
                    if (drxz != null)
                    {
                        MessageBox.Show(drxz.message);
                    }
                    break;
            }
            this.Refresh();

        }

        private void Myurls_Click(object sender, EventArgs e)
        {
            if (Component.util.Visible)
            {
                Component.util.Hide();
                CoreSystem.Resize_window();
            }
            else
            {
                if (!isUtilOpen)
                {
                   // this.SendMessage("", NetworkConstants.SITES, NetworkCommands.cmd0);
                }
            }

        }

        private void Buymins_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.autosurf-traffic-exchange.com/Buy-Minutes?user=" + LoginDialog.Username);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!chatLoaded)
            {
                chatLoaded = true;
               // this.SendMessage("", NetworkConstants.CHAT, NetworkCommands.cmd2);
            }


        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not implemented!");
        }
    }
}
