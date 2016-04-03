using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSDropAssist.Settings
{
   
    public partial class VSDropAssistPopupControl : UserControl
    {
        public class SettingUpdateEventArgs : EventArgs
        {
            public DropActionConfiguration SelectedSetting { get; private set; }
            public string ExampleText { get; set; }

            public SettingUpdateEventArgs(DropActionConfiguration selectedSetting) 
            {
                
                SelectedSetting = selectedSetting;
            }
        }

        public EventHandler<SettingUpdateEventArgs> OnSettingUpdate;
        
        public VSDropAssistPopupControl()
        {
            InitializeComponent();
        }
        
        public DropActionConfiguration Data
        {
            get { return (DropActionConfiguration)this.settingsBindingSource.DataSource; } 
            set { this.settingsBindingSource.DataSource = value; }
        }

        
    }
}
