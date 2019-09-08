using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Launcher : Form
    {
        private int version = 0;
        private System.Windows.Forms.Timer timer1;
        public int counter = 3;
        public int counterINIT = 3;
        private Stopwatch stopwatch;
        private long ctime = 0, ptime = 0, current = 0, previous = 0;
        public Launcher()
        {
            InitializeComponent();
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer1.Tick += new EventHandler(this.Timer1_Tick);
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Start();
            infoLabel.Text = "Please Wait...";
            this.progressBar.Style = ProgressBarStyle.Marquee;
            this.progressBar.MarqueeAnimationSpeed = 30;
            this.version = int.Parse(GetUrl());
        }

        private string GetUrl()
        {
            string url = "http://www.autosurf-traffic-exchange.com/SurfingShark/update.ini";
            Application.DoEvents();
            HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Application.DoEvents();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return "1";
                }
                else
                {
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        Application.DoEvents();
                        return sr.ReadToEnd();
                    }
                }

            }
        }

        private void Download()
        {
            stopwatch = new Stopwatch();
            string url = "http://www.autosurf-traffic-exchange.com/SurfingShark/Install_Surfing_Shark.exe";
            string path = Path.GetTempPath() + "Install_Surfing_Shark.exe";
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri(url), path);
            stopwatch.Start();
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            string path = Path.GetTempPath() + "Install_Surfing_Shark.exe";
            MessageBox.Show("The program will now exit to start the update, please follow the instalation guide.");
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = "update";
            start.FileName = path;
            Process.Start(start);
            Application.Exit();
            Environment.Exit(0);
        }

        private void Get_Versions()
        {
            infoLabel.Text = "Checking for program updates...";
            infoLabel.Text = "Please Wait...";
            if (InfoVersion.version < this.version)
            {
                if (ShowFoundDialog() == true)
                {
                    this.progressBar.Style = ProgressBarStyle.Continuous;
                    this.progressBar.MarqueeAnimationSpeed = 0;
                    this.progressBar.Value = 0;
                    Download();
                }
                else
                {
                    int diff = this.version - InfoVersion.version;
                    if (diff > 5)
                    {
                        MessageBox.Show("Sorry you must update before using this program again!");
                    }
                    else
                    {
                        Start_Program_exit();
                    }
                }
            }
            else
            {
                Start_Program_exit();
            }

        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ctime = stopwatch.ElapsedMilliseconds;
            current = e.BytesReceived;
            this.progressBar.Value = e.ProgressPercentage;
            string perc = ((int)(((current - previous) / (double)1024) / ((ctime - ptime) / (double)1000))).ToString() + " Kbps";
            infoLabel.Text = "Downloading update with " + perc + "";
        }

        private void Start_Program_exit()
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = "start";
            start.FileName = "CS.exe";
            Process.Start(start);
            Application.Exit();
            Environment.Exit(0);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.counter--;
            this.progressBar.Value++;
            if (this.counter == 0)
            {
                this.timer1.Stop();
                infoLabel.Text = "Please Wait...";
                this.progressBar.Maximum = 100;
                this.progressBar.Value = 100;
                this.progressBar.Style = ProgressBarStyle.Marquee;
                this.progressBar.MarqueeAnimationSpeed = 30;
                Get_Versions();
            }
            else
            {
                this.progressBar.Style = ProgressBarStyle.Continuous;
                this.progressBar.MarqueeAnimationSpeed = 0;
                infoLabel.Text = "Checking program integrity...";
                this.progressBar.Maximum = counterINIT;

            }

        }

        public static bool ShowFoundDialog()
        {
            const string message = "Found a new Update would you like to download it now?";
            const string caption = "Question:";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
}
