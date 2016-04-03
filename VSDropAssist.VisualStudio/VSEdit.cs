using Microsoft.VisualStudio.Text;
using VSDropAssist.Core;

namespace VSDropAssist.VisualStudio
{
    public class VSEdit : IEdit
    {
        private ITextEdit _editPoint;

        
        public  VSEdit(ITextEdit ep)
        {
            this._editPoint = ep;
        }

        public void Apply()
        {
            _editPoint.Apply();
        }

        public void Insert(int position, string textToInsert)
        {
            _editPoint.Insert(position, textToInsert);
        }
    }
}