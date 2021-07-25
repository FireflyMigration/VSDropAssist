using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using VSDropAssist.Settings;
using VSDropAssistOptionsControl = VSDropAssist.Options.VSDropAssistOptionsControl;

namespace VSDropAssist
{
    public class VSDropAssistOptionsPage : DialogPage, IOptionsOwner
    {
       
        private VSDropSettings _settings;

        public VSDropAssistOptionsPage()
        {
            _settings = Application.Settings;

        }

       

        public VSDropSettings Settings
        {
            get
            {
                Application.ResetSettings();
                _settings = Application.Settings;
                return _settings;
            }
        }

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();
            
            SettingsHelper.SaveToStorage(this.Settings);

        }
        public override void LoadSettingsFromStorage()
        {
            base.LoadSettingsFromStorage();

            _settings = SettingsHelper.LoadSettingsFromStorage();

        }

        protected override IWin32Window Window
        {
            get
            {
                var ret = new VSDropAssistOptionsControl();
                ret.Init(this);

                return ret;
            }
        }


    }
}