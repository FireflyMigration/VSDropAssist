using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;

namespace VSDropAssist.Options
{
    [XmlRoot("SETTING")]
    public class DropSetting
    {
        public DropSetting(string key, string formatExpression)
        {
            this.Key = key;
            this.FormatExpression = formatExpression;
        }

        public DropSetting()
        {
            
        }

        [XmlElement("KEY")]
        public string Key { get; set; }
        [XmlElement("FORMATEXPRESSION")]
        public string FormatExpression { get; set; }
    }
    [XmlRoot("options")]
    public class VSDropSettings
    {
        public const string CONTROL = "control";
        public const string ALT = "alt";

        public VSDropSettings()
        {
            this.Settings = new List<DropSetting>();
           
        }
        public string GetControlFormatExpression()
        {
            var setting= this.Settings.FirstOrDefault(x => x.Key.Equals(CONTROL, StringComparison.CurrentCultureIgnoreCase));
            if (setting != null) return setting.FormatExpression;
            return null;
        }

        public string GetAltFormatExpression()
        {

            var setting = this.Settings.FirstOrDefault(x => x.Key.Equals(ALT, StringComparison.CurrentCultureIgnoreCase));
            if (setting != null) return setting.FormatExpression;
            return null;
        }
        public string ToXml()
        {
            var xs = new XmlSerializer(GetType()) ;
            using (var sw = new StringWriter())
            {
                xs.Serialize(sw, this);
                return sw.ToString();
            }
                
        }

        public static VSDropSettings FromXml(string xml)
        {
            var xs = new XmlSerializer(typeof(VSDropSettings));
            using (var sr = new StringReader(xml))
            {
                return (VSDropSettings)xs.Deserialize(sr);
                    
            }

        }
      

        [XmlArray("SETTINGS")]
        [XmlArrayItem("SETTING", typeof(DropSetting))]
        public List<DropSetting> Settings { get; set; }

        public static VSDropSettings Default
        {
            get
            {
                var ret = new VSDropSettings();
                ret.Settings.Add(new DropSetting(CONTROL, "{v}.{m}.Value = new{m};\n"));
                ret.Settings.Add(new DropSetting(ALT, "Columns.Add({v}.{m});\n"));
                return ret;
            }
        }

        const string collectionName = "VSDropAssistVSIX";

        public static void SaveToStorage(VSDropSettings settings)
        {

            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.CollectionExists(collectionName))
                userSettingsStore.CreateCollection(collectionName);

            if (settings == null) settings = new VSDropSettings();

            var s = settings;
            userSettingsStore.SetString(
                collectionName,
                nameof(VSDropSettings), s.ToXml()
                );
        }

        public static VSDropSettings LoadSettingsFromStorage()
        {
            var settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            var userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!userSettingsStore.PropertyExists(collectionName, nameof(VSDropSettings)))
                return null;

            var xmlData = userSettingsStore.GetString(collectionName, nameof(VSDropSettings));

            if (!string.IsNullOrEmpty(xmlData)) return VSDropSettings.FromXml(xmlData);

            return null;
        }
    }
}