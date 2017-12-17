using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace mutiny_control_panel {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static Mutex mutex = null;

        static MainWindow panel;

        [STAThread]
        static void Main() {

            bool createdNew;
            const string name = "mutiny control panel"; 
            mutex = new Mutex(true, name, out createdNew);

            if (!createdNew) {
                //if (main.WindowState == FormWindowState.Minimized) main.WindowState = FormWindowState.Normal;
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            panel = new MainWindow(name);
            Application.Run(panel);
        }
    }
}
