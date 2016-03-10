using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using EnvDTE;
using log4net;
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
        private Lazy<ClassFullNameDropAction> _classFullNameDropAction;
        private ILog _log = LogManager.GetLogger(typeof (SmartDropAction));
        private Lazy<ClassVarDropAction> _classVarDropAction;
        private Lazy<ClassPrivateDropAction> _classPrivateDropAction;

        public SmartDropAction(IFormatExpressionService formatExpressionService )
        {
            _formatExpressionService = formatExpressionService;
            _insertColumnsAddDropAction =
                new Lazy<InsertColumnsAddDropAction>(() => new InsertColumnsAddDropAction(_formatExpressionService));
            _insertColumnsUpdateDropAction = new Lazy<InsertColumnsUpdateDropAction>(() => new InsertColumnsUpdateDropAction(_formatExpressionService ));
            _commaDelimitedListDropAction = new Lazy<CommaDelimitedListDropAction>(() => new CommaDelimitedListDropAction(_formatExpressionService ));
            _classFullNameDropAction = new Lazy<ClassFullNameDropAction>(()=> new ClassFullNameDropAction(_formatExpressionService ));
            _classVarDropAction = new Lazy<ClassVarDropAction>(() => new ClassVarDropAction(_formatExpressionService));
            _classPrivateDropAction = new Lazy<ClassPrivateDropAction>(() => new ClassPrivateDropAction(_formatExpressionService));

        }

        public IExecuteResult  Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo, string indentText)
        {
            var dropAction = getDropAction(nodes, dragDropInfo);

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
                    var start = new VirtualSnapshotPoint(startLine,Math.Max(0, offset  + result.SelectionStartInChars));

                    var endLine = startLine;
                    if (result.SelectionHeightInLines > 1)
                       endLine= textView.TextSnapshot.GetLineFromLineNumber(startLine.LineNumber +
                                                                    result.SelectionHeightInLines - 1);
                            
                    var end = new VirtualSnapshotPoint(endLine, offset + result.SelectionWidthInChars + result.SelectionStartInChars );
                    textView.Selection.Mode = TextSelectionMode.Box;

                    textView.Selection.Select(start, end);
                }
            }
            return ExecuteResult.None ;

        }

        private IDropAction getDropAction(IEnumerable<Node> nodes, DragDropInfo dragDropInfo)
        {
            // if dropping any non-classes
            if (nodes.Any(x => x.IsClass == false))
            {
                if ((dragDropInfo.KeyStates & DragDropKeyStates.AltKey) != 0)
                {
                    return _insertColumnsUpdateDropAction.Value;
                }
                if ((dragDropInfo.KeyStates & DragDropKeyStates.ShiftKey) != 0)
                {
                    return _insertColumnsAddDropAction.Value;
                }
                if ((dragDropInfo.KeyStates & DragDropKeyStates.ControlKey) != 0)
                {
                    MessageBox.Show("Not supported (yet)");
                    return null;
                    //return new DialogDropAction(_formatExpressionService);
                }
                return _commaDelimitedListDropAction.Value;
            }
            else
            {

                if ((dragDropInfo.KeyStates & DragDropKeyStates.ShiftKey) != 0)
                {
                    var codeElementHelper = new CodeElementHelper();

                    var droppedClass =(CodeClass) codeElementHelper.GetCodeElement(Application.DTE.Value,
                        dragDropInfo.VirtualBufferPosition.Position, vsCMElement.vsCMElementClass);
                    var droppedMethod =(CodeFunction ) codeElementHelper.GetCodeElement(Application.DTE.Value,
                        dragDropInfo.VirtualBufferPosition.Position, vsCMElement.vsCMElementFunction);

                    if (droppedMethod != null)
                    {
                        // in a method, create a var
                        _log.Debug("Create a var in " + droppedMethod.FullName);
                        
                        return _classVarDropAction.Value;
                    }
                    if (droppedClass != null)
                    {
                        _log.Debug("Create a private in " + droppedClass.FullName);
                        // in a class, but not a method, create a private variable
                        return _classPrivateDropAction.Value;
                    }
                    _log.Debug(
                        "Shift held down, but could not identify a class or function at the drop location. Reverting to full classname");
                }
                
                // at least 1 class, so just drop the classes
                    return _classFullNameDropAction.Value;
            }
            return null;
        }


    }
}