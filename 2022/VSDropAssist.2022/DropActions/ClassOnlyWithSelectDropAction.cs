namespace VSDropAssist.DropActions
{
    public abstract class ClassOnlyWithSelectDropAction : ConfigurableDropAction
    {
     
        protected  ClassOnlyWithSelectDropAction(IFormatExpressionService formatExpressionService, IDropActionConfiguration config, string name, string description ) : 
            base(formatExpressionService,config , name, description )
        {
        }
    }
}