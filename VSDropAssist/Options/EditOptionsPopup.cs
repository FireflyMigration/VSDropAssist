using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDropAssist.Settings;

namespace VSDropAssist.Options
{
    public partial class EditOptionsPopup : Form
    {
        public EditOptionsPopup(IDropActionConfiguration selected)
        {
            
            InitializeComponent();

            this.vsDropAssistPopupControl1.Data = selected;

        }
    }
}
