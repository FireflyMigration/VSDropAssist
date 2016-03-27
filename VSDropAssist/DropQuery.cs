namespace VSDropAssist
{
    public class DropQuery : IDropQuery
    {
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
    }
}