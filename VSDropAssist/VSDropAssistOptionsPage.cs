using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using VSDropAssist.Settings;
using VSDropAssistOptionsControl = VSDropAssist.Options.VSDropAssistOptionsControl;

namespace VSDropAssist
{
    public class VSDropAssistOptionsPage : DialogPage, IOptionsOwner
    {
       
    
    
       

        public VSDropSettings Settings
        {
            get
            {
                
                
                return Application.Settings;
            }
        }

        public override void SaveSettingsToStorage()
        {
            base.SaveSettingsToStorage();

            Application.SaveSettingsToStorage();

        }
        public override void LoadSettingsFromStorage()
        {
            base.LoadSettingsFromStorage();

            Application.LoadSettingsFromStorage();

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