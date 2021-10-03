using System.Collections.Generic;
using System.Xml.Serialization;
using VSDropAssist.Settings;

namespace VSDropAssist
{
    public class Configuration
    {
        [XmlElement("Item")]
        public IEnumerable<DropActionConfiguration> Items { get; set; }

        public static Configuration FromXml(string filepath)
        {
            var s = new XmlSerializer(typeof(Configuration));
            using (var r = System.Xml.XmlReader.Create(filepath))
            {

                return (Configuration)s.Deserialize(r);

            }
            return null;
        }


    }
}