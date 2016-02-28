using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using VSDropAssist.Options;

namespace VSDropAssist
{
    public class VSDropAssistOptionsPage : DialogPage
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

            VSDropSettings.SaveToStorage(this.Settings);

        }
        public override void LoadSettingsFromStorage()
        {
            base.LoadSettingsFromStorage();

            _settings = VSDropSettings.LoadSettingsFromStorage();

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