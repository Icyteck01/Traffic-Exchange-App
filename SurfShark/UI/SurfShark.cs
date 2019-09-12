using JHSEngine.Interfaces;
using JHSEngine.Patterns.Mediator;
using JHSNetProtocol;
using JHUI;
using SurfShark.Core;
using SurfShark.Network.Packets;
using System;
using System.Drawing;
using System.Windows.Forms;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark
{
    public partial class SurfShark : JMediator
    {
        private bool Started = false;
        public SurfShark()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            if (!Started)
            {
                LateInvoker.InvokeRepeating(SUpdate, 1);
                Started = true;
            }
        }

        private void OpenLinkInDefaultBrowser(object sender, EventArgs e)
        {
            var confirmResult = JMessageBox.Show(this, "Are you sure to open in a new window this site ?", "Open in new window", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Url);
            }

        }

        private void SurfShark_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MainComponent.Core.SendNotification(STOP_SURFING);
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Finished = false;
            Console.WriteLine("WebBrowser1_Navigated");
        }

        private void WebBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Finished = false;
            Console.WriteLine("WebBrowser1_Navigating");
        }

        private Bitmap bgImage = null;
        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Finished = true;
            Url = webBrowser1.Url.ToString();
            TakeCroppedScreenShot();
            Console.WriteLine("WebBrowser1_DocumentCompleted");
            if (webBrowser1.Url.ToString() != "about:blank") { }
                Running = true;
        }

        private void TakeCroppedScreenShot()
        {
            using (Graphics g = webBrowser1.CreateGraphics())
            {
                if (bgImage != null)
                    bgImage.Dispose();

                bgImage = new Bitmap(webBrowser1.Width, webBrowser1.Height);
                webBrowser1.DrawToBitmap(bgImage, new Rectangle(0, 0, webBrowser1.Width, webBrowser1.Height));
                jPictureBox1.BackgroundImage = bgImage;
                jPictureBox1.Refresh();
            }
        }

        private void SurfShark_Shown(object sender, EventArgs e)
        {
            LoadBlank();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            MainComponent.Core.SendNotification(GOT_NEW_URL, new UrlDetails()
            {
                Url = "https://www.youtube.com/watch?v=zIBeehL2ZT0",
                Time = 10
            }); 
        }

        private void SurfShark_Load(object sender, EventArgs e)
        {
            //  webBrowser1.Enabled = false;

        }

        private void WebBrowser1_Resize(object sender, EventArgs e)
        {
            if(Finished)
                TakeCroppedScreenShot();
        }

        private void LoadBlank()
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            webBrowser1.DocumentText = "<html><body><center><h1>Loading please wait.</center></h1></body></html>";
            TakeCroppedScreenShot();
        }

        #region LOGIC
        private string Url;
        private bool Finished = true;
        private bool started = false;

        private bool Running = false;
        private int Time = 0;
        private int Maxtime = 1000;
        protected void Start(string url, int time, uint Credits = 0)
        {
            MainCache.AddCredit = Credits;
            rewardTxt.Text = Credits.ToString();
            Url = url;
            Maxtime = time;
            Time = 0;
            webBrowser1.Navigate(url);
        }

        protected void TimesUp()
        {
            LoadBlank();
            MainComponent.Core.SendNotification(ASK_4_NEW_URL);
        }

        void SUpdate()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { SUpdate(); });
                return;
            }
            if (!started)
            {
                progressBar2.Value = 0;
            }
            if (Running)
            {
                if(Time >= Maxtime)
                {
                    Running = false;
                    TimesUp();
                    progressBar2.Value = 100;
                    return;
                }
                progressBar2.Value = (int)((float)Time / (float)Maxtime * 100F);
                Time++;
            }
        }

        public override string[] ListNotificationInterests()
        {
            return new string[] { START_SURFING, GOT_NEW_URL, STOP_SURFING };
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
                case STOP_SURFING:
                    MainCache.AddCredit = 0;
                    Running = false;
                    started = false;
                    break;
                case START_SURFING:

                    if (!started)
                    {
                        LoadBlank();
                        MainComponent.Core.SendNotification(ASK_4_NEW_URL);
                    }
                    break;
                case GOT_NEW_URL:
                    if (notification.Body is UrlDetails packet)
                    {
                        if (packet.code == ErrorCodes.SUCCESS)
                        {
                            started = true;
                            uint reward = 0;
                            switch (MainCache.MemberType)
                            {
                                case UserType.FREE:
                                    reward = (uint)(packet.Time * 0.5f);
                                    break;
                                default:
                                    reward = packet.Time;
                                    break;
                            }
                            Start(packet.Url, (int)packet.Time, reward);
                        }
                        else
                        {

                        }
                    }
                    break;
            }
        }
        #endregion;


    }
}
