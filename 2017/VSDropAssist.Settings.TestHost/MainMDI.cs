using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSDropAssist.Settings.TestHost
{
    public partial class MainMDI : Form
    {
        public MainMDI()
        {
            InitializeComponent();
        }

        private void mnuViewOptions_Click(object sender, EventArgs e)
        {
            newForm<frmTestOptions>();
        }

        private void newForm<T>() where T : Form, new()
        {
            var f = new T();
            f.MdiParent = this;
            f.Show();

        }
        private void mnuViewPopup_Click(object sender, EventArgs e)
        {
            newForm<frmTestPopup>();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
