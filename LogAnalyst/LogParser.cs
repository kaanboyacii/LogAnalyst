using Sprache;
using System.Linq;

namespace LogAnalyst
{
    public static class LogParser
    {
        public static LogEntry ParseLog(string log)
        {
            var logLevel = Parse.String("[ERR]").Or(Parse.String("[WRN]")).Or(Parse.String("[INF]")).Text().Token().Optional();
            var logEntryParser =
                from source in Parse.AnyChar.Except(Parse.String(" "))
                    .Many().Text().Token()
                from date in Parse.CharExcept(' ').Many().Text().Token()
                from time in Parse.CharExcept(' ').Many().Text().Token()
                from level in logLevel
                from message in Parse.AnyChar.Many().Text()
                select new LogEntry
                {
                    Source = source,
                    Date = date,
                    Time = time,
                    Level = level.GetOrElse(""),
                    Message = message
                };

            return logEntryParser.Parse(log);
        }
    }
}
