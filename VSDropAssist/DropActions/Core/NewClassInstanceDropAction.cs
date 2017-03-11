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
            })
        {
        }

        public override int Match(DropQuery qry)
        {
            var ret = base.Match(qry);

            return ret;
        }


    }
}