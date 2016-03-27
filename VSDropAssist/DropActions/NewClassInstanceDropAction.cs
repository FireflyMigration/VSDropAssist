namespace VSDropAssist.DropActions
{
    internal class NewClassInstanceDropAction : ConfigurableDropAction
    {
        public NewClassInstanceDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService,
            new DropActionConfiguration() { FormatExpression = "new %f%();", Delimiter="\n", AltMustBeDown=true, SupportsMembers = false, SupportsDroppingIntoClass = false, SupportsDroppingIntoMethod = true })
        {
        }

        
        
    }
}