namespace VSDropAssist.Core
{
    public interface IControllerFactory
    {
        T Create<T>() where T : IController;
    }
}