namespace mutiny_control_panel {
    partial class preferencesForm {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.scriptTab = new System.Windows.Forms.TabPage();
            this.programTab = new System.Windows.Forms.TabPage();
            this.findNodeButton = new System.Windows.Forms.Button();
            this.nodeLocationLabel = new System.Windows.Forms.Label();
            this.findScriptButton = new System.Windows.Forms.Button();
            this.scriptPathText = new System.Windows.Forms.TextBox();
            this.scriptLocationLabel = new System.Windows.Forms.Label();
            this.findScriptEditorButton = new System.Windows.Forms.Button();
            this.customEditorPathText = new System.Windows.Forms.TextBox();
            this.customScriptEditorButton = new System.Windows.Forms.RadioButton();
            this.nodeGroupBox = new System.Windows.Forms.GroupBox();
            this.nodePathText = new System.Windows.Forms.TextBox();
            this.defaultScriptEditorButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scriptSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.scriptTab.SuspendLayout();
            this.nodeGroupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.scriptSettingsGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.scriptTab);
            this.tabControl1.Controls.Add(this.programTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 236);
            this.tabControl1.TabIndex = 0;
            // 
            // scriptTab
            // 
            this.scriptTab.BackColor = System.Drawing.Color.White;
            this.scriptTab.Controls.Add(this.tableLayoutPanel1);
            this.scriptTab.Location = new System.Drawing.Point(4, 22);
            this.scriptTab.Name = "scriptTab";
            this.scriptTab.Padding = new System.Windows.Forms.Padding(3);
            this.scriptTab.Size = new System.Drawing.Size(311, 210);
            this.scriptTab.TabIndex = 0;
            this.scriptTab.Text = "Script settings";
            // 
            // programTab
            // 
            this.programTab.BackColor = System.Drawing.Color.White;
            this.programTab.Location = new System.Drawing.Point(4, 22);
            this.programTab.Name = "programTab";
            this.programTab.Padding = new System.Windows.Forms.Padding(3);
            this.programTab.Size = new System.Drawing.Size(311, 210);
            this.programTab.TabIndex = 1;
            this.programTab.Text = "Program settings";
            // 
            // findNodeButton
            // 
            this.findNodeButton.Location = new System.Drawing.Point(264, 41);
            this.findNodeButton.Name = "findNodeButton";
            this.findNodeButton.Size = new System.Drawing.Size(29, 20);
            this.findNodeButton.TabIndex = 7;
            this.findNodeButton.Text = "...";
            this.findNodeButton.UseVisualStyleBackColor = true;
            // 
            // nodeLocationLabel
            // 
            this.nodeLocationLabel.AutoSize = true;
            this.nodeLocationLabel.Location = new System.Drawing.Point(7, 23);
            this.nodeLocationLabel.Name = "nodeLocationLabel";
            this.nodeLocationLabel.Size = new System.Drawing.Size(94, 13);
            this.nodeLocationLabel.TabIndex = 7;
            this.nodeLocationLabel.Text = "node.exe directory";
            // 
            // findScriptButton
            // 
            this.findScriptButton.Location = new System.Drawing.Point(264, 89);
            this.findScriptButton.Name = "findScriptButton";
            this.findScriptButton.Size = new System.Drawing.Size(29, 20);
            this.findScriptButton.TabIndex = 6;
            this.findScriptButton.Text = "...";
            this.findScriptButton.UseVisualStyleBackColor = true;
            // 
            // scriptPathText
            // 
            this.scriptPathText.Location = new System.Drawing.Point(12, 89);
            this.scriptPathText.Name = "scriptPathText";
            this.scriptPathText.Size = new System.Drawing.Size(245, 20);
            this.scriptPathText.TabIndex = 5;
            // 
            // scriptLocationLabel
            // 
            this.scriptLocationLabel.AutoSize = true;
            this.scriptLocationLabel.Location = new System.Drawing.Point(7, 71);
            this.scriptLocationLabel.Name = "scriptLocationLabel";
            this.scriptLocationLabel.Size = new System.Drawing.Size(77, 13);
            this.scriptLocationLabel.TabIndex = 4;
            this.scriptLocationLabel.Text = "Script directory";
            // 
            // findScriptEditorButton
            // 
            this.findScriptEditorButton.Location = new System.Drawing.Point(264, 40);
            this.findScriptEditorButton.Name = "findScriptEditorButton";
            this.findScriptEditorButton.Size = new System.Drawing.Size(29, 20);
            this.findScriptEditorButton.TabIndex = 3;
            this.findScriptEditorButton.Text = "...";
            this.findScriptEditorButton.UseVisualStyleBackColor = true;
            // 
            // customEditorPathText
            // 
            this.customEditorPathText.Location = new System.Drawing.Point(30, 40);
            this.customEditorPathText.Name = "customEditorPathText";
            this.customEditorPathText.ReadOnly = true;
            this.customEditorPathText.Size = new System.Drawing.Size(227, 20);
            this.customEditorPathText.TabIndex = 2;
            // 
            // customScriptEditorButton
            // 
            this.customScriptEditorButton.AutoSize = true;
            this.customScriptEditorButton.Location = new System.Drawing.Point(10, 43);
            this.customScriptEditorButton.Name = "customScriptEditorButton";
            this.customScriptEditorButton.Size = new System.Drawing.Size(14, 13);
            this.customScriptEditorButton.TabIndex = 1;
            this.customScriptEditorButton.TabStop = true;
            this.customScriptEditorButton.UseVisualStyleBackColor = true;
            // 
            // nodeGroupBox
            // 
            this.nodeGroupBox.Controls.Add(this.findNodeButton);
            this.nodeGroupBox.Controls.Add(this.nodePathText);
            this.nodeGroupBox.Controls.Add(this.nodeLocationLabel);
            this.nodeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeGroupBox.Location = new System.Drawing.Point(3, 128);
            this.nodeGroupBox.Name = "nodeGroupBox";
            this.nodeGroupBox.Size = new System.Drawing.Size(299, 73);
            this.nodeGroupBox.TabIndex = 2;
            this.nodeGroupBox.TabStop = false;
            this.nodeGroupBox.Text = "Node settings";
            // 
            // nodePathText
            // 
            this.nodePathText.Location = new System.Drawing.Point(12, 41);
            this.nodePathText.Name = "nodePathText";
            this.nodePathText.Size = new System.Drawing.Size(245, 20);
            this.nodePathText.TabIndex = 7;
            // 
            // defaultScriptEditorButton
            // 
            this.defaultScriptEditorButton.AutoSize = true;
            this.defaultScriptEditorButton.Location = new System.Drawing.Point(10, 20);
            this.defaultScriptEditorButton.Name = "defaultScriptEditorButton";
            this.defaultScriptEditorButton.Size = new System.Drawing.Size(152, 17);
            this.defaultScriptEditorButton.TabIndex = 0;
            this.defaultScriptEditorButton.TabStop = true;
            this.defaultScriptEditorButton.Text = "Use my default script editor";
            this.defaultScriptEditorButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.scriptSettingsGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nodeGroupBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 204);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // scriptSettingsGroupBox
            // 
            this.scriptSettingsGroupBox.Controls.Add(this.findScriptButton);
            this.scriptSettingsGroupBox.Controls.Add(this.scriptPathText);
            this.scriptSettingsGroupBox.Controls.Add(this.scriptLocationLabel);
            this.scriptSettingsGroupBox.Controls.Add(this.findScriptEditorButton);
            this.scriptSettingsGroupBox.Controls.Add(this.customEditorPathText);
            this.scriptSettingsGroupBox.Controls.Add(this.customScriptEditorButton);
            this.scriptSettingsGroupBox.Controls.Add(this.defaultScriptEditorButton);
            this.scriptSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptSettingsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.scriptSettingsGroupBox.Name = "scriptSettingsGroupBox";
            this.scriptSettingsGroupBox.Size = new System.Drawing.Size(299, 119);
            this.scriptSettingsGroupBox.TabIndex = 0;
            this.scriptSettingsGroupBox.TabStop = false;
            this.scriptSettingsGroupBox.Text = "Script settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 235);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(319, 33);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(154, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(84, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "version 0.4b";
            // 
            // preferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 268);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "preferencesForm";
            this.Text = "Preferences";
            this.tabControl1.ResumeLayout(false);
            this.scriptTab.ResumeLayout(false);
            this.nodeGroupBox.ResumeLayout(false);
            this.nodeGroupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.scriptSettingsGroupBox.ResumeLayout(false);
            this.scriptSettingsGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage scriptTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox scriptSettingsGroupBox;
        private System.Windows.Forms.Button findScriptButton;
        private System.Windows.Forms.TextBox scriptPathText;
        private System.Windows.Forms.Label scriptLocationLabel;
        private System.Windows.Forms.Button findScriptEditorButton;
        private System.Windows.Forms.TextBox customEditorPathText;
        private System.Windows.Forms.RadioButton customScriptEditorButton;
        private System.Windows.Forms.RadioButton defaultScriptEditorButton;
        private System.Windows.Forms.GroupBox nodeGroupBox;
        private System.Windows.Forms.Button findNodeButton;
        private System.Windows.Forms.TextBox nodePathText;
        private System.Windows.Forms.Label nodeLocationLabel;
        private System.Windows.Forms.TabPage programTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
    }
}