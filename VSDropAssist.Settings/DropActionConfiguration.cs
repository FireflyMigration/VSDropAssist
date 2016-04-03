using System.Xml.Serialization;

namespace VSDropAssist.Settings
{
    [XmlRoot("DropActionConfiguration")]
    public class DropActionConfiguration : IDropActionConfiguration {
        public bool ShiftMustBeDown { get; set; }
        public bool ControlMustBeDown { get; set; }
        public bool AltMustBeDown { get; set; }
        public string FormatExpression { get; set; }
        public bool SelectAfterDrop { get; set; }
        public bool SupportsMembers { get; set; }
        public bool SupportsClasses { get; set; }
        public bool SupportsDroppingIntoMethod { get; set; }
        public bool SupportsDroppingIntoClass { get; set; }
        public string TokenToSelectAfterDrop { get; set; }
        public bool SelectFirstLineOnly { get;set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string Delimiter { get; set; }
        public string Name { get; set; }
        public DropActionConfiguration()
        {
            SupportsClasses = true;
            SupportsMembers = true;
            SupportsDroppingIntoClass = true;
            SupportsDroppingIntoMethod = true;
            SelectAfterDrop = true;
            TokenToSelectAfterDrop = "%v%";
            Delimiter = "\n";
            Prefix = "\n";
            SelectFirstLineOnly = true;
        }

     
    }
}