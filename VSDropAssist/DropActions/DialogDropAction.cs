using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Settings;

namespace VSDropAssist.DropActions
{
    
    internal class DialogDropAction : DropActionBase
    {
        private readonly IFormatExpressionService _formatExpressionService;

        public DialogDropAction(IFormatExpressionService formatExpressionService)
        {
            _formatExpressionService = formatExpressionService;
        }

        public override DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            var settings = createSettings(dragDropInfo, textView);
            var dlg = new DropActionDialog();
            dlg.VSDropSettings = settings;
            var result = dlg.GetSelectedDropSetting();

            if (dlg.DialogResult == DialogResult.OK)
            {

               textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, getTextToInsert(nodes, result.FormatExpression, result.VariableName  ));
                
            }
            return DropActionResultEnum.None;
        }

        private string getTextToInsert(IEnumerable<Node> nodes,string formatExpression, string variableName )
        {
            return _formatExpressionService.ReplaceText(variableName, nodes, formatExpression);
        }

        private VSDropSettings createSettings(DragDropInfo dragDropInfo, IWpfTextView textView)
        {
            var ret = new VSDropSettings();

            //ret.VariableName = "variableName";

            //if ((dragDropInfo.KeyStates & DragDropKeyStates.AltKey ) != 0)
            //{
            //    ret.FormatExpression = "Columns.Add ({v}.{m});\n";
                
            //}
            //if ((dragDropInfo.KeyStates & DragDropKeyStates.ControlKey) != 0)
            //{
            //    ret.FormatExpression = "{v}.{m}.Value = ;\n";

            //}
            //ret.EvaluateEventHandler += (sender, args) =>
            //{
            //    var fmt = args.FormatExpression;
            //    if (!string.IsNullOrEmpty(args.VariableName))
            //    {
            //        fmt = fmt.Replace("{v}", args.VariableName);
            //    }
            //    else
            //    {
            //        fmt = fmt.Replace("{v}", "{t}");
            //    }
            //    fmt= fmt.Replace("{m}", "Property");
            //    fmt = fmt.Replace("{t}", "ClassName".ToLower());
            //    fmt = fmt.Replace("{T}", "ClassName");
            //    fmt = fmt.Replace("{a}", "MyAssembly");
            //    fmt = fmt.Replace("{n}", "Namespace");

            //    args.Example = fmt;
            //};
            return ret;
        }
    }
}