using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSDropAssist.Settings
{
    public partial class VSDropAssistList : UserControl
    {
        private VSDropSettings _data;

        public VSDropAssistList()
        {
            InitializeComponent();
        }
        

        public VSDropSettings Data
        {
            get
            {
                this.settingsBindingSource.EndEdit();
                return _data;
            }
            set
            {
                _data = value;
                this.settingsBindingSource.DataSource = _data?.Settings;
                this.grid.Columns[0].Frozen = true;
                this.settingsBindingSource.ResetBindings(false );

            }
        }

        public IDropActionConfiguration SelectedItem
        {
            get
            {
                if (this.Data != null)
                {
                    return  (IDropActionConfiguration) this.settingsBindingSource.Current;
                }


                return null;
            }
        }
    }
}
