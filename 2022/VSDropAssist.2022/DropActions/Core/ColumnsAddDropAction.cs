using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    public class ColumnsAddDropAction : ConfigurableDropAction
    {
        public ColumnsAddDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                FormatExpression = "Columns.Add(%v%.%m%);",
                SupportsClasses = false,
                SupportsMembers = true,
                ControlMustBeDown = false,
                AltMustBeDown = false,
                ShiftMustBeDown = true,
                SupportsDroppingIntoClass = false,
                SupportsDroppingIntoMethod = true,
                SelectFirstLineOnly = false
            },
            "Columns.Add",
            "Adds the Columns.Add() command for every dropped column")
        {
        }
    }
}