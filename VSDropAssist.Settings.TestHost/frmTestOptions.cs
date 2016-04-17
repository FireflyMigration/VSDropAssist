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
    public partial class frmTestOptions : Form , IOptionsOwner
    {
        private VSDropSettings _settings;

        public frmTestOptions()
        {
            InitializeComponent();
            initSettings();
            
        }

        private void initSettings()
        {
            _settings = new VSDropSettings();
            foreach (var i in Enumerable.Range(1,50))
            {
                _settings.Settings.Add(new DropActionConfiguration() {Name= $"item {i}"});
            }

            this.vsDropAssistList1.Data = _settings;

        }

        private void SaveControl_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public VSDropSettings Settings { get { return _settings; } }
        public void ResetSettings()
        {
            initSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetSettings();
        }

        private void editControl_Click(object sender, EventArgs e)
        {
            var selected = this.vsDropAssistList1.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("You must select a setting to edit");
                return;
            }

            var dlg = new frmTestPopup(selected);
            var result = dlg.ShowDialog();
        }
    }
}
