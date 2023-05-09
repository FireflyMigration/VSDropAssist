using System;
using System.Windows.Forms;
using log4net;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist
{
    public static class Extensions
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof (Extensions));

        public static void Dump(this DragDropInfo dragDropInfo)
        {
            try
            {
                _log.Debug("DragDropInfo");
                _log.DebugFormat("Source:{0}", dragDropInfo.Source);
                _log.DebugFormat("Formats:\n{0}", string.Join("\n", dragDropInfo.Data.GetFormats()));

                foreach (var d in dragDropInfo.Data.GetFormats())
                {
                    _log.DebugFormat("--------------START----------------------------");
                    _log.DebugFormat("Format: {0}", d);
                    _log.Debug(dragDropInfo.Data.GetData(d));
                    _log.DebugFormat("--------------END----------------------------");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}