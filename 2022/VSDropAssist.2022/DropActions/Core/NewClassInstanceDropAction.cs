using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    internal class NewClassInstanceDropAction : ConfigurableDropAction
    {
        public NewClassInstanceDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService,
            new DropActionConfiguration()
            {
                FormatExpression = "new %f%();",
                Delimiter = "\n",
                SupportsClasses = true,
                SupportsMembers = false,
                ControlMustBeDown = false,
                AltMustBeDown = true,
                ShiftMustBeDown = false,
                SupportsDroppingIntoClass = false ,
                SupportsDroppingIntoMethod = true
            },
            "New Instance",
            "Creates a new instance of the dropped class 'new XXX'")
        {
        }

        public override int Match(IDropQuery qry)
        {
            var ret = base.Match(qry);

            return ret;
        }
    }
}