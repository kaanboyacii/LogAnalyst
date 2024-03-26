using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalystApp.Business
{
    public class LogParserService
    {
        public List<LogEntry> ParseLogFile(string filePath)
        {
            List<LogEntry> logEntries = new List<LogEntry>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                string currentLogChunk = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (IsLogLevel(line))
                    {
                        if (!string.IsNullOrEmpty(currentLogChunk))
                        {
                            logEntries.Add(ParseLog(currentLogChunk));
                            currentLogChunk = "";
                        }
                    }

                    currentLogChunk += line + "\n";
                }

                if (!string.IsNullOrEmpty(currentLogChunk))
                {
                    logEntries.Add(ParseLog(currentLogChunk));
                }
            }

            return logEntries;
        }

        private bool IsLogLevel(string line)
        {
            return line.Contains("[ERR]") || line.Contains("[WRN]") || line.Contains("[INF]");
        }

        private LogEntry ParseLog(string log)
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
