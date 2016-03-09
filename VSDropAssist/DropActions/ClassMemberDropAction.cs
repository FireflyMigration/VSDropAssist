namespace VSDropAssist.DropActions
{
    internal abstract class ClassMemberDropAction : SimpleTextDropAction
    {
        public ClassMemberDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }

        public override bool getNodeFilter(Node n)
        {
            return base.getNodeFilter(n) && n.IsClass == false;
        }
    }
}