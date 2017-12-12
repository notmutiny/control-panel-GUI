using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace mutiny_control_panel {
    public partial class Debug : Form {

        delegate void StringArgReturningVoidDelegate(string text); // i don't know what this is

        public Debug() {
            InitializeComponent();
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            //debugCheckBox.Checked = false;
            e.Cancel = true; // this cancels the close event.
        }
    }
}