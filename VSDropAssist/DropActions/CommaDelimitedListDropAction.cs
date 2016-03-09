namespace VSDropAssist.DropActions
{
    internal class CommaDelimitedListDropAction : ClassMemberDropAction
    {

        private const string FORMAT = "%v%.%m%,\n";
        protected override string GetFormatString()
        {
            return FORMAT;
        }

        public CommaDelimitedListDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
    }
}