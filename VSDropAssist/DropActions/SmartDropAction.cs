using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using EnvDTE;
using EnvDTE80;
using log4net;
using Microsoft.VisualStudio.Imaging.Interop;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Entities;

namespace VSDropAssist.DropActions
{
    internal class SmartDropAction : IDropAction
    {
        private readonly IFormatExpressionService _formatExpressionService;
        private readonly IDropActionProvider _dropActionProvider;

        private ILog _log = LogManager.GetLogger(typeof (SmartDropAction));
        public SmartDropAction(IFormatExpressionService formatExpressionService, IDropActionProvider dropActionProvider )
        {
            _formatExpressionService = formatExpressionService;
            _dropActionProvider = dropActionProvider;
        }

        public IExecuteResult  Execute(IEnumerable<Node> enodes, IWpfTextView textView, DragDropInfo dragDropInfo)
        {
            var dropLocation = GetDropLocation();
            var nodes = new List<Node>(enodes);
            normaliseNamespaces(dropLocation, nodes);

            var dropAction = getDropAction(nodes, dragDropInfo, dropLocation);

            if (dropAction != null)
            {
                // store the start buffer position
                var droppedPosition = dragDropInfo.VirtualBufferPosition.Position.Position;
           
                var result =  dropAction.Execute(nodes, textView, dragDropInfo);

                if (result.SelectAfterDrop)
                {
                    
               
                    var startLine = textView.TextSnapshot.GetLineFromPosition(droppedPosition);
                    if (result.SelectionStartLine > 0)
                    {
                        startLine = textView.TextSnapshot.GetLineFromLineNumber(result.SelectionStartLine);
                    }
                    var start = new VirtualSnapshotPoint(startLine,Math.Max(0,  result.SelectionStartInChars));

                    var endLine = startLine;
                    if (result.SelectionHeightInLines > 1)
                       endLine= textView.TextSnapshot.GetLineFromLineNumber(startLine.LineNumber +
                                                                    result.SelectionHeightInLines - 1);
                            
                    var end = new VirtualSnapshotPoint(endLine, result.SelectionWidthInChars + result.SelectionStartInChars );
                    textView.Selection.Mode = TextSelectionMode.Box;

                    textView.Selection.Select(start, end);
                }
                textView.Caret.MoveTo(textView.Selection.End);

            }
            return ExecuteResult.None ;

        }

        public virtual int Match(DropQuery qry)
        {
            return 1;
        }

        private void normaliseNamespaces(DropLocation dropLocation , List<Node> nodes)
        {
            List<NamespaceDeclaration> namespaces = new List<NamespaceDeclaration>(dropLocation.Namespaces);
            if (Application.Settings.NormaliseProjectNamespace)
            {
                var defaultNS = dropLocation.ProjectDefaultNamespace;
                if (!namespaces.Any(x => x.Namespace == defaultNS))
                {
                    namespaces.Add(new NamespaceDeclaration() {Namespace = defaultNS});
                }
            }
            foreach (var n in nodes)
            {
                var ns = n.Namespace;
                n.NormalisedNamespace = ns ;
                var nsComponents = ns.Split('.');

                if (!string.IsNullOrEmpty(ns))
                {
                    var exactMatch = namespaces.FirstOrDefault(x => x.Namespace == ns);
                    if (exactMatch != null)
                    {
                        n.NormalisedNamespace = exactMatch.Alias ; // namespace not needed, as its already imported
                    }
                    else
                    {
                        // find a using statement similar to this one;
                        var similar =
                            namespaces.Where(x => !x.Namespace.Split('.').Except(nsComponents).Any())
                                .OrderByDescending(x => x.Namespace.Length)
                                .FirstOrDefault();

                        if (similar != null)
                        {
                            n.NormalisedNamespace =   ns.Substring(similar.Namespace.Length + 1);
                            if (!string.IsNullOrEmpty(similar.Alias))
                                n.NormalisedNamespace = similar.Alias + "." + n.NormalisedNamespace;
                        }

                    }
                }
            }
        }

        public class DropLocation
        {
            private List<NamespaceDeclaration> _namespaces;
            public  CodeClass Class { get; set; }
           public  CodeFunction Function { get; set; }

            public IEnumerable<NamespaceDeclaration> Namespaces
            {
                get { return _namespaces; }
                
            }

            public DropLocation()
            {
                _namespaces = new List<NamespaceDeclaration>();
            }
            public string ProjectDefaultNamespace
            {
                get
                {
                    if (Class == null) return null;
                    
                    return Class?.ProjectItem?.ContainingProject?.Properties?.Item("DefaultNamespace")?.Value.ToString();
                }
            }

            public void AddNamespace(IEnumerable<NamespaceDeclaration> namespaces)
            {
                foreach (var ns in namespaces)
                {
                    AddNamespace(ns);
                    
                }
            }

            public void AddNamespace(NamespaceDeclaration ns)
            {
                if (string.IsNullOrEmpty(ns.Namespace)) return;
                if (this.Namespaces.All(x => x.Namespace != ns.Namespace )) _namespaces.Add(ns);
            }
            public void AddNamespace(string ns)
            {
                AddNamespace(new NamespaceDeclaration() {Namespace=ns });
            }
        }

        private DropLocation GetDropLocation()
        {
            var ret = new DropLocation();
            var activeDocument = Application.DTE.Value?.ActiveDocument;
            var sel = activeDocument?.Selection as TextSelection;
            CodeElement droppedClass = null;
            CodeElement droppedMethod = null;
          
            ret.AddNamespace( getImportStatements(activeDocument));
            if (sel != null)
            {

                droppedClass = sel.ActivePoint.CodeElement[vsCMElement.vsCMElementClass];
                droppedMethod = sel.ActivePoint.CodeElement[vsCMElement.vsCMElementFunction];
             
                try
                {
                    if (droppedMethod != null)
                    {
                        Debug.WriteLine("Dropped onto method " + droppedMethod.Name);

                    }
                    if (droppedClass != null)
                    {

                        Debug.WriteLine("Dropped onto class " + droppedClass.Name);
                        ret.AddNamespace(droppedClass.SafeNamespace());
                    }
                }
                catch
                {
                }

            }

            if(droppedClass!=null) ret.Class =(CodeClass) droppedClass;
            if(droppedMethod!=null) ret.Function = (CodeFunction)droppedMethod;

            return ret;
        }

        public class NamespaceDeclaration
        {
            public string Alias { get; set; }
            public string Namespace { get; set; }

            public override string ToString()
            {
                if (!string.IsNullOrEmpty(Alias)) return String.Format("{0}={1}", this.Alias, this.Namespace);
                return this.Namespace;
            }
        }

        private List<NamespaceDeclaration> getImportStatements(Document activeDocument)
        {
            if (activeDocument == null) return null;

            var helper = new CodeElementHelper();
            var tmp = helper.GetCodeElements(activeDocument.ProjectItem.FileCodeModel.CodeElements,
                (ce) => ce.Kind == vsCMElement.vsCMElementImportStmt || ce.Kind == vsCMElement.vsCMElementNamespace);

            var ret = new List<NamespaceDeclaration>();

            foreach (CodeElement t in tmp)
            {
                if (t.Kind == vsCMElement.vsCMElementImportStmt)
                {
                    var istmt = t as CodeImport;
                    var i = new NamespaceDeclaration();

                    i.Alias = istmt.Alias;
                    i.Namespace = istmt.Namespace;

                    ret.Add(i);
                }
                if (t.Kind == vsCMElement.vsCMElementNamespace)
                {
                    var ns = t as CodeNamespace;

                    ret.Add(new NamespaceDeclaration() { Namespace = ns.Name});
                }
            }
            return ret;
        }

        private IDropAction getDropAction(IEnumerable<Node> nodes, DragDropInfo dragDropInfo, DropLocation dropLocation )
        {
            var qry = new DropQuery()
            {
                AltDown = ((dragDropInfo.KeyStates & DragDropKeyStates.AltKey) != 0),
                ShiftDown = ((dragDropInfo.KeyStates & DragDropKeyStates.ShiftKey) != 0),
                ControlDown = ((dragDropInfo.KeyStates & DragDropKeyStates.ControlKey) != 0),
                ContainsClasses = (nodes.Any(x => x.IsClass)),
                ContainsMembers = (nodes.Any(x => !x.IsClass)),
                DroppingIntoClass = dropLocation.Class != null,
                DroppingIntoMethod = dropLocation.Function != null
            };

            return _dropActionProvider.GetAction(qry);

        }


    }
}