using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    public class CommaDelimitedListDropAction : ConfigurableDropAction
    {
        public CommaDelimitedListDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                FormatExpression = "%v%.%m%,",
                Delimiter = "\n",
                SupportsClasses = false,
                SupportsMembers = true,
                ControlMustBeDown = false,
                AltMustBeDown = false,
                ShiftMustBeDown = false,
                SupportsDroppingIntoClass = false,
                SupportsDroppingIntoMethod = true,
                SelectFirstLineOnly = false
            },
            "Comma-Delimited List",
            "Adds a comma delimited list of every column dropped")
        {
        }
    }
}