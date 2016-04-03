namespace VSDropAssist.Core
{
    public interface IEndPoint { }
    public interface  IIndentationService {
        int? GetDesiredIndentation(ITextView textView, ILine dropLine);
    }
}