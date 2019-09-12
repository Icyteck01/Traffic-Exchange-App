using System;

namespace SurfShark
{
    partial class ChatWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatWindow));
            this.button1 = new JHUI.Controls.JButton();
            this.textBox2 = new JHUI.Controls.JTextBox();
            this.chatTextBox = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new JHUI.Controls.JToggle();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(264, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.Style = JHUI.JColorStyle.White;
            this.button1.TabIndex = 7;
            this.button1.Text = "Send";
            this.button1.Theme = JHUI.JThemeStyle.Light;
            this.button1.UseSelectable = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.OnBtnDownSend);
            // 
            // textBox2
            // 
            this.textBox2.BorderBottomLineSize = 5;
            this.textBox2.BorderColor = System.Drawing.Color.Black;
            this.textBox2.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox2.CustomButton.Image = null;
            this.textBox2.CustomButton.Location = new System.Drawing.Point(203, 2);
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.textBox2.CustomButton.Style = JHUI.JColorStyle.White;
            this.textBox2.CustomButton.TabIndex = 1;
            this.textBox2.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = false;
            this.textBox2.DrawBorder = true;
            this.textBox2.DrawBorderBottomLine = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(14, 346);
            this.textBox2.MaxLength = 60;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(221, 20);
            this.textBox2.Style = JHUI.JColorStyle.White;
            this.textBox2.TabIndex = 8;
            this.textBox2.TextWaterMark = "Enter message";
            this.textBox2.Theme = JHUI.JThemeStyle.Light;
            this.textBox2.UseCustomFont = true;
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox2_KeyDown);
            // 
            // chatTextBox
            // 
            this.chatTextBox.Location = new System.Drawing.Point(4, 63);
            this.chatTextBox.Name = "chatTextBox";
            this.chatTextBox.ReadOnly = true;
            this.chatTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatTextBox.Size = new System.Drawing.Size(341, 276);
            this.chatTextBox.TabIndex = 9;
            this.chatTextBox.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(264, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.OffText = "Off";
            this.checkBox1.OnText = "On";
            this.checkBox1.Size = new System.Drawing.Size(72, 24);
            this.checkBox1.Style = JHUI.JColorStyle.White;
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Off";
            this.checkBox1.Theme = JHUI.JThemeStyle.Light;
            this.checkBox1.UseSelectable = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 378);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chatTextBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(348, 378);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(348, 378);
            this.Name = "ChatWindow";
            this.Resizable = false;
            this.Text = "Surfing Chat";
            this.Theme = JHUI.JThemeStyle.Light;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private JHUI.Controls.JButton button1;
        private JHUI.Controls.JTextBox textBox2;
        private System.Windows.Forms.RichTextBox chatTextBox;
        private JHUI.Controls.JToggle checkBox1;
    }
}