using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VSDropAssist.DropActions
{
    internal class InsertColumnsAddDropAction : SimpleTextDropAction
    {
       

        protected override  string getTextToInsert(IEnumerable<Node> nodes)
        {
            var output = new StringBuilder();
            
            foreach (var n in nodes)
            {
                output.AppendFormat("Columns.Add({0}.{1});\n",n.Type.ToLower(), n.Member);
            }

            var ret= output.ToString();

            return ret;

        }
    }
}