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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.metroSetPanel2 = new MetroSet_UI.Controls.MetroSetPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.metroSetPanel1 = new MetroSet_UI.Controls.MetroSetPanel();
            this.metroSetButton1 = new MetroSet_UI.Controls.MetroSetButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.metroSetPanel3 = new MetroSet_UI.Controls.MetroSetPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.metroSetButton5 = new MetroSet_UI.Controls.MetroSetButton();
            this.metroSetTile1 = new MetroSet_UI.Controls.MetroSetTile();
            this.metroSetButton4 = new MetroSet_UI.Controls.MetroSetButton();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Main_Window.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.metroSetPanel2.SuspendLayout();
            this.metroSetPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.metroSetPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox2);
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
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox2.Location = new System.Drawing.Point(150, 123);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(140, 21);
            this.checkBox2.TabIndex = 19;
            this.checkBox2.Text = "Toggle Deep Check";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(88, 164);
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
            this.Install_NS_Button.Location = new System.Drawing.Point(4, 204);
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
            // tabPage1
            // 
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
            this.tabPage2.Controls.Add(this.metroSetPanel2);
            this.tabPage2.Controls.Add(this.metroSetPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(974, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mods";
            // 
            // metroSetPanel2
            // 
            this.metroSetPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.metroSetPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.metroSetPanel2.BorderThickness = 1;
            this.metroSetPanel2.Controls.Add(this.label2);
            this.metroSetPanel2.Controls.Add(this.checkedListBox1);
            this.metroSetPanel2.IsDerivedStyle = true;
            this.metroSetPanel2.Location = new System.Drawing.Point(477, 3);
            this.metroSetPanel2.Name = "metroSetPanel2";
            this.metroSetPanel2.Size = new System.Drawing.Size(494, 579);
            this.metroSetPanel2.Style = MetroSet_UI.Enums.Style.Custom;
            this.metroSetPanel2.StyleManager = null;
            this.metroSetPanel2.TabIndex = 1;
            this.metroSetPanel2.ThemeAuthor = "Narwin";
            this.metroSetPanel2.ThemeName = "MetroDark";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(226, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "MODS";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.ForeColor = System.Drawing.Color.White;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(11, 47);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(472, 468);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged_1);
            // 
            // metroSetPanel1
            // 
            this.metroSetPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.metroSetPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.metroSetPanel1.BorderThickness = 1;
            this.metroSetPanel1.Controls.Add(this.metroSetButton1);
            this.metroSetPanel1.Controls.Add(this.label1);
            this.metroSetPanel1.Controls.Add(this.textBox1);
            this.metroSetPanel1.IsDerivedStyle = true;
            this.metroSetPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroSetPanel1.Name = "metroSetPanel1";
            this.metroSetPanel1.Size = new System.Drawing.Size(476, 579);
            this.metroSetPanel1.Style = MetroSet_UI.Enums.Style.Custom;
            this.metroSetPanel1.StyleManager = null;
            this.metroSetPanel1.TabIndex = 0;
            this.metroSetPanel1.ThemeAuthor = "Narwin";
            this.metroSetPanel1.ThemeName = "MetroDark";
            // 
            // metroSetButton1
            // 
            this.metroSetButton1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroSetButton1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton1.IsDerivedStyle = true;
            this.metroSetButton1.Location = new System.Drawing.Point(5, 66);
            this.metroSetButton1.Name = "metroSetButton1";
            this.metroSetButton1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton1.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton1.Size = new System.Drawing.Size(461, 27);
            this.metroSetButton1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetButton1.StyleManager = null;
            this.metroSetButton1.TabIndex = 2;
            this.metroSetButton1.Text = "Download";
            this.metroSetButton1.ThemeAuthor = "Narwin";
            this.metroSetButton1.ThemeName = "MetroLite";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(145, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download New Mod From URL";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(463, 23);
            this.textBox1.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(982, 631);
            this.Controls.Add(this.Main_Window);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "NorthStar Mod Launcher Version 1.0.7";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Main_Window.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.metroSetPanel2.ResumeLayout(false);
            this.metroSetPanel2.PerformLayout();
            this.metroSetPanel1.ResumeLayout(false);
            this.metroSetPanel1.PerformLayout();
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
        private CheckedListBox checkedListBox1;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel1;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton3;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton2;
        private TabPage tabPage3;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel3;
        private MetroSet_UI.Controls.MetroSetTile metroSetTile1;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton4;
        private Label label3;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton5;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
    }
}