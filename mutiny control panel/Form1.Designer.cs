﻿namespace mutiny_control_panel {
    partial class mainWindow {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scriptGroupBox = new System.Windows.Forms.GroupBox();
            this.onlineButton = new System.Windows.Forms.RadioButton();
            this.offlineButton = new System.Windows.Forms.RadioButton();
            this.parrotEnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.botStatusLabel = new System.Windows.Forms.Label();
            this.pushButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.scriptGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(311, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.58842F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.41158F));
            this.tableLayoutPanel1.Controls.Add(this.scriptGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(311, 78);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // scriptGroupBox
            // 
            this.scriptGroupBox.Controls.Add(this.parrotEnabledCheckbox);
            this.scriptGroupBox.Controls.Add(this.offlineButton);
            this.scriptGroupBox.Controls.Add(this.onlineButton);
            this.scriptGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptGroupBox.Location = new System.Drawing.Point(3, 3);
            this.scriptGroupBox.Name = "scriptGroupBox";
            this.scriptGroupBox.Size = new System.Drawing.Size(142, 72);
            this.scriptGroupBox.TabIndex = 0;
            this.scriptGroupBox.TabStop = false;
            this.scriptGroupBox.Text = "mutiny bot configuration";
            // 
            // onlineButton
            // 
            this.onlineButton.AutoSize = true;
            this.onlineButton.Location = new System.Drawing.Point(6, 19);
            this.onlineButton.Name = "onlineButton";
            this.onlineButton.Size = new System.Drawing.Size(55, 17);
            this.onlineButton.TabIndex = 0;
            this.onlineButton.TabStop = true;
            this.onlineButton.Text = "Online";
            this.onlineButton.UseVisualStyleBackColor = true;
            // 
            // offlineButton
            // 
            this.offlineButton.AutoSize = true;
            this.offlineButton.Location = new System.Drawing.Point(67, 19);
            this.offlineButton.Name = "offlineButton";
            this.offlineButton.Size = new System.Drawing.Size(55, 17);
            this.offlineButton.TabIndex = 1;
            this.offlineButton.TabStop = true;
            this.offlineButton.Text = "Offline";
            this.offlineButton.UseVisualStyleBackColor = true;
            // 
            // parrotEnabledCheckbox
            // 
            this.parrotEnabledCheckbox.AutoSize = true;
            this.parrotEnabledCheckbox.Location = new System.Drawing.Point(6, 43);
            this.parrotEnabledCheckbox.Name = "parrotEnabledCheckbox";
            this.parrotEnabledCheckbox.Size = new System.Drawing.Size(109, 17);
            this.parrotEnabledCheckbox.TabIndex = 2;
            this.parrotEnabledCheckbox.Text = "Parroting enabled";
            this.parrotEnabledCheckbox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.botStatusLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pushButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.editButton, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(151, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(157, 72);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // botStatusLabel
            // 
            this.botStatusLabel.AutoSize = true;
            this.botStatusLabel.Location = new System.Drawing.Point(3, 0);
            this.botStatusLabel.Name = "botStatusLabel";
            this.botStatusLabel.Size = new System.Drawing.Size(142, 13);
            this.botStatusLabel.TabIndex = 0;
            this.botStatusLabel.Text = "mutiny bot is currently ??line!";
            // 
            // pushButton
            // 
            this.pushButton.Location = new System.Drawing.Point(3, 16);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(142, 23);
            this.pushButton.TabIndex = 1;
            this.pushButton.Text = "Push changes";
            this.pushButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(3, 45);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(142, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit script";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.goToGitHubToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // goToGitHubToolStripMenuItem
            // 
            this.goToGitHubToolStripMenuItem.Name = "goToGitHubToolStripMenuItem";
            this.goToGitHubToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.goToGitHubToolStripMenuItem.Text = "GitHub";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 102);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainWindow";
            this.Text = "mutiny control panel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.scriptGroupBox.ResumeLayout(false);
            this.scriptGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox scriptGroupBox;
        private System.Windows.Forms.CheckBox parrotEnabledCheckbox;
        private System.Windows.Forms.RadioButton offlineButton;
        private System.Windows.Forms.RadioButton onlineButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label botStatusLabel;
        private System.Windows.Forms.Button pushButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToGitHubToolStripMenuItem;
    }
}

