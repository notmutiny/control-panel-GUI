using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mutiny_control_panel {
    public partial class mainWindow : Form {
        /*  todo
            - get process by id
            - rework functions to only handle our processes
        */

        // Visual Studio methods //
        private bool onlineEnabled;
        private bool debugEnabled;

        public mainWindow() {
            InitializeComponent();
        }

        private void onlineButton_CheckedChanged(object sender, EventArgs e) {
            onlineEnabled = true;
        }

        private void offlineButton_CheckedChanged(object sender, EventArgs e) {
            onlineEnabled = false;
        }

        private void editButton_Click(object sender, EventArgs e) {
            try {
                if (Properties.Settings.Default.useDefaultEditor)
                    Process.Start(Properties.Settings.Default.scriptPath);
                else
                    Process.Start(Properties.Settings.Default.editorCustomPath, Properties.Settings.Default.scriptPath);
            } catch {
                MessageBox.Show("Editor cannot be opened. Did you configure settings > preferences?", "Script editor error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pushButton_Click(object sender, EventArgs e) {
            Process[] node = Process.GetProcessesByName("node");
            Process[] cmd = Process.GetProcessesByName("cmd");

            if (onlineEnabled) hostJSBot(node, cmd);
            else killJSBot(node, cmd); //need to add cmd functionality
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            preferencesForm pref = new preferencesForm();
            pref.ShowDialog();
        }

        private void goToGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/notmutiny/control-panel-GUI");
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (debugCheckBox.Checked) {
                debugEnabled = true;
            } else {
                debugEnabled = false;
            }
        }

        private void statusTimer_Tick(object sender, EventArgs e) {
            updateBotStatus();
        }

        // custom methods //
        private void updateBotStatus() {
            onlineStatusLabel.Text = "mutiny bot is currently "+checkServer()+"!";
        }

        private string checkServer() {
            Process[] node = Process.GetProcessesByName("node");
            Process[] cmd = Process.GetProcessesByName("cmd");
            
            foreach (Process proc in node) {
                if (proc.Id == Properties.Settings.Default.processID) return "online";
            }

            foreach (Process proc in cmd) {
                if (proc.Id == Properties.Settings.Default.processID) return "online";
            }

            return "offline";
        }

        private string getBotFolder() { // this removes file path so cmd can cd into the directory
            string path = Properties.Settings.Default.scriptPath;
            int cache = 0;
            if (path == "") return "";
            else {
                for (int i = path.Length - 1; i >= 0; i--) {
                    if (i != path.Length - 1) {
                        if (path.Substring(i, 1) == "\\" || path.Substring(i, 1) == "/") {
                            cache = i;
                            Console.WriteLine("Bot directory found: " + path.Substring(0, cache));
                            return path.Substring(0, cache);
                        }
                    }
                }
                return "";
            }
        }

        private void hostJSBot(Process[] node, Process[] cmd) {
            if (Properties.Settings.Default.scriptPath == "") {
                MessageBox.Show("Script location not set. Did you configure settings > preferences?", "File path error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmd.Length > 0) { //bug, cant kill cmd with kill(),
                foreach (Process proc in cmd) {
                    if (proc.Id == Properties.Settings.Default.processID) return;
                }
            }

            killJSBot(node, cmd);

            try {
                if (debugEnabled) {
                    ProcessStartInfo cmdClient = new ProcessStartInfo("cmd.exe");

                    cmdClient.Arguments = "/k node .";
                    cmdClient.WorkingDirectory = getBotFolder();

                    Process cmdProcess = Process.Start(cmdClient);
                    Console.WriteLine("process id saved " + cmdProcess.Id);
                    Properties.Settings.Default.processID = cmdProcess.Id;
                } else {
                    ProcessStartInfo nodeClient = new ProcessStartInfo(Properties.Settings.Default.nodePath);

                    nodeClient.Arguments = Properties.Settings.Default.scriptPath;
                    nodeClient.WindowStyle = ProcessWindowStyle.Hidden;

                    Process nodeProcess = Process.Start(nodeClient);
                    Console.WriteLine("process id saved " + nodeProcess.Id);
                    Properties.Settings.Default.processID = nodeProcess.Id;
                }
            } catch {
                MessageBox.Show("Cannot host bot. Did you configure settings > preferences?", "Node.exe error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Properties.Settings.Default.Save();
        }

        private void killJSBot(Process[] node, Process[] cmd) {
            if (cmd.Length > 0) {
                foreach (Process process in cmd) {
                    if (process.Id == Properties.Settings.Default.processID) {
                        process.Kill();
                        break;
                    }
                }
            }

            if (node.Length > 0) {
                foreach (Process process in node) {
                    if (process.Id == Properties.Settings.Default.processID) {
                        process.Kill();
                        break;
                    }
                }
            }
        }
    }
}
