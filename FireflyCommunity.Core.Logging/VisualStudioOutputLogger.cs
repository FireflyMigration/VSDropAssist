using System.Diagnostics;
using EnvDTE;
using log4net.Appender;
using log4net.Core;
using Newtonsoft.Json;
using System;

namespace FireflyCommunity.Core.Logging
{
    
    public class VisualStudioOutputLogger : AppenderSkeleton
    {
      
        private const string OUTPUTPANENAME = "FireflyCommunity";
        public static Lazy<EnvDTE.DTE> DTE { get; set; }

        public VisualStudioOutputLogger()
        {
            
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            Debug.WriteLine("ClassOutline.Logging:" + loggingEvent.RenderedMessage);
            string msg = "";
           
            if (loggingEvent.ExceptionObject != null)
            {
               var tmp = new
                {
                    level = loggingEvent.Level.ToString(),
                    Message = loggingEvent.RenderedMessage,
                    Exception = loggingEvent.ExceptionObject,
                    Domain = loggingEvent.Domain
                };
                msg= JsonConvert.SerializeObject(tmp);
              
            }
            else
            {
                msg = string.Format("{0}:{1}", loggingEvent.Level, loggingEvent.RenderedMessage);
            }
            ReportError(msg);
        }

        private void ReportError(string errorInfo)
        {
            var dte = DTE.Value;
            if (dte == null) return;

            var w = dte.Windows.Item(Constants.vsWindowKindOutput);
            var outp = w.Object as OutputWindow;
            OutputWindowPane pane = null;

            try
            {
                pane = outp.OutputWindowPanes.Item(OUTPUTPANENAME);
            }
            catch
            { 
                pane = outp.OutputWindowPanes.Add(OUTPUTPANENAME);
            }


            pane.Activate();
            pane.OutputString(errorInfo);
            pane.OutputString("\n");
        }
    }
}
