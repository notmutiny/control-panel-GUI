using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mutiny_control_panel {
    public partial class preferencesForm : Form {
        public preferencesForm() {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e) {

        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Hide();
        }

        private void findScriptButton_Click(object sender, EventArgs e) {
            OpenFileDialog script = new OpenFileDialog();
            script.InitialDirectory = "c:\\";
            script.Filter = "Javascript files (*.js)|*.js";
            if (script.ShowDialog() == DialogResult.OK) {
                scriptPathText.Text = script.FileName;
            }
        }

        private void customScriptEditorButton_CheckedChanged(object sender, EventArgs e) {
            if (customScriptEditorButton.Checked == true) {
                customEditorPathText.ReadOnly = false;
            } else {
                customEditorPathText.ReadOnly = true;
            }
        }
    }
}
