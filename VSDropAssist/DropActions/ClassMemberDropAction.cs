using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Core;
using VSDropAssist.Core.Entities;

namespace VSDropAssist.DropActions
{
    internal abstract class ClassMemberDropAction : SimpleTextDropAction
    {
        public ClassMemberDropAction(IFormatExpressionService formatExpressionService, IIndentationService indentationService) : base(formatExpressionService, indentationService)
        {
        }

        
        public override bool getNodeFilter(Node n)
        {
            return base.getNodeFilter(n) && n.IsClass == false;
        }
    }
}