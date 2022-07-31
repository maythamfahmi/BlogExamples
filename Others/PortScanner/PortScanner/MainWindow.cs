using PortScanner.Reporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NLog;

namespace PortScanner
{
    public partial class MainWindow : Form
    {
        // Delegate to report back with one open port
        public delegate void ExecuteOnceCallback(int openPort);

        // Delegate to report back with one open port (Async)
        public delegate void ExecuteOnceAsyncCallback(int port, bool isOpen, bool isCancelled, bool isLast);

        //Logger instance (Logs to file at application directory root)
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        // The manager instance
        IScannerManagerSingleton smc;

        // Cancellation token source for the cancel button
        private CancellationTokenSource cts;

        // Current mode of operation
        private ScannerManagerSingleton.ScanMode currentScanMode;

        //Handler for Reporting Utilities
        private static ReportingHandler _reportingHandler = new ReportingHandler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Get the ScannerManagerSingleton instance
            smc = ScannerManagerSingleton.Instance;

            // Add new line to log text box
            statusTextBox.Text += Environment.NewLine;

            // Populate the timeout times list box
            PopulateTimeoutListBox();
        }

        // Populate the timeout combo box
        private void PopulateTimeoutListBox()
        {
            // Assign the list to the ComboBox's DataSource property
            timeoutComboBox.DataSource = TimeoutListItem.CreateTimeoutListItems();
            timeoutComboBox.DisplayMember = "DisplayMember";
            timeoutComboBox.ValueMember = "ValueMember";

            // Set default value
            timeoutComboBox.SelectedValue = 2000;
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        // This method is used as a callback for portscanning - writes to the log box (text box)
        public void PortResult(int port, bool isOpen, bool isCancelled, bool isLast)
        {
            string status;

            // The operation has been cancelled by MainWindow
            if (isCancelled)
            {
                status = "Operation cancelled." + Environment.NewLine;
                Logger.Info("Operation is Cancelled");
            }

            // The port is open
            else if (isOpen)
            {
                status = String.Format("{0}, {1} port {2} is open.{3}", hostnameTextBox.Text, currentScanMode.ToString(), port, Environment.NewLine);
                Logger.Info(status);
            }

            // The port is closed
            else
            {
                status = String.Format("{0}, {1} port {2} is closed.{3}", hostnameTextBox.Text, currentScanMode.ToString(), port, Environment.NewLine);
                Logger.Info(status);

            }

            // Write to the logging box and then unfreeze user inputs
            statusTextBox.AppendText(status);

            if (isLast || isCancelled)
                ToggleInputs(true);
        }

        // Checks whether the timeout combo box has user input or not
        private bool IsTimeoutComboBoxUserInput()
        {
            var inputText = timeoutComboBox.Text;

            foreach (var displayMemberText in (List<TimeoutListItem>)timeoutComboBox.DataSource)
            {
                if (displayMemberText.DisplayMember == inputText)
                {
                    // Select the one that's in the box's list to prevent some problems
                    // This will return because the user input IS in the combo box's DataSource
                    // However it is still user input and does not have a ValueMember. Exception
                    // will be thrown.
                    timeoutComboBox.SelectedItem = displayMemberText;
                    return false;
                }
            }

            return true;
        }

        // Executed when the Check Port button is clicked
        private void checkPortButton_Click(object sender, EventArgs e)
        {
            // Get user inputs
            string hostname = hostnameTextBox.Text;
            if (hostname == "")
            {
                MessageBox.Show("Please enter a valid hostname.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                hostnameTextBox.Focus();
                return;
            }

            // Check port
            int portMin = InputChecker.ParsePort(portTextBoxMin.Text);
            if (portMin == -1)
            {
                MessageBox.Show((portRangeCheckBox.Checked ? "Lower limit of port range" : "Port") + " invalid.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                portTextBoxMin.Focus();
                return;
            }

            // Get scan mode
            ScannerManagerSingleton.ScanMode scanMode = ReadScanMode();

            // If custom timeout time, verify correct user input
            int timeout;
            if (IsTimeoutComboBoxUserInput())
            {
                // If valid, proceed with that input as timeout
                timeout = InputChecker.ParseTimeout(timeoutComboBox.Text);
                if (timeout == -1)
                {
                    MessageBox.Show("Timeout format: [time], [time]ms or [time] ms.\nTimeout must be between 250 ms and 20000 ms.",
                        "Timeout Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Else, use the ValueMember of the selected Member
                timeout = (int)timeoutComboBox.SelectedValue;
            }

            // Instantiate CTS
            cts = new CancellationTokenSource();

            // Simple one port check
            if (!portRangeCheckBox.Checked)
            {
                // Set status box text
                var connectionText = String.Format("Connecting to {0}, port {1}...{2}", hostname, portMin,
                    Environment.NewLine);
                statusTextBox.AppendText(connectionText);
                Logger.Info(connectionText);

                // The callback for scan result
                var callback = new ExecuteOnceAsyncCallback(PortResult);
                
                // Send one check request and toggle user inputs
                ToggleInputs(false);
                smc.ExecuteOnceAsync(hostname, portMin, timeout, scanMode, callback, cts.Token);
            }

            // Port range check
            else
            {
                // Verify input
                int portMax = InputChecker.ParsePort(portTextBoxMax.Text);
                if (portMax == -1)
                {
                    MessageBox.Show("Upper limit of port range invalid.",
                        "Input Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    portTextBoxMax.Focus();
                    return;
                }

                if (portMax < portMin)
                {
                    MessageBox.Show("Port range invalid.",
                        "Input Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    portTextBoxMax.Focus();
                    return;
                }

                // The callback for scan result
                var callback = new ExecuteOnceAsyncCallback(PortResult);

                // Set status box text
                var connectionText = String.Format("Connecting to {0}, port {1}...{2}", hostname, portMin,
                    Environment.NewLine);
                statusTextBox.AppendText(connectionText);
                Logger.Info(connectionText);
                // Toggle inputs and begin operation
                ToggleInputs(false);
                smc.ExecuteRangeAsync(hostname, portMin, portMax, timeout, scanMode, callback, cts.Token);
            }
        }

        // Read scan mode radio button selection
        private ScannerManagerSingleton.ScanMode ReadScanMode()
        {
            if (tcpModeRadioButton.Checked)
            {
                currentScanMode = ScannerManagerSingleton.ScanMode.TCP;
                Logger.Info("Current Scan Mode: "+ currentScanMode);
            }
            else
            {
                currentScanMode = ScannerManagerSingleton.ScanMode.UDP;
                Logger.Info("Current Scan Mode: " + currentScanMode);

            }
            return currentScanMode;
        }

        private void portRangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // This enables or disables the max. port input box
            if (portRangeCheckBox.Checked)
            {
                portTextBoxMax.Enabled = true;
            }
            else
            {
                portTextBoxMax.Enabled = false;
            }
        }

        // Toggle all inputs
        private void ToggleInputs(bool setting)
        {
            hostnameTextBox.Enabled = setting;
            portTextBoxMin.Enabled = setting;
            checkPortButton.Enabled = setting;
            portTextBoxMax.Enabled = setting;
            portRangeCheckBox.Enabled = setting;

            // Re-disable the portMax text box
            if (!portRangeCheckBox.Checked)
            {
                portTextBoxMax.Enabled = false;
            }

            // Set focus to hostnameTextBox
            if (setting)
                hostnameTextBox.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // If cts is instantiated (i.e. the scanning operation is in progress, request cancellation
            if (cts != null)
            {
                cts.Cancel();
            }
        }

        // Executes when the exit button is clicked - form closes after prompt
        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void saveReportButton_Click(object sender, EventArgs e)
        {
            //If txt type
            if (_reportingHandler.GetReportType() == 1)
            {
                var saveFileDialog = _reportingHandler.GetSaveFileDialog();
                var result = saveFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, _reportingHandler.BuildTextFile(statusTextBox));
                }
            }
            else
            {
                //If xls type
                var path = _reportingHandler.GetSaveFileLocation(Enum.ReportType.Xls);
                _reportingHandler.BuildWorkBook(statusTextBox,path);
            }
        }

        private void textFileRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _reportingHandler.SetReportType(Enum.ReportType.Txt);
        }

        private void xlsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _reportingHandler.SetReportType(Enum.ReportType.Xls);
        }

        private void csvRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            _reportingHandler.SetReportType(Enum.ReportType.Csv);
        }
    }
}