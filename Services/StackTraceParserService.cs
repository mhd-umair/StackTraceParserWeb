using StackTraceParserWeb.Models;
using System.Text.RegularExpressions;

namespace StackTraceParserWeb.Services
{
    public class StackTraceParserService : IStackTraceParserService
    {
        public string ParseToHtml(string stackTrace)
        {
            if (string.IsNullOrWhiteSpace(stackTrace))
            {
                // Return an empty string or a message indicating the stack trace is empty
                return string.Empty;
            }
            var parsedEntries = new List<StackTraceEntry>();
            var lines = stackTrace.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);

            // Extract the exception type and message from the first line
            string exceptionType = string.Empty;
            string exceptionMessage = string.Empty;

            if (lines.Length > 0)
            {
                var exceptionMatch = Regex.Match(lines[0], @"^(?<ExceptionType>[\w\.]+):\s*(?<ExceptionMessage>.+)$");
                if (exceptionMatch.Success)
                {
                    exceptionType = exceptionMatch.Groups["ExceptionType"].Value;
                    exceptionMessage = exceptionMatch.Groups["ExceptionMessage"].Value;
                }
            }

            // Parse each subsequent line as a stack trace entry
            for (int i = 1; i < lines.Length; i++)
            {
                var parsedEntry = ParseLine(lines[i]);
                if (parsedEntry != null)
                {
                    parsedEntry.ExceptionType = exceptionType;
                    parsedEntry.ExceptionMessage = exceptionMessage;
                    parsedEntries.Add(parsedEntry);
                    exceptionType = string.Empty;
                    exceptionMessage = string.Empty;
                }
            }

            string htmlOutput = "<div class='stack-trace'>";
            foreach (var entry in parsedEntries)
            {
                htmlOutput += entry.ToHtmlString();
            }
            htmlOutput += "</div>";

            return htmlOutput;
        }

        private StackTraceEntry ParseLine(string line)
        {
            // Regex pattern to parse the stack trace line
            var pattern = @"^\s*at\s+(?<Method>.+?)\s+in\s+(?<File>.+?):line\s+(?<LineNumber>\d+)$";
            var match = Regex.Match(line, pattern);

            if (match.Success)
            {
                return new StackTraceEntry
                {
                    Method = match.Groups["Method"].Value.Trim(),
                    File = match.Groups["File"].Value.Trim(),
                    LineNumber = int.Parse(match.Groups["LineNumber"].Value.Trim())
                };
            }

            return null;
        }
    }
}
