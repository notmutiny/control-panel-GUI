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

        // visual studio data
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

        private void pushButton_Click(object sender, EventArgs e) {
            //Process[] node = Process.GetProcessesByName("node");
            hostJavascriptBot();
            //if (onlineEnabled == true) {
            //    try {
            //        if (checkServer() == "online") {
            //            node[0].Kill();
            //            Process.Start(Properties.Settings.Default.nodePath, Properties.Settings.Default.scriptPath);
            //        } else {
            //            Process.Start(Properties.Settings.Default.nodePath, Properties.Settings.Default.scriptPath);
            //        }
            //    } catch {
            //        MessageBox.Show("Cannot connect with with node. Is your path to node.exe correct?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //} else {
            //    if (checkServer() == "offline") {
            //        return;
            //    } else {
            //        node[0].Kill();
            //    }
            //}
        }

        private void editButton_Click(object sender, EventArgs e) {
            try {
                if (Properties.Settings.Default.useDefaultEditor) {
                    Process.Start(Properties.Settings.Default.scriptPath);
                } else {
                    Process.Start(Properties.Settings.Default.editorCustomPath, Properties.Settings.Default.scriptPath);
                }
            } catch {
                MessageBox.Show("Script cannot be opened for editing. Is your text editor set up correctly?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            preferencesForm pref = new preferencesForm();
            pref.Show();
        }

        private void goToGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/notmutiny/control-panel-GUI");
        }

        private void statusTimer_Tick(object sender, EventArgs e) {
            updateServerStatus();
        }

        // custom functions
        private void updateServerStatus() {
            onlineStatusLabel.Text = "mutiny bot is currently " + checkServer() + "!";
        }

        private string checkServer() {
            Process[] node = Process.GetProcessesByName("node");
            string onlineStatus;
            if (node.Length > 0) {
                onlineStatus = "online";
            } else {
                onlineStatus = "offline";
            }
            return onlineStatus;
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (debugCheckBox.Checked) {
                debugEnabled = true;
            } else {
                debugEnabled = false;
            }
        }

        // TODO

            // substring cmd directory from script save
            // rename variables

        private void hostJavascriptBot() {
            Process[] node = Process.GetProcessesByName("node");
            Process[] cmd = Process.GetProcessesByName("cmd");
            if (onlineEnabled == true) {
                if (node.Length > 0) {
                    node[0].Kill();
                }
                if (cmd.Length > 0) {
                    cmd[0].Kill();
                }
                if (debugEnabled) {
                    ProcessStartInfo prompt = new ProcessStartInfo("cmd.exe");
                    prompt.WorkingDirectory = "D:/Library/Projects/Coding/Discord/mutiny_bot";
                    prompt.Arguments = "/k node .";
                    try {
                        Process.Start(prompt);
                    } catch {
                        MessageBox.Show("Cannot launch cmd.exe.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    try {
                        Process.Start(Properties.Settings.Default.nodePath, Properties.Settings.Default.scriptPath);
                    } catch {
                        MessageBox.Show("Cannot connect with with node. Is your path to node.exe correct?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                if (node.Length > 0) {
                    node[0].Kill();
                } else if (cmd.Length > 0) {
                    cmd[0].Kill();
                } else {
                    return;
                }
            }
        }


            //try {
            //    if (debugEnabled) {
            //        if (checkServer() == "online") {

            //        }
            //    }


            //if (checkServer() == "online") {
            //    node[0].Kill();
            //    Process.Start(Properties.Settings.Default.nodePath, Properties.Settings.Default.scriptPath);
            //} else {
            //    Process.Start(Properties.Settings.Default.nodePath, Properties.Settings.Default.scriptPath);
            //}
            //        } catch {
            //            MessageBox.Show("Cannot connect with with node. Is your path to node.exe correct?", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    } else {
            //        if (checkServer() == "offline") {
            //            return;
            //        } else {
            //            node[0].Kill();
            //        }
            //    }
            //}


            //if (debugEnabled) {
            //    Process.Start("cmd.exe", "d: && cd D:/Library/Projects/Coding/Discord/mutiny_bot && . node");
            //} else {

            //}
    }
}
