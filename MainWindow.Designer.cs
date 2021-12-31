namespace Northstar_Manger
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Arg_Box = new System.Windows.Forms.TextBox();
            this.Start_Client = new MetroSet_UI.Controls.MetroSetButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Brows_Bttn = new MetroSet_UI.Controls.MetroSetButton();
            this.Check_Bttn = new MetroSet_UI.Controls.MetroSetButton();
            this.Install_NS_Button = new MetroSet_UI.Controls.MetroSetButton();
            this.Version_TextBox = new System.Windows.Forms.TextBox();
            this.Northstar_Version_label = new System.Windows.Forms.Label();
            this.Install_Textbox = new System.Windows.Forms.TextBox();
            this.Install_Location_Label = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.metroSetButton3 = new MetroSet_UI.Controls.MetroSetButton();
            this.metroSetButton2 = new MetroSet_UI.Controls.MetroSetButton();
            this.Log_Box = new MetroSet_UI.Controls.MetroSetRichTextBox();
            this.Log_Label = new System.Windows.Forms.Label();
            this.Main_Window = new MetroSet_UI.Controls.MetroSetTabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.metroSetPanel1 = new MetroSet_UI.Controls.MetroSetPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.metroSetPanel4 = new MetroSet_UI.Controls.MetroSetPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.Browse_Local = new MetroSet_UI.Controls.MetroSetButton();
            this.local_box = new System.Windows.Forms.TextBox();
            this.Download_Bt = new MetroSet_UI.Controls.MetroSetButton();
            this.Url_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.metroSetPanel2 = new MetroSet_UI.Controls.MetroSetPanel();
            this.Make_Inactive = new MetroSet_UI.Controls.MetroSetButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Make_Active = new MetroSet_UI.Controls.MetroSetButton();
            this.Active_List = new System.Windows.Forms.ListBox();
            this.Inactive_List = new System.Windows.Forms.ListBox();
            this.Apply_Btn_Mods = new MetroSet_UI.Controls.MetroSetButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.metroSetPanel3 = new MetroSet_UI.Controls.MetroSetPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.metroSetButton5 = new MetroSet_UI.Controls.MetroSetButton();
            this.metroSetTile1 = new MetroSet_UI.Controls.MetroSetTile();
            this.metroSetButton4 = new MetroSet_UI.Controls.MetroSetButton();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Main_Window.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.metroSetPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.metroSetPanel4.SuspendLayout();
            this.metroSetPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.metroSetPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Arg_Box);
            this.panel1.Controls.Add(this.Start_Client);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.Brows_Bttn);
            this.panel1.Controls.Add(this.Check_Bttn);
            this.panel1.Controls.Add(this.Install_NS_Button);
            this.panel1.Controls.Add(this.Version_TextBox);
            this.panel1.Controls.Add(this.Northstar_Version_label);
            this.panel1.Controls.Add(this.Install_Textbox);
            this.panel1.Controls.Add(this.Install_Location_Label);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 579);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(160, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "Startup Arguments";
            // 
            // Arg_Box
            // 
            this.Arg_Box.Location = new System.Drawing.Point(4, 369);
            this.Arg_Box.Name = "Arg_Box";
            this.Arg_Box.Size = new System.Drawing.Size(420, 23);
            this.Arg_Box.TabIndex = 21;
            this.Arg_Box.Enter += new System.EventHandler(this.Arg_Box_Enter);
            this.Arg_Box.Leave += new System.EventHandler(this.Arg_Box_Leave);
            // 
            // Start_Client
            // 
            this.Start_Client.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Start_Client.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Start_Client.DisabledForeColor = System.Drawing.Color.Gray;
            this.Start_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Start_Client.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Start_Client.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Start_Client.HoverTextColor = System.Drawing.Color.White;
            this.Start_Client.IsDerivedStyle = true;
            this.Start_Client.Location = new System.Drawing.Point(4, 412);
            this.Start_Client.Name = "Start_Client";
            this.Start_Client.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Start_Client.NormalColor = System.Drawing.Color.DarkCyan;
            this.Start_Client.NormalTextColor = System.Drawing.Color.White;
            this.Start_Client.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Start_Client.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Start_Client.PressTextColor = System.Drawing.Color.White;
            this.Start_Client.Size = new System.Drawing.Size(420, 50);
            this.Start_Client.Style = MetroSet_UI.Enums.Style.Custom;
            this.Start_Client.StyleManager = null;
            this.Start_Client.TabIndex = 20;
            this.Start_Client.Text = "Start Northstar Client";
            this.Start_Client.ThemeAuthor = "Narwin";
            this.Start_Client.ThemeName = "MetroLite";
            this.Start_Client.Click += new System.EventHandler(this.Start_Client_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(90, 120);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(257, 21);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "DO NOT Overwrite \"ns_startup_args.txt\"";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Brows_Bttn
            // 
            this.Brows_Bttn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Brows_Bttn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Brows_Bttn.DisabledForeColor = System.Drawing.Color.Gray;
            this.Brows_Bttn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Brows_Bttn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Brows_Bttn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Brows_Bttn.HoverTextColor = System.Drawing.Color.White;
            this.Brows_Bttn.IsDerivedStyle = true;
            this.Brows_Bttn.Location = new System.Drawing.Point(367, 24);
            this.Brows_Bttn.Name = "Brows_Bttn";
            this.Brows_Bttn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Brows_Bttn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Brows_Bttn.NormalTextColor = System.Drawing.Color.White;
            this.Brows_Bttn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Brows_Bttn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Brows_Bttn.PressTextColor = System.Drawing.Color.White;
            this.Brows_Bttn.Size = new System.Drawing.Size(57, 23);
            this.Brows_Bttn.Style = MetroSet_UI.Enums.Style.Light;
            this.Brows_Bttn.StyleManager = null;
            this.Brows_Bttn.TabIndex = 11;
            this.Brows_Bttn.Text = "Browse";
            this.Brows_Bttn.ThemeAuthor = "Narwin";
            this.Brows_Bttn.ThemeName = "MetroLite";
            this.Brows_Bttn.Click += new System.EventHandler(this.Brows_Bttn_Click);
            // 
            // Check_Bttn
            // 
            this.Check_Bttn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Check_Bttn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Check_Bttn.DisabledForeColor = System.Drawing.Color.Gray;
            this.Check_Bttn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Check_Bttn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Check_Bttn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Check_Bttn.HoverTextColor = System.Drawing.Color.White;
            this.Check_Bttn.IsDerivedStyle = true;
            this.Check_Bttn.Location = new System.Drawing.Point(367, 73);
            this.Check_Bttn.Name = "Check_Bttn";
            this.Check_Bttn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Check_Bttn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Check_Bttn.NormalTextColor = System.Drawing.Color.White;
            this.Check_Bttn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Check_Bttn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Check_Bttn.PressTextColor = System.Drawing.Color.White;
            this.Check_Bttn.Size = new System.Drawing.Size(57, 23);
            this.Check_Bttn.Style = MetroSet_UI.Enums.Style.Light;
            this.Check_Bttn.StyleManager = null;
            this.Check_Bttn.TabIndex = 10;
            this.Check_Bttn.Text = "Check";
            this.Check_Bttn.ThemeAuthor = "Narwin";
            this.Check_Bttn.ThemeName = "MetroLite";
            this.Check_Bttn.Click += new System.EventHandler(this.Check_Bttn_Click);
            // 
            // Install_NS_Button
            // 
            this.Install_NS_Button.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Install_NS_Button.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Install_NS_Button.DisabledForeColor = System.Drawing.Color.Gray;
            this.Install_NS_Button.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Install_NS_Button.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Install_NS_Button.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Install_NS_Button.HoverTextColor = System.Drawing.Color.White;
            this.Install_NS_Button.IsDerivedStyle = true;
            this.Install_NS_Button.Location = new System.Drawing.Point(4, 166);
            this.Install_NS_Button.Name = "Install_NS_Button";
            this.Install_NS_Button.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Install_NS_Button.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Install_NS_Button.NormalTextColor = System.Drawing.Color.White;
            this.Install_NS_Button.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Install_NS_Button.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Install_NS_Button.PressTextColor = System.Drawing.Color.White;
            this.Install_NS_Button.Size = new System.Drawing.Size(420, 47);
            this.Install_NS_Button.Style = MetroSet_UI.Enums.Style.Light;
            this.Install_NS_Button.StyleManager = null;
            this.Install_NS_Button.TabIndex = 9;
            this.Install_NS_Button.Text = "Install NorthStar";
            this.Install_NS_Button.ThemeAuthor = "Narwin";
            this.Install_NS_Button.ThemeName = "MetroLite";
            this.Install_NS_Button.Click += new System.EventHandler(this.Install_NS_Button_Click_1);
            // 
            // Version_TextBox
            // 
            this.Version_TextBox.BackColor = System.Drawing.Color.White;
            this.Version_TextBox.ForeColor = System.Drawing.Color.Black;
            this.Version_TextBox.Location = new System.Drawing.Point(3, 73);
            this.Version_TextBox.Name = "Version_TextBox";
            this.Version_TextBox.ReadOnly = true;
            this.Version_TextBox.Size = new System.Drawing.Size(358, 23);
            this.Version_TextBox.TabIndex = 5;
            // 
            // Northstar_Version_label
            // 
            this.Northstar_Version_label.AutoSize = true;
            this.Northstar_Version_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Northstar_Version_label.Location = new System.Drawing.Point(167, 53);
            this.Northstar_Version_label.Name = "Northstar_Version_label";
            this.Northstar_Version_label.Size = new System.Drawing.Size(98, 15);
            this.Northstar_Version_label.TabIndex = 4;
            this.Northstar_Version_label.Text = "Northstar Version";
            // 
            // Install_Textbox
            // 
            this.Install_Textbox.Location = new System.Drawing.Point(3, 24);
            this.Install_Textbox.Name = "Install_Textbox";
            this.Install_Textbox.Size = new System.Drawing.Size(358, 23);
            this.Install_Textbox.TabIndex = 2;
            // 
            // Install_Location_Label
            // 
            this.Install_Location_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Install_Location_Label.AutoSize = true;
            this.Install_Location_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Install_Location_Label.Location = new System.Drawing.Point(150, 6);
            this.Install_Location_Label.Name = "Install_Location_Label";
            this.Install_Location_Label.Size = new System.Drawing.Size(141, 15);
            this.Install_Location_Label.TabIndex = 0;
            this.Install_Location_Label.Text = "Titanfall 2 Install Location";
            this.Install_Location_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Install_Location_Label.Click += new System.EventHandler(this.Install_Location_Label_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.metroSetButton3);
            this.panel4.Controls.Add(this.metroSetButton2);
            this.panel4.Controls.Add(this.Log_Box);
            this.panel4.Controls.Add(this.Log_Label);
            this.panel4.Location = new System.Drawing.Point(437, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(534, 579);
            this.panel4.TabIndex = 3;
            // 
            // metroSetButton3
            // 
            this.metroSetButton3.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton3.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton3.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroSetButton3.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton3.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton3.IsDerivedStyle = true;
            this.metroSetButton3.Location = new System.Drawing.Point(274, 539);
            this.metroSetButton3.Name = "metroSetButton3";
            this.metroSetButton3.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton3.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton3.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton3.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton3.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton3.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton3.Size = new System.Drawing.Size(254, 27);
            this.metroSetButton3.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetButton3.StyleManager = null;
            this.metroSetButton3.TabIndex = 15;
            this.metroSetButton3.Text = "Clear Log";
            this.metroSetButton3.ThemeAuthor = "Narwin";
            this.metroSetButton3.ThemeName = "MetroLite";
            this.metroSetButton3.Click += new System.EventHandler(this.metroSetButton3_Click);
            // 
            // metroSetButton2
            // 
            this.metroSetButton2.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton2.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton2.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroSetButton2.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton2.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton2.IsDerivedStyle = true;
            this.metroSetButton2.Location = new System.Drawing.Point(3, 539);
            this.metroSetButton2.Name = "metroSetButton2";
            this.metroSetButton2.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton2.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton2.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton2.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton2.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton2.Size = new System.Drawing.Size(265, 27);
            this.metroSetButton2.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetButton2.StyleManager = null;
            this.metroSetButton2.TabIndex = 14;
            this.metroSetButton2.Text = "Save Log";
            this.metroSetButton2.ThemeAuthor = "Narwin";
            this.metroSetButton2.ThemeName = "MetroLite";
            this.metroSetButton2.Click += new System.EventHandler(this.metroSetButton2_Click);
            // 
            // Log_Box
            // 
            this.Log_Box.AutoWordSelection = false;
            this.Log_Box.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.Log_Box.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Log_Box.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Log_Box.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Log_Box.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Log_Box.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.Log_Box.IsDerivedStyle = true;
            this.Log_Box.Lines = null;
            this.Log_Box.Location = new System.Drawing.Point(3, 24);
            this.Log_Box.MaxLength = 32767;
            this.Log_Box.Name = "Log_Box";
            this.Log_Box.ReadOnly = true;
            this.Log_Box.Size = new System.Drawing.Size(526, 509);
            this.Log_Box.Style = MetroSet_UI.Enums.Style.Dark;
            this.Log_Box.StyleManager = null;
            this.Log_Box.TabIndex = 9;
            this.Log_Box.ThemeAuthor = "Narwin";
            this.Log_Box.ThemeName = "MetroDark";
            this.Log_Box.WordWrap = true;
            // 
            // Log_Label
            // 
            this.Log_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_Label.AutoSize = true;
            this.Log_Label.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Log_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Log_Label.Location = new System.Drawing.Point(232, 4);
            this.Log_Label.Name = "Log_Label";
            this.Log_Label.Size = new System.Drawing.Size(67, 17);
            this.Log_Label.TabIndex = 0;
            this.Log_Label.Text = "Install Log";
            this.Log_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main_Window
            // 
            this.Main_Window.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.Main_Window.AnimateTime = 200;
            this.Main_Window.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Main_Window.Controls.Add(this.tabPage1);
            this.Main_Window.Controls.Add(this.tabPage2);
            this.Main_Window.Controls.Add(this.tabPage3);
            this.Main_Window.Controls.Add(this.tabPage4);
            this.Main_Window.HotTrack = true;
            this.Main_Window.IsDerivedStyle = true;
            this.Main_Window.ItemSize = new System.Drawing.Size(100, 38);
            this.Main_Window.Location = new System.Drawing.Point(0, 0);
            this.Main_Window.Name = "Main_Window";
            this.Main_Window.SelectedIndex = 0;
            this.Main_Window.SelectedTextColor = System.Drawing.Color.White;
            this.Main_Window.Size = new System.Drawing.Size(982, 631);
            this.Main_Window.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.Main_Window.Speed = 350;
            this.Main_Window.Style = MetroSet_UI.Enums.Style.Dark;
            this.Main_Window.StyleManager = null;
            this.Main_Window.TabIndex = 2;
            this.Main_Window.ThemeAuthor = "Narwin";
            this.Main_Window.ThemeName = "MetroDark";
            this.Main_Window.UnselectedTextColor = System.Drawing.Color.Gray;
            this.Main_Window.UseAnimation = false;
            this.Main_Window.SelectedIndexChanged += new System.EventHandler(this.metroSetTabControl1_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage4.Controls.Add(this.metroSetPanel1);
            this.tabPage4.Location = new System.Drawing.Point(4, 42);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(974, 585);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            // 
            // metroSetPanel1
            // 
            this.metroSetPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.metroSetPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.metroSetPanel1.BorderThickness = 1;
            this.metroSetPanel1.Controls.Add(this.richTextBox1);
            this.metroSetPanel1.IsDerivedStyle = true;
            this.metroSetPanel1.Location = new System.Drawing.Point(-4, 3);
            this.metroSetPanel1.Name = "metroSetPanel1";
            this.metroSetPanel1.Size = new System.Drawing.Size(978, 582);
            this.metroSetPanel1.Style = MetroSet_UI.Enums.Style.Custom;
            this.metroSetPanel1.StyleManager = null;
            this.metroSetPanel1.TabIndex = 0;
            this.metroSetPanel1.ThemeAuthor = "Narwin";
            this.metroSetPanel1.ThemeName = "MetroLite";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(4, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(978, 583);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 42);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(974, 585);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Install";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage2.Controls.Add(this.metroSetPanel4);
            this.tabPage2.Controls.Add(this.metroSetPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(974, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mods";
            // 
            // metroSetPanel4
            // 
            this.metroSetPanel4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.metroSetPanel4.BorderColor = System.Drawing.Color.DimGray;
            this.metroSetPanel4.BorderThickness = 1;
            this.metroSetPanel4.Controls.Add(this.label7);
            this.metroSetPanel4.Controls.Add(this.Browse_Local);
            this.metroSetPanel4.Controls.Add(this.local_box);
            this.metroSetPanel4.Controls.Add(this.Download_Bt);
            this.metroSetPanel4.Controls.Add(this.Url_box);
            this.metroSetPanel4.Controls.Add(this.label1);
            this.metroSetPanel4.IsDerivedStyle = true;
            this.metroSetPanel4.Location = new System.Drawing.Point(0, 0);
            this.metroSetPanel4.Name = "metroSetPanel4";
            this.metroSetPanel4.Size = new System.Drawing.Size(974, 129);
            this.metroSetPanel4.Style = MetroSet_UI.Enums.Style.Custom;
            this.metroSetPanel4.StyleManager = null;
            this.metroSetPanel4.TabIndex = 2;
            this.metroSetPanel4.ThemeAuthor = "Narwin";
            this.metroSetPanel4.ThemeName = "MetroLite";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(572, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Install New Mod From Local Zip";
            // 
            // Browse_Local
            // 
            this.Browse_Local.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Browse_Local.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Browse_Local.DisabledForeColor = System.Drawing.Color.Gray;
            this.Browse_Local.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Browse_Local.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Browse_Local.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Browse_Local.HoverTextColor = System.Drawing.Color.White;
            this.Browse_Local.IsDerivedStyle = true;
            this.Browse_Local.Location = new System.Drawing.Point(480, 66);
            this.Browse_Local.Name = "Browse_Local";
            this.Browse_Local.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Browse_Local.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Browse_Local.NormalTextColor = System.Drawing.Color.White;
            this.Browse_Local.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Browse_Local.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Browse_Local.PressTextColor = System.Drawing.Color.White;
            this.Browse_Local.Size = new System.Drawing.Size(371, 27);
            this.Browse_Local.Style = MetroSet_UI.Enums.Style.Light;
            this.Browse_Local.StyleManager = null;
            this.Browse_Local.TabIndex = 4;
            this.Browse_Local.Text = "Browse";
            this.Browse_Local.ThemeAuthor = "Narwin";
            this.Browse_Local.ThemeName = "MetroLite";
            this.Browse_Local.Click += new System.EventHandler(this.Browse_Local_Click);
            // 
            // local_box
            // 
            this.local_box.BackColor = System.Drawing.Color.Gainsboro;
            this.local_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.local_box.Location = new System.Drawing.Point(480, 37);
            this.local_box.Name = "local_box";
            this.local_box.ReadOnly = true;
            this.local_box.Size = new System.Drawing.Size(373, 23);
            this.local_box.TabIndex = 3;
            // 
            // Download_Bt
            // 
            this.Download_Bt.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Download_Bt.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Download_Bt.DisabledForeColor = System.Drawing.Color.Gray;
            this.Download_Bt.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Download_Bt.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Download_Bt.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Download_Bt.HoverTextColor = System.Drawing.Color.White;
            this.Download_Bt.IsDerivedStyle = true;
            this.Download_Bt.Location = new System.Drawing.Point(101, 66);
            this.Download_Bt.Name = "Download_Bt";
            this.Download_Bt.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Download_Bt.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Download_Bt.NormalTextColor = System.Drawing.Color.White;
            this.Download_Bt.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Download_Bt.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Download_Bt.PressTextColor = System.Drawing.Color.White;
            this.Download_Bt.Size = new System.Drawing.Size(371, 27);
            this.Download_Bt.Style = MetroSet_UI.Enums.Style.Light;
            this.Download_Bt.StyleManager = null;
            this.Download_Bt.TabIndex = 2;
            this.Download_Bt.Text = "Download";
            this.Download_Bt.ThemeAuthor = "Narwin";
            this.Download_Bt.ThemeName = "MetroLite";
            this.Download_Bt.Click += new System.EventHandler(this.metroSetButton1_Click);
            // 
            // Url_box
            // 
            this.Url_box.BackColor = System.Drawing.Color.White;
            this.Url_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Url_box.Location = new System.Drawing.Point(101, 37);
            this.Url_box.Name = "Url_box";
            this.Url_box.Size = new System.Drawing.Size(371, 23);
            this.Url_box.TabIndex = 0;
            this.Url_box.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(191, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download New Mod From URL";
            // 
            // metroSetPanel2
            // 
            this.metroSetPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.metroSetPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.metroSetPanel2.BorderThickness = 1;
            this.metroSetPanel2.Controls.Add(this.Make_Inactive);
            this.metroSetPanel2.Controls.Add(this.label6);
            this.metroSetPanel2.Controls.Add(this.label5);
            this.metroSetPanel2.Controls.Add(this.Make_Active);
            this.metroSetPanel2.Controls.Add(this.Active_List);
            this.metroSetPanel2.Controls.Add(this.Inactive_List);
            this.metroSetPanel2.Controls.Add(this.Apply_Btn_Mods);
            this.metroSetPanel2.Controls.Add(this.label2);
            this.metroSetPanel2.IsDerivedStyle = true;
            this.metroSetPanel2.Location = new System.Drawing.Point(0, 129);
            this.metroSetPanel2.Name = "metroSetPanel2";
            this.metroSetPanel2.Size = new System.Drawing.Size(974, 456);
            this.metroSetPanel2.Style = MetroSet_UI.Enums.Style.Custom;
            this.metroSetPanel2.StyleManager = null;
            this.metroSetPanel2.TabIndex = 1;
            this.metroSetPanel2.ThemeAuthor = "Narwin";
            this.metroSetPanel2.ThemeName = "MetroDark";
            // 
            // Make_Inactive
            // 
            this.Make_Inactive.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Inactive.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Inactive.DisabledForeColor = System.Drawing.Color.Gray;
            this.Make_Inactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Make_Inactive.ForeColor = System.Drawing.Color.Black;
            this.Make_Inactive.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Make_Inactive.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Make_Inactive.HoverTextColor = System.Drawing.Color.White;
            this.Make_Inactive.IsDerivedStyle = true;
            this.Make_Inactive.Location = new System.Drawing.Point(436, 138);
            this.Make_Inactive.Name = "Make_Inactive";
            this.Make_Inactive.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Inactive.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Inactive.NormalTextColor = System.Drawing.Color.White;
            this.Make_Inactive.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Make_Inactive.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Make_Inactive.PressTextColor = System.Drawing.Color.White;
            this.Make_Inactive.Size = new System.Drawing.Size(85, 39);
            this.Make_Inactive.Style = MetroSet_UI.Enums.Style.Dark;
            this.Make_Inactive.StyleManager = null;
            this.Make_Inactive.TabIndex = 10;
            this.Make_Inactive.Text = "<<";
            this.Make_Inactive.ThemeAuthor = "Narwin";
            this.Make_Inactive.ThemeName = "MetroDark";
            this.Make_Inactive.Click += new System.EventHandler(this.Make_Inactive_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(731, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "ACTIVE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "INACTIVE";
            // 
            // Make_Active
            // 
            this.Make_Active.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Active.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Active.DisabledForeColor = System.Drawing.Color.Gray;
            this.Make_Active.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Make_Active.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Make_Active.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Make_Active.HoverTextColor = System.Drawing.Color.White;
            this.Make_Active.IsDerivedStyle = true;
            this.Make_Active.Location = new System.Drawing.Point(436, 211);
            this.Make_Active.Name = "Make_Active";
            this.Make_Active.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Active.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Make_Active.NormalTextColor = System.Drawing.Color.White;
            this.Make_Active.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Make_Active.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Make_Active.PressTextColor = System.Drawing.Color.White;
            this.Make_Active.Size = new System.Drawing.Size(85, 39);
            this.Make_Active.Style = MetroSet_UI.Enums.Style.Dark;
            this.Make_Active.StyleManager = null;
            this.Make_Active.TabIndex = 7;
            this.Make_Active.Text = ">>";
            this.Make_Active.ThemeAuthor = "Narwin";
            this.Make_Active.ThemeName = "MetroDark";
            this.Make_Active.Click += new System.EventHandler(this.Make_Active_Click);
            // 
            // Active_List
            // 
            this.Active_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Active_List.ForeColor = System.Drawing.SystemColors.Window;
            this.Active_List.FormattingEnabled = true;
            this.Active_List.ItemHeight = 15;
            this.Active_List.Location = new System.Drawing.Point(549, 73);
            this.Active_List.Name = "Active_List";
            this.Active_List.Size = new System.Drawing.Size(422, 304);
            this.Active_List.TabIndex = 6;
            // 
            // Inactive_List
            // 
            this.Inactive_List.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Inactive_List.ForeColor = System.Drawing.SystemColors.Window;
            this.Inactive_List.FormattingEnabled = true;
            this.Inactive_List.ItemHeight = 15;
            this.Inactive_List.Location = new System.Drawing.Point(5, 73);
            this.Inactive_List.Name = "Inactive_List";
            this.Inactive_List.Size = new System.Drawing.Size(405, 304);
            this.Inactive_List.TabIndex = 5;
            // 
            // Apply_Btn_Mods
            // 
            this.Apply_Btn_Mods.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Apply_Btn_Mods.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Apply_Btn_Mods.DisabledForeColor = System.Drawing.Color.Gray;
            this.Apply_Btn_Mods.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Apply_Btn_Mods.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Apply_Btn_Mods.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Apply_Btn_Mods.HoverTextColor = System.Drawing.Color.White;
            this.Apply_Btn_Mods.IsDerivedStyle = true;
            this.Apply_Btn_Mods.Location = new System.Drawing.Point(247, 406);
            this.Apply_Btn_Mods.Name = "Apply_Btn_Mods";
            this.Apply_Btn_Mods.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Apply_Btn_Mods.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Apply_Btn_Mods.NormalTextColor = System.Drawing.Color.White;
            this.Apply_Btn_Mods.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Apply_Btn_Mods.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.Apply_Btn_Mods.PressTextColor = System.Drawing.Color.White;
            this.Apply_Btn_Mods.Size = new System.Drawing.Size(463, 32);
            this.Apply_Btn_Mods.Style = MetroSet_UI.Enums.Style.Light;
            this.Apply_Btn_Mods.StyleManager = null;
            this.Apply_Btn_Mods.TabIndex = 4;
            this.Apply_Btn_Mods.Text = "Apply";
            this.Apply_Btn_Mods.ThemeAuthor = "Narwin";
            this.Apply_Btn_Mods.ThemeName = "MetroLite";
            this.Apply_Btn_Mods.Click += new System.EventHandler(this.Apply_Btn_Mods_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(453, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "MODS";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.metroSetPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 42);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(974, 585);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Updates";
            // 
            // metroSetPanel3
            // 
            this.metroSetPanel3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.metroSetPanel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.metroSetPanel3.BorderThickness = 1;
            this.metroSetPanel3.Controls.Add(this.label3);
            this.metroSetPanel3.Controls.Add(this.metroSetButton5);
            this.metroSetPanel3.Controls.Add(this.metroSetTile1);
            this.metroSetPanel3.Controls.Add(this.metroSetButton4);
            this.metroSetPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroSetPanel3.IsDerivedStyle = true;
            this.metroSetPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroSetPanel3.Name = "metroSetPanel3";
            this.metroSetPanel3.Size = new System.Drawing.Size(974, 585);
            this.metroSetPanel3.Style = MetroSet_UI.Enums.Style.Custom;
            this.metroSetPanel3.StyleManager = null;
            this.metroSetPanel3.TabIndex = 0;
            this.metroSetPanel3.ThemeAuthor = "Narwin";
            this.metroSetPanel3.ThemeName = "MetroDark";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(427, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Updates";
            // 
            // metroSetButton5
            // 
            this.metroSetButton5.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton5.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton5.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroSetButton5.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton5.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton5.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton5.IsDerivedStyle = true;
            this.metroSetButton5.Location = new System.Drawing.Point(470, 463);
            this.metroSetButton5.Name = "metroSetButton5";
            this.metroSetButton5.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton5.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton5.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton5.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton5.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton5.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton5.Size = new System.Drawing.Size(191, 45);
            this.metroSetButton5.Style = MetroSet_UI.Enums.Style.Dark;
            this.metroSetButton5.StyleManager = null;
            this.metroSetButton5.TabIndex = 2;
            this.metroSetButton5.Text = "Configure Updates";
            this.metroSetButton5.ThemeAuthor = "Narwin";
            this.metroSetButton5.ThemeName = "MetroDark";
            this.metroSetButton5.Click += new System.EventHandler(this.metroSetButton5_Click);
            // 
            // metroSetTile1
            // 
            this.metroSetTile1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.metroSetTile1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.metroSetTile1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.metroSetTile1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroSetTile1.ForeColor = System.Drawing.Color.Transparent;
            this.metroSetTile1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.metroSetTile1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetTile1.HoverTextColor = System.Drawing.Color.White;
            this.metroSetTile1.IsDerivedStyle = true;
            this.metroSetTile1.Location = new System.Drawing.Point(261, 57);
            this.metroSetTile1.Name = "metroSetTile1";
            this.metroSetTile1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetTile1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetTile1.NormalTextColor = System.Drawing.Color.White;
            this.metroSetTile1.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetTile1.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetTile1.PressTextColor = System.Drawing.Color.White;
            this.metroSetTile1.Size = new System.Drawing.Size(400, 400);
            this.metroSetTile1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetTile1.StyleManager = null;
            this.metroSetTile1.TabIndex = 1;
            this.metroSetTile1.ThemeAuthor = "Narwin";
            this.metroSetTile1.ThemeName = "MetroLite";
            this.metroSetTile1.TileAlign = MetroSet_UI.Enums.TileAlign.Topleft;
            this.metroSetTile1.Click += new System.EventHandler(this.metroSetTile1_Click);
            // 
            // metroSetButton4
            // 
            this.metroSetButton4.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton4.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton4.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroSetButton4.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton4.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton4.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton4.IsDerivedStyle = true;
            this.metroSetButton4.Location = new System.Drawing.Point(261, 463);
            this.metroSetButton4.Name = "metroSetButton4";
            this.metroSetButton4.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton4.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton4.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton4.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton4.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton4.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton4.Size = new System.Drawing.Size(203, 45);
            this.metroSetButton4.Style = MetroSet_UI.Enums.Style.Dark;
            this.metroSetButton4.StyleManager = null;
            this.metroSetButton4.TabIndex = 0;
            this.metroSetButton4.Text = "Check for Updates";
            this.metroSetButton4.ThemeAuthor = "Narwin";
            this.metroSetButton4.ThemeName = "MetroDark";
            this.metroSetButton4.Click += new System.EventHandler(this.metroSetButton4_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(982, 631);
            this.Controls.Add(this.Main_Window);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "NorthStar Mod Manager Version 1.0.7";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Main_Window.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.metroSetPanel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.metroSetPanel4.ResumeLayout(false);
            this.metroSetPanel4.PerformLayout();
            this.metroSetPanel2.ResumeLayout(false);
            this.metroSetPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.metroSetPanel3.ResumeLayout(false);
            this.metroSetPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label Install_Location_Label;
        private Panel panel4;
        private TextBox Version_TextBox;
        private Label Northstar_Version_label;
        private TextBox Install_Textbox;
        private Label Log_Label;
        private MetroSet_UI.Controls.MetroSetTabControl Main_Window;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MetroSet_UI.Controls.MetroSetRichTextBox Log_Box;
        private MetroSet_UI.Controls.MetroSetButton Install_NS_Button;
        private MetroSet_UI.Controls.MetroSetButton Brows_Bttn;
        private MetroSet_UI.Controls.MetroSetButton Check_Bttn;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel2;
        private MetroSet_UI.Controls.MetroSetButton Download_Bt;
        private Label label1;
        private TextBox Url_box;
        private Label label2;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton3;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton2;
        private TabPage tabPage3;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel3;
        private MetroSet_UI.Controls.MetroSetTile metroSetTile1;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton4;
        private Label label3;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton5;
        private CheckBox checkBox1;
        private Label label4;
        private TextBox Arg_Box;
        private MetroSet_UI.Controls.MetroSetButton Start_Client;
        private MetroSet_UI.Controls.MetroSetButton Apply_Btn_Mods;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel4;
        private ListBox Inactive_List;
        private MetroSet_UI.Controls.MetroSetButton Make_Inactive;
        private Label label6;
        private Label label5;
        private MetroSet_UI.Controls.MetroSetButton Make_Active;
        private ListBox Active_List;
        private Label label7;
        private MetroSet_UI.Controls.MetroSetButton Browse_Local;
        private TextBox local_box;
        private TabPage tabPage4;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel1;
        private RichTextBox richTextBox1;
    }
}