using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using log4net;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.DropActions;

namespace VSDropAssist
{
    internal class SmartDropAction : IDropAction
    {
        private readonly IFormatExpressionService _formatExpressionService;

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
                return new InsertColumnsUpdateDropAction();
            }
            if ((dragDropInfo.KeyStates & DragDropKeyStates.ShiftKey) != 0)
            {
                return new InsertColumnsAddDropAction();
            }
            if ((dragDropInfo.KeyStates & DragDropKeyStates.ControlKey) != 0)
            {
                // not supported yet
                MessageBox.Show("Not supported (yet)");
                return null;
                //return new DialogDropAction(_formatExpressionService);
            }

            return new CommaDelimitedListDropAction();
        }
    }
    internal class DropHandler : IDropHandler
    {
        private readonly IDropAction _dropAction; // new MessageBoxDropAction();
        private readonly IEnumerable<IDropInfoHandler> _dropInfoHandlers; // new GraphModelDropInfoHandler();
        private readonly ILog _log = LogManager.GetLogger(typeof (DropHandler));
        private readonly IWpfTextView _tgt;

        public DropHandler(IWpfTextView wpfTextView, IEnumerable<IDropInfoHandler> dropInfoHandlers, IDropAction dropAction)
        {
            _log.Debug("DropHandler.ctor");
            _tgt = wpfTextView;
            _dropInfoHandlers = dropInfoHandlers;
            _dropAction = dropAction;
        }

        public DragDropPointerEffects HandleDragStarted(DragDropInfo dragDropInfo)
        {
            return DragDropPointerEffects.Copy;
        }

        public DragDropPointerEffects HandleDraggingOver(DragDropInfo dragDropInfo)
        {
            try
            {
                //set the insertion point to follow the drop location
                _tgt.Caret.MoveTo(dragDropInfo.VirtualBufferPosition);

                return DragDropPointerEffects.Copy;
            }
            catch (Exception e)
            {
                _log.Error("HandleDraggingOver", e );
            }
            return DragDropPointerEffects.Copy;
        }

        public DragDropPointerEffects HandleDataDropped(DragDropInfo dragDropInfo)
        {
            //dump(dragDropInfo);
            var nodes = getNodesfromDropInfo(dragDropInfo);

            if (nodes == null)
            {
                _log.Debug("did not understand dropped info");
                return DragDropPointerEffects.None;
            }
            if (_dropAction == null)
            {
                _log.Debug("No DropAction specified");
                return DragDropPointerEffects.None;
            }
            
            var result = _dropAction.Execute(nodes, _tgt, dragDropInfo);
            if (result == DropActionResultEnum.AllowCopy) return DragDropPointerEffects.Copy;

            return DragDropPointerEffects.None;
        }


        public bool IsDropEnabled(DragDropInfo dragDropInfo)
        {
            return true;
        }

        public void HandleDragCanceled()
        {
            // ignore it
        }

        private IEnumerable<Node> getNodesfromDropInfo(DragDropInfo dragDropInfo)
        {
            try
            {
                
                var dropInfoHandler = _dropInfoHandlers.FirstOrDefault(x => x.CanUnderstand(dragDropInfo));
                if (dropInfoHandler == null )
                {
                    _log.Debug("No DropInfoHandler registered");
                    return null;
                }

                return dropInfoHandler.GetNodes(dragDropInfo);
            }
            catch (Exception e)
            {
                _log.Error("getNodesfromDropInfo", e );
            }
            return null;
        }
    }
}