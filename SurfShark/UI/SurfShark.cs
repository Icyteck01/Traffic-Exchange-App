using JHSEngine.Patterns.Mediator;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SurfShark
{
    public partial class MainProgram : JMediator
    {
        public static MainProgram CoreSystemInstance;
        private readonly Timer Timer1;
        internal static int counter = 0;
        internal static int counterMax = 0;
        internal static int Minutes = 0;
        internal static int reward = 0;
        internal static bool loaded = false;
        internal static int tempCounter = 0;
        public bool ShowPercentage { get; private set; }

        public MainProgram()
        {
            CoreSystemInstance = this;
            this.Timer1 = new Timer();
            this.Timer1.Tick += new EventHandler(this.Timer1_Tick);
            this.Timer1.Enabled = false;
            this.Timer1.Stop();
            InitializeComponent();
            this.webBrowser1.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1_navi);
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            ((Control)this.webBrowser1).Enabled = false;
        }

        private void WebBrowser1_navi(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //MessageBox.Show("Compleated!");
            Application.DoEvents();
            MainProgram.loaded = true;
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Application.DoEvents();
        }

        public string getAlexa(string URL)
        {

            string AlexaRank = "N/A";
            try
            {
                WebRequest request = WebRequest.Create("http://data.alexa.com/data?cli=10&dat=snbamz&url=" + URL);
                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    Regex rankRegex = new Regex("<REACH RANK=\"(.*)\"/>");
                    Match match = rankRegex.Match(line);
                    if (match.Success)
                    {
                        AlexaRank = match.Groups[1].Value.ToString();
                    }
                }
                sr.Close();
            }
            catch (Exception) { }
            return AlexaRank;
        }

        public void Navigate_to(string url)
        {
            /*
            this.EndInvoke(this.BeginInvoke((Action)(() =>
            {
                this.label8.Text = getAlexa(url).ToString();
                this.webBrowser1.Stop();
                this.webBrowser1.DocumentText =
                    "<html></body><center><h1>Loading next site....</h1></center></body></html>";
                this.webBrowser1.Navigate(url);
                this.startTick();
                float newMins = (ProgramVars.ratioTxt / 100.0f) * reward;
                this.rewardTxt.Text = "" + (int)(Math.Round(newMins)) + " Seconds.";
                this.surfedTotalTxt.Text = "" + (int.Parse(ProgramVars.surfed));
                this.memberTypeTxt.Text = ProgramVars.typeTxt;
                this.RatioText.Text = ProgramVars.ratioTxt + "%";
                Application.DoEvents();
                //100 / 
                try
                {
                    int at = 10;
                    int surfed = int.Parse(ProgramVars.surfed); // 23
                    int result = 0;
                    if (surfed > 0)
                    {
                        if (surfed > at) // 23
                        {
                            int surfedx = surfed / at; // 2
                            int surfedy = at * surfedx; //10 * 2 = 20
                            result = surfed - surfedy; // 23 - 20 = 3
                        }
                        else
                        {
                            result = surfed;
                        }

                    }

                    int percent = result * (100 / at);
                    progressBar1.Value = percent;
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
                this.minsNowTxt.Text = Minutes / 60 + " Minute" + ((Minutes / 60) > 0 ? "s" : "");
                int tsx = ProgramVars.minutes / 60;
                this.TotalMinutesTxt.Text = tsx + " Minute" + (tsx > 0 ? "s" : "");
            }))
            );
            */
        }

        private void startTick()
        {
    
                this.Timer1.Enabled = true;
                this.Timer1.Interval = 1000; // 1 second
                this.Timer1.Start();
                MainProgram.loaded = false;
                MainProgram.tempCounter = 10;
                ChangePergentage();
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (MainProgram.loaded || MainProgram.tempCounter <= 0)
            {
                MainProgram.counter--;
                if (MainProgram.counter <= 0)
                {

                    this.webBrowser1.DocumentText =
                        "<html></body><center><h1>Loading next site....</h1></center></body></html>";
                    this.Timer1.Stop();
                }
                else
                {

                        this.Timer1.Stop();
                    
                }
            }
            else
            {
                MainProgram.tempCounter--;
            }
            ChangePergentage();
        }

        private void ChangePergentage()
        {
            try
            {
                int raza = 100 / MainProgram.counterMax;
                progressBar2.Value = raza * MainProgram.counter;
            }
            catch (Exception) { }
        }

        public static bool CloseCancel()
        {
            const string message = "Are you sure that you would like to exit Surf Shark?";
            const string caption = "Question:";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void WebBrowser1_NewWindow_1(object sender, CancelEventArgs e)
        {

        }

        private void WebBrowser1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("You get " + (10 + int.Parse(ProgramVars.surfed) * 0.02) + " seconds when this status is full!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to open in a new window this site ?", "Open in new window", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Preview pv = new Preview();
                pv.Show();
                pv.Navigate_to(webBrowser1.Url.ToString());
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to report this site as spam ?", "Report as Spam!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
                MessageBox.Show("Thank you we will investigate your request asap!");
        }
    }
}
