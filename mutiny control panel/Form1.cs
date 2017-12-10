using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mutiny_control_panel {
    public partial class mainWindow : Form {
        /*  todo
            - get process by id
            - rework functions to only handle our processes
        */

        // Visual Studio methods //
        public debugger test;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what the fuck this is

        private Thread nodeThread;

        private bool onlineEnabled;
        private bool debugEnabled;

        private bool useDefaultEditor;

        private string nodePath;
        private string scriptPath;
        private string editorPath;

        public mainWindow() {
            InitializeComponent();

            useDefaultEditor = Properties.Settings.Default.useDefaultEditor;

            nodePath = Properties.Settings.Default.nodePath;
            scriptPath = Properties.Settings.Default.scriptPath;
            editorPath = Properties.Settings.Default.editorCustomPath;
        }

        private void onlineButton_CheckedChanged(object sender, EventArgs e) {
            onlineEnabled = true;
        }

        private void offlineButton_CheckedChanged(object sender, EventArgs e) {
            onlineEnabled = false;
        }

        private void editButton_Click(object sender, EventArgs e) {
            try {
                if (useDefaultEditor) Process.Start(scriptPath);
                else Process.Start(editorPath, scriptPath);
            } catch {
                MessageBox.Show("Editor cannot be opened. Did you configure settings > preferences?", "Script editor error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pushButton_Click(object sender, EventArgs e) {
            Process[] node = Process.GetProcessesByName("node");

            if (onlineEnabled) Initialize(); //hostJSBot(node);
            else killJSBot(node);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            preferencesForm pref = new preferencesForm();
            pref.ShowDialog();
        }

        private void goToGitHubToolStripMenuItem_Click(object sender, EventArgs e) {
            Process.Start("https://github.com/notmutiny/control-panel-GUI");
        }

        private void debugCheckBox_CheckedChanged(object sender, EventArgs e) {
            debugEnabled = debugCheckBox.Checked;

            test = new debugger();

            if (debugEnabled) test.Show();
            else test.Hide();
                //debugEnabled = false;
        }

        private void statusTimer_Tick(object sender, EventArgs e) {
            onlineStatusLabel.Text = "mutiny bot is currently " + checkServer() + "!";
        }

        // custom methods //
        private string checkServer() {
            Process[] node = Process.GetProcessesByName("node");
            
            foreach (Process proc in node) {
                if (proc.Id == Properties.Settings.Default.processID) return "online";
            }

            return "offline";
        }

        private void Initialize() {
            // start node in another thread
            nodeThread = new Thread(new ThreadStart(ThreadProc));
            nodeThread.Start();

            // wait for the node thread to die
            //nodeThread.Join();
        }

        private void Display(string txt) {
            if (test.textBox2.InvokeRequired) { // nodejs and Lua manage multithreading without all this bullshit
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(Display);
                this.Invoke(d, new object[] { txt });
            } else {
                test.textBox2.Text += txt + "\r\n";
            }
        }

        public void ThreadProc() { //thread process
            // node is like a beacon of light among this retarded mess
            ProcessStartInfo startInfo = new ProcessStartInfo(nodePath);
            startInfo.CreateNoWindow = true; // comment this if you want to see the node window while node is running
            startInfo.RedirectStandardOutput = true; // though its in/out is redirected so it won't display anything
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;

            var proc = new Process();
            proc.StartInfo = startInfo;
            proc.EnableRaisingEvents = true;
            proc.OutputDataReceived += (sender, args) => this.Display(args.Data);
            proc.ErrorDataReceived += (sender, args) => this.Display(args.Data);
            proc.Start();

            var startCommand = "require('D:/Library/Projects/Coding/Discord/mutiny_bot/mybot.js').Start()"; // start the server after node has started
            StreamWriter myStreamWriter = proc.StandardInput;
            myStreamWriter.WriteLine(startCommand);
            myStreamWriter.Close();

            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();
        }

        private void hostJSBot(Process[] node) {

            try {
                ProcessStartInfo startInfo = new ProcessStartInfo(nodePath);

                startInfo.Arguments = Properties.Settings.Default.scriptPath;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;

                Process nodeProcess = Process.Start(startInfo);
                Console.WriteLine("process id saved " + nodeProcess.Id);
                Properties.Settings.Default.processID = nodeProcess.Id;
            } catch {
                MessageBox.Show("Cannot host bot. Did you configure settings > preferences?", "Node.exe error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Properties.Settings.Default.Save();
        }

        private void killJSBot(Process[] node) {
            if (node.Length > 0) {
                foreach (Process process in node) {
                    if (process.Id == Properties.Settings.Default.processID) {
                        process.Kill();
                        break;
                    }
                }
            }
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e) {
            debugger debug = new debugger();

            debug.Show();
        }
    }
}
