using System.Collections.Generic;
using log4net;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.DropActions;
using VSDropAssist.DropInfoHandlers;

namespace VSDropAssist
{
    internal class DropHandler : IDropHandler
    {
        private ILog _log = LogManager.GetLogger(typeof(DropHandler));
        private IDropInfoHandler _dropInfoHandler = null; // new GraphModelDropInfoHandler();
        private IDropAction _dropAction = null; // new MessageBoxDropAction();
        private IWpfTextView _tgt;

        public DropHandler(IWpfTextView wpfTextView, IDropInfoHandler dropInfoHandler, IDropAction dropAction )
        {
            _tgt = wpfTextView;
            _dropInfoHandler = dropInfoHandler;
            _dropAction = dropAction;
        }

        public DragDropPointerEffects HandleDragStarted(DragDropInfo dragDropInfo)
        {
            return DragDropPointerEffects.Copy;
        }

        public DragDropPointerEffects HandleDraggingOver(DragDropInfo dragDropInfo)
        {
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

            var result = _dropAction.Execute(nodes, _tgt);
            if(result == DropActionResultEnum.AllowCopy) return DragDropPointerEffects.Copy ;

            return DragDropPointerEffects.None;

        }

        private IEnumerable<Node> getNodesfromDropInfo(DragDropInfo dragDropInfo)
        {
            if (_dropInfoHandler == null)
            {
                _log.Debug("No DropInfoHandler registered");
                return null;
            }
            return _dropInfoHandler.GetNodes(dragDropInfo);
        }


        public bool IsDropEnabled(DragDropInfo dragDropInfo)
        {

            return true;

        }

        public void HandleDragCanceled()
        {
            // ignore it
        }

       
    }
}