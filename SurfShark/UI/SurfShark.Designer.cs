namespace SurfShark
{
    partial class MainProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
            this.groupBox1 = new JHUI.Controls.JGroupBox();
            this.btnDelete = new JHUI.Controls.JButton();
            this.progressBar2 = new JHUI.Controls.JProgressBar();
            this.label9 = new JHUI.Controls.JLabel();
            this.button1 = new JHUI.Controls.JButton();
            this.label8 = new JHUI.Controls.JLabel();
            this.rewardTxt = new JHUI.Controls.JLabel();
            this.label2 = new JHUI.Controls.JLabel();
            this.label1 = new JHUI.Controls.JLabel();
            this.button7 = new JHUI.Controls.JButton();
            this.progressBar1 = new JHUI.Controls.JProgressBar();
            this.label10 = new JHUI.Controls.JLabel();
            this.surfedTotalTxt = new JHUI.Controls.JLabel();
            this.label7 = new JHUI.Controls.JLabel();
            this.RatioText = new JHUI.Controls.JLabel();
            this.TotalMinutesTxt = new JHUI.Controls.JLabel();
            this.label4 = new JHUI.Controls.JLabel();
            this.label3 = new JHUI.Controls.JLabel();
            this.groupBox2 = new JHUI.Controls.JGroupBox();
            this.minsNowTxt = new JHUI.Controls.JLabel();
            this.memberTypeTxt = new JHUI.Controls.JLabel();
            this.label6 = new JHUI.Controls.JLabel();
            this.label5 = new JHUI.Controls.JLabel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox3 = new JHUI.Controls.JGroupBox();
            this.jLabel1 = new JHUI.Controls.JLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.progressBar2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.rewardTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.DrawBottomLine = false;
            this.groupBox1.DrawShadows = false;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.FontSize = JHUI.JLabelSize.Small;
            this.groupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(17, 529);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.PaintDefault = false;
            this.groupBox1.Size = new System.Drawing.Size(760, 55);
            this.groupBox1.Style = JHUI.JColorStyle.White;
            this.groupBox1.StyleManager = null;
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Info";
            this.groupBox1.Theme = JHUI.JThemeStyle.Light;
            this.groupBox1.UseStyleColors = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(693, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 19);
            this.btnDelete.Style = JHUI.JColorStyle.White;
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Report";
            this.btnDelete.Theme = JHUI.JThemeStyle.Light;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.ForeColor = System.Drawing.Color.Red;
            this.progressBar2.Location = new System.Drawing.Point(64, 36);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.ProgressTextType = JHUI.Controls.ProgressTextType.DONT_SHOW;
            this.progressBar2.Size = new System.Drawing.Size(689, 13);
            this.progressBar2.Style = JHUI.JColorStyle.White;
            this.progressBar2.TabIndex = 7;
            this.progressBar2.Theme = JHUI.JThemeStyle.Light;
            this.progressBar2.Value = 100;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.DropShadowColor = System.Drawing.Color.Black;
            this.label9.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label9.FontSize = JHUI.JLabelSize.Small;
            this.label9.ForeColor = System.Drawing.Color.Crimson;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.Style = JHUI.JColorStyle.White;
            this.label9.TabIndex = 3;
            this.label9.Text = "Alexa Rank:";
            this.label9.Theme = JHUI.JThemeStyle.Light;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(629, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 19);
            this.button1.Style = JHUI.JColorStyle.White;
            this.button1.TabIndex = 9;
            this.button1.Text = "Open";
            this.button1.Theme = JHUI.JThemeStyle.Light;
            this.button1.UseSelectable = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DropShadowColor = System.Drawing.Color.Black;
            this.label8.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label8.FontSize = JHUI.JLabelSize.Small;
            this.label8.Location = new System.Drawing.Point(70, 17);
            this.label8.MaximumSize = new System.Drawing.Size(0, 13);
            this.label8.MinimumSize = new System.Drawing.Size(55, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.Style = JHUI.JColorStyle.White;
            this.label8.TabIndex = 2;
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Theme = JHUI.JThemeStyle.Light;
            // 
            // rewardTxt
            // 
            this.rewardTxt.AutoSize = true;
            this.rewardTxt.DropShadowColor = System.Drawing.Color.Black;
            this.rewardTxt.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.rewardTxt.FontSize = JHUI.JLabelSize.Small;
            this.rewardTxt.Location = new System.Drawing.Point(200, 17);
            this.rewardTxt.MaximumSize = new System.Drawing.Size(55, 13);
            this.rewardTxt.MinimumSize = new System.Drawing.Size(55, 13);
            this.rewardTxt.Name = "rewardTxt";
            this.rewardTxt.Size = new System.Drawing.Size(13, 15);
            this.rewardTxt.Style = JHUI.JColorStyle.White;
            this.rewardTxt.TabIndex = 0;
            this.rewardTxt.Text = "0";
            this.rewardTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rewardTxt.Theme = JHUI.JThemeStyle.Light;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DropShadowColor = System.Drawing.Color.Black;
            this.label2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.FontSize = JHUI.JLabelSize.Small;
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(126, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.Style = JHUI.JColorStyle.White;
            this.label2.TabIndex = 0;
            this.label2.Text = "Add Reward:";
            this.label2.Theme = JHUI.JThemeStyle.Light;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DropShadowColor = System.Drawing.Color.Black;
            this.label1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.Style = JHUI.JColorStyle.White;
            this.label1.TabIndex = 0;
            this.label1.Text = "Next Add:";
            this.label1.Theme = JHUI.JThemeStyle.Light;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = global::SurfShark.Properties.Resources.gen_question_b_20;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(733, 33);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(21, 20);
            this.button7.Style = JHUI.JColorStyle.White;
            this.button7.TabIndex = 6;
            this.button7.Theme = JHUI.JThemeStyle.Light;
            this.button7.UseSelectable = true;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.progressBar1.Location = new System.Drawing.Point(524, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressTextType = JHUI.Controls.ProgressTextType.DONT_SHOW;
            this.progressBar1.Size = new System.Drawing.Size(200, 12);
            this.progressBar1.Style = JHUI.JColorStyle.White;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Theme = JHUI.JThemeStyle.Light;
            this.progressBar1.Value = 100;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DropShadowColor = System.Drawing.Color.Black;
            this.label10.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.FontSize = JHUI.JLabelSize.Small;
            this.label10.ForeColor = System.Drawing.Color.Teal;
            this.label10.Location = new System.Drawing.Point(454, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 15);
            this.label10.Style = JHUI.JColorStyle.White;
            this.label10.TabIndex = 4;
            this.label10.Text = "Next Bonus:";
            this.label10.Theme = JHUI.JThemeStyle.Light;
            // 
            // surfedTotalTxt
            // 
            this.surfedTotalTxt.AutoSize = true;
            this.surfedTotalTxt.DropShadowColor = System.Drawing.Color.Black;
            this.surfedTotalTxt.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.surfedTotalTxt.FontSize = JHUI.JLabelSize.Small;
            this.surfedTotalTxt.Location = new System.Drawing.Point(552, 16);
            this.surfedTotalTxt.MaximumSize = new System.Drawing.Size(55, 13);
            this.surfedTotalTxt.MinimumSize = new System.Drawing.Size(55, 13);
            this.surfedTotalTxt.Name = "surfedTotalTxt";
            this.surfedTotalTxt.Size = new System.Drawing.Size(13, 15);
            this.surfedTotalTxt.Style = JHUI.JColorStyle.White;
            this.surfedTotalTxt.TabIndex = 0;
            this.surfedTotalTxt.Text = "0";
            this.surfedTotalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.surfedTotalTxt.Theme = JHUI.JThemeStyle.Light;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.DropShadowColor = System.Drawing.Color.Black;
            this.label7.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.FontSize = JHUI.JLabelSize.Small;
            this.label7.ForeColor = System.Drawing.Color.Teal;
            this.label7.Location = new System.Drawing.Point(454, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.Style = JHUI.JColorStyle.White;
            this.label7.TabIndex = 0;
            this.label7.Text = "Surfed Today:";
            this.label7.Theme = JHUI.JThemeStyle.Light;
            // 
            // RatioText
            // 
            this.RatioText.AutoSize = true;
            this.RatioText.DropShadowColor = System.Drawing.Color.Black;
            this.RatioText.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.RatioText.FontSize = JHUI.JLabelSize.Small;
            this.RatioText.Location = new System.Drawing.Point(147, 35);
            this.RatioText.MaximumSize = new System.Drawing.Size(55, 13);
            this.RatioText.MinimumSize = new System.Drawing.Size(55, 13);
            this.RatioText.Name = "RatioText";
            this.RatioText.Size = new System.Drawing.Size(28, 15);
            this.RatioText.Style = JHUI.JColorStyle.White;
            this.RatioText.TabIndex = 0;
            this.RatioText.Text = "70%";
            this.RatioText.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.RatioText.Theme = JHUI.JThemeStyle.Light;
            // 
            // TotalMinutesTxt
            // 
            this.TotalMinutesTxt.AutoSize = true;
            this.TotalMinutesTxt.DropShadowColor = System.Drawing.Color.Black;
            this.TotalMinutesTxt.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.TotalMinutesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.TotalMinutesTxt.FontSize = JHUI.JLabelSize.Small;
            this.TotalMinutesTxt.Location = new System.Drawing.Point(336, 35);
            this.TotalMinutesTxt.MaximumSize = new System.Drawing.Size(104, 13);
            this.TotalMinutesTxt.MinimumSize = new System.Drawing.Size(104, 13);
            this.TotalMinutesTxt.Name = "TotalMinutesTxt";
            this.TotalMinutesTxt.Size = new System.Drawing.Size(55, 15);
            this.TotalMinutesTxt.Style = JHUI.JColorStyle.White;
            this.TotalMinutesTxt.TabIndex = 0;
            this.TotalMinutesTxt.Text = "0 Minutes";
            this.TotalMinutesTxt.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.TotalMinutesTxt.Theme = JHUI.JThemeStyle.Light;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DropShadowColor = System.Drawing.Color.Black;
            this.label4.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.FontSize = JHUI.JLabelSize.Small;
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 15);
            this.label4.Style = JHUI.JColorStyle.White;
            this.label4.TabIndex = 0;
            this.label4.Text = "Traffic Exchange Ratio:";
            this.label4.Theme = JHUI.JThemeStyle.Light;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DropShadowColor = System.Drawing.Color.Black;
            this.label3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.FontSize = JHUI.JLabelSize.Small;
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(204, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.Style = JHUI.JColorStyle.White;
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Minutes You Have:";
            this.label3.Theme = JHUI.JThemeStyle.Light;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox2.Controls.Add(this.minsNowTxt);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.surfedTotalTxt);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TotalMinutesTxt);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.memberTypeTxt);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.RatioText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.DrawBottomLine = false;
            this.groupBox2.DrawShadows = false;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox2.FontSize = JHUI.JLabelSize.Small;
            this.groupBox2.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox2.Location = new System.Drawing.Point(17, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.PaintDefault = false;
            this.groupBox2.Size = new System.Drawing.Size(760, 54);
            this.groupBox2.Style = JHUI.JColorStyle.White;
            this.groupBox2.StyleManager = null;
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Your Account Info";
            this.groupBox2.Theme = JHUI.JThemeStyle.Light;
            this.groupBox2.UseStyleColors = false;
            // 
            // minsNowTxt
            // 
            this.minsNowTxt.AutoSize = true;
            this.minsNowTxt.DropShadowColor = System.Drawing.Color.Black;
            this.minsNowTxt.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.minsNowTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.minsNowTxt.FontSize = JHUI.JLabelSize.Small;
            this.minsNowTxt.Location = new System.Drawing.Point(339, 16);
            this.minsNowTxt.MaximumSize = new System.Drawing.Size(100, 13);
            this.minsNowTxt.MinimumSize = new System.Drawing.Size(100, 13);
            this.minsNowTxt.Name = "minsNowTxt";
            this.minsNowTxt.Size = new System.Drawing.Size(55, 15);
            this.minsNowTxt.Style = JHUI.JColorStyle.White;
            this.minsNowTxt.TabIndex = 0;
            this.minsNowTxt.Text = "0 Minutes";
            this.minsNowTxt.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.minsNowTxt.Theme = JHUI.JThemeStyle.Light;
            // 
            // memberTypeTxt
            // 
            this.memberTypeTxt.AutoSize = true;
            this.memberTypeTxt.DropShadowColor = System.Drawing.Color.Black;
            this.memberTypeTxt.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.memberTypeTxt.FontSize = JHUI.JLabelSize.Small;
            this.memberTypeTxt.ForeColor = System.Drawing.Color.Black;
            this.memberTypeTxt.Location = new System.Drawing.Point(106, 16);
            this.memberTypeTxt.MaximumSize = new System.Drawing.Size(92, 13);
            this.memberTypeTxt.MinimumSize = new System.Drawing.Size(92, 13);
            this.memberTypeTxt.Name = "memberTypeTxt";
            this.memberTypeTxt.Size = new System.Drawing.Size(75, 15);
            this.memberTypeTxt.Style = JHUI.JColorStyle.White;
            this.memberTypeTxt.TabIndex = 0;
            this.memberTypeTxt.Text = "Normal Shark";
            this.memberTypeTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.memberTypeTxt.Theme = JHUI.JThemeStyle.Light;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.CausesValidation = false;
            this.label6.DropShadowColor = System.Drawing.Color.Black;
            this.label6.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.FontSize = JHUI.JLabelSize.Small;
            this.label6.ForeColor = System.Drawing.Color.Teal;
            this.label6.Location = new System.Drawing.Point(204, 16);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(133, 15);
            this.label6.Style = JHUI.JColorStyle.White;
            this.label6.TabIndex = 0;
            this.label6.Text = "Total Earned Time Today: ";
            this.label6.Theme = JHUI.JThemeStyle.Light;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DropShadowColor = System.Drawing.Color.Black;
            this.label5.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.FontSize = JHUI.JLabelSize.Small;
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.Style = JHUI.JColorStyle.White;
            this.label5.TabIndex = 0;
            this.label5.Text = "Membership Type:";
            this.label5.Theme = JHUI.JThemeStyle.Light;
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.CausesValidation = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(6, 19);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(747, 408);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            this.webBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(this.WebBrowser1_NewWindow_1);
            this.webBrowser1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.WebBrowser1_ControlAdded);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.DrawBottomLine = false;
            this.groupBox3.DrawShadows = false;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox3.FontSize = JHUI.JLabelSize.Small;
            this.groupBox3.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(17, 90);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.PaintDefault = false;
            this.groupBox3.Size = new System.Drawing.Size(760, 433);
            this.groupBox3.Style = JHUI.JColorStyle.White;
            this.groupBox3.StyleManager = null;
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Add View";
            this.groupBox3.Theme = JHUI.JThemeStyle.Light;
            this.groupBox3.UseStyleColors = false;
            // 
            // jLabel1
            // 
            this.jLabel1.DropShadowColor = System.Drawing.Color.Cyan;
            this.jLabel1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.jLabel1.FontSize = JHUI.JLabelSize.Tall;
            this.jLabel1.Location = new System.Drawing.Point(17, 3);
            this.jLabel1.Name = "jLabel1";
            this.jLabel1.Size = new System.Drawing.Size(302, 23);
            this.jLabel1.Style = JHUI.JColorStyle.White;
            this.jLabel1.TabIndex = 14;
            this.jLabel1.Text = "Surfing Shark - Surf";
            this.jLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.jLabel1.Theme = JHUI.JThemeStyle.Light;
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.jLabel1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainProgram";
            this.Resizable = false;
            this.Text = "Surfing Shark - Surf";
            this.Theme = JHUI.JThemeStyle.Light;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private JHUI.Controls.JGroupBox groupBox1;
        private JHUI.Controls.JLabel RatioText;
        private JHUI.Controls.JLabel TotalMinutesTxt;
        private JHUI.Controls.JLabel label4;
        private JHUI.Controls.JLabel rewardTxt;
        private JHUI.Controls.JLabel label3;
        private JHUI.Controls.JLabel label2;
        private JHUI.Controls.JLabel label1;
        private JHUI.Controls.JGroupBox groupBox2;
        private JHUI.Controls.JLabel minsNowTxt;
        private JHUI.Controls.JLabel memberTypeTxt;
        private JHUI.Controls.JLabel label6;
        private JHUI.Controls.JLabel label5;
        private JHUI.Controls.JLabel surfedTotalTxt;
        private JHUI.Controls.JLabel label7;
        private JHUI.Controls.JLabel label8;
        private JHUI.Controls.JLabel label9;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private JHUI.Controls.JProgressBar progressBar1;
        private JHUI.Controls.JLabel label10;
        private JHUI.Controls.JButton button7;
        private JHUI.Controls.JProgressBar progressBar2;
        private JHUI.Controls.JGroupBox groupBox3;
        private JHUI.Controls.JButton btnDelete;
        private JHUI.Controls.JButton button1;
        private JHUI.Controls.JLabel jLabel1;
    }
}

