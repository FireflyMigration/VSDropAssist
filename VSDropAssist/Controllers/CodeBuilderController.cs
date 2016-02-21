using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSDropAssist.Core;

namespace VSDropAssist.Controllers
{
    public interface ICodeBuilderController : IController
    {
        
    }
    public class CodeBuilderController :ControllerBase, ICodeBuilderController
    {
        public CodeBuilderController(IViewFactory viewFactory) : base(viewFactory)
        {
        }
    }
}
