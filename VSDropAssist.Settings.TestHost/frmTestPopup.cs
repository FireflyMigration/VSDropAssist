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
        private IDropActionConfiguration _dataItem;


        public frmTestPopup()
        {
            InitializeComponent();
            this.vsDropAssistPopupControl1.OnSettingUpdate += OnSettingUpdate;
        }
        public frmTestPopup(IDropActionConfiguration item):this()
        {
            
            _dataItem = item;
            
            
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

            this.vsDropAssistPopupControl1.Data = _dataItem;

        }

        private void vsDropAssistPopupControl1_Load(object sender, EventArgs e)
        {

        }

        private void saveControl_Click(object sender, EventArgs e)
        {
            var finished = this.vsDropAssistPopupControl1.Data;

            MessageBox.Show(finished.ToString());

        }
    }
}
