using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using EnvDTE;
using log4net;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text.Editor.DragDrop;
using VSDropAssist.Entities;

namespace VSDropAssist.DropInfoHandlers
{
    internal class ProjectItemDropInfoHandler : IDropInfoHandler
    {
        private const string PROJECTITEMFORMAT = "CF_VSSTGPROJECTITEMS";
        private readonly ILog _log = LogManager.GetLogger(typeof(ProjectItemDropInfoHandler));

        // Copyright © Microsoft Corporation.  All Rights Reserved.
        // This code released under the terms of the
        // Apache License, Version 2.0. Please see http://www.apache.org/licenses/LICENSE-2.0.html
        /// <summary>
        /// A structure containing the data for each of the drag-dropped Solution Explorer node
        /// </summary>
        struct SolutionExplorerNodeData
        {
            /// <summary>
            /// IDataObject format string for project items from solution explorer.
            /// </summary>
            internal const string ClipFormatProjectItem = "CF_VSSTGPROJECTITEMS";

            /// <summary>
            /// Very arcane method to decode an IDataObject from Solution Explorer.
            /// </summary>
            /// <param name="data">The data object.</param>
            /// <param name="streamKey">The key to get the memory stream  from data</param>
            /// <param name="nodeIsProject">True if the given node is a project node.</param>
            /// <returns>A list of SolutionExplorerNodeData objects.</returns>
            internal static IList<SolutionExplorerNodeData> DecodeProjectItemData(IDataObject data, bool nodeIsProject)
            {
                /*
                 This function reads the memory stream in the data object and parses the data.
                 The structure of the data is as follows:
                DROPFILES structure (20 bytes)
                String\0
                String\0
                ..
                String\0\0

                One String for each drag-dropped Soln Explorer node.
                The fWide member in the DROPFILES structure tells us if the string is encoded in Unicode or ASCII.
                And each string contains the following:
                {project guid} +"|"+ project file name +"|"+ drag-dropped file name
                */

                MemoryStream stream = data.GetData(ClipFormatProjectItem) as MemoryStream;
                List<SolutionExplorerNodeData> nodeData = new List<SolutionExplorerNodeData>();
                if (stream != null && stream.Length > 0 && stream.CanRead)
                {
                    BinaryReader reader = null;
                    try
                    {
                        Encoding encoding = (System.BitConverter.IsLittleEndian ? Encoding.Unicode : Encoding.BigEndianUnicode);
                        reader = new BinaryReader(stream, encoding);

                        // Read the initial DROPFILES struct (20 bytes)
                        Int32 files = reader.ReadInt32();
                        Int32 x = reader.ReadInt32();
                        Int32 y = reader.ReadInt32();
                        Int32 unused = reader.ReadInt32(); // This is not used anywhere, but is read out of the way.
                        Int32 unicode = reader.ReadInt32();

                        // If the string is not unicode, use ASCII encoding
                        if (unicode == 0)
                        {
                            reader = new BinaryReader(stream, Encoding.ASCII);
                        }

                        char lastChar = '\0';
                        ArrayList eachNodeStrings = new ArrayList();
                        StringBuilder fileNameString = new StringBuilder();
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            char c = reader.ReadChar();
                            if (c == '\0' && lastChar == '\0')
                            {
                                break;
                            }

                            if (c == '\0')
                            {
                                eachNodeStrings.Add(fileNameString.ToString());
                                fileNameString = new StringBuilder();
                            }
                            else
                            {
                                fileNameString.Append(c);
                            }

                            lastChar = c;
                        }

                        foreach (string eachNode in eachNodeStrings)
                        {
                            string[] splitString = eachNode.Split('|');
                            //Debug.Assert(splitString.Length == 3);
                            if (splitString.Length == 3)
                            {
                                SolutionExplorerNodeData node = new SolutionExplorerNodeData();
                                node.ProjectGuid = new Guid(splitString[0]);
                                node.ProjectFileName = splitString[1];
                                node.ProjectRef = eachNode;

                                // For PROJECTITEM data structures, the file name portion has been run through ToLower (or equivalent)
                                // but the IDataObject will also have a "System.String" data type which is still in the correct case
                                // so we will use the System.String data for PROJECTITEM objects. If there's more than one item in the
                                // data string then just use the path embedded in the data since the System.String value depends
                                // on what was selected first in the multiple selection. No, I didn't write this.
                                if (nodeIsProject || !data.GetDataPresent("System.String") || (1 != eachNodeStrings.Count))
                                {
                                    node.FileName = splitString[2];
                                }
                                else
                                {
                                    node.FileName = data.GetData("System.String") as String;
                                }

                                node.IsProjectNode = nodeIsProject;
                                nodeData.Add(node);
                            }
                        }
                    }
                    finally
                    {
                        if (reader != null)
                        {
                            reader.Close();
                        }
                    }
                }

                return nodeData;
            }

            public string ProjectRef { get; set; }

            #region Private Members
            /// <summary>
            /// The project GUID
            /// </summary>
            private Guid projectGuid;

            /// <summary>
            /// The project file name.
            /// </summary>
            private string projectFileName;

            /// <summary>
            /// The file name
            /// </summary>
            private string fileName;

            /// <summary>
            /// True if the node being examined is a project node.
            /// </summary>
            private bool nodeIsProject;

            #endregion

            /// <summary>
            /// The guid of the project
            /// </summary>
            public Guid ProjectGuid
            {
                get
                {
                    return this.projectGuid;
                }

                set
                {
                    this.projectGuid = value;
                }
            }

            /// <summary>
            /// Path of the project file
            /// </summary>
            /// <value></value>
            public string ProjectFileName
            {
                get
                {
                    return this.projectFileName;
                }

                set
                {
                    this.projectFileName = value;
                }
            }

            /// <summary>
            /// Path of the file that is drag-dropped
            /// </summary>
            /// <value></value>
            public string FileName
            {
                get
                {
                    return this.fileName;
                }

                set
                {
                    this.fileName = value;
                }
            }

            /// <summary>
            /// Whether the node is a project node or not
            /// </summary>
            public bool IsProjectNode
            {
                get
                {
                    return this.nodeIsProject;
                }

                set
                {
                    this.nodeIsProject = value;
                }
            }

            #region Equality Methods
            /// <summary>
            /// Object.Equals().
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object obj)
            {
                if (obj == null || !(obj is SolutionExplorerNodeData))
                {
                    return false;
                }

                return this == (SolutionExplorerNodeData)obj;
            }

            /// <summary>
            /// Calculate GetHashCode of this struct
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                int hashCode = 0;
                hashCode ^= this.ProjectFileName.GetHashCode();
                hashCode ^= this.FileName.GetHashCode();
                hashCode ^= this.IsProjectNode.GetHashCode();
                hashCode ^= this.ProjectGuid.GetHashCode();
                return hashCode;
            }

            /// <summary>
            /// Operator !=.
            /// </summary>
            /// <param name="data1"></param>
            /// <param name="data2"></param>
            /// <returns></returns>
            public static bool operator !=(SolutionExplorerNodeData data1, SolutionExplorerNodeData data2)
            {
                return !(data1 == data2);
            }

            /// <summary>
            /// Operator ==.
            /// </summary>
            /// <param name="data1"></param>
            /// <param name="data2"></param>
            /// <returns></returns>
            public static bool operator ==(SolutionExplorerNodeData data1, SolutionExplorerNodeData data2)
            {
                return (data1.IsProjectNode == data2.IsProjectNode &&
                        data1.ProjectGuid == data2.ProjectGuid &&
                        (data1.FileName == data2.FileName) &&
                        (data1.ProjectFileName == data2.ProjectFileName));
            }
            #endregion
        }
        
        public bool CanUnderstand(DragDropInfo dragDropInfo)
        {
            if (!dragDropInfo.Data.GetDataPresent(PROJECTITEMFORMAT))
            {
                return false;
            }
            return true;

        }

        public IEnumerable<INode> GetNodes(DragDropInfo dragDropInfo)
        {
            try
            {
                if (!dragDropInfo.Data.GetDataPresent(PROJECTITEMFORMAT))
                {
                    _log.Debug("Data not found");
                    return null;
                }
                
                // create nodes from the projectitems
                var data = dragDropInfo.Data.GetData(PROJECTITEMFORMAT);
                var nodeIsProject = false;
                var droppedData = SolutionExplorerNodeData.DecodeProjectItemData(dragDropInfo.Data, nodeIsProject);

                // find the nodes in the solution
                var solutionItems = findSolutionItems(droppedData);
                if (solutionItems != null) return solutionItems;

                _log.Debug("FAiled to find items in IVSHierarchy. Generating items based on filename only");
                var nodes = droppedData.Select(x => new Node() {Type = getClassNameFromFileName(x.FileName)});
                _log.Debug("Found data");

                return nodes;
            }
            catch (Exception e)
            {
                throw new Exception("GetNodes failed", e);
            }
            
        }

        private IEnumerable<Node > findSolutionItems(IList<SolutionExplorerNodeData> droppedData)
        {
            var ret = new List<Node>();

            foreach (var item in droppedData)
            {
                var solutionItem = createNodeFromSolutionItem(item.ProjectRef );

                if (solutionItem != null)
                {
                    if(!ret.Contains(solutionItem )) ret.Add(solutionItem);
                }
            }
            return ret;

        }

        private Node createNodeFromSolutionItem(string projectRef)
        {
            var solution = Application.Solution.Value;

            IVsHierarchy hierarchy= null ;
            uint itemid;
            
            VSUPDATEPROJREFREASON[] updateReasons = new VSUPDATEPROJREFREASON[1];
            string updatedProjectRef;
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            if (solution.GetItemOfProjref(projectRef, out hierarchy,out itemid, out updatedProjectRef,updateReasons ) == 0)
            {
                object objProj;
                hierarchy.GetProperty(itemid, (int)__VSHPROPID.VSHPROPID_ExtObject, out objProj);

                // identify what this thing is
                var pi = objProj as ProjectItem;
                var p = objProj as Project;
                var ce = objProj as CodeElement;

                if(pi!=null)
                {
                    // find the first class inthe project
                    var theClass = findFirstClass(pi);
                    var asm = "";
                    var ns = getNamespace(theClass);
                    var t = theClass.Name ;
                    var startline = theClass.StartPoint.Line;
                    var fullname = theClass.FullName;

                    return new Node()
                    {
                        Assembly = asm,
                        Namespace = ns,
                        Type = t,
                        Member = string.Empty,
                        StartLine = startline,
                        IsClass = true ,
                        FullName = fullname 
                    };
                }
            }
            return null;

        }

        private string getNamespace(CodeClass theClass)
        {
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            var fn = theClass.FullName;
            var typename = theClass.Name;

            return fn.Substring(0,fn.Length -  typename.Length-1);
        }

        private CodeClass findFirstClass(ProjectItem pi)
        {
            
            if (pi?.FileCodeModel?.CodeElements == null) return null;

            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            return findFirstClass(pi.FileCodeModel.CodeElements);
            
        }

        private CodeClass findFirstClass(CodeElements elements)
        {
            if (elements == null) return null;
            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();

            foreach (CodeElement ce in elements )
            {
                if (ce.Kind == vsCMElement.vsCMElementClass) return ce as CodeClass;

                if (ce.Children.Count > 0)
                {
                    var ret = findFirstClass(ce.Children);
                    if (ret != null) return ret;
                }
                else
                {
                
                }
            }
            return null;
        }
        private string getClassNameFromFileName(string fileName)
        {
            // assumes the classname is the filename
            return Path.GetFileNameWithoutExtension(fileName );
        }
    }

  
}