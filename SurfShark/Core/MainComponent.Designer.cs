using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfShark.Core
{
    partial class MainComponent
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainComponent));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.jContextMenu1 = new JHUI.Controls.JContextMenu(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tEst2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jContextMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.jContextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // jContextMenu1
            // 
            this.jContextMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.tEst2ToolStripMenuItem});
            this.jContextMenu1.Name = "jContextMenu1";
            this.jContextMenu1.Size = new System.Drawing.Size(104, 48);
            this.jContextMenu1.Style = JHUI.JColorStyle.White;
            this.jContextMenu1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.testToolStripMenuItem.Text = "Show";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // tEst2ToolStripMenuItem
            // 
            this.tEst2ToolStripMenuItem.Name = "tEst2ToolStripMenuItem";
            this.tEst2ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.tEst2ToolStripMenuItem.Text = "Exit";
            this.tEst2ToolStripMenuItem.Click += new System.EventHandler(this.TEst2ToolStripMenuItem_Click);
            // 
            // MainComponent
            // 
            this.ClientSize = new System.Drawing.Size(300, 214);
            this.ControlBox = false;
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.JControlBoxShow = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainComponent";
            this.PaintTopBorder = false;
            this.Resizable = false;
            this.ShadowType = JHUI.Forms.JFormShadowType.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MainComponent";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.jContextMenu1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
