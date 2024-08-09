namespace StackTraceParserWeb.Models
{
    public class StackTraceEntry
    {
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string Method { get; set; }
        public string File { get; set; }
        public int LineNumber { get; set; }

        public string ToHtmlString()
        {
            string exceptionDetails = string.Empty;

            if (!string.IsNullOrEmpty(ExceptionType) && !string.IsNullOrEmpty(ExceptionMessage))
            {
                exceptionDetails = $@"
                <div class='exception-details'>
                    <div><strong>Exception Type:</strong> {ExceptionType}</div>
                    <div><strong>Message:</strong> {ExceptionMessage}</div>
                </div>
            ";
            }

            return $@"
            {exceptionDetails}
            <div class='stack-trace-entry'>
                <div class='method'>
                    <i class='bi bi-code-slash'></i> <strong>{Method}</strong>
                </div>
                <div class='file'>
                    <i class='bi bi-file-earmark-text'></i> {File}
                </div>
                <div class='line-number'>
                    <i class='bi bi-hash'></i> Line: {LineNumber}
                </div>
            </div>";
        }
    }
}
