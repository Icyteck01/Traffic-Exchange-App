using JHSEngine.Patterns.Mediator;
using JHUI.Forms;
using System;

namespace SurfShark
{
    public partial class Preview : JMediator
    {
        public Preview()
        {
            InitializeComponent();
        }

        public void Navigate_to(string url)
        {
            this.EndInvoke(this.BeginInvoke((Action)(() =>
            {
                textBox1.Text = url;
                this.webBrowser1.Navigate(url);
            }))
            );
        }
    }
}
