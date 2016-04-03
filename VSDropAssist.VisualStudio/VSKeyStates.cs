using VSDropAssist.Core;

namespace VSDropAssist.VisualStudio
{
    public class VSKeyStates : IKeyStates
    {
        public bool AltKeyDown { get; private set; }

        public bool ControlKeyDown { get; private set; }

        public bool ShiftKeyDown        { get; private set; }

        public  VSKeyStates(bool alt, bool ctrl, bool shift )
        {
            this.AltKeyDown = alt;
            this.ControlKeyDown = ctrl;
            this.ShiftKeyDown = shift;
        }
    }
}