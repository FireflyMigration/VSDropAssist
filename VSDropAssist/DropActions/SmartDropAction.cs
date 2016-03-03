using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    internal class SmartDropAction : IDropAction
    {
        private readonly IFormatExpressionService _formatExpressionService;

        private Lazy< InsertColumnsAddDropAction> _insertColumnsAddDropAction = new Lazy<InsertColumnsAddDropAction>( ()=> new InsertColumnsAddDropAction());
        private Lazy<InsertColumnsUpdateDropAction> _insertColumnsUpdateDropAction = new Lazy<InsertColumnsUpdateDropAction>( ()=> new InsertColumnsUpdateDropAction());
        private Lazy<CommaDelimitedListDropAction> _commaDelimitedListDropAction = new Lazy<CommaDelimitedListDropAction>(()=> new CommaDelimitedListDropAction());
        
        public SmartDropAction(IFormatExpressionService formatExpressionService )
        {
            _formatExpressionService = formatExpressionService;
        }

        public DropActionResultEnum Execute(IEnumerable<Node> nodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            var dropAction = getDropAction(dragDropInfo);

            if (dropAction != null)
            {
                return dropAction.Execute(nodes, textView, dragDropInfo);
            }
            return DropActionResultEnum.None;

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