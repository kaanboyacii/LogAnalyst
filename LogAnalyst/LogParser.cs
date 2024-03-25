using System;

namespace LogAnalyst
{
    public static class LogParser
    {
        public static LogEntry ParseLog(string log)
        {
            var logEntry = new LogEntry();
            int startIndex = 0;

            int endIndex = log.IndexOf(' ', startIndex);
            logEntry.Source = log.Substring(startIndex, endIndex - startIndex);
            startIndex = endIndex + 1;

            endIndex = log.IndexOf(' ', startIndex);
            logEntry.Date = log.Substring(startIndex, endIndex - startIndex);
            startIndex = endIndex + 1;

            endIndex = log.IndexOf(' ', startIndex);
            logEntry.Time = log.Substring(startIndex, endIndex - startIndex);
            startIndex = endIndex + 1;

            endIndex = log.IndexOf(' ', startIndex);
            logEntry.Level = log.Substring(startIndex, endIndex - startIndex);
            startIndex = endIndex + 1;

            logEntry.Message = log.Substring(startIndex);
            return logEntry;
        }
    }
}
