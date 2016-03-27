namespace VSDropAssist.DropActions
{
    internal abstract class ClassOnlyWithSelectDropAction : ConfigurableDropAction
    {
     
        protected  ClassOnlyWithSelectDropAction(IFormatExpressionService formatExpressionService, IDropActionConfiguration config ) : base(formatExpressionService,config  )
        {
        }
    }
}