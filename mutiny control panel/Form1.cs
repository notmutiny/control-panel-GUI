using System;
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
        /*  todo
            - tie log checkbox to form3 visibility
            - clean and add to console output ui
        */

        // Visual Studio methods //
        public Debug console;

        private Thread nodeThread;
        private bool onlineEnabled;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

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
            e.Cancel = true; // this cancels the close event.
        }

        private void onlineButton_CheckedChanged(object sender, EventArgs e) {
            onlineEnabled = true;
        }

        private void offlineButton_CheckedChanged(object sender, EventArgs e) {
            onlineEnabled = false;
        }

        private void editButton_Click(object sender, EventArgs e) {
            try {
                if (Properties.Settings.Default.useDefaultEditor) Process.Start(Properties.Settings.Default.scriptPath);
                else Process.Start(Properties.Settings.Default.editorCustomPath, Properties.Settings.Default.scriptPath);
            } catch {
                MessageBox.Show("Did you configure settings > preferences?", "Error! Cannot open for editing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pushButton_Click(object sender, EventArgs e) {
            if (Properties.Settings.Default.scriptPath == "") {
                MessageBox.Show("Did you configure settings > preferences?", "Error! Script directory not set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Properties.Settings.Default.nodePath == "") {
                MessageBox.Show("Did you configure settings > preferences?", "Error! Node directory not set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (onlineEnabled) {
                killJSBot();
                hostJSBot();
            } else killJSBot();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            preferencesForm pref = new preferencesForm();
            pref.ShowDialog();
        }

        private void goToGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/notmutiny/control-panel-GUI");
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (debugCheckBox.Checked) console.Show();
            else console.Hide(); //fix disposed error
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

                var startCommand = "require('D:/Library/Projects/Coding/Discord/mutiny_bot/mybot.js').Start()"; // start the server after node has started
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
