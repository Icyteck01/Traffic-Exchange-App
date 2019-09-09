using JHSEngine.Patterns.Mediator;
using SurfShark.Core;
using System;
using System.Drawing;
using System.Windows.Forms;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark
{
    public partial class CoreSystem : JMediator
    {
        private Point lastLocation;

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
                        this.Location = new Point(scrn.Bounds.Right - this.Width - 5, scrn.Bounds.Bottom - 5);
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

        private void Myurls_Click(object sender, EventArgs e)
        {

        }

        private void Buymins_Click(object sender, EventArgs e)
        {
          //  System.Diagnostics.Process.Start("http://www.autosurf-traffic-exchange.com/Buy-Minutes?user=" + LoginDialog.Username);
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function not implemented!");
        }
    }
}
