namespace Snapshot_Maker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.devicesCombo = new System.Windows.Forms.ComboBox();
            this.videoResolutionsCombo = new System.Windows.Forms.ComboBox();
            this.snapshotResolutionsCombo = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.triggerButton = new System.Windows.Forms.Button();
            this.button_algorytm = new System.Windows.Forms.Button();
            this.checkBox_calibrated = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // devicesCombo
            // 
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(20, 17);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(320, 21);
            this.devicesCombo.TabIndex = 1;
            this.devicesCombo.SelectedIndexChanged += new System.EventHandler(this.devicesCombo_SelectedIndexChanged);
            // 
            // videoResolutionsCombo
            // 
            this.videoResolutionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoResolutionsCombo.FormattingEnabled = true;
            this.videoResolutionsCombo.Location = new System.Drawing.Point(20, 43);
            this.videoResolutionsCombo.Name = "videoResolutionsCombo";
            this.videoResolutionsCombo.Size = new System.Drawing.Size(100, 21);
            this.videoResolutionsCombo.TabIndex = 3;
            // 
            // snapshotResolutionsCombo
            // 
            this.snapshotResolutionsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.snapshotResolutionsCombo.FormattingEnabled = true;
            this.snapshotResolutionsCombo.Location = new System.Drawing.Point(126, 43);
            this.snapshotResolutionsCombo.Name = "snapshotResolutionsCombo";
            this.snapshotResolutionsCombo.Size = new System.Drawing.Size(100, 21);
            this.snapshotResolutionsCombo.TabIndex = 4;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(346, 17);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(159, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "&START";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(232, 41);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(108, 23);
            this.disconnectButton.TabIndex = 7;
            this.disconnectButton.Text = "&WYŁĄCZ";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.DarkRed;
            this.videoSourcePlayer.Location = new System.Drawing.Point(20, 70);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(320, 240);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.VideoSource = null;
            // 
            // triggerButton
            // 
            this.triggerButton.Location = new System.Drawing.Point(346, 43);
            this.triggerButton.Name = "triggerButton";
            this.triggerButton.Size = new System.Drawing.Size(159, 23);
            this.triggerButton.TabIndex = 9;
            this.triggerButton.Text = "&KALIBRACJA";
            this.triggerButton.UseVisualStyleBackColor = true;
            this.triggerButton.Click += new System.EventHandler(this.triggerButton_Click);
            // 
            // button_algorytm
            // 
            this.button_algorytm.Location = new System.Drawing.Point(346, 69);
            this.button_algorytm.Name = "button_algorytm";
            this.button_algorytm.Size = new System.Drawing.Size(159, 23);
            this.button_algorytm.TabIndex = 10;
            this.button_algorytm.Text = "&ROZPOZNAWANIE";
            this.button_algorytm.UseVisualStyleBackColor = true;
            this.button_algorytm.Click += new System.EventHandler(this.button_algorytm_Click);
            // 
            // checkBox_calibrated
            // 
            this.checkBox_calibrated.AutoSize = true;
            this.checkBox_calibrated.Location = new System.Drawing.Point(350, 98);
            this.checkBox_calibrated.Name = "checkBox_calibrated";
            this.checkBox_calibrated.Size = new System.Drawing.Size(90, 17);
            this.checkBox_calibrated.TabIndex = 12;
            this.checkBox_calibrated.Text = "Skalibrowane";
            this.checkBox_calibrated.UseVisualStyleBackColor = true;
            this.checkBox_calibrated.CheckedChanged += new System.EventHandler(this.checkBox_calibrated_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "&TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 312);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_calibrated);
            this.Controls.Add(this.button_algorytm);
            this.Controls.Add(this.videoSourcePlayer);
            this.Controls.Add(this.triggerButton);
            this.Controls.Add(this.disconnectButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.snapshotResolutionsCombo);
            this.Controls.Add(this.videoResolutionsCombo);
            this.Controls.Add(this.devicesCombo);
            this.MaximumSize = new System.Drawing.Size(530, 350);
            this.MinimumSize = new System.Drawing.Size(530, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PROJEKT X";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox devicesCombo;
        private System.Windows.Forms.ComboBox videoResolutionsCombo;
        private System.Windows.Forms.ComboBox snapshotResolutionsCombo;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.Button triggerButton;
        private System.Windows.Forms.Button button_algorytm;
        private System.Windows.Forms.CheckBox checkBox_calibrated;
        private System.Windows.Forms.Button button1;
    }
}

