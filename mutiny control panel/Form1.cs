﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace mutiny_control_panel {
    public partial class MainWindow : Form {

        private string version = "0.5.8a";
        private string changes = "Changelog: \r\n\r\n" + 
                                 " - major code changes for saving \r\n" +
                                 " - colorized tray icon for hosting \r\n" +
                                 " - added start with windows method \r\n" +
                                 " - default script auto behavior on \r\n" +
                                 " - probably random bug fixes \r\n"+
                                 "\r\n ヾ(＾∇＾)";
        /* todo
         *  - clean form1, modulate functions to provide better checks
         *  
         *  - add fluff to debug form
         *  - add setting clean log every x changes
         *  - make form3 topmost toggle
         */

        private Debug consoleForm; 
        private Thread nodeThread;

        public MainWindow Session;
        public string StatusCache;
        public string ProgramName;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        public MainWindow(string constname) {
            InitializeComponent();
            Session = this;

            StatusCache = "offline";
            ProgramName = constname;
            this.Text = ProgramName;

            AutoHostScript();
            SpawnConsole();            
            SetValues();
        }

        public void SpawnConsole() {
            consoleForm = new Debug();
            consoleForm.Text = Saves.scriptPath;
            consoleForm.FormClosing += new FormClosingEventHandler(console_FormClosing);
        }

        public void AutoHostScript() {
            if (!Saves.autoStartBot || Saves.scriptPath == "") return;
            if (checkProcess() == "online") killJSBot();
            hostJSBot();
        }

        public void SetValues() {
            if (Saves.minimizeToTray) {
                notifyIcon.Visible = true;
                notifyIcon.ContextMenuStrip = trayContextMenu;
            } else notifyIcon.Visible = false;

            consoleForm.Text = Saves.scriptPath;
            if (checkProcess() == "online") SetTrayIcon();
            scriptGroupBox.Text = String.Format("{0} configuration", Saves.botNickname);
        }

        // Visual Studio methods //
        private void pushButton_Click(object sender, EventArgs e) {
            killJSBot();

            if (onlineButton.Checked) hostJSBot();
        }

        private void editButton_Click(object sender, EventArgs ev) {
           try {
                if (Saves.useDefaultEditor) Process.Start(Saves.scriptPath);
                else Process.Start(Saves.editorPath, Saves.scriptPath);
            } catch(InvalidOperationException e) {
                MessageBox.Show("Script directory not saved. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("{0}", e);
            } catch(Win32Exception e) {
                MessageBox.Show("Script editor is not valid. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("{0}", e);
            }
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (debugCheckBox.Checked) consoleForm.Show();
            else consoleForm.Hide();
        }

        private void statusRefresh_Tick(object sender, EventArgs e) {
            string name = Saves.botNickname;
            string status = checkProcess();

            if (status != StatusCache) {
                ChangeProcessStatus(status);
                StatusCache = status;
            }

            onlineStatusLabel.Text = String.Format("{0} is currently {1}!", name, status);
        }

        public void ChangeProcessStatus(string status) {
            if (!notifyIcon.Visible) return;

            if (status == "online") {
                if (notifyIcon.Icon != Properties.Resources.green) notifyIcon.Icon = Properties.Resources.green;
            } else {
                if (notifyIcon.Icon != Properties.Resources.red) notifyIcon.Icon = Properties.Resources.red;
            }
        }

        // system tray icon
        public void SetTrayIcon() {
            if (!notifyIcon.Visible) return;

            if (checkProcess() == "online" && notifyIcon.Icon != Properties.Resources.green) notifyIcon.Icon = Properties.Resources.green;
            if (checkProcess() == "offline" && notifyIcon.Icon != Properties.Resources.red) notifyIcon.Icon = Properties.Resources.red;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (Saves.minimizeToTray) {
                this.WindowState = FormWindowState.Normal;
                showToolStripMenuItem.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void mainWindow_Resize(object sender, EventArgs e) {
            if (Saves.minimizeToTray && this.WindowState == FormWindowState.Minimized) {
                showToolStripMenuItem.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e) {
            HandleConsoleForm(showWindowToolStripMenuItem.Checked);
        }

        private void HandleConsoleForm(bool visible) {
            if (visible) {
                consoleForm.Hide();
                debugCheckBox.Checked = false;
                showWindowToolStripMenuItem.Checked = false;
            } else {
                consoleForm.Show();
                debugCheckBox.Checked = true;
                showWindowToolStripMenuItem.Checked = true;
            }
        }

        private void clearOutputLogToolStripMenuItem_Click(object sender, EventArgs e) {
            ClearConsole();
        }

        // form1 menu strip
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            PreferencesForm pref = new PreferencesForm(Session, Saves);
            pref.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 about = new AboutBox1();
            about.labelVersion.Text = "Version " +version;
            about.textBoxDescription.Text = changes;
            about.ShowDialog();
        }

        private void goToGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/notmutiny/control-panel-GUI");
        }

        // form3 methods
        public void ClearConsole() {
            consoleForm.textBox2.Text = "";
        }

        // form close events
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (checkProcess() == "online" && Saves.autoStopBot) killJSBot();
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e) {
            debugCheckBox.Checked = false;
            consoleForm.Hide();
            e.Cancel = true;
        }

        // Custom methods //
        private string checkProcess() {
            Process[] node = Process.GetProcessesByName("node");

            foreach (Process proc in node) {
                if (proc.Id == Saves.processID) return "online";
            }

            return "offline";
        }

        private void hostJSBot() {
            if (Saves.scriptPath == "") {
                MessageBox.Show("Script directory not saved. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Saves.nodePath == "") {
                MessageBox.Show("Node directory not saved. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nodeThread = new Thread(new ThreadStart(ThreadProc));
            nodeThread.IsBackground = true;
            nodeThread.Start();
        }

        private void killJSBot() {
            Process[] node = Process.GetProcessesByName("node");

            if (node.Length <= 0) return;
            
            foreach (Process proc in node) {
                if (Saves.processID == proc.Id) {
                    proc.Kill();
                    break;
                }
            }
        }

        private void Display(string txt) {
            try {
                if (consoleForm.textBox2.InvokeRequired) {
                    StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(Display);
                    this.Invoke(d, new object[] { txt });
                } else {
                    consoleForm.textBox2.Text += txt + "\r\n";

                    consoleForm.textBox2.SelectionStart = consoleForm.textBox2.Text.Length;
                    consoleForm.textBox2.ScrollToCaret();
                }
            } catch (ObjectDisposedException e) {
                Console.WriteLine("You closed the program while it was writing text. Did it offend you in some way? {0}", e);
            }
        }

        public void ThreadProc() { //thread process
            try {
                ProcessStartInfo startInfo = new ProcessStartInfo(Saves.nodePath);
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;

                var proc = new Process();
                proc.StartInfo = startInfo;
                proc.EnableRaisingEvents = true;
                proc.OutputDataReceived += (sender, args) => this.Display(args.Data);
                proc.ErrorDataReceived += (sender, args) => this.Display(args.Data);
                proc.Start();

                Saves.processID = proc.Id;
                Console.WriteLine("Process ID saved as: {0}", proc.Id);
                Saves.Save();

                char[] array = Saves.scriptPath.ToCharArray();
                string patch = ""; //adds double backslashes to fix script directory

                foreach (char letter in array) {
                    if (letter == '\\') patch += '\\';
                    patch += letter;
                }

                var startCommand = String.Format("require('{0}').Start()", patch); // start the server after node has started
                StreamWriter myStreamWriter = proc.StandardInput;
                myStreamWriter.WriteLine(startCommand);
                myStreamWriter.Close();

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                proc.WaitForExit();
            } catch (InvalidOperationException e) {
                Console.WriteLine("how do you even error this {0}", e);
                //throw message box
            } catch (Win32Exception e) {
                Console.WriteLine("{0}", e);
                MessageBox.Show("Node directory is invalid. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
