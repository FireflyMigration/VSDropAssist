using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist
{
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

        private string getIndent(ITextView textView, VirtualSnapshotPoint virtualSnapshotPoint, ITextSnapshotLine line )
        {
            if (Application.EditorOperationsFactoryService == null)
            {
                _log.Debug("Failed to connect to EditorOperationsFactorySevice. Whitespace cannot be identifier");
             
            }
            else
            {

                var editorOperations = Application.EditorOperationsFactoryService.GetEditorOperations(textView);

                var whitespace = editorOperations.GetWhitespaceForVirtualSpace(virtualSnapshotPoint);

                if (whitespace.Length > 0) return whitespace;
            }
            if (Application.SmartIndentationService == null)
            {
                _log.Debug("SmartIndentService unavailable");
            }
            else
            {
                var ws = Application.SmartIndentationService.GetDesiredIndentation(textView, line);

                if (ws.HasValue) return new string( ' ',ws.Value);
            }
            return null;
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

            // store the start buffer position
        
            var droppedLine = dragDropInfo.VirtualBufferPosition.Position.GetContainingLine();

            var indentText = getIndent(_tgt, dragDropInfo.VirtualBufferPosition, droppedLine ) ?? "";

            var result = _dropAction.Execute(nodes, _tgt, dragDropInfo, indentText );
            if (result.DropActionResultEnum  == DropActionResultEnum.AllowCopy) return DragDropPointerEffects.Copy;

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