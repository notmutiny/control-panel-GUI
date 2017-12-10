using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace mutiny_control_panel {
    public partial class debugger : Form {

        private TextBox textBox1;
        private Thread nodeThread;

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        public debugger() {
            InitializeComponent();
        }

        private void debugger_Load(object sender, System.EventArgs e) {

        }
    }
}
