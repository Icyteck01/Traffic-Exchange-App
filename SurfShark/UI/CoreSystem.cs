using JHSEngine.Interfaces;
using JHSEngine.Patterns.Mediator;
using SurfShark.Core;
using SurfShark.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark
{
    public partial class CoreSystem : JMediator
    {
        Point lastLocation;

        public CoreSystem()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Opacity = 1;
            this.PaintTopBorder = true;
            this.TopMost = true;
            if (lastLocation.IsEmpty)
            {
                this.StartPosition = FormStartPosition.Manual;
                foreach (var scrn in Screen.AllScreens)
                {
                    if (scrn.Bounds.Contains(this.Location))
                    {
                        this.Location = new Point(scrn.Bounds.Right - this.Width - 20, scrn.Bounds.Top + 20);
                        return;
                    }
                }
            }
            else
            {
                Location = lastLocation;
            }
        }

        protected void OnFormClosingx(object sender, EventArgs e)
        {
            if (CloseCancel() == true)
            {
                MainComponent.Core.SendNotification(DO_EXIT_PROGRAM);
            }
            else
            {
                MainComponent.Core.SendNotification(EVENT_RESIZE);
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
            MainComponent.Core.SendNotification(EVENT_RESIZE);
        }

        private void OpenUrlEditor(object sender, EventArgs e)
        {
            MainComponent.Core.SendNotification(SHOW_URL_EDITOR);
        }

        private void OnBuyCreditsClick(object sender, EventArgs e)
        {
            //  System.Diagnostics.Process.Start("http://www.autosurf-traffic-exchange.com/Buy-Minutes?user=" + LoginDialog.Username);
        }

        private void OnOpenChatClick(object sender, EventArgs e)
        {
            MainComponent.Core.SendNotification(SHOW_CHAT_WINDOW);
        }
        private Bitmap GetImage()
        {
            try
            {
                string path = Path.Combine(Path.GetTempPath() , MainCache.UserName + ".jpg");
                if (File.Exists(path))
                    return new Bitmap(new MemoryStream(File.ReadAllBytes(path)));
            }
            catch { }
            return Resources.user_default_avatar;
        }

        private void seaveImage(string filePath)
        {
            string path = Path.Combine(Path.GetTempPath(), MainCache.UserName + ".jpg");
            File.WriteAllBytes(path, File.ReadAllBytes(filePath));
            pictureBox2.BackgroundImage = GetImage();
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.FilterIndex = 1;
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dialog.ShowDialog() == DialogResult.OK && File.Exists(dialog.FileName))
                {
               
                    seaveImage(dialog.FileName);
                }
            }
        }


        public override string[] ListNotificationInterests()
        {
            return new string[] { SHOW_MAIN };
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case SHOW_MAIN:
                    pictureBox2.BackgroundImage = GetImage();
                    MemberTypExd.Text = MainCache.MemberType.ToString();
                    Surfed.Text = MainCache.SurfedSites.ToString();
                    Minutes.Text = MainCache.Credit.ToString();
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainComponent.Core.SendNotification(START_SURFING);
        }
    }
}
