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
    public partial class MainWindow : Form {

        private string version = "0.5.1";
        private string changes = "Changelog: \r\n\r\n" +
                                 "- added behavior groupbox"+
         /*  todo  */            "\r\n\r\n ヾ(＾∇＾)";                     
         /*  
         *  - clean threadproc
         *  
         *  - add fluff to debug form
         *  - add setting clean log every x changes
         *  - make form3 topmost toggle
         *  - add close with program option
         * 
         */

        public MainWindow Instance;

        private Thread nodeThread;
        private Debug consoleForm;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        public MainWindow() {
            InitializeComponent();
            Instance = this;

            SpawnConsole();            
            SetValues();

            if (checkServer() == "offline" && Properties.Settings.Default.autoStartBot) hostJSBot();
        }

        public void SpawnConsole() {
            consoleForm = new Debug();
            consoleForm.Text = Properties.Settings.Default.scriptPath;
            consoleForm.FormClosing += new FormClosingEventHandler(console_FormClosing);
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e) {
            debugCheckBox.Checked = false;
            consoleForm.Hide();
            e.Cancel = true;
        }

        public void SetValues() {
            var saves = Properties.Settings.Default;

            if (saves.minimizeToTray) notifyIcon.Visible = true;
            else notifyIcon.Visible = false;

            scriptGroupBox.Text = String.Format("{0} configuration", saves.botNickname);
            consoleForm.Text = Properties.Settings.Default.scriptPath;
        }

        // Visual Studio methods //
        private void pushButton_Click(object sender, EventArgs e) {
            killJSBot();

            if (onlineButton.Checked) hostJSBot();
        }

        private void editButton_Click(object sender, EventArgs e) {
            var saves = Properties.Settings.Default;

            try {
                if (saves.useDefaultEditor) Process.Start(saves.scriptPath);
                else Process.Start(saves.editorPath, saves.scriptPath);
            } catch(Win32Exception err) {
                MessageBox.Show("Cannot open script editor. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("{0}", err);
            }
        }

        private void mainWindow_Resize(object sender, EventArgs e) {
            if (Properties.Settings.Default.minimizeToTray && this.WindowState == FormWindowState.Minimized) {
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (Properties.Settings.Default.minimizeToTray) {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            PreferencesForm pref = new PreferencesForm(Instance);
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

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (debugCheckBox.Checked) consoleForm.Show();
            else consoleForm.Hide();
        }

        private void statusTimer_Tick(object sender, EventArgs e) {
            string nickname = Properties.Settings.Default.botNickname;
            if (nickname.Length > 10) nickname = nickname.Substring(0, 11);

            onlineStatusLabel.Text = String.Format("{0} is currently {1}!", nickname, checkServer());
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
            if (Properties.Settings.Default.scriptPath == "") {
                MessageBox.Show("Script directory not saved. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Properties.Settings.Default.nodePath == "") {
                MessageBox.Show("Node directory not saved. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            nodeThread = new Thread(new ThreadStart(ThreadProc));
            nodeThread.IsBackground = true;
            nodeThread.Start();
        }

        private void killJSBot() {
            Process[] node = Process.GetProcessesByName("node");

            if (node.Length > 0) {
                foreach (Process proc in node) {
                    if (Properties.Settings.Default.processID == proc.Id) {
                        proc.Kill();
                        break;
                    }
                }
            }
        }

        private void Display(string txt) {
            if (consoleForm.textBox2.InvokeRequired) {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(Display);
                this.Invoke(d, new object[] { txt });
            } else {
                consoleForm.textBox2.Text += txt + "\r\n";

                consoleForm.textBox2.SelectionStart = consoleForm.textBox2.Text.Length;
                consoleForm.textBox2.ScrollToCaret();
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
