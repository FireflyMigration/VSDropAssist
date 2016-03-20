using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal abstract class ClassOnlyDropAction : SimpleTextDropAction
    {
        public override bool getNodeFilter(Node n)
        {
            return base.getNodeFilter(n) && n.IsClass;
        }

        protected override bool getSelectAfterDrop()
        {
            return false ;
        }

        
        public ClassOnlyDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
    }
}