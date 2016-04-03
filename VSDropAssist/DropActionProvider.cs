using System.Collections.Generic;
using System.Linq;
using log4net;
using VSDropAssist;
using VSDropAssist.Core;

namespace VSDropAssist
{
    public class DropActionProvider : IDropActionProvider
    {
        private List<IDropAction> _actions;

        private ILog _log = LogManager.GetLogger(typeof (DropActionProvider));

        public DropActionProvider(IEnumerable<IConfigurableDropAction> actions)
        {
            _actions = new List<IDropAction>(actions );
        }

        public IDropAction GetAction(IDropQuery qry)
        {
            _log.Debug("Searching for " + qry);
            var matching = _actions.Select(a => new { Match= a.Match(qry), Action=a }).Where(x => x.Match > 0).OrderByDescending(x => x.Match).ToList();
             _log.Debug("Actions:" + matching);
                return matching.FirstOrDefault()?.Action;


        }
    }
}