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
            this.Settings = new List<DropActionConfiguration>();
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
        [XmlArrayItem("SETTING", typeof(DropActionConfiguration))]
        public List<DropActionConfiguration> Settings { get; set; }

        
        public bool NormaliseProjectNamespace { get; set; }
    }
}