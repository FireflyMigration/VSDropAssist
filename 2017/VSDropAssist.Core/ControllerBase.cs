namespace VSDropAssist.Core
{
    public abstract class ControllerBase : IController
    {
        private readonly IViewFactory _viewFactory;

        protected ControllerBase(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        protected TVIEW createView<TVIEW, TMODEL>(TMODEL model)
        {
            return _viewFactory.Create<TVIEW, TMODEL>(model);
        }
    }
}