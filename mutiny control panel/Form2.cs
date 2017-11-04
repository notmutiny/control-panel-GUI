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
        private bool useDefaultEditor;

        public preferencesForm() {
            InitializeComponent();
            RestoreSettings();
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

        private void findScriptEditorButton_Click(object sender, EventArgs e) {
            OpenFileDialog editor = new OpenFileDialog();
            editor.InitialDirectory = "c:\\";
            editor.Filter = "Executable files (*.exe)|*.exe";
            if (editor.ShowDialog() == DialogResult.OK) {
                customScriptEditorButton.Checked = true;
                customEditorPathText.Text = editor.FileName;
            }
        }

        private void defaultScriptEditorButton_CheckedChanged(object sender, EventArgs e) {

        }

        private void customScriptEditorButton_CheckedChanged(object sender, EventArgs e) {
            if (customScriptEditorButton.Checked == true) {
                useDefaultEditor = false;
                customEditorPathText.ReadOnly = false;
            } else {
                useDefaultEditor = true;
                customEditorPathText.ReadOnly = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            if (scriptPathText.Text != Properties.Settings.Default.scriptPath) {
                Properties.Settings.Default.scriptPath = scriptPathText.Text;
            }
            if (customEditorPathText.Text != Properties.Settings.Default.editorCustomPath) {
                Properties.Settings.Default.editorCustomPath = customEditorPathText.Text;
            }
            if (useDefaultEditor != Properties.Settings.Default.useDefaultEditor) {
                Properties.Settings.Default.useDefaultEditor = useDefaultEditor;
            }
            Properties.Settings.Default.Save();
            this.Hide();
        }

        private void RestoreSettings() {
            if (Properties.Settings.Default.scriptPath != "") {
                scriptPathText.Text = Properties.Settings.Default.scriptPath;
            }
            if (Properties.Settings.Default.editorCustomPath != "") {
                customEditorPathText.Text = Properties.Settings.Default.editorCustomPath;
            }
            useDefaultEditor = Properties.Settings.Default.useDefaultEditor;
            if (useDefaultEditor) {
                defaultScriptEditorButton.Checked = true;
            } else {
                customScriptEditorButton.Checked = true;
            }
        }
    }
}
