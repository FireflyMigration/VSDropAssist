using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace VSDropAssist
{
    /// <summary>
    /// strategy provider that given a list of dropaction handlers, will identify the correct one and return it
    /// </summary>
    public class DropActionProvider : IDropActionProvider
    {
        private List<IDropAction> _actions;

        private class MatchResult
        {
            public int Match { get; set; }
            public IDropAction Action { get; set; }

            public override string ToString()
            {
                return $"{Match}, {Action.ToString()}";
            }

            public MatchResult(int match, IDropAction action)
            {
                this.Match = match;
                this.Action = action;
            }
        }

        private ILog _log = LogManager.GetLogger(typeof(DropActionProvider));

        public DropActionProvider(IEnumerable<IConfigurableDropAction> actions)
        {
            _actions = new List<IDropAction>(actions);
        }

        public IEnumerable<IDropAction> GetActions()
        {
            return _actions;
        }
        public IDropAction GetAction(IDropQuery qry)
        {
            _log.Debug("Searching for DropActionQry:" + qry);
            _log.Debug("Available actions:\n" + displayActions(_actions));
            var matching = _actions.Select(a => new MatchResult(a.Match(qry), a)).Where(x => x.Match > 0).OrderByDescending(x => x.Match).ToList();
            _log.Debug("Found:\n" + displayActions(matching));

            return matching.FirstOrDefault()?.Action;
        }

        private string displayActions(List<MatchResult> matching)
        {
            return string.Join("\n", matching);
        }

        private string displayActions(List<IDropAction> actions)
        {
            return string.Join("\n", actions);
        }
    }
}