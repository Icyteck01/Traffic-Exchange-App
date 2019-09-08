namespace SurfShark
{
    partial class Preview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new JHUI.Controls.JTextBox();
            this.label1 = new JHUI.Controls.JLabel();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.CausesValidation = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(15, 99);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(636, 371);
            this.webBrowser1.TabIndex = 4;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderBottomLineSize = 5;
            this.textBox1.BorderColor = System.Drawing.Color.Black;
            this.textBox1.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(583, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox1.CustomButton.Style = JHUI.JColorStyle.White;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.DrawBorder = true;
            this.textBox1.DrawBorderBottomLine = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(48, 73);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(601, 20);
            this.textBox1.Style = JHUI.JColorStyle.White;
            this.textBox1.TabIndex = 5;
            this.textBox1.TextWaterMark = "";
            this.textBox1.Theme = JHUI.JThemeStyle.Light;
            this.textBox1.UseCustomFont = true;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DropShadowColor = System.Drawing.Color.Black;
            this.label1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.Style = JHUI.JColorStyle.White;
            this.label1.TabIndex = 6;
            this.label1.Text = "URL:";
            this.label1.Theme = JHUI.JThemeStyle.Light;
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(663, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.webBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Preview";
            this.Resizable = false;
            this.Text = "Preview";
            this.Theme = JHUI.JThemeStyle.Light;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private JHUI.Controls.JTextBox textBox1;
        private JHUI.Controls.JLabel label1;
    }
}