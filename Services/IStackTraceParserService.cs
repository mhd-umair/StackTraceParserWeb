namespace StackTraceParserWeb.Services
{
    public interface IStackTraceParserService
    {
        string ParseToHtml(string stackTrace);
    }
}
