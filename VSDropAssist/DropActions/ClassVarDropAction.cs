namespace VSDropAssist.DropActions
{
    internal class ClassVarDropAction : ClassOnlyDropAction 
    {
        public ClassVarDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService)
        {
        }

        protected override string GetFormatString()
        {
            return "var %v% = new %f%();\n";
        }
    }
}