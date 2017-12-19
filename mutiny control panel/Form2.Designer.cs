namespace mutiny_control_panel {
    partial class PreferencesForm {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.scriptTab = new System.Windows.Forms.TabPage();
            this.scriptBehaviorGroupBox = new System.Windows.Forms.GroupBox();
            this.scriptShutdownCheckBox = new System.Windows.Forms.CheckBox();
            this.scriptStartupCheckbox = new System.Windows.Forms.CheckBox();
            this.findNodeButton = new System.Windows.Forms.Button();
            this.nodeDirTextBox = new System.Windows.Forms.TextBox();
            this.nodeLocationLabel = new System.Windows.Forms.Label();
            this.findScriptButton = new System.Windows.Forms.Button();
            this.scriptDirTextBox = new System.Windows.Forms.TextBox();
            this.scriptLocationLabel = new System.Windows.Forms.Label();
            this.findEditorButton = new System.Windows.Forms.Button();
            this.customScriptEditorTextBox = new System.Windows.Forms.TextBox();
            this.customScriptEditorButton = new System.Windows.Forms.RadioButton();
            this.defaultScriptEditorButton = new System.Windows.Forms.RadioButton();
            this.programTab = new System.Windows.Forms.TabPage();
            this.minimizeToTrayCheckbox = new System.Windows.Forms.CheckBox();
            this.botnameTextBox = new System.Windows.Forms.TextBox();
            this.startWithWindowsCheckBox = new System.Windows.Forms.CheckBox();
            this.botnameLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.scriptTab.SuspendLayout();
            this.scriptBehaviorGroupBox.SuspendLayout();
            this.programTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 260);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 229);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 28);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.cancelButton.Location = new System.Drawing.Point(222, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveButton.Location = new System.Drawing.Point(141, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 220);
            this.panel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.scriptTab);
            this.tabControl1.Controls.Add(this.programTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 220);
            this.tabControl1.TabIndex = 4;
            // 
            // scriptTab
            // 
            this.scriptTab.BackColor = System.Drawing.Color.White;
            this.scriptTab.Controls.Add(this.scriptBehaviorGroupBox);
            this.scriptTab.Controls.Add(this.findNodeButton);
            this.scriptTab.Controls.Add(this.nodeDirTextBox);
            this.scriptTab.Controls.Add(this.nodeLocationLabel);
            this.scriptTab.Controls.Add(this.findScriptButton);
            this.scriptTab.Controls.Add(this.scriptDirTextBox);
            this.scriptTab.Controls.Add(this.scriptLocationLabel);
            this.scriptTab.Controls.Add(this.findEditorButton);
            this.scriptTab.Controls.Add(this.customScriptEditorTextBox);
            this.scriptTab.Controls.Add(this.customScriptEditorButton);
            this.scriptTab.Controls.Add(this.defaultScriptEditorButton);
            this.scriptTab.Location = new System.Drawing.Point(4, 22);
            this.scriptTab.Name = "scriptTab";
            this.scriptTab.Padding = new System.Windows.Forms.Padding(3);
            this.scriptTab.Size = new System.Drawing.Size(292, 194);
            this.scriptTab.TabIndex = 0;
            this.scriptTab.Text = "Script settings";
            // 
            // scriptBehaviorGroupBox
            // 
            this.scriptBehaviorGroupBox.Controls.Add(this.scriptShutdownCheckBox);
            this.scriptBehaviorGroupBox.Controls.Add(this.scriptStartupCheckbox);
            this.scriptBehaviorGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.scriptBehaviorGroupBox.Location = new System.Drawing.Point(3, 3);
            this.scriptBehaviorGroupBox.Name = "scriptBehaviorGroupBox";
            this.scriptBehaviorGroupBox.Size = new System.Drawing.Size(286, 39);
            this.scriptBehaviorGroupBox.TabIndex = 24;
            this.scriptBehaviorGroupBox.TabStop = false;
            this.scriptBehaviorGroupBox.Text = "Script behavior";
            // 
            // scriptShutdownCheckBox
            // 
            this.scriptShutdownCheckBox.AutoSize = true;
            this.scriptShutdownCheckBox.Location = new System.Drawing.Point(146, 17);
            this.scriptShutdownCheckBox.Name = "scriptShutdownCheckBox";
            this.scriptShutdownCheckBox.Size = new System.Drawing.Size(139, 17);
            this.scriptShutdownCheckBox.TabIndex = 31;
            this.scriptShutdownCheckBox.Text = "Stop script with program";
            this.scriptShutdownCheckBox.UseVisualStyleBackColor = true;
            // 
            // scriptStartupCheckbox
            // 
            this.scriptStartupCheckbox.AutoSize = true;
            this.scriptStartupCheckbox.Checked = true;
            this.scriptStartupCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scriptStartupCheckbox.Location = new System.Drawing.Point(6, 17);
            this.scriptStartupCheckbox.Name = "scriptStartupCheckbox";
            this.scriptStartupCheckbox.Size = new System.Drawing.Size(139, 17);
            this.scriptStartupCheckbox.TabIndex = 30;
            this.scriptStartupCheckbox.Text = "Start script with program";
            this.scriptStartupCheckbox.UseVisualStyleBackColor = true;
            // 
            // findNodeButton
            // 
            this.findNodeButton.Location = new System.Drawing.Point(257, 167);
            this.findNodeButton.Name = "findNodeButton";
            this.findNodeButton.Size = new System.Drawing.Size(29, 20);
            this.findNodeButton.TabIndex = 21;
            this.findNodeButton.Text = "...";
            this.findNodeButton.UseVisualStyleBackColor = true;
            this.findNodeButton.Click += new System.EventHandler(this.findNodeButton_Click);
            // 
            // nodeDirTextBox
            // 
            this.nodeDirTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.nodeDirTextBox.Location = new System.Drawing.Point(5, 167);
            this.nodeDirTextBox.Name = "nodeDirTextBox";
            this.nodeDirTextBox.Size = new System.Drawing.Size(245, 20);
            this.nodeDirTextBox.TabIndex = 22;
            this.nodeDirTextBox.TextChanged += new System.EventHandler(this.nodeDirTextBox_TextChanged);
            // 
            // nodeLocationLabel
            // 
            this.nodeLocationLabel.AutoSize = true;
            this.nodeLocationLabel.Location = new System.Drawing.Point(0, 147);
            this.nodeLocationLabel.Name = "nodeLocationLabel";
            this.nodeLocationLabel.Size = new System.Drawing.Size(94, 13);
            this.nodeLocationLabel.TabIndex = 23;
            this.nodeLocationLabel.Text = "node.exe directory";
            // 
            // findScriptButton
            // 
            this.findScriptButton.Location = new System.Drawing.Point(257, 117);
            this.findScriptButton.Name = "findScriptButton";
            this.findScriptButton.Size = new System.Drawing.Size(29, 20);
            this.findScriptButton.TabIndex = 20;
            this.findScriptButton.Text = "...";
            this.findScriptButton.UseVisualStyleBackColor = true;
            this.findScriptButton.Click += new System.EventHandler(this.findScriptButton_Click);
            // 
            // scriptDirTextBox
            // 
            this.scriptDirTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.scriptDirTextBox.Location = new System.Drawing.Point(5, 117);
            this.scriptDirTextBox.Name = "scriptDirTextBox";
            this.scriptDirTextBox.Size = new System.Drawing.Size(245, 20);
            this.scriptDirTextBox.TabIndex = 19;
            this.scriptDirTextBox.TextChanged += new System.EventHandler(this.scriptDirTextBox_TextChanged);
            // 
            // scriptLocationLabel
            // 
            this.scriptLocationLabel.AutoSize = true;
            this.scriptLocationLabel.Location = new System.Drawing.Point(0, 97);
            this.scriptLocationLabel.Name = "scriptLocationLabel";
            this.scriptLocationLabel.Size = new System.Drawing.Size(77, 13);
            this.scriptLocationLabel.TabIndex = 18;
            this.scriptLocationLabel.Text = "Script directory";
            // 
            // findEditorButton
            // 
            this.findEditorButton.Location = new System.Drawing.Point(257, 68);
            this.findEditorButton.Name = "findEditorButton";
            this.findEditorButton.Size = new System.Drawing.Size(29, 20);
            this.findEditorButton.TabIndex = 17;
            this.findEditorButton.Text = "...";
            this.findEditorButton.UseVisualStyleBackColor = true;
            this.findEditorButton.Click += new System.EventHandler(this.findEditorButton_Click);
            // 
            // customScriptEditorTextBox
            // 
            this.customScriptEditorTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.customScriptEditorTextBox.Location = new System.Drawing.Point(23, 68);
            this.customScriptEditorTextBox.Name = "customScriptEditorTextBox";
            this.customScriptEditorTextBox.Size = new System.Drawing.Size(227, 20);
            this.customScriptEditorTextBox.TabIndex = 16;
            // 
            // customScriptEditorButton
            // 
            this.customScriptEditorButton.AutoSize = true;
            this.customScriptEditorButton.Location = new System.Drawing.Point(3, 71);
            this.customScriptEditorButton.Name = "customScriptEditorButton";
            this.customScriptEditorButton.Size = new System.Drawing.Size(14, 13);
            this.customScriptEditorButton.TabIndex = 15;
            this.customScriptEditorButton.TabStop = true;
            this.customScriptEditorButton.UseVisualStyleBackColor = true;
            this.customScriptEditorButton.CheckedChanged += new System.EventHandler(this.customScriptEditorButton_CheckedChanged);
            // 
            // defaultScriptEditorButton
            // 
            this.defaultScriptEditorButton.AutoSize = true;
            this.defaultScriptEditorButton.Location = new System.Drawing.Point(3, 48);
            this.defaultScriptEditorButton.Name = "defaultScriptEditorButton";
            this.defaultScriptEditorButton.Size = new System.Drawing.Size(152, 17);
            this.defaultScriptEditorButton.TabIndex = 14;
            this.defaultScriptEditorButton.TabStop = true;
            this.defaultScriptEditorButton.Text = "Use my default script editor";
            this.defaultScriptEditorButton.UseVisualStyleBackColor = true;
            // 
            // programTab
            // 
            this.programTab.BackColor = System.Drawing.Color.White;
            this.programTab.Controls.Add(this.minimizeToTrayCheckbox);
            this.programTab.Controls.Add(this.botnameTextBox);
            this.programTab.Controls.Add(this.startWithWindowsCheckBox);
            this.programTab.Controls.Add(this.botnameLabel);
            this.programTab.Location = new System.Drawing.Point(4, 22);
            this.programTab.Name = "programTab";
            this.programTab.Padding = new System.Windows.Forms.Padding(3);
            this.programTab.Size = new System.Drawing.Size(292, 194);
            this.programTab.TabIndex = 1;
            this.programTab.Text = "Program settings";
            // 
            // minimizeToTrayCheckbox
            // 
            this.minimizeToTrayCheckbox.AutoSize = true;
            this.minimizeToTrayCheckbox.Checked = true;
            this.minimizeToTrayCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minimizeToTrayCheckbox.Location = new System.Drawing.Point(3, 29);
            this.minimizeToTrayCheckbox.Name = "minimizeToTrayCheckbox";
            this.minimizeToTrayCheckbox.Size = new System.Drawing.Size(133, 17);
            this.minimizeToTrayCheckbox.TabIndex = 27;
            this.minimizeToTrayCheckbox.Text = "Minimize to system tray";
            this.minimizeToTrayCheckbox.UseVisualStyleBackColor = true;
            // 
            // botnameTextBox
            // 
            this.botnameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.botnameTextBox.Location = new System.Drawing.Point(146, 55);
            this.botnameTextBox.Name = "botnameTextBox";
            this.botnameTextBox.Size = new System.Drawing.Size(140, 20);
            this.botnameTextBox.TabIndex = 26;
            this.botnameTextBox.Text = "Discord bot";
            this.botnameTextBox.TextChanged += new System.EventHandler(this.botnameTextBox_TextChanged);
            // 
            // startWithWindowsCheckBox
            // 
            this.startWithWindowsCheckBox.AutoSize = true;
            this.startWithWindowsCheckBox.Checked = true;
            this.startWithWindowsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startWithWindowsCheckBox.Location = new System.Drawing.Point(3, 6);
            this.startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
            this.startWithWindowsCheckBox.Size = new System.Drawing.Size(155, 17);
            this.startWithWindowsCheckBox.TabIndex = 25;
            this.startWithWindowsCheckBox.Text = "Start program with windows";
            this.startWithWindowsCheckBox.UseVisualStyleBackColor = true;
            this.startWithWindowsCheckBox.CheckedChanged += new System.EventHandler(this.startWithWindowsCheckBox_CheckedChanged);
            // 
            // botnameLabel
            // 
            this.botnameLabel.AutoSize = true;
            this.botnameLabel.Location = new System.Drawing.Point(0, 57);
            this.botnameLabel.Name = "botnameLabel";
            this.botnameLabel.Size = new System.Drawing.Size(110, 13);
            this.botnameLabel.TabIndex = 24;
            this.botnameLabel.Text = "Discord bot nickname";
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 260);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.scriptTab.ResumeLayout(false);
            this.scriptTab.PerformLayout();
            this.scriptBehaviorGroupBox.ResumeLayout(false);
            this.scriptBehaviorGroupBox.PerformLayout();
            this.programTab.ResumeLayout(false);
            this.programTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage scriptTab;
        private System.Windows.Forms.Button findScriptButton;
        private System.Windows.Forms.TextBox scriptDirTextBox;
        private System.Windows.Forms.Label scriptLocationLabel;
        private System.Windows.Forms.Button findEditorButton;
        private System.Windows.Forms.TextBox customScriptEditorTextBox;
        private System.Windows.Forms.RadioButton customScriptEditorButton;
        private System.Windows.Forms.RadioButton defaultScriptEditorButton;
        private System.Windows.Forms.TabPage programTab;
        private System.Windows.Forms.Button findNodeButton;
        private System.Windows.Forms.TextBox nodeDirTextBox;
        private System.Windows.Forms.Label nodeLocationLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label botnameLabel;
        private System.Windows.Forms.CheckBox startWithWindowsCheckBox;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TextBox botnameTextBox;
        private System.Windows.Forms.CheckBox minimizeToTrayCheckbox;
        private System.Windows.Forms.GroupBox scriptBehaviorGroupBox;
        private System.Windows.Forms.CheckBox scriptShutdownCheckBox;
        private System.Windows.Forms.CheckBox scriptStartupCheckbox;
    }
}