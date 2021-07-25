

using System.Collections.Generic;
using System.Xml.Serialization;

namespace VSDropAssist.Settings
{
    [XmlRoot("DropActionConfiguration")]
    public class DropActionConfiguration : IDropActionConfiguration {
        private const bool BRIEF_TOSTRING = true;

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
            SelectFirstLineOnly = true;
        }

        public override string ToString()
        {

            if (BRIEF_TOSTRING)
            {
                var keys = new List<string>();
                if(ShiftMustBeDown) keys.Add($"Shift");
                if (ControlMustBeDown) keys.Add($"Control");
                if (AltMustBeDown) keys.Add($"Alt");

                var tgt = new List<string>();
                if (SupportsClasses) tgt.Add("classes");
                if (SupportsDroppingIntoMethod) tgt.Add("methods");
                if (SupportsDroppingIntoClass) tgt.Add("class");

                return string.Join("+",keys) + " (" + string.Join("|",tgt) + ")";
            }

            return $"ShiftMustBeDown: {ShiftMustBeDown}, ControlMustBeDown: {ControlMustBeDown}, AltMustBeDown: {AltMustBeDown}, Classes: {SupportsClasses}, Members: {SupportsMembers}, DroppingIntoMethod: {SupportsDroppingIntoMethod}, DroppingIntoClass: {SupportsDroppingIntoClass}";

        }
    }
}