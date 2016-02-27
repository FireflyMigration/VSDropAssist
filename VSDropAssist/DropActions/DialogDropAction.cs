using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal class DialogDropAction : DropActionBase
    {
        public DialogDropAction()
        {
            
        }
        public override DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            var settings = createSettings(dragDropInfo, textView);
            var dlg = new DropActionDialog();
            settings = dlg.GetSettings(settings);

            if (dlg.DialogResult == DialogResult.OK)
            {

                textView.TextBuffer.Insert(dragDropInfo.VirtualBufferPosition.Position.Position, getTextToInsert(nodes, settings ));
                
            }
            return DropActionResultEnum.None;
        }

        private string getTextToInsert(IEnumerable<Node> nodes, Settings settings )
        {
            var sb = new StringBuilder();

            foreach (var n in nodes)
            {
                var expr = settings.FormatExpression;
                
                expr = expr.Replace("{m}", n.Member);
                expr = expr.Replace("{t}", n.Type);
                expr = expr.Replace("{n}", n.Namespace);
                expr = expr.Replace("{a}", n.Assembly);
                expr = expr.Replace("{v}", string.IsNullOrEmpty(settings.VariableName ) ? n.Type.ToLower() : settings.VariableName );
                sb.AppendFormat("{0}", expr);

            }
            return sb.ToString();
        }

        private Settings createSettings(DragDropInfo dragDropInfo, IWpfTextView textView)
        {
            var ret = new Settings();
            ret.VariableName = "myCustomer";

            if ((dragDropInfo.KeyStates & DragDropKeyStates.AltKey ) != 0)
            {
                ret.FormatExpression = "Columns.Add ({v}.{m});\n";
                
            }
            if ((dragDropInfo.KeyStates & DragDropKeyStates.ControlKey) != 0)
            {
                ret.FormatExpression = "{v}.{m}.Value = ;\n";

            }
            ret.EvaluateEventHandler += (sender, args) =>
            {
                var fmt = args.FormatExpression;
                if (!string.IsNullOrEmpty(args.VariableName))
                {
                    fmt = fmt.Replace("{v}", args.VariableName);
                }
                else
                {
                    fmt = fmt.Replace("{v}", "{t}");
                }
                fmt= fmt.Replace("{m}", "Property");
                fmt = fmt.Replace("{t}", "ClassName".ToLower());
                fmt = fmt.Replace("{T}", "ClassName");
                fmt = fmt.Replace("{a}", "MyAssembly");
                fmt = fmt.Replace("{n}", "Namespace");

                args.Example = fmt;
            };
            return ret;
        }
    }
}