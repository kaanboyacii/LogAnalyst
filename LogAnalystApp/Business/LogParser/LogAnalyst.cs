using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LogAnalystApp.Business.LogParser
{
    public class LogParserService
    {
        public List<LogEntry> ParseLogFile(string filePath)
        {
            List<LogEntry> logEntries = new List<LogEntry>();

            string pattern = @"^(?<Source>[^\s]+)\s(?<Timestamp>\d{2}\.\d{2}\.\d{4}\s\d{2}:\d{2}:\d{2}\.\d{3})\s\[(?<Level>[^\]]+)\]\s(?<Message>.+)$";
            Regex regex = new Regex(pattern, RegexOptions.Multiline);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                string currentLog = "";

                while ((line = reader.ReadLine()) != null)
                {
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        if (!string.IsNullOrEmpty(currentLog))
                        {
                            logEntries.Add(ParseLog(currentLog));
                        }
                        currentLog = line;
                    }
                    else
                    {
                        currentLog += Environment.NewLine + line;
                    }
                }

                if (!string.IsNullOrEmpty(currentLog))
                {
                    logEntries.Add(ParseLog(currentLog));
                }
            }

            return logEntries;
        }

        private LogEntry ParseLog(string log)
        {
            string[] logParts = log.Split(' ');
            string level = logParts[3].Trim('[', ']');

            var logEntry = new LogEntry
            {
                Source = logParts[0],
                Date = logParts[1],
                Time = logParts[2],
                Level = level,
                Message = string.Join(" ", logParts.Skip(4))
            };

            return logEntry;
        }

    }
}
