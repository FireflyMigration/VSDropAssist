using VSDropAssist.Settings;

namespace VSDropAssist.Core
{
    public interface IDropQuery
    {
        bool ShiftDown { get; }
        bool ControlDown { get; }
        bool AltDown { get; }
        bool ContainsClasses { get;  }
        bool ContainsMembers { get; }
        bool DroppingIntoMethod { get;  }
        bool DroppingIntoClass { get; }

        int Match(IDropActionConfiguration tgt);
    }
}