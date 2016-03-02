using System.Xml.Serialization;

namespace VSDropAssist.Settings
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
}