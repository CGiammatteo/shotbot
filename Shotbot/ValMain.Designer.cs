namespace Shotbot
{
    partial class ValMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValMain));
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.pixelTrackBar = new MetroFramework.Controls.MetroTrackBar();
            this.xPixelsLabel = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.delaySetButton = new MetroFramework.Controls.MetroButton();
            this.delayTextBox = new MetroFramework.Controls.MetroTextBox();
            this.shotDelayLabel = new MetroFramework.Controls.MetroLabel();
            this.triggerbotKeybindButton = new MetroFramework.Controls.MetroButton();
            this.yellowRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.purpleRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.redRadioButton = new MetroFramework.Controls.MetroRadioButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.audioCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.monitorComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.topmostCheckBox = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.expirationLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(252, 294);
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.metroTrackBar1);
            this.metroTabPage1.Controls.Add(this.pixelTrackBar);
            this.metroTabPage1.Controls.Add(this.xPixelsLabel);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.pictureBox1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(244, 255);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Detection";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.LargeChange = 10;
            this.metroTrackBar1.Location = new System.Drawing.Point(3, 188);
            this.metroTrackBar1.Minimum = 5;
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(238, 23);
            this.metroTrackBar1.TabIndex = 5;
            this.metroTrackBar1.Text = "metroTrackBar1";
            this.metroTrackBar1.Value = 10;
            this.metroTrackBar1.ValueChanged += new System.EventHandler(this.metroTrackBar1_ValueChanged);
            // 
            // pixelTrackBar
            // 
            this.pixelTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.pixelTrackBar.Location = new System.Drawing.Point(0, 0);
            this.pixelTrackBar.Name = "pixelTrackBar";
            this.pixelTrackBar.Size = new System.Drawing.Size(0, 0);
            this.pixelTrackBar.TabIndex = 2;
            // 
            // xPixelsLabel
            // 
            this.xPixelsLabel.AutoSize = true;
            this.xPixelsLabel.Location = new System.Drawing.Point(0, 166);
            this.xPixelsLabel.Name = "xPixelsLabel";
            this.xPixelsLabel.Size = new System.Drawing.Size(78, 19);
            this.xPixelsLabel.TabIndex = 4;
            this.xPixelsLabel.Text = "Pixels: 10x10";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 2);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(99, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Detection zone:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroButton1);
            this.metroTabPage2.Controls.Add(this.metroTextBox1);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.delaySetButton);
            this.metroTabPage2.Controls.Add(this.delayTextBox);
            this.metroTabPage2.Controls.Add(this.shotDelayLabel);
            this.metroTabPage2.Controls.Add(this.triggerbotKeybindButton);
            this.metroTabPage2.Controls.Add(this.yellowRadioButton);
            this.metroTabPage2.Controls.Add(this.purpleRadioButton);
            this.metroTabPage2.Controls.Add(this.redRadioButton);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(244, 255);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Basic settings";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(110, 193);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(131, 23);
            this.metroButton1.TabIndex = 14;
            this.metroButton1.Text = "Set delay";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(110, 164);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(131, 23);
            this.metroTextBox1.TabIndex = 13;
            this.metroTextBox1.Text = "75";
            this.metroTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.metroTextBox1_KeyPress);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(0, 164);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(104, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Shot delay (MS):";
            // 
            // delaySetButton
            // 
            this.delaySetButton.Location = new System.Drawing.Point(110, 135);
            this.delaySetButton.Name = "delaySetButton";
            this.delaySetButton.Size = new System.Drawing.Size(131, 23);
            this.delaySetButton.TabIndex = 11;
            this.delaySetButton.Text = "Set speed";
            this.delaySetButton.Click += new System.EventHandler(this.delaySetButton_Click);
            // 
            // delayTextBox
            // 
            this.delayTextBox.Location = new System.Drawing.Point(110, 106);
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(131, 23);
            this.delayTextBox.TabIndex = 10;
            this.delayTextBox.Text = "100";
            this.delayTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.delayTextBox_KeyPress);
            // 
            // shotDelayLabel
            // 
            this.shotDelayLabel.AutoSize = true;
            this.shotDelayLabel.Location = new System.Drawing.Point(0, 106);
            this.shotDelayLabel.Name = "shotDelayLabel";
            this.shotDelayLabel.Size = new System.Drawing.Size(108, 19);
            this.shotDelayLabel.TabIndex = 9;
            this.shotDelayLabel.Text = "Shot speed (MS):";
            // 
            // triggerbotKeybindButton
            // 
            this.triggerbotKeybindButton.Location = new System.Drawing.Point(119, 9);
            this.triggerbotKeybindButton.Name = "triggerbotKeybindButton";
            this.triggerbotKeybindButton.Size = new System.Drawing.Size(122, 23);
            this.triggerbotKeybindButton.TabIndex = 7;
            this.triggerbotKeybindButton.Text = "Keybind: None";
            this.triggerbotKeybindButton.Click += new System.EventHandler(this.triggerbotKeybindButton_Click);
            // 
            // yellowRadioButton
            // 
            this.yellowRadioButton.AutoSize = true;
            this.yellowRadioButton.Location = new System.Drawing.Point(3, 73);
            this.yellowRadioButton.Name = "yellowRadioButton";
            this.yellowRadioButton.Size = new System.Drawing.Size(57, 15);
            this.yellowRadioButton.TabIndex = 5;
            this.yellowRadioButton.TabStop = true;
            this.yellowRadioButton.Text = "Yellow";
            this.yellowRadioButton.UseVisualStyleBackColor = true;
            this.yellowRadioButton.CheckedChanged += new System.EventHandler(this.yellowRadioButton_CheckedChanged);
            // 
            // purpleRadioButton
            // 
            this.purpleRadioButton.AutoSize = true;
            this.purpleRadioButton.Location = new System.Drawing.Point(3, 52);
            this.purpleRadioButton.Name = "purpleRadioButton";
            this.purpleRadioButton.Size = new System.Drawing.Size(57, 15);
            this.purpleRadioButton.TabIndex = 4;
            this.purpleRadioButton.Text = "Purple";
            this.purpleRadioButton.UseVisualStyleBackColor = true;
            this.purpleRadioButton.CheckedChanged += new System.EventHandler(this.purpleRadioButton_CheckedChanged);
            // 
            // redRadioButton
            // 
            this.redRadioButton.AutoSize = true;
            this.redRadioButton.Checked = true;
            this.redRadioButton.Location = new System.Drawing.Point(3, 31);
            this.redRadioButton.Name = "redRadioButton";
            this.redRadioButton.Size = new System.Drawing.Size(43, 15);
            this.redRadioButton.TabIndex = 3;
            this.redRadioButton.TabStop = true;
            this.redRadioButton.Text = "Red";
            this.redRadioButton.UseVisualStyleBackColor = true;
            this.redRadioButton.CheckedChanged += new System.EventHandler(this.redRadioButton_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 9);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(46, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Color:";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.audioCheckBox);
            this.metroTabPage3.Controls.Add(this.metroLabel7);
            this.metroTabPage3.Controls.Add(this.monitorComboBox);
            this.metroTabPage3.Controls.Add(this.metroLabel6);
            this.metroTabPage3.Controls.Add(this.topmostCheckBox);
            this.metroTabPage3.Controls.Add(this.metroLabel5);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(244, 255);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Misc";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // audioCheckBox
            // 
            this.audioCheckBox.AutoSize = true;
            this.audioCheckBox.Checked = true;
            this.audioCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.audioCheckBox.Location = new System.Drawing.Point(3, 71);
            this.audioCheckBox.Name = "audioCheckBox";
            this.audioCheckBox.Size = new System.Drawing.Size(65, 15);
            this.audioCheckBox.TabIndex = 7;
            this.audioCheckBox.Text = "Enabled";
            this.audioCheckBox.UseVisualStyleBackColor = true;
            this.audioCheckBox.CheckedChanged += new System.EventHandler(this.audioCheckBox_CheckedChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(3, 49);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(95, 19);
            this.metroLabel7.TabIndex = 6;
            this.metroLabel7.Text = "Shotbot audio:";
            // 
            // monitorComboBox
            // 
            this.monitorComboBox.FormattingEnabled = true;
            this.monitorComboBox.ItemHeight = 23;
            this.monitorComboBox.Location = new System.Drawing.Point(3, 111);
            this.monitorComboBox.Name = "monitorComboBox";
            this.monitorComboBox.Size = new System.Drawing.Size(238, 29);
            this.monitorComboBox.TabIndex = 5;
            this.monitorComboBox.SelectedIndexChanged += new System.EventHandler(this.monitorComboBox_SelectedIndexChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 89);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(60, 19);
            this.metroLabel6.TabIndex = 4;
            this.metroLabel6.Text = "Monitor:";
            // 
            // topmostCheckBox
            // 
            this.topmostCheckBox.AutoSize = true;
            this.topmostCheckBox.Checked = true;
            this.topmostCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.topmostCheckBox.Location = new System.Drawing.Point(3, 31);
            this.topmostCheckBox.Name = "topmostCheckBox";
            this.topmostCheckBox.Size = new System.Drawing.Size(65, 15);
            this.topmostCheckBox.TabIndex = 3;
            this.topmostCheckBox.Text = "Enabled";
            this.topmostCheckBox.UseVisualStyleBackColor = true;
            this.topmostCheckBox.CheckedChanged += new System.EventHandler(this.topmostCheckBox_CheckedChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(3, 9);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(66, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "Top most:";
            // 
            // expirationLabel
            // 
            this.expirationLabel.AutoSize = true;
            this.expirationLabel.Location = new System.Drawing.Point(4, 360);
            this.expirationLabel.Name = "expirationLabel";
            this.expirationLabel.Size = new System.Drawing.Size(109, 19);
            this.expirationLabel.TabIndex = 1;
            this.expirationLabel.Text = "license expiration";
            // 
            // ValMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 380);
            this.Controls.Add(this.expirationLabel);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ValMain";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Shotbot";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ValMain_FormClosing);
            this.Load += new System.EventHandler(this.ValMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTrackBar pixelTrackBar;
        private MetroFramework.Controls.MetroLabel xPixelsLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroRadioButton yellowRadioButton;
        private MetroFramework.Controls.MetroRadioButton purpleRadioButton;
        private MetroFramework.Controls.MetroRadioButton redRadioButton;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel shotDelayLabel;
        private MetroFramework.Controls.MetroButton triggerbotKeybindButton;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroComboBox monitorComboBox;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroCheckBox topmostCheckBox;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroCheckBox audioCheckBox;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel expirationLabel;
        private MetroFramework.Controls.MetroTextBox delayTextBox;
        private MetroFramework.Controls.MetroButton delaySetButton;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
    }
}