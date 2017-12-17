using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace mutiny_control_panel {
    public partial class PreferencesForm : Form {

        private MainWindow instance;

        public PreferencesForm(MainWindow param) {
            InitializeComponent();
            this.instance = param;
            RestoreSettings();

            toolTip.SetToolTip(scriptStartupCheckbox, "Hosts the script automatically when program is ran");
            toolTip.SetToolTip(scriptShutdownCheckBox, "Kills the script automatically when program is closed");
            toolTip.SetToolTip(startWithWindowsCheckBox, "Experimental, modifies registry. Use with caution.");
            toolTip.SetToolTip(minimizeToTrayCheckbox, "Hides the program so it can quietly collect logs");
        }

        public void RestoreSettings() { // restore persistent settings
            var saves = Properties.Settings.Default;

            //script settings
            scriptStartupCheckbox.Checked = saves.autoStartBot;
            scriptShutdownCheckBox.Checked = saves.autoStopBot;

            customScriptEditorTextBox.Text = saves.editorPath;
            customScriptEditorTextBox.Text = saves.editorPath;
            customScriptEditorButton.Checked = !saves.useDefaultEditor;
            defaultScriptEditorButton.Checked = saves.useDefaultEditor;

            scriptDirTextBox.Text = saves.scriptPath;
            nodeDirTextBox.Text = saves.nodePath;

            //program settings
            startWithWindowsCheckBox.Checked = saves.startWithWindows;
            minimizeToTrayCheckbox.Checked = saves.minimizeToTray;

            botnameTextBox.Text = saves.botNickname;
        }

        private void saveButton_Click(object sender, EventArgs e) { // save persistent settings
            var saves = Properties.Settings.Default;

            //script settings
            if (scriptStartupCheckbox.Checked != saves.autoStartBot) saves.autoStartBot = scriptStartupCheckbox.Checked;
            if (scriptShutdownCheckBox.Checked != saves.autoStopBot) saves.autoStopBot = scriptShutdownCheckBox.Checked;

            if (defaultScriptEditorButton.Checked != saves.useDefaultEditor) saves.useDefaultEditor = defaultScriptEditorButton.Checked;
            if (customScriptEditorTextBox.Text != "" && customScriptEditorTextBox.Text != saves.editorPath) saves.editorPath = customScriptEditorTextBox.Text;

            if (scriptDirTextBox.Text != "" && scriptDirTextBox.Text != saves.scriptPath) saves.scriptPath = scriptDirTextBox.Text;
            if (nodeDirTextBox.Text != "" && nodeDirTextBox.Text != saves.nodePath) saves.nodePath = nodeDirTextBox.Text;

            //program settings
            if (startWithWindowsCheckBox.Checked != saves.startWithWindows) {
                saves.startWithWindows = startWithWindowsCheckBox.Checked;
                HandleWindowsStartup();
            }

            if (minimizeToTrayCheckbox.Checked != saves.minimizeToTray) saves.minimizeToTray = minimizeToTrayCheckbox.Checked;

            if (botnameTextBox.Text != "" && botnameTextBox.Text != saves.botNickname) saves.botNickname = botnameTextBox.Text;

            saves.Save();
            instance.SetValues();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void HandleWindowsStartup() {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (Properties.Settings.Default.startWithWindows) registryKey.SetValue(instance.ProgramName, Application.ExecutablePath);
            else registryKey.DeleteValue(instance.ProgramName, false);
        }

        // popup file explorer buttons
        private void findEditorButton_Click(object sender, EventArgs e) {
            OpenFileDialog editor = new OpenFileDialog();
            editor.InitialDirectory = "c:\\";
            editor.Filter = "Executable files (*.exe)|*.exe";
            if (editor.ShowDialog() == DialogResult.OK) {
                customScriptEditorButton.Checked = true;
                customScriptEditorTextBox.Text = editor.FileName;
            }
        }

        private void findScriptButton_Click(object sender, EventArgs e) {
            OpenFileDialog script = new OpenFileDialog();
            script.InitialDirectory = "c:\\";
            script.Filter = "Javascript files (*.js)|*.js";
            if (script.ShowDialog() == DialogResult.OK) scriptDirTextBox.Text = script.FileName;
        }

        private void findNodeButton_Click(object sender, EventArgs e) {
            OpenFileDialog node = new OpenFileDialog();
            node.InitialDirectory = "c:\\";
            node.Filter = "node.exe|*.exe";
            if (node.ShowDialog() == DialogResult.OK) nodeDirTextBox.Text = node.FileName;
        }

        // handles changing textbox color for invalid entry
        private void scriptDirTextBox_TextChanged(object sender, EventArgs e) {
            if (scriptDirTextBox.Text != "") scriptDirTextBox.BackColor = Color.White;
            else scriptDirTextBox.BackColor = SystemColors.Control;
        }

        private void nodeDirTextBox_TextChanged(object sender, EventArgs e) {
            if (nodeDirTextBox.Text != "") nodeDirTextBox.BackColor = Color.White;
            else nodeDirTextBox.BackColor = SystemColors.Control;
        }

        private void customScriptEditorButton_CheckedChanged(object sender, EventArgs e) {
            if (customScriptEditorButton.Checked) customScriptEditorTextBox.BackColor = Color.White;
            else customScriptEditorTextBox.BackColor = SystemColors.Control;
        }

        private void botnameTextBox_TextChanged(object sender, EventArgs e) {
            if (botnameTextBox.Text != "") botnameTextBox.BackColor = Color.White;
            else botnameTextBox.BackColor = SystemColors.Control;
        }
    }
}
