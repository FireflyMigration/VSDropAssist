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
      

        public VSDropSettings()
        {
            this.Settings = new List<DropSetting>();
            this.NormaliseProjectNamespace = true;
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
                ret.NormaliseProjectNamespace = true;
                return ret;
            }
        }

        public bool NormaliseProjectNamespace { get; set; }
    }
}