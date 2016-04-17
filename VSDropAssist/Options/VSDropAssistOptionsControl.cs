using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VSDropAssist.DropActions;
using VSDropAssist.Settings;
using VSDropAssist.Core;

namespace VSDropAssist.Options
{
    public partial class VSDropAssistOptionsControl : UserControl
    {
        private IOptionsOwner _owner;

        public VSDropAssistOptionsControl()
        {
            InitializeComponent();
        }

        public void Init(IOptionsOwner owner)
        {
            _owner = owner;
            if (_owner != null)
            {
                // show the settings
                this.DataSource = _owner?.Settings;
            }
        
        }

        private VSDropSettings DataSource
        {
            get { return this.vsDropAssistList1.Data; }
            set { this.vsDropAssistList1.Data = value; }
        }

        private void ViewControl_Click(object sender, EventArgs e)
        {
            var selected = this.vsDropAssistList1.SelectedItem;
            if (selected != null)
            {
                var clone = selected.Clone();
                var dlg = new EditOptionsPopup(clone  );

                DialogResult result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    selected.CopyFrom(clone);

                }
            }
        }
    }
}
