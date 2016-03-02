using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace VSDropAssist.Settings
{
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

    }
}