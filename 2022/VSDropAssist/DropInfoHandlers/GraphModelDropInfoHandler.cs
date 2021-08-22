using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using log4net;

using Microsoft.VisualStudio.GraphModel;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

using VSDropAssist.Entities;

namespace VSDropAssist.DropInfoHandlers
{
    public class DGMLDropInfoHandler : IDropInfoHandler
    {
        private const string DATAFORMAT = "DGML";
        private ILog _log = LogManager.GetLogger(typeof(DGMLDropInfoHandler));

        public bool CanUnderstand(DragDropInfo dragDropInfo)
        {
            return dragDropInfo.Data.GetDataPresent(DATAFORMAT);
        }

        public IEnumerable<Node> GetNodes(DragDropInfo dragDropInfo)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Handes drag and drop of multiselection from solution explorer
    /// </summary>
    internal class GraphModelDropInfoHandler : IDropInfoHandler
    {
        private const string GRAPHMODELFORMAT = "Microsoft.VisualStudio.GraphModel.Graph";
        private readonly ILog _log = LogManager.GetLogger(typeof(GraphModelDropInfoHandler));

        public bool CanUnderstand(DragDropInfo dragDropInfo)
        {
            return (dragDropInfo.Data.GetDataPresent(GRAPHMODELFORMAT));
        }

        /// <summary>
        /// Returns the Node instances from the given drop info
        /// </summary>
        /// <param name="dragDropInfo"></param>
        /// <returns></returns>
        public IEnumerable<Node> GetNodes(DragDropInfo dragDropInfo)
        {
            try
            {
                if (!dragDropInfo.Data.GetDataPresent(GRAPHMODELFORMAT))
                {
                    _log.Debug("GraphModel not found in dragdrop");
                    return null;
                }
                var ret = new List<Node>();

                var gm = (Graph)dragDropInfo.Data.GetData(GRAPHMODELFORMAT);
                if (gm != null)
                {
                    _log.Debug("Found a GraphModel");
                    foreach (var n in gm.Nodes)
                    {
                        // ignore if no descriptive label as these are added by VisualStudio for some reason
                        if (string.IsNullOrEmpty(n.DescriptiveCategoryLabel)) continue;

                        _log.Debug("Found node:" + n.Id.Value);
                        var assembly = "";
                        var type = "";
                        var ns = "";
                        var member = "";
                        var startLine = 0;

                        // todo: dropping a class doesnt work as Insufficient information

                        var c = n.Id.Value as GraphNodeIdCollection;
                        if (c != null)
                        {
                            foreach (var i in c)
                            {
                                var value = i.Value.ToString();
                                if (i.Name.Name == "Assembly") assembly = value;
                                else if (i.Name.Name == "Type") type = value;
                                else if (i.Name.Name == "Member") member = value;
                                else if (i.Name.Name == "Namespace") ns = value;
                                else _log.Debug("Unknown GraphNodeId:" + i.LiteralValue);
                            }
                        }
                        try
                        {
                            foreach (var p in n.Properties)
                            {
                                if (p.Key.Id == "SourceLocation")
                                {
                                    var pos = (Microsoft.VisualStudio.GraphModel.CodeSchema.SourceLocation)p.Value;
                                    startLine = pos.StartPosition.Line;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            _log.Error("Failed to get node sourcecode location: " + member);
                        }

                        if (!string.IsNullOrEmpty(type))
                        {
                            var nestedTypeName = new TypeParser().GetTypeFromString(type);

                            ret.Add(new Node
                            {
                                Assembly = assembly,
                                Member = member,
                                Namespace = ns,
                                Type = nestedTypeName,
                                StartLine = startLine
                            });
                        }
                    }
                }
                if (ret.Any()) return ret.OrderBy(x => x.StartLine);
            }
            catch (Exception e)
            {
                _log.Error("GetNodes failed", e);
            }
            return null;
        }
    }

    /// <summary>
    /// Converts a given node into a type-string
    /// </summary>
    public class TypeParser
    {
        public string GetTypeFromString(string source)
        {
            var pattern = @"(Name=(?<theName>\w*) (?<parent>ParentType=(?<parentType>\w*)))";
            var reg = new Regex(pattern);
            var typeNames = new List<string>();
            var mc = reg.Matches(source);
            if (mc.Count == 0) return source;

            foreach (Match m in mc)
            {
                foreach (Capture g in m.Groups["theName"].Captures)
                {
                    if (!string.IsNullOrEmpty(g.Value)) typeNames.Add(g.Value);
                }
                foreach (Capture pg in m.Groups["parentType"].Captures)
                {
                    if (!string.IsNullOrEmpty(pg.Value))
                    {
                        typeNames.Add(pg.Value);
                    }
                }
            }
            typeNames.Reverse();
            return string.Join(".", typeNames);
        }
    }
}