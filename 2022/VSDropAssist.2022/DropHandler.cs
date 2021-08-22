using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using log4net;

using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

using VSDropAssist.Entities;

namespace VSDropAssist
{
    /// <summary>
    /// Routes drag and drop operations to the correct dropinfohandler strategy that determines what to drop
    /// </summary>
    internal class DropHandler : IDropHandler
    {
        private readonly IDropAction _dropAction; // new MessageBoxDropAction();
        private readonly IEnumerable<IDropInfoHandler> _dropInfoHandlers; // new GraphModelDropInfoHandler();
        private readonly ILog _log = LogManager.GetLogger(typeof(DropHandler));
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
            if (_tgt.IsClosed) return DragDropPointerEffects.None;

            try
            {
                //set the insertion point to follow the drop location
                _tgt.Caret.MoveTo(new SnapshotPoint(_tgt.TextSnapshot, dragDropInfo.VirtualBufferPosition.Position));

                return DragDropPointerEffects.Copy;
            }
            catch (TaskCanceledException tc)
            {
                _log.Info("TaskCancelledException retrieved whilst moving Caret to droplocation [can be ignored]", tc);
            }
            catch (InvalidOperationException e)
            {
                _log.Error("InvalidOperation trying to move the dragdrop cursor (view likely not initialized)", e);
            }
            catch (Exception e)
            {
                _log.Error("HandleDraggingOver", e);
            }
            return DragDropPointerEffects.None;
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
            if (result.DropActionResultEnum == DropActionResultEnum.AllowCopy) return DragDropPointerEffects.Copy;

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

        private IEnumerable<INode> getNodesfromDropInfo(DragDropInfo dragDropInfo)
        {
            try
            {
                var dropInfoHandler = _dropInfoHandlers.FirstOrDefault(x => x.CanUnderstand(dragDropInfo));
                if (dropInfoHandler == null)
                {
                    _log.Debug("No DropInfoHandler registered");
                    return null;
                }

                return dropInfoHandler.GetNodes(dragDropInfo);
            }
            catch (Exception e)
            {
                _log.Error("getNodesfromDropInfo", e);
            }
            return null;
        }
    }
}