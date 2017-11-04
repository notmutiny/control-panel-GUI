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
            Process[] node = Process.GetProcessesByName("node");
            if (onlineEnabled == true) {
                if (checkServer() == "online") {
                    node[0].Kill();
                    Process.Start("C:/Program Files/nodejs/node.exe", "D:/Library/Projects/Coding/Discord/mutiny_bot/mybot.js"); // replace with persistant settings
                } else {
                    Process.Start("C:/Program Files/nodejs/node.exe", "D:/Library/Projects/Coding/Discord/mutiny_bot/mybot.js"); // ^
                }
            } else {
                if (checkServer() == "offline") {
                    return;
                } else {
                    node[0].Kill();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e) {

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
    }
}
