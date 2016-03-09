using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using Microsoft.VisualStudio.GraphModel;
using Microsoft.VisualStudio.GraphModel.CodeSchema;
using Microsoft.VisualStudio.GraphModel.Schemas;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropInfoHandlers
{
    internal class GraphModelDropInfoHandler : IDropInfoHandler
    {
        private const string GRAPHMODELFORMAT = "Microsoft.VisualStudio.GraphModel.Graph";
        private readonly ILog _log = LogManager.GetLogger(typeof (GraphModelDropInfoHandler));

        public bool CanUnderstand(DragDropInfo dragDropInfo)
        {
            return (dragDropInfo.Data.GetDataPresent(GRAPHMODELFORMAT));

        }

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

                var gm = (Graph) dragDropInfo.Data.GetData(GRAPHMODELFORMAT);
                if (gm != null)
                {
                    _log.Debug("Found a GraphModel");
                    foreach (var n in gm.Nodes)
                    {
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
                                    var pos = (Microsoft.VisualStudio.GraphModel.CodeSchema.SourceLocation) p.Value;
                                    startLine = pos.StartPosition.Line;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            _log.Error("Failed to get node sourcecode location: " + member );
                        }

                        if (!string.IsNullOrEmpty(type))
                            ret.Add(new Node {Assembly = assembly, Member = member, Namespace = ns, Type = type, StartLine = startLine});
                    }
                }
                if (ret.Any()) return ret.OrderBy(x => x.StartLine );
            }
            catch (Exception e)
            {
                _log.Error("GetNodes failed", e);
            }
            return null;
        }
    }
}