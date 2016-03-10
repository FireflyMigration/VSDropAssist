namespace VSDropAssist.DropActions
{
    internal class ClassPrivateDropAction:ClassOnlyDropAction
    {
        public ClassPrivateDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }
        
        protected override string GetFormatString()
        {
            return "public readonly %f% %v% = new %f%();\n";
        }
    }
}