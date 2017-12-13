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

namespace mutiny_control_panel {
    public partial class mainWindow : Form {

        private string version = "0.4.3";

        /*  todo
         *  
         *  - clean and add to console output ui
         *  - fix threadproc hardcode
         *  - add setting script > clean log every i changes
         *
         */

        private bool pushOnline;

        private Debug console;
        private Thread nodeThread;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        // Visual Studio methods //
        public mainWindow() {
            InitializeComponent();
            spawnConsole();
        }

        private void spawnConsole() {
            console = new Debug();
            console.FormClosing += new FormClosingEventHandler(console_FormClosing);
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e) {
            console.Hide();
            debugCheckBox.Checked = false;
            e.Cancel = true;
        }

        private void onlineButton_CheckedChanged(object sender, EventArgs e) {
            pushOnline = true;
        }

        private void offlineButton_CheckedChanged(object sender, EventArgs e) {
            pushOnline = false;
        }

        private void editButton_Click(object sender, EventArgs e) {
            try {
                if (Properties.Settings.Default.useDefaultEditor) Process.Start(Properties.Settings.Default.scriptPath);
                else Process.Start(Properties.Settings.Default.editorPath, Properties.Settings.Default.scriptPath);
            } catch {
                MessageBox.Show("Cannot edit script, configure Settings > Preferences", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pushButton_Click(object sender, EventArgs e) {
            killJSBot();

            if (pushOnline) {
                if (Properties.Settings.Default.scriptPath == "") {
                    MessageBox.Show("Script directory not saved, configure Settings > Preferences", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Properties.Settings.Default.nodePath == "") {
                    MessageBox.Show("Node directory not saved, configure Settings > Preferences", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hostJSBot();
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            preferencesForm pref = new preferencesForm();
            pref.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 about = new AboutBox1();
            about.labelVersion.Text = "Version " + version;
            about.ShowDialog();
        }

        private void goToGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/notmutiny/control-panel-GUI");
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (debugCheckBox.Checked) console.Show();
            else console.Hide();
        }

        private void statusTimer_Tick(object sender, EventArgs e) {
            onlineStatusLabel.Text = "mutiny bot is currently " + checkServer() + "!";
        }

        // custom methods //
        private string checkServer() {
            Process[] node = Process.GetProcessesByName("node");
            
            foreach (Process proc in node) {
                if (proc.Id == Properties.Settings.Default.processID) return "online";
            }

            return "offline";
        }

        private void hostJSBot() {
            nodeThread = new Thread(new ThreadStart(ThreadProc));
            nodeThread.Start();
        }

        private void killJSBot() {
            Process[] node = Process.GetProcessesByName("node");

            if (node.Length > 0) {
                foreach (Process process in node) {
                    if (process.Id == Properties.Settings.Default.processID) {
                        process.Kill();
                        break;
                    }
                }
            }
        }

        private void Display(string txt) {
            if (console.textBox2.InvokeRequired) {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(Display);
                this.Invoke(d, new object[] { txt });
            } else {
                console.textBox2.Text += txt + "\r\n";

                console.textBox2.SelectionStart = console.textBox2.Text.Length;
                console.textBox2.ScrollToCaret();
            }
        }

        public void ThreadProc() { //thread process
            try {
                ProcessStartInfo startInfo = new ProcessStartInfo(Properties.Settings.Default.nodePath);
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

                Properties.Settings.Default.processID = proc.Id;
                Console.WriteLine("Process ID saved as: {0}", proc.Id);
                Properties.Settings.Default.Save();

                char[] array = Properties.Settings.Default.scriptPath.ToCharArray();
                string patch = ""; //adds double backslashes to allow script directory

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
                Console.WriteLine("{0}", e);
                //throw message box
            }
        }
    }
}
