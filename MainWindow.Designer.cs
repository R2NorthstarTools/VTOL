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
            this.Brows_Bttn = new MetroSet_UI.Controls.MetroSetButton();
            this.Check_Bttn = new MetroSet_UI.Controls.MetroSetButton();
            this.Install_NS_Button = new MetroSet_UI.Controls.MetroSetButton();
            this.Version_TextBox = new System.Windows.Forms.TextBox();
            this.Northstar_Version_label = new System.Windows.Forms.Label();
            this.Install_Textbox = new System.Windows.Forms.TextBox();
            this.Install_Location_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Log_Box = new MetroSet_UI.Controls.MetroSetRichTextBox();
            this.Log_Label = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.metroSetButton1 = new MetroSet_UI.Controls.MetroSetButton();
            this.button2 = new System.Windows.Forms.Button();
            this.Main_Window = new MetroSet_UI.Controls.MetroSetTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.Main_Window.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            // Brows_Bttn
            // 
            this.Brows_Bttn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Brows_Bttn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.Brows_Bttn.DisabledForeColor = System.Drawing.Color.Gray;
            this.Brows_Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.Check_Bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.Install_NS_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Install_NS_Button.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Install_NS_Button.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.Install_NS_Button.HoverTextColor = System.Drawing.Color.White;
            this.Install_NS_Button.IsDerivedStyle = true;
            this.Install_NS_Button.Location = new System.Drawing.Point(3, 178);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Location = new System.Drawing.Point(503, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 462);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(460, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Info;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 71);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(460, 346);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.Log_Box);
            this.panel4.Controls.Add(this.Log_Label);
            this.panel4.Location = new System.Drawing.Point(437, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(534, 579);
            this.panel4.TabIndex = 3;
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
            this.Log_Box.Size = new System.Drawing.Size(526, 549);
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
            this.Log_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Log_Label.Location = new System.Drawing.Point(240, 4);
            this.Log_Label.Name = "Log_Label";
            this.Log_Label.Size = new System.Drawing.Size(61, 15);
            this.Log_Label.TabIndex = 0;
            this.Log_Label.Text = "Install Log";
            this.Log_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Teal;
            this.panel5.Controls.Add(this.metroSetButton1);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(428, 102);
            this.panel5.TabIndex = 5;
            // 
            // metroSetButton1
            // 
            this.metroSetButton1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroSetButton1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton1.IsDerivedStyle = true;
            this.metroSetButton1.Location = new System.Drawing.Point(170, 20);
            this.metroSetButton1.Name = "metroSetButton1";
            this.metroSetButton1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton1.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton1.Size = new System.Drawing.Size(75, 23);
            this.metroSetButton1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetButton1.StyleManager = null;
            this.metroSetButton1.TabIndex = 1;
            this.metroSetButton1.Text = "metroSetButton1";
            this.metroSetButton1.ThemeAuthor = "Narwin";
            this.metroSetButton1.ThemeName = "MetroLite";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(342, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Download Mods From Repo";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Main_Window
            // 
            this.Main_Window.AnimateEasingType = MetroSet_UI.Enums.EasingType.CubeOut;
            this.Main_Window.AnimateTime = 200;
            this.Main_Window.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Main_Window.Controls.Add(this.tabPage1);
            this.Main_Window.Controls.Add(this.tabPage2);
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
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(974, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mods";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(982, 631);
            this.Controls.Add(this.Main_Window);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "NorthStar Mod Launcher Version 1.0.0";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.Main_Window.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label Install_Location_Label;
        private Panel panel2;
        private Panel panel4;
        private TextBox Version_TextBox;
        private Label Northstar_Version_label;
        private TextBox Install_Textbox;
        private Label Log_Label;
        private Panel panel5;
        private Button button1;
        private CheckedListBox checkedListBox1;
        private Button button2;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton1;
        private MetroSet_UI.Controls.MetroSetTabControl Main_Window;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MetroSet_UI.Controls.MetroSetRichTextBox Log_Box;
        private MetroSet_UI.Controls.MetroSetButton Install_NS_Button;
        private MetroSet_UI.Controls.MetroSetButton Brows_Bttn;
        private MetroSet_UI.Controls.MetroSetButton Check_Bttn;
    }
}