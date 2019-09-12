namespace SurfShark
{
    partial class UrlUtilityForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlUtilityForm));
            this.SitesDataGrid = new JHUI.Controls.JDataGridView();
            this.SiteName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.websiteInp = new JHUI.Controls.JTextBox();
            this.secondsDrop = new JHUI.Controls.JNumericUpDown();
            this.groupBox1 = new JHUI.Controls.JGroupBox();
            this.button2 = new JHUI.Controls.JButton();
            this.region = new JHUI.Controls.JComboBox();
            this.label8 = new JHUI.Controls.JLabel();
            this.btnDelete = new JHUI.Controls.JButton();
            this.btnPause = new JHUI.Controls.JButton();
            this.button1 = new JHUI.Controls.JButton();
            this.Referral = new JHUI.Controls.JComboBox();
            this.save = new JHUI.Controls.JButton();
            this.button5 = new JHUI.Controls.JButton();
            this.button4 = new JHUI.Controls.JButton();
            this.label2 = new JHUI.Controls.JLabel();
            this.nameInp = new JHUI.Controls.JTextBox();
            this.label3 = new JHUI.Controls.JLabel();
            this.label4 = new JHUI.Controls.JLabel();
            this.label1 = new JHUI.Controls.JLabel();
            this.btnAdd = new JHUI.Controls.JButton();
            this.groupBox2 = new JHUI.Controls.JGroupBox();
            this.groupBox3 = new JHUI.Controls.JGroupBox();
            this.AlexaRankLabel = new JHUI.Controls.JLabel();
            this.label10 = new JHUI.Controls.JLabel();
            this.labelStatus = new JHUI.Controls.JLabel();
            this.label6 = new JHUI.Controls.JLabel();
            this.hitsLabel = new JHUI.Controls.JLabel();
            this.label5 = new JHUI.Controls.JLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SitesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsDrop)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SitesDataGrid
            // 
            this.SitesDataGrid.AllowUserToAddRows = false;
            this.SitesDataGrid.AllowUserToDeleteRows = false;
            this.SitesDataGrid.AllowUserToResizeColumns = false;
            this.SitesDataGrid.AllowUserToResizeRows = false;
            this.SitesDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SitesDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SitesDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SitesDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SitesDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SitesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SiteName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SitesDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.SitesDataGrid.EnableHeadersVisualStyles = false;
            this.SitesDataGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.SitesDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SitesDataGrid.Location = new System.Drawing.Point(9, 16);
            this.SitesDataGrid.MultiSelect = false;
            this.SitesDataGrid.Name = "SitesDataGrid";
            this.SitesDataGrid.ReadOnly = true;
            this.SitesDataGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SitesDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SitesDataGrid.RowHeadersVisible = false;
            this.SitesDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SitesDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SitesDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SitesDataGrid.ShowEditingIcon = false;
            this.SitesDataGrid.Size = new System.Drawing.Size(105, 199);
            this.SitesDataGrid.Style = JHUI.JColorStyle.White;
            this.SitesDataGrid.TabIndex = 0;
            this.SitesDataGrid.Theme = JHUI.JThemeStyle.Dark;
            this.SitesDataGrid.SelectionChanged += new System.EventHandler(this.ListBox1_SelectionChanged);
            // 
            // SiteName
            // 
            this.SiteName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SiteName.HeaderText = "Site Name";
            this.SiteName.Name = "SiteName";
            this.SiteName.ReadOnly = true;
            this.SiteName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // websiteInp
            // 
            this.websiteInp.BorderBottomLineSize = 5;
            this.websiteInp.BorderColor = System.Drawing.Color.Black;
            this.websiteInp.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.websiteInp.CustomButton.Image = null;
            this.websiteInp.CustomButton.Location = new System.Drawing.Point(520, 2);
            this.websiteInp.CustomButton.Name = "";
            this.websiteInp.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.websiteInp.CustomButton.Style = JHUI.JColorStyle.White;
            this.websiteInp.CustomButton.TabIndex = 1;
            this.websiteInp.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.websiteInp.CustomButton.UseSelectable = true;
            this.websiteInp.CustomButton.Visible = false;
            this.websiteInp.DrawBorder = true;
            this.websiteInp.DrawBorderBottomLine = false;
            this.websiteInp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.websiteInp.Lines = new string[0];
            this.websiteInp.Location = new System.Drawing.Point(6, 110);
            this.websiteInp.MaxLength = 32767;
            this.websiteInp.Name = "websiteInp";
            this.websiteInp.PasswordChar = '\0';
            this.websiteInp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.websiteInp.SelectedText = "";
            this.websiteInp.SelectionLength = 0;
            this.websiteInp.SelectionStart = 0;
            this.websiteInp.ShortcutsEnabled = true;
            this.websiteInp.Size = new System.Drawing.Size(538, 20);
            this.websiteInp.Style = JHUI.JColorStyle.White;
            this.websiteInp.TabIndex = 1;
            this.websiteInp.TextWaterMark = "";
            this.websiteInp.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.websiteInp, "Address of the Website you wish you promote.");
            this.websiteInp.UseCustomFont = true;
            this.websiteInp.UseSelectable = true;
            this.websiteInp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.websiteInp.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // secondsDrop
            // 
            this.secondsDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.secondsDrop.CustomDrawButtons = false;
            this.secondsDrop.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.secondsDrop.FontSize = JHUI.JLabelSize.Medium;
            this.secondsDrop.FontWeight = JHUI.JLabelWeight.Light;
            this.secondsDrop.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.secondsDrop.Location = new System.Drawing.Point(202, 154);
            this.secondsDrop.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.secondsDrop.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.secondsDrop.Name = "secondsDrop";
            this.secondsDrop.Size = new System.Drawing.Size(136, 26);
            this.secondsDrop.Style = JHUI.JColorStyle.Blue;
            this.secondsDrop.StyleManager = null;
            this.secondsDrop.TabIndex = 2;
            this.secondsDrop.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.secondsDrop, "Specifiy the length of the visit in seconds.");
            this.secondsDrop.UseAlternateColors = false;
            this.secondsDrop.UseSelectable = true;
            this.secondsDrop.UseStyleColors = false;
            this.secondsDrop.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox1.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.region);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.Referral);
            this.groupBox1.Controls.Add(this.save);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameInp);
            this.groupBox1.Controls.Add(this.secondsDrop);
            this.groupBox1.Controls.Add(this.websiteInp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.DrawBottomLine = false;
            this.groupBox1.DrawShadows = false;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox1.FontSize = JHUI.JLabelSize.Small;
            this.groupBox1.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Location = new System.Drawing.Point(149, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.PaintDefault = false;
            this.groupBox1.Size = new System.Drawing.Size(571, 270);
            this.groupBox1.Style = JHUI.JColorStyle.White;
            this.groupBox1.StyleManager = null;
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            this.groupBox1.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox1.UseStyleColors = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::SurfShark.Properties.Resources.gen_question_b_20;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(550, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 20);
            this.button2.Style = JHUI.JColorStyle.White;
            this.button2.TabIndex = 11;
            this.button2.Theme = JHUI.JThemeStyle.Dark;
            this.button2.UseSelectable = true;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // region
            // 
            this.region.BackColor = System.Drawing.Color.White;
            this.region.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.region.FontSize = JHUI.JComboBoxSize.Small;
            this.region.FormattingEnabled = true;
            this.region.ItemHeight = 19;
            this.region.Items.AddRange(new object[] {
            "Direct / Anonymous",
            "Google",
            "Custom"});
            this.region.Location = new System.Drawing.Point(423, 153);
            this.region.Name = "region";
            this.region.Size = new System.Drawing.Size(121, 25);
            this.region.Style = JHUI.JColorStyle.White;
            this.region.TabIndex = 10;
            this.region.Theme = JHUI.JThemeStyle.Dark;
            this.region.UseSelectable = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DropShadowColor = System.Drawing.Color.Black;
            this.label8.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label8.FontSize = JHUI.JLabelSize.Small;
            this.label8.Location = new System.Drawing.Point(423, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 15);
            this.label8.Style = JHUI.JColorStyle.White;
            this.label8.TabIndex = 9;
            this.label8.Text = "Region Preference:";
            this.label8.Theme = JHUI.JThemeStyle.Dark;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(490, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.Style = JHUI.JColorStyle.White;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Theme = JHUI.JThemeStyle.Dark;
            this.btnDelete.UseSelectable = true;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.DarkOrange;
            this.btnPause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.ForeColor = System.Drawing.Color.White;
            this.btnPause.Location = new System.Drawing.Point(90, 16);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.Style = JHUI.JColorStyle.White;
            this.btnPause.TabIndex = 4;
            this.btnPause.Text = "Pause";
            this.btnPause.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.btnPause, "Pause this site.");
            this.btnPause.UseSelectable = true;
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RoyalBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(9, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.Style = JHUI.JColorStyle.White;
            this.button1.TabIndex = 6;
            this.button1.Text = "Preview";
            this.button1.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.button1, "Preview this site.");
            this.button1.UseSelectable = true;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Referral
            // 
            this.Referral.BackColor = System.Drawing.Color.White;
            this.Referral.CutstomBorderColor = System.Drawing.Color.Transparent;
            this.Referral.FontSize = JHUI.JComboBoxSize.Small;
            this.Referral.FormattingEnabled = true;
            this.Referral.ItemHeight = 19;
            this.Referral.Items.AddRange(new object[] {
            "Direct / Anonymous",
            "Google",
            "Custom"});
            this.Referral.Location = new System.Drawing.Point(6, 154);
            this.Referral.Name = "Referral";
            this.Referral.Size = new System.Drawing.Size(121, 25);
            this.Referral.Style = JHUI.JColorStyle.White;
            this.Referral.TabIndex = 7;
            this.Referral.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.Referral, "Choose the traffic source, this will show up as the origin of the Traffic.\\nYou c" +
        "an leave it blank for Direct/Anonymous visit.");
            this.Referral.UseSelectable = true;
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.DarkViolet;
            this.save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.Color.White;
            this.save.Location = new System.Drawing.Point(490, 16);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.Style = JHUI.JColorStyle.White;
            this.save.TabIndex = 4;
            this.save.Text = "Save";
            this.save.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.save, "Save changes to this site.");
            this.save.UseSelectable = true;
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.Save_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::SurfShark.Properties.Resources.gen_question_b_20;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(133, 156);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(21, 20);
            this.button5.Style = JHUI.JColorStyle.White;
            this.button5.TabIndex = 5;
            this.button5.Theme = JHUI.JThemeStyle.Dark;
            this.button5.UseSelectable = true;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::SurfShark.Properties.Resources.gen_question_b_20;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(344, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 20);
            this.button4.Style = JHUI.JColorStyle.White;
            this.button4.TabIndex = 5;
            this.button4.Theme = JHUI.JThemeStyle.Dark;
            this.button4.UseSelectable = true;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.DropShadowColor = System.Drawing.Color.Black;
            this.label2.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label2.FontSize = JHUI.JLabelSize.Small;
            this.label2.Location = new System.Drawing.Point(202, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.Style = JHUI.JColorStyle.White;
            this.label2.TabIndex = 3;
            this.label2.Text = "Seconds:";
            this.label2.Theme = JHUI.JThemeStyle.Dark;
            // 
            // nameInp
            // 
            this.nameInp.BorderBottomLineSize = 5;
            this.nameInp.BorderColor = System.Drawing.Color.Black;
            this.nameInp.BottomLineOffset = new System.Drawing.Size(3, 3);
            // 
            // 
            // 
            this.nameInp.CustomButton.Image = null;
            this.nameInp.CustomButton.Location = new System.Drawing.Point(520, 2);
            this.nameInp.CustomButton.Name = "";
            this.nameInp.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.nameInp.CustomButton.Style = JHUI.JColorStyle.White;
            this.nameInp.CustomButton.TabIndex = 1;
            this.nameInp.CustomButton.Theme = JHUI.JThemeStyle.Dark;
            this.nameInp.CustomButton.UseSelectable = true;
            this.nameInp.CustomButton.Visible = false;
            this.nameInp.DrawBorder = true;
            this.nameInp.DrawBorderBottomLine = false;
            this.nameInp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.nameInp.Lines = new string[0];
            this.nameInp.Location = new System.Drawing.Point(6, 67);
            this.nameInp.MaxLength = 32767;
            this.nameInp.Name = "nameInp";
            this.nameInp.PasswordChar = '\0';
            this.nameInp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameInp.SelectedText = "";
            this.nameInp.SelectionLength = 0;
            this.nameInp.SelectionStart = 0;
            this.nameInp.ShortcutsEnabled = true;
            this.nameInp.Size = new System.Drawing.Size(538, 20);
            this.nameInp.Style = JHUI.JColorStyle.White;
            this.nameInp.TabIndex = 1;
            this.nameInp.TextWaterMark = "";
            this.nameInp.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.nameInp, "Site name, only you can see this.");
            this.nameInp.UseCustomFont = true;
            this.nameInp.UseSelectable = true;
            this.nameInp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameInp.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.DropShadowColor = System.Drawing.Color.Black;
            this.label3.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label3.FontSize = JHUI.JLabelSize.Small;
            this.label3.Location = new System.Drawing.Point(6, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.Style = JHUI.JColorStyle.White;
            this.label3.TabIndex = 3;
            this.label3.Text = "Referral URL:";
            this.label3.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.DropShadowColor = System.Drawing.Color.Black;
            this.label4.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label4.FontSize = JHUI.JLabelSize.Small;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.Style = JHUI.JColorStyle.White;
            this.label4.TabIndex = 3;
            this.label4.Text = "Website Name:";
            this.label4.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.DropShadowColor = System.Drawing.Color.Black;
            this.label1.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label1.FontSize = JHUI.JLabelSize.Small;
            this.label1.Location = new System.Drawing.Point(6, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.Style = JHUI.JColorStyle.White;
            this.label1.TabIndex = 3;
            this.label1.Text = "Website URL";
            this.label1.Theme = JHUI.JThemeStyle.Dark;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Cornsilk;
            this.btnAdd.Location = new System.Drawing.Point(9, 241);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 23);
            this.btnAdd.Style = JHUI.JColorStyle.White;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add New Site";
            this.btnAdd.Theme = JHUI.JThemeStyle.Dark;
            this.toolTip1.SetToolTip(this.btnAdd, "Add a new url.");
            this.btnAdd.UseSelectable = true;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox2.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox2.Controls.Add(this.SitesDataGrid);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.DrawBottomLine = false;
            this.groupBox2.DrawShadows = false;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox2.FontSize = JHUI.JLabelSize.Small;
            this.groupBox2.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Location = new System.Drawing.Point(23, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.PaintDefault = false;
            this.groupBox2.Size = new System.Drawing.Size(120, 270);
            this.groupBox2.Style = JHUI.JColorStyle.White;
            this.groupBox2.StyleManager = null;
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sites";
            this.groupBox2.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox2.UseStyleColors = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.groupBox3.BorderStyle = JHUI.Controls.JGroupBox.BorderMode.Header;
            this.groupBox3.Controls.Add(this.AlexaRankLabel);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.labelStatus);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.hitsLabel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.DrawBottomLine = false;
            this.groupBox3.DrawShadows = false;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.groupBox3.FontSize = JHUI.JLabelSize.Small;
            this.groupBox3.FontWeight = JHUI.JLabelWeight.Light;
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox3.Location = new System.Drawing.Point(23, 339);
            this.groupBox3.MinimumSize = new System.Drawing.Size(571, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.PaintDefault = false;
            this.groupBox3.Size = new System.Drawing.Size(697, 36);
            this.groupBox3.Style = JHUI.JColorStyle.White;
            this.groupBox3.StyleManager = null;
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistics";
            this.groupBox3.Theme = JHUI.JThemeStyle.Dark;
            this.groupBox3.UseStyleColors = false;
            // 
            // AlexaRankLabel
            // 
            this.AlexaRankLabel.AutoSize = true;
            this.AlexaRankLabel.DropShadowColor = System.Drawing.Color.Black;
            this.AlexaRankLabel.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.AlexaRankLabel.FontSize = JHUI.JLabelSize.Small;
            this.AlexaRankLabel.Location = new System.Drawing.Point(415, 16);
            this.AlexaRankLabel.MinimumSize = new System.Drawing.Size(103, 13);
            this.AlexaRankLabel.Name = "AlexaRankLabel";
            this.AlexaRankLabel.Size = new System.Drawing.Size(13, 15);
            this.AlexaRankLabel.Style = JHUI.JColorStyle.White;
            this.AlexaRankLabel.TabIndex = 4;
            this.AlexaRankLabel.Text = "0";
            this.AlexaRankLabel.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.DropShadowColor = System.Drawing.Color.Black;
            this.label10.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label10.FontSize = JHUI.JLabelSize.Small;
            this.label10.Location = new System.Drawing.Point(351, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 15);
            this.label10.Style = JHUI.JColorStyle.White;
            this.label10.TabIndex = 5;
            this.label10.Text = "Alexa Rank:";
            this.label10.Theme = JHUI.JThemeStyle.Dark;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.DropShadowColor = System.Drawing.Color.Black;
            this.labelStatus.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.labelStatus.FontSize = JHUI.JLabelSize.Small;
            this.labelStatus.Location = new System.Drawing.Point(52, 16);
            this.labelStatus.MinimumSize = new System.Drawing.Size(103, 13);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 15);
            this.labelStatus.Style = JHUI.JColorStyle.White;
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Active";
            this.labelStatus.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.DropShadowColor = System.Drawing.Color.Black;
            this.label6.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label6.FontSize = JHUI.JLabelSize.Small;
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.Style = JHUI.JColorStyle.White;
            this.label6.TabIndex = 3;
            this.label6.Text = "Status:";
            this.label6.Theme = JHUI.JThemeStyle.Dark;
            // 
            // hitsLabel
            // 
            this.hitsLabel.AutoSize = true;
            this.hitsLabel.DropShadowColor = System.Drawing.Color.Black;
            this.hitsLabel.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.hitsLabel.FontSize = JHUI.JLabelSize.Small;
            this.hitsLabel.Location = new System.Drawing.Point(208, 16);
            this.hitsLabel.MinimumSize = new System.Drawing.Size(103, 13);
            this.hitsLabel.Name = "hitsLabel";
            this.hitsLabel.Size = new System.Drawing.Size(13, 15);
            this.hitsLabel.Style = JHUI.JColorStyle.White;
            this.hitsLabel.TabIndex = 3;
            this.hitsLabel.Text = "0";
            this.hitsLabel.Theme = JHUI.JThemeStyle.Dark;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.DropShadowColor = System.Drawing.Color.Black;
            this.label5.DropShadowOffset = new System.Drawing.Size(1, 1);
            this.label5.FontSize = JHUI.JLabelSize.Small;
            this.label5.Location = new System.Drawing.Point(181, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.Style = JHUI.JColorStyle.White;
            this.label5.TabIndex = 3;
            this.label5.Text = "Hits:";
            this.label5.Theme = JHUI.JThemeStyle.Dark;
            // 
            // UrlUtilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(737, 386);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlUtilityForm";
            this.PaddingTop = 0;
            this.PaintTopBorder = false;
            this.Resizable = false;
            this.Text = "Sharky URL Manager";
            this.UseCustomBackColor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UrlUtilityForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SitesDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondsDrop)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private JHUI.Controls.JDataGridView SitesDataGrid;
        private JHUI.Controls.JTextBox websiteInp;
        private JHUI.Controls.JNumericUpDown secondsDrop;
        private JHUI.Controls.JGroupBox groupBox1;
        private JHUI.Controls.JButton btnDelete;
        private JHUI.Controls.JButton btnPause;
        private JHUI.Controls.JButton btnAdd;
        private JHUI.Controls.JLabel label3;
        private JHUI.Controls.JLabel label2;
        private JHUI.Controls.JLabel label4;
        private JHUI.Controls.JLabel label1;
        private JHUI.Controls.JTextBox nameInp;
        private JHUI.Controls.JGroupBox groupBox2;
        private JHUI.Controls.JButton button4;
        private JHUI.Controls.JButton button5;
        private JHUI.Controls.JGroupBox groupBox3;
        private JHUI.Controls.JLabel hitsLabel;
        private JHUI.Controls.JLabel label5;
        private JHUI.Controls.JLabel labelStatus;
        private JHUI.Controls.JLabel label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private JHUI.Controls.JButton save;
        private JHUI.Controls.JButton button1;
        private JHUI.Controls.JComboBox Referral;
        private JHUI.Controls.JButton button2;
        private JHUI.Controls.JComboBox region;
        private JHUI.Controls.JLabel label8;
        private JHUI.Controls.JLabel AlexaRankLabel;
        private JHUI.Controls.JLabel label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteName;
    }
}