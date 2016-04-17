using VSDropAssist.Core;
using VSDropAssist.Settings;

namespace VSDropAssist
{
    public interface IConfigurableDropAction : IDropAction
    {
        IDropActionConfiguration Configuration { get; }
    }
}