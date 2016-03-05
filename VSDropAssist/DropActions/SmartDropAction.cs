using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.VisualStudio.Imaging.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal class SmartDropAction : IDropAction
    {
        private readonly IFormatExpressionService _formatExpressionService;

        private Lazy< InsertColumnsAddDropAction> _insertColumnsAddDropAction ;
        private Lazy<InsertColumnsUpdateDropAction> _insertColumnsUpdateDropAction ;
        private Lazy<CommaDelimitedListDropAction> _commaDelimitedListDropAction;
        
        public SmartDropAction(IFormatExpressionService formatExpressionService )
        {
            _formatExpressionService = formatExpressionService;
            _insertColumnsAddDropAction =
                new Lazy<InsertColumnsAddDropAction>(() => new InsertColumnsAddDropAction(_formatExpressionService));
            _insertColumnsUpdateDropAction = new Lazy<InsertColumnsUpdateDropAction>(() => new InsertColumnsUpdateDropAction(_formatExpressionService ));
            _commaDelimitedListDropAction = new Lazy<CommaDelimitedListDropAction>(() => new CommaDelimitedListDropAction(_formatExpressionService ));
        }

        public IExecuteResult  Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo, string indentText)
        {
            var dropAction = getDropAction(dragDropInfo);

            if (dropAction != null)
            {
                // store the start buffer position
                var droppedPosition = dragDropInfo.VirtualBufferPosition.Position.Position;
                var droppedLine = dragDropInfo.VirtualBufferPosition.Position.GetContainingLine();
                var offset = droppedPosition - droppedLine.Start.Position;
                
                var indent = indentText.Length;
                
                var result =  dropAction.Execute(nodes, textView, dragDropInfo, indentText);

                if (result.SelectAfterDrop)
                {
                    
               
                    var startLine = textView.TextSnapshot.GetLineFromPosition(droppedPosition);
                    var start = new VirtualSnapshotPoint(startLine, offset  + result.SelectionStartInChars);
                    var endLine = textView.TextSnapshot.GetLineFromLineNumber(startLine.LineNumber + result.SelectionHeightInLines-1);
                    var end = new VirtualSnapshotPoint(endLine, offset + result.SelectionWidthInChars + result.SelectionStartInChars );
                    textView.Selection.Mode = TextSelectionMode.Box;

                    textView.Selection.Select(start, end);
                }
            }
            return ExecuteResult.None ;

        }

        private IDropAction getDropAction(DragDropInfo dragDropInfo)
        {
            if ((dragDropInfo.KeyStates & DragDropKeyStates.AltKey) != 0)
            {
                return _insertColumnsUpdateDropAction.Value ;
            }
            if ((dragDropInfo.KeyStates & DragDropKeyStates.ShiftKey) != 0)
            {
               return _insertColumnsAddDropAction.Value ;
            }
            if ((dragDropInfo.KeyStates & DragDropKeyStates.ControlKey) != 0)
            {
                MessageBox.Show("Not supported (yet)");
                return null;
                //return new DialogDropAction(_formatExpressionService);
            }
            return _commaDelimitedListDropAction.Value ;
        }
    }
}