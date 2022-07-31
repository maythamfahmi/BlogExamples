namespace PortScanner
{
    partial class MainWindow
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
            this.hostnameTextBox = new System.Windows.Forms.TextBox();
            this.hostnameLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portTextBoxMin = new System.Windows.Forms.TextBox();
            this.checkPortButton = new System.Windows.Forms.Button();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.dashLabel = new System.Windows.Forms.Label();
            this.portTextBoxMax = new System.Windows.Forms.TextBox();
            this.portRangeCheckBox = new System.Windows.Forms.CheckBox();
            this.tcpModeRadioButton = new System.Windows.Forms.RadioButton();
            this.udpModeRadioButton = new System.Windows.Forms.RadioButton();
            this.modeGroupBox = new System.Windows.Forms.GroupBox();
            this.timeoutGroupBox = new System.Windows.Forms.GroupBox();
            this.timeoutComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.reportingGroupBox = new System.Windows.Forms.GroupBox();
            this.xlsRadioButton = new System.Windows.Forms.RadioButton();
            this.textFileRadioBtn = new System.Windows.Forms.RadioButton();
            this.saveReportButton = new System.Windows.Forms.Button();
            this.modeGroupBox.SuspendLayout();
            this.timeoutGroupBox.SuspendLayout();
            this.reportingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // hostnameTextBox
            // 
            this.hostnameTextBox.Location = new System.Drawing.Point(101, 15);
            this.hostnameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hostnameTextBox.MaxLength = 15;
            this.hostnameTextBox.Name = "hostnameTextBox";
            this.hostnameTextBox.Size = new System.Drawing.Size(231, 22);
            this.hostnameTextBox.TabIndex = 0;
            // 
            // hostnameLabel
            // 
            this.hostnameLabel.AutoSize = true;
            this.hostnameLabel.Location = new System.Drawing.Point(16, 18);
            this.hostnameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hostnameLabel.Name = "hostnameLabel";
            this.hostnameLabel.Size = new System.Drawing.Size(72, 17);
            this.hostnameLabel.TabIndex = 1;
            this.hostnameLabel.Text = "Hostname";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(341, 18);
            this.portLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(41, 17);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Ports";
            // 
            // portTextBoxMin
            // 
            this.portTextBoxMin.Location = new System.Drawing.Point(395, 15);
            this.portTextBoxMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portTextBoxMin.MaxLength = 5;
            this.portTextBoxMin.Name = "portTextBoxMin";
            this.portTextBoxMin.Size = new System.Drawing.Size(49, 22);
            this.portTextBoxMin.TabIndex = 3;
            // 
            // checkPortButton
            // 
            this.checkPortButton.Location = new System.Drawing.Point(468, 358);
            this.checkPortButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkPortButton.Name = "checkPortButton";
            this.checkPortButton.Size = new System.Drawing.Size(164, 28);
            this.checkPortButton.TabIndex = 4;
            this.checkPortButton.Text = "Check Ports";
            this.checkPortButton.UseVisualStyleBackColor = true;
            this.checkPortButton.Click += new System.EventHandler(this.checkPortButton_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Font = new System.Drawing.Font("Lucida Console", 9F);
            this.statusTextBox.Location = new System.Drawing.Point(20, 68);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(417, 310);
            this.statusTextBox.TabIndex = 5;
            this.statusTextBox.Text = "Standby...";
            this.statusTextBox.TextChanged += new System.EventHandler(this.statusTextBox_TextChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(16, 48);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(48, 17);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status";
            // 
            // dashLabel
            // 
            this.dashLabel.AutoSize = true;
            this.dashLabel.Location = new System.Drawing.Point(453, 18);
            this.dashLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dashLabel.Name = "dashLabel";
            this.dashLabel.Size = new System.Drawing.Size(13, 17);
            this.dashLabel.TabIndex = 7;
            this.dashLabel.Text = "-";
            // 
            // portTextBoxMax
            // 
            this.portTextBoxMax.Enabled = false;
            this.portTextBoxMax.Location = new System.Drawing.Point(475, 15);
            this.portTextBoxMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portTextBoxMax.MaxLength = 5;
            this.portTextBoxMax.Name = "portTextBoxMax";
            this.portTextBoxMax.Size = new System.Drawing.Size(49, 22);
            this.portTextBoxMax.TabIndex = 8;
            // 
            // portRangeCheckBox
            // 
            this.portRangeCheckBox.AutoSize = true;
            this.portRangeCheckBox.Location = new System.Drawing.Point(533, 17);
            this.portRangeCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portRangeCheckBox.Name = "portRangeCheckBox";
            this.portRangeCheckBox.Size = new System.Drawing.Size(102, 21);
            this.portRangeCheckBox.TabIndex = 9;
            this.portRangeCheckBox.Text = "Port Range";
            this.portRangeCheckBox.UseVisualStyleBackColor = true;
            this.portRangeCheckBox.CheckedChanged += new System.EventHandler(this.portRangeCheckBox_CheckedChanged);
            // 
            // tcpModeRadioButton
            // 
            this.tcpModeRadioButton.AutoSize = true;
            this.tcpModeRadioButton.Checked = true;
            this.tcpModeRadioButton.Location = new System.Drawing.Point(17, 30);
            this.tcpModeRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcpModeRadioButton.Name = "tcpModeRadioButton";
            this.tcpModeRadioButton.Size = new System.Drawing.Size(56, 21);
            this.tcpModeRadioButton.TabIndex = 10;
            this.tcpModeRadioButton.TabStop = true;
            this.tcpModeRadioButton.Text = "TCP";
            this.tcpModeRadioButton.UseVisualStyleBackColor = true;
            this.tcpModeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // udpModeRadioButton
            // 
            this.udpModeRadioButton.AutoSize = true;
            this.udpModeRadioButton.Location = new System.Drawing.Point(17, 58);
            this.udpModeRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.udpModeRadioButton.Name = "udpModeRadioButton";
            this.udpModeRadioButton.Size = new System.Drawing.Size(58, 21);
            this.udpModeRadioButton.TabIndex = 11;
            this.udpModeRadioButton.Text = "UDP";
            this.udpModeRadioButton.UseVisualStyleBackColor = true;
            this.udpModeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // modeGroupBox
            // 
            this.modeGroupBox.Controls.Add(this.udpModeRadioButton);
            this.modeGroupBox.Controls.Add(this.tcpModeRadioButton);
            this.modeGroupBox.Location = new System.Drawing.Point(457, 52);
            this.modeGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modeGroupBox.Name = "modeGroupBox";
            this.modeGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modeGroupBox.Size = new System.Drawing.Size(148, 102);
            this.modeGroupBox.TabIndex = 12;
            this.modeGroupBox.TabStop = false;
            this.modeGroupBox.Text = "Mode";
            // 
            // timeoutGroupBox
            // 
            this.timeoutGroupBox.Controls.Add(this.timeoutComboBox);
            this.timeoutGroupBox.Location = new System.Drawing.Point(457, 166);
            this.timeoutGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeoutGroupBox.Name = "timeoutGroupBox";
            this.timeoutGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeoutGroupBox.Size = new System.Drawing.Size(147, 64);
            this.timeoutGroupBox.TabIndex = 13;
            this.timeoutGroupBox.TabStop = false;
            this.timeoutGroupBox.Text = "Timeout";
            // 
            // timeoutComboBox
            // 
            this.timeoutComboBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.timeoutComboBox.FormattingEnabled = true;
            this.timeoutComboBox.Items.AddRange(new object[] {
            "500 ms",
            "1000 ms",
            "1500 ms",
            "2000 ms"});
            this.timeoutComboBox.Location = new System.Drawing.Point(8, 26);
            this.timeoutComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeoutComboBox.Name = "timeoutComboBox";
            this.timeoutComboBox.Size = new System.Drawing.Size(129, 24);
            this.timeoutComboBox.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(468, 327);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(164, 28);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(468, 297);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(164, 28);
            this.exitButton.TabIndex = 15;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // reportingGroupBox
            // 
            this.reportingGroupBox.Controls.Add(this.xlsRadioButton);
            this.reportingGroupBox.Controls.Add(this.textFileRadioBtn);
            this.reportingGroupBox.Location = new System.Drawing.Point(642, 52);
            this.reportingGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.reportingGroupBox.Name = "reportingGroupBox";
            this.reportingGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.reportingGroupBox.Size = new System.Drawing.Size(106, 102);
            this.reportingGroupBox.TabIndex = 16;
            this.reportingGroupBox.TabStop = false;
            this.reportingGroupBox.Text = "Reporting";
            this.reportingGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // xlsRadioButton
            // 
            this.xlsRadioButton.AutoSize = true;
            this.xlsRadioButton.Location = new System.Drawing.Point(17, 58);
            this.xlsRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.xlsRadioButton.Name = "xlsRadioButton";
            this.xlsRadioButton.Size = new System.Drawing.Size(49, 21);
            this.xlsRadioButton.TabIndex = 11;
            this.xlsRadioButton.Text = ".xls";
            this.xlsRadioButton.UseVisualStyleBackColor = true;
            this.xlsRadioButton.CheckedChanged += new System.EventHandler(this.xlsRadioButton_CheckedChanged);
            // 
            // textFileRadioBtn
            // 
            this.textFileRadioBtn.AutoSize = true;
            this.textFileRadioBtn.Checked = true;
            this.textFileRadioBtn.Location = new System.Drawing.Point(17, 30);
            this.textFileRadioBtn.Margin = new System.Windows.Forms.Padding(4);
            this.textFileRadioBtn.Name = "textFileRadioBtn";
            this.textFileRadioBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textFileRadioBtn.Size = new System.Drawing.Size(47, 21);
            this.textFileRadioBtn.TabIndex = 10;
            this.textFileRadioBtn.TabStop = true;
            this.textFileRadioBtn.Text = ".txt";
            this.textFileRadioBtn.UseVisualStyleBackColor = true;
            this.textFileRadioBtn.CheckedChanged += new System.EventHandler(this.textFileRadioBtn_CheckedChanged);
            // 
            // saveReportButton
            // 
            this.saveReportButton.Location = new System.Drawing.Point(650, 162);
            this.saveReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveReportButton.Name = "saveReportButton";
            this.saveReportButton.Size = new System.Drawing.Size(98, 28);
            this.saveReportButton.TabIndex = 17;
            this.saveReportButton.Text = "Save Report";
            this.saveReportButton.UseVisualStyleBackColor = true;
            this.saveReportButton.Click += new System.EventHandler(this.saveReportButton_Click);
            // 
            // MainWindow
            // 
            this.AcceptButton = this.checkPortButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(775, 413);
            this.Controls.Add(this.saveReportButton);
            this.Controls.Add(this.reportingGroupBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.timeoutGroupBox);
            this.Controls.Add(this.modeGroupBox);
            this.Controls.Add(this.portRangeCheckBox);
            this.Controls.Add(this.portTextBoxMax);
            this.Controls.Add(this.dashLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.checkPortButton);
            this.Controls.Add(this.portTextBoxMin);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.hostnameLabel);
            this.Controls.Add(this.hostnameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "PortScanner 0.1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.modeGroupBox.ResumeLayout(false);
            this.modeGroupBox.PerformLayout();
            this.timeoutGroupBox.ResumeLayout(false);
            this.reportingGroupBox.ResumeLayout(false);
            this.reportingGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hostnameTextBox;
        private System.Windows.Forms.Label hostnameLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portTextBoxMin;
        private System.Windows.Forms.Button checkPortButton;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label dashLabel;
        private System.Windows.Forms.TextBox portTextBoxMax;
        private System.Windows.Forms.CheckBox portRangeCheckBox;
        private System.Windows.Forms.RadioButton tcpModeRadioButton;
        private System.Windows.Forms.RadioButton udpModeRadioButton;
        private System.Windows.Forms.GroupBox modeGroupBox;
        private System.Windows.Forms.GroupBox timeoutGroupBox;
        private System.Windows.Forms.ComboBox timeoutComboBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.GroupBox reportingGroupBox;
        private System.Windows.Forms.RadioButton xlsRadioButton;
        private System.Windows.Forms.RadioButton textFileRadioBtn;
        private System.Windows.Forms.Button saveReportButton;
    }
}

