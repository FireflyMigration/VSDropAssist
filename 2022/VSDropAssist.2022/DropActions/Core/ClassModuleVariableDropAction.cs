using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    public  class ClassModuleVariableDropAction : ClassOnlyWithSelectDropAction
    {
        public ClassModuleVariableDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService
            , new DropActionConfiguration()
            {
                FormatExpression = "public readonly %f% %v% = new %f%();\n",
                SupportsClasses = true,
                SupportsMembers = false,
                ControlMustBeDown = false,
                AltMustBeDown = false,
                ShiftMustBeDown = true ,
                SupportsDroppingIntoClass = true,
                SupportsDroppingIntoMethod = true
            },
            "Add Module variable",
            "Creates a new module-level variable for every dropped class")
        {
        }


    }
}