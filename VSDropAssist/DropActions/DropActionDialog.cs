using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDropAssist.Annotations;
using VSDropAssist.Options;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
 
    public partial class DropActionDialog : Form
    {
        private  VSDropSettings _vsDropSettings;

        public DropActionDialog()
        {
           
            InitializeComponent();
        }
        public VSDropSettings VSDropSettings {  get { return _vsDropSettings; }
            set { _vsDropSettings = value; }
        }

        public UserDropSetting GetSelectedDropSetting()
        {
            this.vsDropAssistPopupControl1.Data = _vsDropSettings;
            this.ShowDialog();
            
            return new UserDropSetting()
            {
                VariableName = this.vsDropAssistPopupControl1.VariableName,
                FormatExpression = this.vsDropAssistPopupControl1.FormatExpression,
                DropSetting = this.vsDropAssistPopupControl1.SelectedItem
            };
        }

       
    }

    public class UserDropSetting
    {
        public string VariableName { get; set; }
        public string FormatExpression { get; set; }
        public DropSetting DropSetting { get; set; }
    }
}
