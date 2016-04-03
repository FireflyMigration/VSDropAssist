using System.Windows;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Core;

namespace VSDropAssist.VisualStudio
{
    public class VSDragDropInfo : IDragDropInfo
    {
        private DragDropInfo _dragDropInfo;

        public  VSDragDropInfo(DragDropInfo dragDropInfo)
        {
            _dragDropInfo = dragDropInfo;
        }

        public IKeyStates KeyStates
        {
            get
            {

                return new VSKeyStates(
                    ((_dragDropInfo.KeyStates & DragDropKeyStates.AltKey) != 0),
                    ((_dragDropInfo.KeyStates & DragDropKeyStates.ControlKey) != 0),
                    ((_dragDropInfo.KeyStates & DragDropKeyStates.ShiftKey) != 0)
                    );
            }
        }

        public object GetData(string dataformat)
        {
            return _dragDropInfo.Data.GetData(dataformat);
        }

        public T GetData<T>(string dataformat)
        {
            return (T)_dragDropInfo.Data.GetData(dataformat);
        }

        public object GetDataObject()
        {
            return _dragDropInfo.Data;
        }

        public bool GetDataPresent(string dataformat)
        {
            return _dragDropInfo.Data.GetDataPresent(dataformat );
        }

        public ILine  GetDroppingLine()
        {
            return new VSLine(_dragDropInfo.VirtualBufferPosition.Position.GetContainingLine());

        }

        public IEndPoint GetEndPoint()
        {
            return new  VSEndPoint( _dragDropInfo.VirtualBufferPosition.Position.GetContainingLine().End);

        }

        public int GetStartPosition()
        {
            return _dragDropInfo.VirtualBufferPosition.Position.Position;

            
        }
    }
}