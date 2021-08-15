namespace VSDropAssist
{
    public interface IConfigurableDropAction : IDropAction {

        string Name { get; }
        string Description { get; }
        IDropActionConfiguration Configuration { get; }
    }
}