﻿namespace mutiny_control_panel {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.scriptTab = new System.Windows.Forms.TabPage();
            this.findScriptButton = new System.Windows.Forms.Button();
            this.scriptPathText = new System.Windows.Forms.TextBox();
            this.scriptLocationLabel = new System.Windows.Forms.Label();
            this.findScriptEditorButton = new System.Windows.Forms.Button();
            this.editorDirectoryTextbox = new System.Windows.Forms.TextBox();
            this.customScriptEditorButton = new System.Windows.Forms.RadioButton();
            this.defaultScriptEditorButton = new System.Windows.Forms.RadioButton();
            this.programTab = new System.Windows.Forms.TabPage();
            this.findNodeButton = new System.Windows.Forms.Button();
            this.nodePathText = new System.Windows.Forms.TextBox();
            this.nodeLocationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.scriptTab.SuspendLayout();
            this.programTab.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(306, 214);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 174);
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
            this.tabControl1.Size = new System.Drawing.Size(300, 174);
            this.tabControl1.TabIndex = 4;
            // 
            // scriptTab
            // 
            this.scriptTab.BackColor = System.Drawing.Color.White;
            this.scriptTab.Controls.Add(this.findNodeButton);
            this.scriptTab.Controls.Add(this.nodePathText);
            this.scriptTab.Controls.Add(this.nodeLocationLabel);
            this.scriptTab.Controls.Add(this.findScriptButton);
            this.scriptTab.Controls.Add(this.scriptPathText);
            this.scriptTab.Controls.Add(this.scriptLocationLabel);
            this.scriptTab.Controls.Add(this.findScriptEditorButton);
            this.scriptTab.Controls.Add(this.editorDirectoryTextbox);
            this.scriptTab.Controls.Add(this.customScriptEditorButton);
            this.scriptTab.Controls.Add(this.defaultScriptEditorButton);
            this.scriptTab.Location = new System.Drawing.Point(4, 22);
            this.scriptTab.Name = "scriptTab";
            this.scriptTab.Padding = new System.Windows.Forms.Padding(3);
            this.scriptTab.Size = new System.Drawing.Size(292, 148);
            this.scriptTab.TabIndex = 0;
            this.scriptTab.Text = "Script settings";
            // 
            // findScriptButton
            // 
            this.findScriptButton.Location = new System.Drawing.Point(257, 72);
            this.findScriptButton.Name = "findScriptButton";
            this.findScriptButton.Size = new System.Drawing.Size(29, 20);
            this.findScriptButton.TabIndex = 20;
            this.findScriptButton.Text = "...";
            this.findScriptButton.UseVisualStyleBackColor = true;
            this.findScriptButton.Click += new System.EventHandler(this.findScriptButton_Click);
            // 
            // scriptPathText
            // 
            this.scriptPathText.Location = new System.Drawing.Point(5, 72);
            this.scriptPathText.Name = "scriptPathText";
            this.scriptPathText.ReadOnly = true;
            this.scriptPathText.Size = new System.Drawing.Size(245, 20);
            this.scriptPathText.TabIndex = 19;
            // 
            // scriptLocationLabel
            // 
            this.scriptLocationLabel.AutoSize = true;
            this.scriptLocationLabel.Location = new System.Drawing.Point(0, 54);
            this.scriptLocationLabel.Name = "scriptLocationLabel";
            this.scriptLocationLabel.Size = new System.Drawing.Size(77, 13);
            this.scriptLocationLabel.TabIndex = 18;
            this.scriptLocationLabel.Text = "Script directory";
            // 
            // findScriptEditorButton
            // 
            this.findScriptEditorButton.Location = new System.Drawing.Point(257, 23);
            this.findScriptEditorButton.Name = "findScriptEditorButton";
            this.findScriptEditorButton.Size = new System.Drawing.Size(29, 20);
            this.findScriptEditorButton.TabIndex = 17;
            this.findScriptEditorButton.Text = "...";
            this.findScriptEditorButton.UseVisualStyleBackColor = true;
            this.findScriptEditorButton.Click += new System.EventHandler(this.findScriptEditorButton_Click_1);
            // 
            // editorDirectoryTextbox
            // 
            this.editorDirectoryTextbox.Location = new System.Drawing.Point(23, 23);
            this.editorDirectoryTextbox.Name = "editorDirectoryTextbox";
            this.editorDirectoryTextbox.ReadOnly = true;
            this.editorDirectoryTextbox.Size = new System.Drawing.Size(227, 20);
            this.editorDirectoryTextbox.TabIndex = 16;
            // 
            // customScriptEditorButton
            // 
            this.customScriptEditorButton.AutoSize = true;
            this.customScriptEditorButton.Location = new System.Drawing.Point(3, 26);
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
            this.defaultScriptEditorButton.Location = new System.Drawing.Point(3, 3);
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
            this.programTab.Controls.Add(this.label1);
            this.programTab.Location = new System.Drawing.Point(4, 22);
            this.programTab.Name = "programTab";
            this.programTab.Padding = new System.Windows.Forms.Padding(3);
            this.programTab.Size = new System.Drawing.Size(292, 148);
            this.programTab.TabIndex = 1;
            this.programTab.Text = "Program settings";
            // 
            // findNodeButton
            // 
            this.findNodeButton.Location = new System.Drawing.Point(257, 122);
            this.findNodeButton.Name = "findNodeButton";
            this.findNodeButton.Size = new System.Drawing.Size(29, 20);
            this.findNodeButton.TabIndex = 21;
            this.findNodeButton.Text = "...";
            this.findNodeButton.UseVisualStyleBackColor = true;
            this.findNodeButton.Click += new System.EventHandler(this.findNodeButton_Click_1);
            // 
            // nodePathText
            // 
            this.nodePathText.BackColor = System.Drawing.SystemColors.Control;
            this.nodePathText.Location = new System.Drawing.Point(5, 122);
            this.nodePathText.Name = "nodePathText";
            this.nodePathText.ReadOnly = true;
            this.nodePathText.Size = new System.Drawing.Size(245, 20);
            this.nodePathText.TabIndex = 22;
            // 
            // nodeLocationLabel
            // 
            this.nodeLocationLabel.AutoSize = true;
            this.nodeLocationLabel.Location = new System.Drawing.Point(0, 104);
            this.nodeLocationLabel.Name = "nodeLocationLabel";
            this.nodeLocationLabel.Size = new System.Drawing.Size(94, 13);
            this.nodeLocationLabel.TabIndex = 23;
            this.nodeLocationLabel.Text = "node.exe directory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "nothing to see here yet :^)";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancelButton);
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 183);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(300, 28);
            this.flowLayoutPanel1.TabIndex = 7;
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
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click_1);
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
            // preferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "preferencesForm";
            this.Text = "Preferences";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.scriptTab.ResumeLayout(false);
            this.scriptTab.PerformLayout();
            this.programTab.ResumeLayout(false);
            this.programTab.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage scriptTab;
        private System.Windows.Forms.Button findScriptButton;
        private System.Windows.Forms.TextBox scriptPathText;
        private System.Windows.Forms.Label scriptLocationLabel;
        private System.Windows.Forms.Button findScriptEditorButton;
        private System.Windows.Forms.TextBox editorDirectoryTextbox;
        private System.Windows.Forms.RadioButton customScriptEditorButton;
        private System.Windows.Forms.RadioButton defaultScriptEditorButton;
        private System.Windows.Forms.TabPage programTab;
        private System.Windows.Forms.Button findNodeButton;
        private System.Windows.Forms.TextBox nodePathText;
        private System.Windows.Forms.Label nodeLocationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}