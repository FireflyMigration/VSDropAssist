using EnvDTE;
using log4net;
using Microsoft.VisualStudio.Text;

namespace VSDropAssist.DropActions
{
    public class CodeElementHelper
    {
        private ILog _log = LogManager.GetLogger(typeof (CodeElementHelper));
        public CodeElement GetCodeElement(DTE dte, SnapshotPoint  point, vsCMElement elementType)
        {
            var codeElements = dte.ActiveDocument.ProjectItem.FileCodeModel.CodeElements;
            return GetCodeElement(dte, point, codeElements, elementType);

        }

        private CodeElement GetCodeElement(DTE dte, SnapshotPoint  point, CodeElements codeElements, vsCMElement elementType)
        {
           
            
            foreach (CodeElement ce in codeElements)
            {
                try
                {
                    _log.Debug("Searching " + ce.FullName);
                }
                catch { }

                var sp = getStartPoint(ce);
                var pointLine = point.GetContainingLine().LineNumber;

                if (sp != null)
                {
                    if (sp.Line > pointLine )
                    {
                        // code element starts after the droplocation, ignore it
                    }
                    else if (ce.EndPoint.Line  < pointLine )
                    {
                        // code element finishes before the droplocation, ignore it
                    }
                    else
                    {

                        if (elementType == ce.Kind)
                        {

                            return ce;
                        }

                        var childElements = getCodeElements(ce);
                        if (childElements != null)
                        {
                            var ret = GetCodeElement(dte, point, childElements, elementType);
                            if (ret != null) return ret;
                        }
                    }
                }
            }
            return null;
        }

        private TextPoint getStartPoint(CodeElement ce)
        {
            try
            {
                if (ce.Kind == vsCMElement.vsCMElementFunction || ce.Kind == vsCMElement.vsCMElementClass)
                {
                    return ce.GetStartPoint(vsCMPart.vsCMPartBody);

                }
            }
            catch
            {
                _log.Debug("Failed to rtrieve body part of " + ce.Name + ". Reverting to start of element");
            }

            return ce.StartPoint ;
        }
        private int getStartPosition(CodeElement ce)
        {
            var ret = ce.StartPoint.AbsoluteCharOffset;
            var retline = ce.StartPoint.Line;

            if (ce.Kind == vsCMElement.vsCMElementFunction || ce.Kind == vsCMElement.vsCMElementClass)
            {
                var startPoint = ce.GetStartPoint(vsCMPart.vsCMPartBody);
                var ret2 =  startPoint.AbsoluteCharOffset;
                var ret2Line = startPoint.Line;
                return ret2;
            }

            return ret;
        }

        private CodeElements getCodeElements(CodeElement ce)
        {
            if (ce is CodeNamespace) return ((CodeNamespace) ce).Members;
            if (ce is CodeType ) return ((CodeType )ce).Members;
            if (ce is CodeFunction ) return ((CodeFunction )ce).Parameters ;



            return null;

        }
    }
}