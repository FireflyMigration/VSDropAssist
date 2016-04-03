using Microsoft.VisualStudio.Text;
using VSDropAssist.Core;

namespace VSDropAssist.VisualStudio
{
    public class VSEndPoint : IEndPoint
    {
        private SnapshotPoint end;

        public  VSEndPoint(SnapshotPoint end)
        {
            this.end = end;
        }
    }
}