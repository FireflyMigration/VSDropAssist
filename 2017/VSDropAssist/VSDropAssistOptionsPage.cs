using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using VSDropAssist.Settings;

namespace VSDropAssist
{
    public class VSDropAssistOptionsPage : DialogPage, IOptionsOwner
    {
       
        private VSDropSettings _settings;
        private readonly IDropActionProvider _dropActionProvider;

        public VSDropAssistOptionsPage()
        {
            _settings = Application.Settings;
            _dropActionProvider = Application.GetDropActionsProvider();

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
                ret.Init(this, _dropActionProvider);

                return ret;
            }
        }


    }
}