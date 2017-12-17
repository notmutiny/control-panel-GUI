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
using Microsoft.Win32;

namespace mutiny_control_panel {
    public partial class MainWindow : Form {

        private string version = "0.5.7.1";  
        private string changes = "Changelog: \r\n\r\n" +
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

        public MainWindow Instance;
        public string ProgramName;
        public bool BotStatsCache;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        public MainWindow(string constname) {
            InitializeComponent();
            Instance = this;

            ProgramName = constname;
            this.Text = ProgramName;

            AutoHostScript();
            SpawnConsole();            
            SetValues();
        }

        public void SpawnConsole() {
            consoleForm = new Debug();
            consoleForm.Text = Properties.Settings.Default.scriptPath;
            consoleForm.FormClosing += new FormClosingEventHandler(console_FormClosing);
        }

        public void AutoHostScript() {
            var saves = Properties.Settings.Default;

            if (!saves.autoStartBot || saves.scriptPath == "") return;
            if (checkProcess() == "online") killJSBot();
            hostJSBot();
        }

        public void SetValues() {
            var saves = Properties.Settings.Default;

            scriptGroupBox.Text = String.Format("{0} configuration", saves.botNickname);

            if (saves.minimizeToTray) {
                notifyIcon.Visible = true;
                notifyIcon.ContextMenuStrip = trayContextMenu;
            } else notifyIcon.Visible = false;

            consoleForm.Text = saves.scriptPath;
        }

        // Visual Studio methods //
        private void pushButton_Click(object sender, EventArgs e) {
            killJSBot();

            if (onlineButton.Checked) hostJSBot();
        }

        private void editButton_Click(object sender, EventArgs ev) {
            var saves = Properties.Settings.Default;

           try {
                if (saves.useDefaultEditor) Process.Start(saves.scriptPath);
                else Process.Start(saves.editorPath, saves.scriptPath);
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
            string nickname = Properties.Settings.Default.botNickname;
            string status = checkProcess();
            SetTrayIcon();

            onlineStatusLabel.Text = String.Format("{0} is currently {1}!", nickname, status);
        }

        // system tray icon
        public void SetTrayIcon() {
            if (!notifyIcon.Visible) return;

            if (checkProcess() == "online" && notifyIcon.Icon != Properties.Resources.green) notifyIcon.Icon = Properties.Resources.green;
            if (checkProcess() == "offline" && notifyIcon.Icon != Properties.Resources.red) notifyIcon.Icon = Properties.Resources.red;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (Properties.Settings.Default.minimizeToTray) {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private void mainWindow_Resize(object sender, EventArgs e) {
            if (Properties.Settings.Default.minimizeToTray && this.WindowState == FormWindowState.Minimized) {
                this.ShowInTaskbar = false;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void showScriptOutputToolStripMenuItem_Click(object sender, EventArgs e) {
            if (!consoleForm.Visible) {
                consoleForm.Show();
                debugCheckBox.Checked = true;
            }
        }

        // form1 menu strip
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

        // form close events
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            if (checkProcess() == "online" && Properties.Settings.Default.autoStopBot) killJSBot();
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

            if (node.Length <= 0) return;
            
            foreach (Process proc in node) {
                if (Properties.Settings.Default.processID == proc.Id) {
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
