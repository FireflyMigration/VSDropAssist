using System.Collections.Generic;
using System.Linq;

namespace VSDropAssist.DropActions
{
    internal class CommaDelimitedListDropAction : SimpleTextDropAction
    {

        protected override string getTextToInsert(IEnumerable<Node> nodes)
        {

            var output = string.Join(",", nodes.Select(x => string.Format("{0}.{1}", x.Type.ToLower(), x.Member)));


            return string.Format("{0}\n", output);

        }
    }
}