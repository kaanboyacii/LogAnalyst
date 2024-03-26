using System;
using System.Linq;

namespace LogAnalyst
{
    public static class LogParser
    {
        public static LogEntry ParseLog(string log)
        {
            var logParts = log.Split(' ');

            var logEntry = new LogEntry
            {
                Source = logParts[0],
                Date = logParts[1],
                Time = logParts[2],
                Level = logParts[3],
                Message = string.Join(" ", logParts.Skip(4))
            };
            return logEntry;
        }
    }
}
