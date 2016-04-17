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
            public IDropActionConfiguration SelectedSetting { get; private set; }
            public string ExampleText { get; set; }

            public SettingUpdateEventArgs(IDropActionConfiguration selectedSetting) 
            {
                
                SelectedSetting = selectedSetting;
            }
        }

        public EventHandler<SettingUpdateEventArgs> OnSettingUpdate;
        
        public VSDropAssistPopupControl()
        {
            InitializeComponent();

            
        }

      

        public IDropActionConfiguration Data
        {
            get
            {
                this.settingsBindingSource.EndEdit();
                return (IDropActionConfiguration )this.settingsBindingSource.DataSource;
            }
            set
            {
                this.settingsBindingSource.DataSource = value;
                var ipn = value as INotifyPropertyChanged;
                if (ipn != null)
                {
                    ipn.PropertyChanged += OnDataPropertyChanged;
                }
                   
            }
        }

        private void OnDataPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            fireOnSettingUpdate();
        }

        private void fireOnSettingUpdate()
        {
            var f = this.OnSettingUpdate;
            if (f != null)
            {
                f.Invoke(this, new SettingUpdateEventArgs(this.Data ));

            }
        }
    }
}
