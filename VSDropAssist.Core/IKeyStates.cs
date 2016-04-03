namespace VSDropAssist.Core
{
    public interface IKeyStates {
        bool AltKeyDown { get; }
        bool ShiftKeyDown { get; }
        bool ControlKeyDown { get; }

    }
}