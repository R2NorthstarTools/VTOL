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
            this.InstallNorthsatar = new System.Windows.Forms.Button();
            this.Version_TextBox = new System.Windows.Forms.TextBox();
            this.Northstar_Version_label = new System.Windows.Forms.Label();
            this.Install_Textbox = new System.Windows.Forms.TextBox();
            this.Browse_New_Install = new System.Windows.Forms.Button();
            this.Install_Location_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Log_Label = new System.Windows.Forms.Label();
            this.Log_Box = new System.Windows.Forms.RichTextBox();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.Check_Ver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Check_Ver);
            this.panel1.Controls.Add(this.InstallNorthsatar);
            this.panel1.Controls.Add(this.Version_TextBox);
            this.panel1.Controls.Add(this.Northstar_Version_label);
            this.panel1.Controls.Add(this.Install_Textbox);
            this.panel1.Controls.Add(this.Browse_New_Install);
            this.panel1.Controls.Add(this.Install_Location_Label);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 147);
            this.panel1.TabIndex = 0;
            // 
            // InstallNorthsatar
            // 
            this.InstallNorthsatar.Location = new System.Drawing.Point(3, 102);
            this.InstallNorthsatar.Name = "InstallNorthsatar";
            this.InstallNorthsatar.Size = new System.Drawing.Size(420, 40);
            this.InstallNorthsatar.TabIndex = 7;
            this.InstallNorthsatar.Text = "Install Northstar";
            this.InstallNorthsatar.UseVisualStyleBackColor = true;
            this.InstallNorthsatar.Click += new System.EventHandler(this.InstallNorthsatar_Click);
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
            this.Northstar_Version_label.Location = new System.Drawing.Point(169, 55);
            this.Northstar_Version_label.Name = "Northstar_Version_label";
            this.Northstar_Version_label.Size = new System.Drawing.Size(98, 15);
            this.Northstar_Version_label.TabIndex = 4;
            this.Northstar_Version_label.Text = "Northstar Version";
            // 
            // Install_Textbox
            // 
            this.Install_Textbox.Location = new System.Drawing.Point(9, 24);
            this.Install_Textbox.Name = "Install_Textbox";
            this.Install_Textbox.Size = new System.Drawing.Size(352, 23);
            this.Install_Textbox.TabIndex = 2;
            // 
            // Browse_New_Install
            // 
            this.Browse_New_Install.Location = new System.Drawing.Point(367, 24);
            this.Browse_New_Install.Name = "Browse_New_Install";
            this.Browse_New_Install.Size = new System.Drawing.Size(56, 23);
            this.Browse_New_Install.TabIndex = 1;
            this.Browse_New_Install.Text = "Browse";
            this.Browse_New_Install.UseVisualStyleBackColor = true;
            this.Browse_New_Install.Click += new System.EventHandler(this.Browse_New_Install_Click);
            // 
            // Install_Location_Label
            // 
            this.Install_Location_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Install_Location_Label.AutoSize = true;
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
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Location = new System.Drawing.Point(446, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 462);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(440, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 22);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(440, 346);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.Log_Label);
            this.panel4.Controls.Add(this.Log_Box);
            this.panel4.Location = new System.Drawing.Point(12, 288);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(428, 201);
            this.panel4.TabIndex = 3;
            // 
            // Log_Label
            // 
            this.Log_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_Label.AutoSize = true;
            this.Log_Label.Location = new System.Drawing.Point(194, 4);
            this.Log_Label.Name = "Log_Label";
            this.Log_Label.Size = new System.Drawing.Size(27, 15);
            this.Log_Label.TabIndex = 0;
            this.Log_Label.Text = "Log";
            this.Log_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Log_Box
            // 
            this.Log_Box.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Log_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Log_Box.Location = new System.Drawing.Point(3, 22);
            this.Log_Box.Name = "Log_Box";
            this.Log_Box.ReadOnly = true;
            this.Log_Box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.Log_Box.Size = new System.Drawing.Size(420, 174);
            this.Log_Box.TabIndex = 0;
            this.Log_Box.Text = "";
            this.Log_Box.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1344, 24);
            this.MainMenuStrip.TabIndex = 4;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button2);
            this.panel5.Location = new System.Drawing.Point(12, 180);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(428, 102);
            this.panel5.TabIndex = 5;
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
            // Check_Ver
            // 
            this.Check_Ver.Location = new System.Drawing.Point(367, 73);
            this.Check_Ver.Name = "Check_Ver";
            this.Check_Ver.Size = new System.Drawing.Size(56, 23);
            this.Check_Ver.TabIndex = 8;
            this.Check_Ver.Text = "Check";
            this.Check_Ver.UseVisualStyleBackColor = true;
            this.Check_Ver.Click += new System.EventHandler(this.Check_Ver_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1344, 499);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenuStrip);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "NorthStar Mod Launcher Version 1.0.0";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label Install_Location_Label;
        private Panel panel2;
        private Panel panel4;
        private RichTextBox Log_Box;
        private TextBox Version_TextBox;
        private Label Northstar_Version_label;
        private TextBox Install_Textbox;
        private Button Browse_New_Install;
        private Label Log_Label;
        private MenuStrip MainMenuStrip;
        private Panel panel5;
        private Button button1;
        private CheckedListBox checkedListBox1;
        private Button button2;
        private Button InstallNorthsatar;
        private Button Check_Ver;
    }
}