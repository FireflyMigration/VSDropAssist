using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    public class ClassFullNameDropAction : ConfigurableDropAction
    {

        public ClassFullNameDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService,
             new DropActionConfiguration()
             {
                 FormatExpression = "%f%",
                 Delimiter = "\n",
                 TokenToSelectAfterDrop = "%f%",
                 SupportsClasses=true,
                 SupportsMembers = false,
                 ControlMustBeDown = false,
                 AltMustBeDown = false,
                 ShiftMustBeDown = false,
                 SupportsDroppingIntoClass = true,
                 SupportsDroppingIntoMethod = true
             },
             "Full TypeName",
             "Adds the Declaration/Class name")
        {
        }

    }
}