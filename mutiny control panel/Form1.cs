﻿using System;
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

        private void pushButton_Click(object sender, EventArgs e) {
            Process[] node = Process.GetProcessesByName("node");
            Process[] cmd = Process.GetProcessesByName("cmd");
            if (onlineEnabled) {
                hostJavascriptBot(node, cmd);
            } else {
                killJavascriptBot(node, cmd);
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            preferencesForm pref = new preferencesForm();
            pref.ShowDialog();
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

        private string getBotFolder() { // this removes file path so cmd can cd into the directory
            string path = Properties.Settings.Default.scriptPath;
            int cache = 0;
            if (path != "") {
                for (int i = path.Length - 1; i >= 0; i--) {
                    if (i != path.Length - 1) {
                        if (path.Substring(i, 1) == "\\" || path.Substring(i, 1) == "/") {
                            cache = i;
                            break;
                        }
                    }
                }
                Console.WriteLine("Bot directory found: " + path.Substring(0, cache));
                return path.Substring(0, cache);
            } else {
                Console.WriteLine("Error finding bot directory");
                return "nil";
            }
        }

        private void hostJavascriptBot(Process[] node, Process[] cmd) {
            if (node.Length > 0) {
                node[0].Kill();
            }
            if (cmd.Length > 0) {
                cmd[0].Kill();
            }
            if (getBotFolder() == "nil") {
                MessageBox.Show("Script location not set. Did you configure settings > preferences?", "CMD.exe error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (debugEnabled) {
                ProcessStartInfo prompt = new ProcessStartInfo("cmd.exe");
                prompt.WorkingDirectory = getBotFolder();
                prompt.Arguments = "/k node .";
                try {
                    Process.Start(prompt);
                } catch {
                    MessageBox.Show("Cannot launch command prompt.", "CMD error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                try {
                    Process.Start(Properties.Settings.Default.nodePath, Properties.Settings.Default.scriptPath);
                } catch {
                    MessageBox.Show("Cannot connect with with node. Is your node.exe path correct?", "Node error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void killJavascriptBot(Process[] node, Process[] cmd) {
            if (node.Length > 0 || cmd.Length > 0) {
                node[0].Kill();
                cmd[0].Kill();
            } else return;
        }
    }
}
