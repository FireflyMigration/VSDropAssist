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

            this.vsDropAssistOptionsControl1.Init(this );
        }

        private void initSettings()
        {
            _settings = new VSDropSettings();
            foreach (var i in Enumerable.Range(1,5))
            {
                _settings.Settings.Add(new DropSetting("Key" + i, "expr" + i ));
            }
            
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
    }
}
