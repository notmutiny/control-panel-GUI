using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace mutiny_control_panel {
    public partial class Debug : Form {

        private TextBox textBox1;
        private Thread nodeThread;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        public Debug() {
            InitializeComponent();
        }

        private void debugger_Load(object sender, System.EventArgs e) {

        }
    }
}
