using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using EnvDTE;
using log4net;
using Microsoft.VisualStudio.Text;
using System.Xml.Serialization;

namespace VSDropAssist
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
                if (ce.Kind.ToString() == "vsCMElementImportStmt")
                {
                    continue;
                }
                try
                {
                    _log.Debug("Searching " + ce.Name);
                    Debug.WriteLine(string.Format("Searching {0}:{1}", ce.Kind.ToString(), ce.Name));
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception getting object name [this can be ignored]: " + e.Message );
                }
                try
                {
                    var sp = getStartPoint(ce);
                    var pointLine = point.GetContainingLine().LineNumber;

                    if (sp != null)
                    {
                        if (sp.Line > pointLine)
                        {
                            // code element starts after the droplocation, ignore it
                        }
                        else if (ce.EndPoint.Line < pointLine)
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
                catch (COMException comException)
                {
                    _log.Error("Exception retrieving code element", comException);
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

        public IEnumerable<CodeElement> GetCodeElements(CodeElements elements, Predicate<CodeElement> match)
        {
            try
            {
                var ret = new List<CodeElement>();
                if (elements == null) return null;
                if (elements.Count == 0) return null;

                foreach (CodeElement ce in elements)
                {
                    Debug.WriteLine("{0}: {1}", ce.SafeName(), ce.KindAsString());
                    if (match(ce)) ret.Add(ce);

                    var children = getCodeElements(ce);
                    if (children != null)
                    {
                        var inner = GetCodeElements(children, match);
                        if (inner != null) ret.AddRange(inner);
                    }

                }

                if (!ret.Any()) return null;
                return ret;
            }
            catch (COMException comException)
            {
                _log.Error("Exception getting code elements", comException);
            }
            return null;
        }
        public CodeElements getCodeElements(CodeElement ce)
        {
            if (ce is CodeNamespace) return ((CodeNamespace) ce).Members;
            if (ce is CodeClass) return ((CodeClass) ce).Members;
            if (ce is CodeType ) return ((CodeType )ce).Members;
            if (ce is CodeFunction ) return ((CodeFunction )ce).Parameters ;



            return null;

        }
    }
}