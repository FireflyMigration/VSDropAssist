using System.Collections.Generic;
using System.Text;

namespace VSDropAssist.DropActions
{
    internal class InsertColumnsUpdateDropAction : SimpleTextDropAction
    {
        

        protected override  string getTextToInsert(IEnumerable<Node> nodes)
        {
            var output = new StringBuilder();

            foreach (var n in nodes)
            {
                output.AppendFormat("{0}.{1}.Value = ;\n", n.Type.ToLower(), n.Member);
            }

            var ret = output.ToString();

            return ret;
        }
    }
}