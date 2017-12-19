namespace mutiny_control_panel {
   // public class Data {
    //    Properties.Settings Save = Properties.Settings.Default;
   // }

    partial class MainWindow {

        public Properties.Settings Saves = Properties.Settings.Default;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scriptGroupBox = new System.Windows.Forms.GroupBox();
            this.debugCheckBox = new System.Windows.Forms.CheckBox();
            this.offlineButton = new System.Windows.Forms.RadioButton();
            this.onlineButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.onlineStatusLabel = new System.Windows.Forms.Label();
            this.pushButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToGitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.scriptOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearOutputLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topmostWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scriptOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptOfflineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.scriptGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.trayContextMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(302, 78);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // scriptGroupBox
            // 
            this.scriptGroupBox.Controls.Add(this.debugCheckBox);
            this.scriptGroupBox.Controls.Add(this.offlineButton);
            this.scriptGroupBox.Controls.Add(this.onlineButton);
            this.scriptGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptGroupBox.Location = new System.Drawing.Point(3, 3);
            this.scriptGroupBox.Name = "scriptGroupBox";
            this.scriptGroupBox.Size = new System.Drawing.Size(137, 72);
            this.scriptGroupBox.TabIndex = 0;
            this.scriptGroupBox.TabStop = false;
            this.scriptGroupBox.Text = "mutiny bot configuration";
            // 
            // debugCheckBox
            // 
            this.debugCheckBox.AutoSize = true;
            this.debugCheckBox.Location = new System.Drawing.Point(9, 46);
            this.debugCheckBox.Name = "debugCheckBox";
            this.debugCheckBox.Size = new System.Drawing.Size(114, 17);
            this.debugCheckBox.TabIndex = 2;
            this.debugCheckBox.Text = "Show script output";
            this.debugCheckBox.UseVisualStyleBackColor = true;
            this.debugCheckBox.CheckedChanged += new System.EventHandler(this.debugCheckBox_CheckedChanged);
            // 
            // offlineButton
            // 
            this.offlineButton.AutoSize = true;
            this.offlineButton.Location = new System.Drawing.Point(70, 20);
            this.offlineButton.Name = "offlineButton";
            this.offlineButton.Size = new System.Drawing.Size(55, 17);
            this.offlineButton.TabIndex = 1;
            this.offlineButton.TabStop = true;
            this.offlineButton.Text = "Offline";
            this.offlineButton.UseVisualStyleBackColor = true;
            // 
            // onlineButton
            // 
            this.onlineButton.AutoSize = true;
            this.onlineButton.Location = new System.Drawing.Point(9, 20);
            this.onlineButton.Name = "onlineButton";
            this.onlineButton.Size = new System.Drawing.Size(55, 17);
            this.onlineButton.TabIndex = 0;
            this.onlineButton.TabStop = true;
            this.onlineButton.Text = "Online";
            this.onlineButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.onlineStatusLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pushButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.editButton, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(146, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(153, 72);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // onlineStatusLabel
            // 
            this.onlineStatusLabel.AutoSize = true;
            this.onlineStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.onlineStatusLabel.Location = new System.Drawing.Point(3, 0);
            this.onlineStatusLabel.Name = "onlineStatusLabel";
            this.onlineStatusLabel.Size = new System.Drawing.Size(147, 13);
            this.onlineStatusLabel.TabIndex = 0;
            this.onlineStatusLabel.Text = "mutiny bot is currently broken";
            // 
            // pushButton
            // 
            this.pushButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pushButton.Location = new System.Drawing.Point(3, 16);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(147, 23);
            this.pushButton.TabIndex = 1;
            this.pushButton.Text = "Push changes";
            this.pushButton.UseVisualStyleBackColor = true;
            this.pushButton.Click += new System.EventHandler(this.pushButton_Click);
            // 
            // editButton
            // 
            this.editButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editButton.Location = new System.Drawing.Point(3, 45);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(147, 24);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit script";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // statusTimer
            // 
            this.statusTimer.Enabled = true;
            this.statusTimer.Tick += new System.EventHandler(this.statusRefresh_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "mutiny control panel";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
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
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // goToGitHubToolStripMenuItem
            // 
            this.goToGitHubToolStripMenuItem.Name = "goToGitHubToolStripMenuItem";
            this.goToGitHubToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.goToGitHubToolStripMenuItem.Text = "GitHub";
            this.goToGitHubToolStripMenuItem.Click += new System.EventHandler(this.goToGitHubToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(302, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trayContextMenu
            // 
            this.trayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.showToolStripSeparator1,
            this.scriptOutputToolStripMenuItem,
            this.toolStripSeparator2,
            this.scriptOnlineToolStripMenuItem,
            this.scriptOfflineToolStripMenuItem,
            this.toolStripSeparator3,
            this.quitToolStripMenuItem});
            this.trayContextMenu.Name = "trayContextMenu";
            this.trayContextMenu.Size = new System.Drawing.Size(153, 154);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Visible = false;
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // showToolStripSeparator1
            // 
            this.showToolStripSeparator1.Name = "showToolStripSeparator1";
            this.showToolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            this.showToolStripSeparator1.Visible = false;
            // 
            // scriptOutputToolStripMenuItem
            // 
            this.scriptOutputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWindowToolStripMenuItem,
            this.clearOutputLogToolStripMenuItem,
            this.topmostWindowToolStripMenuItem});
            this.scriptOutputToolStripMenuItem.Name = "scriptOutputToolStripMenuItem";
            this.scriptOutputToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scriptOutputToolStripMenuItem.Text = "Script output";
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showWindowToolStripMenuItem.Text = "Show window";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
            // 
            // clearOutputLogToolStripMenuItem
            // 
            this.clearOutputLogToolStripMenuItem.Name = "clearOutputLogToolStripMenuItem";
            this.clearOutputLogToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.clearOutputLogToolStripMenuItem.Text = "Clear output log";
            this.clearOutputLogToolStripMenuItem.Click += new System.EventHandler(this.clearOutputLogToolStripMenuItem_Click);
            // 
            // topmostWindowToolStripMenuItem
            // 
            this.topmostWindowToolStripMenuItem.Name = "topmostWindowToolStripMenuItem";
            this.topmostWindowToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.topmostWindowToolStripMenuItem.Text = "Keep window on top";
            this.topmostWindowToolStripMenuItem.Click += new System.EventHandler(this.topmostWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // scriptOnlineToolStripMenuItem
            // 
            this.scriptOnlineToolStripMenuItem.Name = "scriptOnlineToolStripMenuItem";
            this.scriptOnlineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scriptOnlineToolStripMenuItem.Text = "Script online";
            this.scriptOnlineToolStripMenuItem.Click += new System.EventHandler(this.scriptOnlineToolStripMenuItem_Click);
            // 
            // scriptOfflineToolStripMenuItem
            // 
            this.scriptOfflineToolStripMenuItem.Name = "scriptOfflineToolStripMenuItem";
            this.scriptOfflineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scriptOfflineToolStripMenuItem.Text = "Script offline";
            this.scriptOfflineToolStripMenuItem.Click += new System.EventHandler(this.scriptOfflineToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 102);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "appname";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.mainWindow_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.scriptGroupBox.ResumeLayout(false);
            this.scriptGroupBox.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.trayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton offlineButton;
        private System.Windows.Forms.RadioButton onlineButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.CheckBox debugCheckBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        public System.Windows.Forms.GroupBox scriptGroupBox;
        private System.Windows.Forms.Label onlineStatusLabel;
        private System.Windows.Forms.Button pushButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToGitHubToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip trayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptOfflineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scriptOutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topmostWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearOutputLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator showToolStripSeparator1;
    }
}

