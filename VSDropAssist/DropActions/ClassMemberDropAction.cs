using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal abstract class ClassMemberDropAction : SimpleTextDropAction
    {
        public ClassMemberDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }

        protected override int getSelectionHeight(IEnumerable<Node> nodes)
        {
            return nodes.Count();
        }

        public override bool getNodeFilter(Node n)
        {
            return base.getNodeFilter(n) && n.IsClass == false;
        }
    }
}