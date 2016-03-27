namespace VSDropAssist.DropActions
{
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
        public string Delimiter { get; set; }
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

        public int Match(IDropQuery qry)
        {
            var ret = 0;
            if (this.ShiftMustBeDown && qry.ShiftDown) ret += 1;
            if (this.AltMustBeDown  && qry.AltDown ) ret += 1;
            if (this.ControlMustBeDown && qry.ControlDown) ret += 1;

            if (this.ShiftMustBeDown && !qry.ShiftDown) return 0;
            if (this.AltMustBeDown && !qry.AltDown) return 0;
            if (this.ControlMustBeDown && !qry.ControlDown) return 0;

            if (this.SupportsClasses && qry.ContainsClasses) ret += 1;
            if (this.SupportsMembers && qry.ContainsMembers) ret += 1;
            if (this.SupportsMembers && !qry.ContainsMembers && !this.SupportsClasses) return 0;
            if (this.SupportsClasses && !qry.ContainsClasses && !this.SupportsMembers) return 0;

            if (this.SupportsDroppingIntoClass && qry.DroppingIntoClass) ret+=1;
            if (this.SupportsDroppingIntoMethod && qry.DroppingIntoMethod) ret += 1;

            if (!this.SupportsDroppingIntoClass && qry.DroppingIntoClass && !qry.DroppingIntoMethod) return 0;
            if (!this.SupportsDroppingIntoMethod && qry.DroppingIntoMethod) return 0;

            return ret;
        }
    }
}