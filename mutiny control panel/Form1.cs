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

/* todo
 *  - clean form1, modulate functions to provide better checks
 *  
 *  - add fluff to debug form
 *  - add setting clean log every x changes
 *  - make form3 topmost toggle
 */

namespace mutiny_control_panel {
    public partial class MainWindow : Form {

        private string version = "0.5.9.2";
        private string changes = "Changelog: \r\n\r\n" +
                                 " - added open directory button \r\n" +
                                 " - colorized tray icon for hosting \r\n" +
                                 " - probably random bug fixes \r\n" +
                                 "\r\n ヾ(＾∇＾)";

        private Debug consoleForm; // form3 reference
        private Thread nodeThread; // node.exe thread

        public MainWindow Session; // winform context
        public string StatusCache; // (on / off) line 
        public string ProgramName; // parent assigned

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        public MainWindow(string constname) {
            InitializeComponent();
            Session = this;

            // set global variables
            StatusCache = "offline";
            ProgramName = constname;
            this.Text = ProgramName;

            // start methods
            AutoHostScript();
            SpawnConsole();
            RestorePrefs();
        }

        public void AutoHostScript() {
            // automatically start script on launch if preferences set
            if (!Saves.autoStartBot || Saves.scriptPath == "") return;
            if (checkProcess() == "online") killJSBot();
            hostJSBot();
        }

        public void SpawnConsole() {
            // starts console winform
            consoleForm = new Debug();
            consoleForm.Text = Saves.scriptPath;
            consoleForm.FormClosing += new FormClosingEventHandler(console_FormClosing);
        }

        public void RestorePrefs() {
            // apply preference variables
            if (Saves.minimizeToTray) {
                notifyIcon.Visible = true;
                notifyIcon.ContextMenuStrip = trayContextMenu;
            } else notifyIcon.Visible = false;

            // set form3 header to scripts path
            consoleForm.Text = Saves.scriptPath;

            // double check status to make sure its not a leftover
            if (checkProcess() == "online") ChangeProcessStatus();

            // ui fluff that changes nickname of bot in this form
            scriptGroupBox.Text = String.Format("{0} configuration", Saves.botNickname);
        }


        //* control panel methods *//

        private void pushButton_Click(object sender, EventArgs e) {
            // kill bot to restart and push any chances
            if (StatusCache == "online") killJSBot(); 
            if (onlineButton.Checked) hostJSBot();
        }

        private void editButton_Click(object sender, EventArgs ev) {
            try {
                // open script editor, default or user specified application
                if (Saves.useDefaultEditor) Process.Start(Saves.scriptPath);
                else Process.Start(Saves.editorPath, Saves.scriptPath);
            } catch (InvalidOperationException e) {
                MessageBox.Show("Script directory not saved. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // wtf add a script directory
                Console.WriteLine("{0}", e);
            } catch (Win32Exception e) {
                MessageBox.Show("Script editor is not valid. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // why are you doing this D:
                Console.WriteLine("{0}", e);
            }
        }

        private void openDirButton_Click(object sender, EventArgs e) {
            // just opens parent directory of script
            string path = GenerateScriptDirectory();

            if (path != "") try {
                Process.Start(path);
            } catch (Win32Exception err) {
                Console.WriteLine("{0}: Error opening file path", err);
            }
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            // show / hide console form on checkbox clicks
            if (debugCheckBox.Checked) consoleForm.Show();
            else consoleForm.Hide();

            // update toolbar context menu to show current visibility
            if (showWindowToolStripMenuItem.Checked != debugCheckBox.Checked) showWindowToolStripMenuItem.Checked = debugCheckBox.Checked;
        }

        private void statusRefresh_Tick(object sender, EventArgs e) {
            // called at every tick (100 ms)
            string name = Saves.botNickname;
            string status = checkProcess();

            if (status != StatusCache) {
                // update online status
                ChangeProcessStatus();
                StatusCache = status;
            }

            // I should really move this into the above if statement
            onlineStatusLabel.Text = String.Format("{0} is currently {1}!", name, status);
        }


        //* tray icon methods *//

        // show window system tray context option
        public void ShowMainWindow(bool visible) {
            if (visible) { // minimize to taskbar if true
                this.WindowState = FormWindowState.Normal;
                showToolStripSeparator1.Visible = false;
                showToolStripMenuItem.Visible = false;
                this.ShowInTaskbar = true;
            } else if (WindowState == FormWindowState.Minimized) {
                showToolStripSeparator1.Visible = true;
                showToolStripMenuItem.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        public void ChangeProcessStatus() {
            // update tray icon status color
            if (!notifyIcon.Visible) return;

            if (checkProcess() == "online") {
                if (notifyIcon.Icon != Properties.Resources.green) notifyIcon.Icon = Properties.Resources.green;
                if (!scriptOnlineToolStripMenuItem.Checked) scriptOnlineToolStripMenuItem.Checked = true;
            } else {
                if (notifyIcon.Icon != Properties.Resources.red) notifyIcon.Icon = Properties.Resources.red;
                if (scriptOnlineToolStripMenuItem.Checked) scriptOnlineToolStripMenuItem.Checked = false;
            }

            // updates tray context menu option
            scriptOfflineToolStripMenuItem.Checked = !scriptOnlineToolStripMenuItem.Checked;
        }

        // (these are self explanatory)
        private void scriptOnlineToolStripMenuItem_Click(object sender, EventArgs e) {
            if (StatusCache == "online") killJSBot();
            hostJSBot();
        }

        private void scriptOfflineToolStripMenuItem_Click(object sender, EventArgs e) {
            killJSBot();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            ShowMainWindow(true);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowMainWindow(true);
        }

        private void mainWindow_Resize(object sender, EventArgs e) {
            if (Saves.minimizeToTray) ShowMainWindow(false);
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

        private void topmostWindowToolStripMenuItem_Click(object sender, EventArgs e) {
            if (topmostWindowToolStripMenuItem.Checked) {
                consoleForm.TopLevel = false;
                topmostWindowToolStripMenuItem.Checked = false;
            } else {
                consoleForm.TopLevel = true;
                topmostWindowToolStripMenuItem.Checked = true;
            }
        }


        //* form1 menu strip *//

        private void openScriptToolStripMenuItem_Click(object sender, EventArgs e) {
            // open script and update saves
            string path = SetScriptPath();
            if (path == "") return;

            Saves.scriptPath = path;
            RestorePrefs();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            PreferencesForm pref = new PreferencesForm(Session, Saves);
            pref.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            AboutBox1 about = new AboutBox1();
            about.labelVersion.Text = "Version " + version;
            about.textBoxDescription.Text = changes;
            about.ShowDialog();
        }

        private void goToGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/notmutiny/control-panel-GUI");
        }


        //* form3 methods *//

        public void ClearConsole() {
            consoleForm.textBox2.Text = "";
        }


        //* form close events *//

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            // automatically kills script hosted by node if program is closed 
            if (checkProcess() == "online" && Saves.autoStopBot) killJSBot();
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e) {
            // update form values on close
            debugCheckBox.Checked = false;
            consoleForm.Hide();
            e.Cancel = true;
        }

        //* data processing methods *//

        public string SetScriptPath() {
            // opens explorer for user to select js file
            OpenFileDialog script = new OpenFileDialog();
            var path = GenerateScriptDirectory();

            if (path != "") script.InitialDirectory = path;
            else script.InitialDirectory = "c:\\";
            script.Filter = "Javascript files (*.js)|*.js";

            if (script.ShowDialog() == DialogResult.OK) {
                Saves.scriptPath = script.FileName;
                RestorePrefs();
                return script.FileName;
            } else return "";
        }

        public string GenerateScriptDirectory() {
            // delete file from path for directory
            string path = Saves.scriptPath;

            if (path != "") {
                for (int i = path.Length - 2; i > 0; i--) {
                    if (path[i] == '\\' || path[i] == '/') {
                        return path.Substring(0, i);
                    }
                }
            }

            return "";
        }

        private string checkProcess() {
            // check if node process is running (which is host)
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
            try { // puts text to console via black magic
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
                // start hosting node in this giant method im not going to comment
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
                string patch = ""; // adds double backslashes to fix script directory

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
            } catch (Win32Exception e) {
                Console.WriteLine("{0}", e);
                MessageBox.Show("Node directory is invalid. Settings > Preferences > Script settings", "Script error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
