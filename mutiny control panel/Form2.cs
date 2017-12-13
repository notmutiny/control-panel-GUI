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
            restoreSettings();

            toolTip1.SetToolTip(programAutoStartCheckbox, "not working bcuz lazy");
        }

        private void restoreSettings() { // rebuild panel here
            if (Properties.Settings.Default.editorPath != "")
                editorDirectoryTextbox.Text = Properties.Settings.Default.editorPath;

            if (Properties.Settings.Default.scriptPath != "") {
                scriptPathText.Text = Properties.Settings.Default.scriptPath;
                scriptPathText.BackColor = Color.White;
            }

            if (Properties.Settings.Default.nodePath != "") {
                string text = Properties.Settings.Default.nodePath;
                nodePathText.Text = text;
  
                if (text.Substring(text.Length - 8, 8) == "node.exe" || text.Substring(text.Length - 9, 8) == "node.exe") {
                    nodePathText.BackColor = Color.White;
                } else nodePathText.BackColor = SystemColors.Control;
            }

            //script settings
            botStartupCheckbox.Checked = Properties.Settings.Default.autoStartBot;
            editorDirectoryTextbox.Text = Properties.Settings.Default.editorPath;

            useDefaultEditor = Properties.Settings.Default.useDefaultEditor;
            if (useDefaultEditor) defaultScriptEditorButton.Checked = true;
            else customScriptEditorButton.Checked = true;

            //program settings
            botnameTextBox.Text = Properties.Settings.Default.botNickname;
        }

        private void saveButton_Click_1(object sender, EventArgs e) { // save persistant settings here
            if (scriptPathText.Text != Properties.Settings.Default.scriptPath) Properties.Settings.Default.scriptPath = scriptPathText.Text;
            if (editorDirectoryTextbox.Text != Properties.Settings.Default.editorPath) Properties.Settings.Default.editorPath = editorDirectoryTextbox.Text;
            if (useDefaultEditor != Properties.Settings.Default.useDefaultEditor) Properties.Settings.Default.useDefaultEditor = useDefaultEditor;
            if (nodePathText.Text != Properties.Settings.Default.nodePath) Properties.Settings.Default.nodePath = nodePathText.Text;
            if (botStartupCheckbox.Checked != Properties.Settings.Default.autoStartBot) Properties.Settings.Default.autoStartBot = botStartupCheckbox.Checked;

            if (botnameTextBox.Text != "" && botnameTextBox.Text != Properties.Settings.Default.botNickname) Properties.Settings.Default.botNickname = botnameTextBox.Text;

            Properties.Settings.Default.Save();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void findScriptButton_Click(object sender, EventArgs e) {
            OpenFileDialog script = new OpenFileDialog();
            script.InitialDirectory = "c:\\";
            script.Filter = "Javascript files (*.js)|*.js";
            if (script.ShowDialog() == DialogResult.OK) {
                scriptPathText.Text = script.FileName;
                if (script.FileName != "") scriptPathText.BackColor = Color.White;
                else scriptPathText.BackColor = SystemColors.Control;
            }
        }

        private void findScriptEditorButton_Click_1(object sender, EventArgs e) {
            OpenFileDialog editor = new OpenFileDialog();
            editor.InitialDirectory = "c:\\";
            editor.Filter = "Executable files (*.exe)|*.exe";
            if (editor.ShowDialog() == DialogResult.OK) {
                customScriptEditorButton.Checked = true;
                editorDirectoryTextbox.Text = editor.FileName;
            }
        }

        private void findNodeButton_Click_1(object sender, EventArgs e) {
            OpenFileDialog node = new OpenFileDialog();
            node.InitialDirectory = "c:\\";
            node.Filter = "node.exe|*.exe";
            if (node.ShowDialog() == DialogResult.OK) {
                nodePathText.Text = node.FileName;

                var text = nodePathText.Text;
                if (text.Substring(text.Length - 8, 8) == "node.exe" || text.Substring(text.Length - 9, 8) == "node.exe") {
                    nodePathText.BackColor = Color.White;
                } else nodePathText.BackColor = SystemColors.Control;
            }
        }

        private void customScriptEditorButton_CheckedChanged(object sender, EventArgs e) {
            if (customScriptEditorButton.Checked == true) {
                useDefaultEditor = false;
                editorDirectoryTextbox.BackColor = Color.White;
            } else {
                useDefaultEditor = true;
                editorDirectoryTextbox.BackColor = SystemColors.Control;
            }
        }

        private void botnameTextBox_TextChanged(object sender, EventArgs e) {
            if (botnameTextBox.Text != "") botnameTextBox.BackColor = Color.White;
            else botnameTextBox.BackColor = SystemColors.Control;
        }
    }
}
