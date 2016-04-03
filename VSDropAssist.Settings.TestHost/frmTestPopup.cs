using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDropAssist.Core;
using VSDropAssist.DropActions;


namespace VSDropAssist.Settings.TestHost
{
    public partial class frmTestPopup : Form
    {
        private IFormatExpressionService _formatExpressionService;

        public frmTestPopup()
        {
            InitializeComponent();
            this.vsDropAssistPopupControl1.OnSettingUpdate += OnSettingUpdate;
            _formatExpressionService = new FormatExpressionService();
        }

        private void OnSettingUpdate(object sender, VSDropAssistPopupControl.SettingUpdateEventArgs args)
        {

            
        }

        private void frmTestPopup_Load(object sender, EventArgs e)
        {
            initData();
        }

        private void initData()
        {
            var s = new VSDropSettings();

            for(var i=0; i<10; i++)
            s.Settings.Add(new DropActionConfiguration() { Name=$"Item{i}" });

            this.vsDropAssistPopupControl1.Data = s.Settings.First();

        }

        private void vsDropAssistPopupControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
