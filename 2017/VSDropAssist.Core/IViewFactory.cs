namespace VSDropAssist.Core
{
    public interface IViewFactory
    {
        T Create<T, TMODEL>(TMODEL model);
    }
}