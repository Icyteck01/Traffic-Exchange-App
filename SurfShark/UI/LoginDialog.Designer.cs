namespace SurfShark
{
    partial class LoginDialog
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
            this.components = new System.ComponentModel.Container();
            JHUI.JAnimation jAnimation1 = new JHUI.JAnimation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
            this.RegisterTabPage = new JHUI.Controls.JTabControl();
            this.loginPage = new JHUI.Controls.JTabPage();
            this.textBox2 = new JHUI.Controls.JTextBox();
            this.textBox1 = new JHUI.Controls.JTextBox();
            this.button1 = new JHUI.Controls.JButton();
            this.pictureBox1 = new JHUI.Controls.JPictureBox();
            this.RegisterPage = new JHUI.Controls.JTabPage();
            this.textBox5 = new JHUI.Controls.JTextBox();
            this.textBox3 = new JHUI.Controls.JTextBox();
            this.textBox4 = new JHUI.Controls.JTextBox();
            this.button2 = new JHUI.Controls.JButton();
            this.pictureBox2 = new JHUI.Controls.JPictureBox();
            this.notice = new JHUI.Controls.JTextBox();
            this.RegisterTabPage.SuspendLayout();
            this.loginPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.RegisterPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // RegisterTabPage
            // 
            jAnimation1.AnimateOnlyDifferences = true;
            jAnimation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.BlindCoeff")));
            jAnimation1.LeafCoeff = 0F;
            jAnimation1.MaxTime = 1F;
            jAnimation1.MinTime = 0F;
            jAnimation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicCoeff")));
            jAnimation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.MosaicShift")));
            jAnimation1.MosaicSize = 20;
            jAnimation1.Padding = new System.Windows.Forms.Padding(30);
            jAnimation1.RotateCoeff = 0F;
            jAnimation1.RotateLimit = 0F;
            jAnimation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.ScaleCoeff")));
            jAnimation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("jAnimation1.SlideCoeff")));
            jAnimation1.TimeCoeff = 0F;
            jAnimation1.TransparencyCoeff = 0F;
            this.RegisterTabPage.ChangeAnimation = jAnimation1;
            this.RegisterTabPage.Controls.Add(this.loginPage);
            this.RegisterTabPage.Controls.Add(this.RegisterPage);
            this.RegisterTabPage.Location = new System.Drawing.Point(6, 63);
            this.RegisterTabPage.Name = "RegisterTabPage";
            this.RegisterTabPage.Padding = new System.Drawing.Point(6, 8);
            this.RegisterTabPage.SelectedIndex = 0;
            this.RegisterTabPage.Size = new System.Drawing.Size(705, 406);
            this.RegisterTabPage.Style = JHUI.JColorStyle.White;
            this.RegisterTabPage.TabIndex = 0;
            this.RegisterTabPage.TabStop = false;
            this.RegisterTabPage.Theme = JHUI.JThemeStyle.Light;
            this.RegisterTabPage.UseSelectable = true;
            this.RegisterTabPage.SelectedIndexChanged += new System.EventHandler(this.RegisterTabPage_SelectedIndexChanged);
            // 
            // loginPage
            // 
            this.loginPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.loginPage.Controls.Add(this.textBox2);
            this.loginPage.Controls.Add(this.textBox1);
            this.loginPage.Controls.Add(this.button1);
            this.loginPage.Controls.Add(this.pictureBox1);
            this.loginPage.HorizontalScrollbarBarColor = true;
            this.loginPage.HorizontalScrollbarHighlightOnWheel = false;
            this.loginPage.HorizontalScrollbarSize = 10;
            this.loginPage.Location = new System.Drawing.Point(4, 38);
            this.loginPage.Name = "loginPage";
            this.loginPage.Size = new System.Drawing.Size(697, 364);
            this.loginPage.Style = JHUI.JColorStyle.White;
            this.loginPage.TabIndex = 0;
            this.loginPage.Text = "Login";
            this.loginPage.Theme = JHUI.JThemeStyle.Dark;
            this.loginPage.VerticalScrollbarBarColor = true;
            this.loginPage.VerticalScrollbarHighlightOnWheel = false;
            this.loginPage.VerticalScrollbarSize = 10;
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
            this.textBox2.CustomButton.Location = new System.Drawing.Point(329, 2);
            this.textBox2.CustomButton.Name = "";
            this.textBox2.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBox2.CustomButton.Style = JHUI.JColorStyle.White;
            this.textBox2.CustomButton.TabIndex = 1;
            this.textBox2.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.textBox2.CustomButton.UseSelectable = true;
            this.textBox2.CustomButton.Visible = false;
            this.textBox2.DrawBorder = true;
            this.textBox2.DrawBorderBottomLine = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.FontSize = JHUI.JTextBoxSize.Tall;
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Lines = new string[0];
            this.textBox2.Location = new System.Drawing.Point(166, 171);
            this.textBox2.MaxLength = 32767;
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectedText = "";
            this.textBox2.SelectionLength = 0;
            this.textBox2.SelectionStart = 0;
            this.textBox2.ShortcutsEnabled = true;
            this.textBox2.Size = new System.Drawing.Size(363, 36);
            this.textBox2.Style = JHUI.JColorStyle.White;
            this.textBox2.TabIndex = 2;
            this.textBox2.TextWaterMark = "Password";
            this.textBox2.Theme = JHUI.JThemeStyle.Dark;
            this.textBox2.UseCustomFont = false;
            this.textBox2.UseSelectable = true;
            this.textBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.Click += new System.EventHandler(this.TextBox2_Click);
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
            this.textBox1.CustomButton.Location = new System.Drawing.Point(329, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBox1.CustomButton.Style = JHUI.JColorStyle.White;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.DrawBorder = true;
            this.textBox1.DrawBorderBottomLine = false;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox1.FontSize = JHUI.JTextBoxSize.Tall;
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(166, 129);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.Size = new System.Drawing.Size(363, 36);
            this.textBox1.Style = JHUI.JColorStyle.White;
            this.textBox1.TabIndex = 1;
            this.textBox1.TextWaterMark = "Username";
            this.textBox1.Theme = JHUI.JThemeStyle.Dark;
            this.textBox1.UseCustomFont = false;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(163)))), ((int)(((byte)(205)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(166, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(363, 75);
            this.button1.Style = JHUI.JColorStyle.White;
            this.button1.TabIndex = 3;
            this.button1.Text = "LOGIN";
            this.button1.Theme = JHUI.JThemeStyle.Dark;
            this.button1.UseSelectable = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(166, -5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 366);
            this.pictureBox1.Style = JHUI.JColorStyle.White;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // RegisterPage
            // 
            this.RegisterPage.Controls.Add(this.textBox5);
            this.RegisterPage.Controls.Add(this.textBox3);
            this.RegisterPage.Controls.Add(this.textBox4);
            this.RegisterPage.Controls.Add(this.button2);
            this.RegisterPage.Controls.Add(this.pictureBox2);
            this.RegisterPage.HorizontalScrollbarBarColor = true;
            this.RegisterPage.HorizontalScrollbarHighlightOnWheel = false;
            this.RegisterPage.HorizontalScrollbarSize = 10;
            this.RegisterPage.Location = new System.Drawing.Point(4, 36);
            this.RegisterPage.Name = "RegisterPage";
            this.RegisterPage.Size = new System.Drawing.Size(192, 60);
            this.RegisterPage.Style = JHUI.JColorStyle.White;
            this.RegisterPage.TabIndex = 1;
            this.RegisterPage.Text = "Register";
            this.RegisterPage.Theme = JHUI.JThemeStyle.Dark;
            this.RegisterPage.UseVisualStyleBackColor = true;
            this.RegisterPage.VerticalScrollbarBarColor = true;
            this.RegisterPage.VerticalScrollbarHighlightOnWheel = false;
            this.RegisterPage.VerticalScrollbarSize = 10;
            // 
            // textBox5
            // 
            this.textBox5.BorderBottomLineSize = 5;
            this.textBox5.BorderColor = System.Drawing.Color.Black;
            this.textBox5.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox5.CustomButton.Image = null;
            this.textBox5.CustomButton.Location = new System.Drawing.Point(329, 2);
            this.textBox5.CustomButton.Name = "";
            this.textBox5.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBox5.CustomButton.Style = JHUI.JColorStyle.White;
            this.textBox5.CustomButton.TabIndex = 1;
            this.textBox5.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.textBox5.CustomButton.UseSelectable = true;
            this.textBox5.CustomButton.Visible = false;
            this.textBox5.DrawBorder = true;
            this.textBox5.DrawBorderBottomLine = false;
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox5.FontSize = JHUI.JTextBoxSize.Tall;
            this.textBox5.FontWeight = JHUI.JTextBoxWeight.Light;
            this.textBox5.ForeColor = System.Drawing.Color.Black;
            this.textBox5.Lines = new string[0];
            this.textBox5.Location = new System.Drawing.Point(166, 213);
            this.textBox5.MaxLength = 32767;
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '*';
            this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox5.SelectedText = "";
            this.textBox5.SelectionLength = 0;
            this.textBox5.SelectionStart = 0;
            this.textBox5.ShortcutsEnabled = true;
            this.textBox5.Size = new System.Drawing.Size(363, 36);
            this.textBox5.Style = JHUI.JColorStyle.White;
            this.textBox5.TabIndex = 3;
            this.textBox5.TextWaterMark = "Repeate Password";
            this.textBox5.Theme = JHUI.JThemeStyle.Dark;
            this.textBox5.UseCustomFont = false;
            this.textBox5.UseSelectable = true;
            this.textBox5.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox5.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox3
            // 
            this.textBox3.BorderBottomLineSize = 5;
            this.textBox3.BorderColor = System.Drawing.Color.Black;
            this.textBox3.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox3.CustomButton.Image = null;
            this.textBox3.CustomButton.Location = new System.Drawing.Point(329, 2);
            this.textBox3.CustomButton.Name = "";
            this.textBox3.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBox3.CustomButton.Style = JHUI.JColorStyle.White;
            this.textBox3.CustomButton.TabIndex = 1;
            this.textBox3.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.textBox3.CustomButton.UseSelectable = true;
            this.textBox3.CustomButton.Visible = false;
            this.textBox3.DrawBorder = true;
            this.textBox3.DrawBorderBottomLine = false;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox3.FontSize = JHUI.JTextBoxSize.Tall;
            this.textBox3.FontWeight = JHUI.JTextBoxWeight.Light;
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Lines = new string[0];
            this.textBox3.Location = new System.Drawing.Point(166, 171);
            this.textBox3.MaxLength = 32767;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox3.SelectedText = "";
            this.textBox3.SelectionLength = 0;
            this.textBox3.SelectionStart = 0;
            this.textBox3.ShortcutsEnabled = true;
            this.textBox3.Size = new System.Drawing.Size(363, 36);
            this.textBox3.Style = JHUI.JColorStyle.White;
            this.textBox3.TabIndex = 2;
            this.textBox3.TextWaterMark = "Password";
            this.textBox3.Theme = JHUI.JThemeStyle.Dark;
            this.textBox3.UseCustomFont = false;
            this.textBox3.UseSelectable = true;
            this.textBox3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox4
            // 
            this.textBox4.BorderBottomLineSize = 5;
            this.textBox4.BorderColor = System.Drawing.Color.Black;
            this.textBox4.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.textBox4.CustomButton.Image = null;
            this.textBox4.CustomButton.Location = new System.Drawing.Point(329, 2);
            this.textBox4.CustomButton.Name = "";
            this.textBox4.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.textBox4.CustomButton.Style = JHUI.JColorStyle.White;
            this.textBox4.CustomButton.TabIndex = 1;
            this.textBox4.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.textBox4.CustomButton.UseSelectable = true;
            this.textBox4.CustomButton.Visible = false;
            this.textBox4.DrawBorder = true;
            this.textBox4.DrawBorderBottomLine = false;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBox4.FontSize = JHUI.JTextBoxSize.Tall;
            this.textBox4.FontWeight = JHUI.JTextBoxWeight.Light;
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Lines = new string[0];
            this.textBox4.Location = new System.Drawing.Point(166, 129);
            this.textBox4.MaxLength = 32767;
            this.textBox4.Name = "textBox4";
            this.textBox4.PasswordChar = '\0';
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox4.SelectedText = "";
            this.textBox4.SelectionLength = 0;
            this.textBox4.SelectionStart = 0;
            this.textBox4.ShortcutsEnabled = true;
            this.textBox4.Size = new System.Drawing.Size(363, 36);
            this.textBox4.Style = JHUI.JColorStyle.White;
            this.textBox4.TabIndex = 1;
            this.textBox4.TextWaterMark = "Username";
            this.textBox4.Theme = JHUI.JThemeStyle.Dark;
            this.textBox4.UseCustomFont = false;
            this.textBox4.UseSelectable = true;
            this.textBox4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(185)))), ((int)(((byte)(78)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F);
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(166, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(363, 34);
            this.button2.Style = JHUI.JColorStyle.White;
            this.button2.TabIndex = 4;
            this.button2.Text = "REGISTER";
            this.button2.Theme = JHUI.JThemeStyle.Dark;
            this.button2.UseSelectable = true;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BTNRegister_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(166, -5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(363, 366);
            this.pictureBox2.Style = JHUI.JColorStyle.White;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // notice
            // 
            this.notice.BackColor = System.Drawing.Color.White;
            this.notice.BorderBottomLineSize = 5;
            this.notice.BorderColor = System.Drawing.Color.Black;
            this.notice.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.notice.CustomButton.Image = null;
            this.notice.CustomButton.Location = new System.Drawing.Point(669, 1);
            this.notice.CustomButton.Name = "";
            this.notice.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.notice.CustomButton.Style = JHUI.JColorStyle.White;
            this.notice.CustomButton.TabIndex = 1;
            this.notice.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.notice.CustomButton.UseSelectable = true;
            this.notice.CustomButton.Visible = false;
            this.notice.DrawBorder = false;
            this.notice.DrawBorderBottomLine = false;
            this.notice.Enabled = false;
            this.notice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.notice.FontWeight = JHUI.JTextBoxWeight.Light;
            this.notice.ForeColor = System.Drawing.Color.Black;
            this.notice.Lines = new string[] {
        "Server unreachable, please wait, it usually takes a few seconds if this error per" +
            "sists please contact us on site."};
            this.notice.Location = new System.Drawing.Point(10, 475);
            this.notice.MaxLength = 32767;
            this.notice.Name = "notice";
            this.notice.PasswordChar = '\0';
            this.notice.ReadOnly = true;
            this.notice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.notice.SelectedText = "";
            this.notice.SelectionLength = 0;
            this.notice.SelectionStart = 0;
            this.notice.ShortcutsEnabled = true;
            this.notice.Size = new System.Drawing.Size(697, 29);
            this.notice.Style = JHUI.JColorStyle.White;
            this.notice.TabIndex = 5;
            this.notice.Text = "Server unreachable, please wait, it usually takes a few seconds if this error per" +
    "sists please contact us on site.";
            this.notice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.notice.TextWaterMark = "";
            this.notice.Theme = JHUI.JThemeStyle.Dark;
            this.notice.UseCustomFont = false;
            this.notice.UseSelectable = true;
            this.notice.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.notice.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LoginDialog
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(718, 512);
            this.Controls.Add(this.RegisterTabPage);
            this.Controls.Add(this.notice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(718, 512);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(718, 512);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(718, 512);
            this.Name = "LoginDialog";
            this.PaddingTop = 0;
            this.PaintTopBorder = false;
            this.Resizable = false;
            this.Text = "Welcome back";
            this.TopMost = true;
            this.UseCustomBackColor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginDialog_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginDialog_KeyDown);
            this.RegisterTabPage.ResumeLayout(false);
            this.loginPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.RegisterPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JTabControl RegisterTabPage;
        private JHUI.Controls.JTabPage loginPage;
        private JHUI.Controls.JTabPage RegisterPage;
        private JHUI.Controls.JTextBox textBox2;
        private JHUI.Controls.JTextBox textBox1;
        private JHUI.Controls.JButton button1;
        private JHUI.Controls.JTextBox textBox3;
        private JHUI.Controls.JTextBox textBox4;
        private JHUI.Controls.JButton button2;
        private JHUI.Controls.JTextBox textBox5;
        private JHUI.Controls.JPictureBox pictureBox1;
        private JHUI.Controls.JPictureBox pictureBox2;
        private JHUI.Controls.JTextBox notice;
    }
}