namespace VSDropAssist
{
    public class DropQuery : IDropQuery
    {
        public static int ControlKeyMatchAmount = 10;
        public static int DropTargetMatchAmount = 100;
        public static int DroppingClassesAndMembersMatchAmount = 1;

        public bool ShiftDown { get; set; }
        public bool ControlDown { get; set; }
        public bool AltDown { get; set; }
        public bool ContainsClasses { get; set; }
        public bool ContainsMembers { get; set; }
        public bool DroppingIntoMethod { get; set; }
        public bool DroppingIntoClass { get; set; }

        public override string ToString()
        {
            return $"ShiftDown: {ShiftDown}, ControlDown: {ControlDown}, AltDown: {AltDown}, ContainsClasses: {ContainsClasses}, ContainsMembers: {ContainsMembers}, DroppingIntoMethod: {DroppingIntoMethod}, DroppingIntoClass: {DroppingIntoClass}";
        }
        public int Match(IDropActionConfiguration tgt)
        {
            var ret = 0;

            if (tgt.ShiftMustBeDown && !this.ShiftDown) return 0;
            if (tgt.AltMustBeDown && !this.AltDown) return 0;
            if (tgt.ControlMustBeDown && !this.ControlDown) return 0;

            if (tgt.SupportsMembers && !this.ContainsMembers && !tgt.SupportsClasses) return 0;
            if (tgt.SupportsClasses && !this.ContainsClasses && !tgt.SupportsMembers) return 0;

            
            if (!tgt.SupportsDroppingIntoClass && this.DroppingIntoClass && !this.DroppingIntoMethod) return 0;
            if (!tgt.SupportsDroppingIntoMethod && this.DroppingIntoMethod) return 0;


            if (tgt.ShiftMustBeDown && this.ShiftDown) ret += ControlKeyMatchAmount;
            if (tgt.AltMustBeDown && this.AltDown) ret += ControlKeyMatchAmount;
            if (tgt.ControlMustBeDown && this.ControlDown) ret += ControlKeyMatchAmount;

            if (tgt.SupportsClasses && this.ContainsClasses) ret += DroppingClassesAndMembersMatchAmount;
            if (tgt.SupportsMembers && this.ContainsMembers) ret += DroppingClassesAndMembersMatchAmount;
            if(this.DroppingIntoMethod)
            {
                if (tgt.SupportsDroppingIntoMethod) ret += DropTargetMatchAmount;
            }else if (this.DroppingIntoClass)
            {
                if (tgt.SupportsDroppingIntoClass) ret += DropTargetMatchAmount;
            }
            
            return ret;
        }
    }
}