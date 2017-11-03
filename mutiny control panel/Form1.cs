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
        public mainWindow() {
            InitializeComponent();
        }

        private void onlineButton_CheckedChanged(object sender, EventArgs e) {

        }

        private void offlineButton_CheckedChanged(object sender, EventArgs e) {

        }

        private void pushButton_Click(object sender, EventArgs e) {

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
    }
}
