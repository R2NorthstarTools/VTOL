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
            this.Version_TextBox = new System.Windows.Forms.TextBox();
            this.Northstar_Version_label = new System.Windows.Forms.Label();
            this.Install_NS_Button = new System.Windows.Forms.Button();
            this.Install_Textbox = new System.Windows.Forms.TextBox();
            this.Browse_New_Install = new System.Windows.Forms.Button();
            this.Install_Location_Label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Log_Label = new System.Windows.Forms.Label();
            this.Log_Box = new System.Windows.Forms.RichTextBox();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Version_TextBox);
            this.panel1.Controls.Add(this.Northstar_Version_label);
            this.panel1.Controls.Add(this.Install_NS_Button);
            this.panel1.Controls.Add(this.Install_Textbox);
            this.panel1.Controls.Add(this.Browse_New_Install);
            this.panel1.Controls.Add(this.Install_Location_Label);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 134);
            this.panel1.TabIndex = 0;
            // 
            // Version_TextBox
            // 
            this.Version_TextBox.Enabled = false;
            this.Version_TextBox.Location = new System.Drawing.Point(117, 97);
            this.Version_TextBox.Name = "Version_TextBox";
            this.Version_TextBox.ReadOnly = true;
            this.Version_TextBox.Size = new System.Drawing.Size(100, 23);
            this.Version_TextBox.TabIndex = 5;
            // 
            // Northstar_Version_label
            // 
            this.Northstar_Version_label.AutoSize = true;
            this.Northstar_Version_label.Location = new System.Drawing.Point(119, 79);
            this.Northstar_Version_label.Name = "Northstar_Version_label";
            this.Northstar_Version_label.Size = new System.Drawing.Size(98, 15);
            this.Northstar_Version_label.TabIndex = 4;
            this.Northstar_Version_label.Text = "Northstar Version";
            // 
            // Install_NS_Button
            // 
            this.Install_NS_Button.Location = new System.Drawing.Point(3, 53);
            this.Install_NS_Button.Name = "Install_NS_Button";
            this.Install_NS_Button.Size = new System.Drawing.Size(342, 23);
            this.Install_NS_Button.TabIndex = 3;
            this.Install_NS_Button.Text = "Install Northstar Launcher";
            this.Install_NS_Button.UseVisualStyleBackColor = true;
            // 
            // Install_Textbox
            // 
            this.Install_Textbox.Location = new System.Drawing.Point(3, 24);
            this.Install_Textbox.Name = "Install_Textbox";
            this.Install_Textbox.Size = new System.Drawing.Size(312, 23);
            this.Install_Textbox.TabIndex = 2;
            // 
            // Browse_New_Install
            // 
            this.Browse_New_Install.Location = new System.Drawing.Point(321, 22);
            this.Browse_New_Install.Name = "Browse_New_Install";
            this.Browse_New_Install.Size = new System.Drawing.Size(24, 25);
            this.Browse_New_Install.TabIndex = 1;
            this.Browse_New_Install.Text = "...";
            this.Browse_New_Install.UseVisualStyleBackColor = true;
            this.Browse_New_Install.Click += new System.EventHandler(this.Browse_New_Install_Click);
            // 
            // Install_Location_Label
            // 
            this.Install_Location_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Install_Location_Label.AutoSize = true;
            this.Install_Location_Label.Location = new System.Drawing.Point(43, 6);
            this.Install_Location_Label.Name = "Install_Location_Label";
            this.Install_Location_Label.Size = new System.Drawing.Size(272, 15);
            this.Install_Location_Label.TabIndex = 0;
            this.Install_Location_Label.Text = "Titanfall 2 with Northstar Launcher Install Location";
            this.Install_Location_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(12, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 346);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(12, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(692, 58);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.Log_Label);
            this.panel4.Controls.Add(this.Log_Box);
            this.panel4.Location = new System.Drawing.Point(366, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(338, 486);
            this.panel4.TabIndex = 3;
            // 
            // Log_Label
            // 
            this.Log_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log_Label.AutoSize = true;
            this.Log_Label.Location = new System.Drawing.Point(158, 5);
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
            this.Log_Box.Enabled = false;
            this.Log_Box.Location = new System.Drawing.Point(0, 23);
            this.Log_Box.Name = "Log_Box";
            this.Log_Box.ReadOnly = true;
            this.Log_Box.Size = new System.Drawing.Size(336, 462);
            this.Log_Box.TabIndex = 0;
            this.Log_Box.Text = "";
            this.Log_Box.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(716, 24);
            this.MainMenuStrip.TabIndex = 4;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(716, 712);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenuStrip);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "NorthStar Mod Launcher Version 1.0.0";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label Install_Location_Label;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private RichTextBox Log_Box;
        private TextBox Version_TextBox;
        private Label Northstar_Version_label;
        private Button Install_NS_Button;
        private TextBox Install_Textbox;
        private Button Browse_New_Install;
        private Label Log_Label;
        private MenuStrip MainMenuStrip;
    }
}