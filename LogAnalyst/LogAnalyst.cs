using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using Serilog;

namespace LogAnalyst
{
    public partial class LogAnalyst : ServiceBase
    {
        private ILogger logger;

        public LogAnalyst()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartParsingLogs();
        }

        protected override void OnStop()
        {
            logger?.Information("Servis durduruldu.");
        }

        public void OnDebug()
        {
            OnStart(null);
        }
        private void StartParsingLogs()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log_20240204.txt");

            List<string> logChunks = new List<string>();

            using (StreamReader reader = new StreamReader(logFilePath))
            {
                string line;
                string currentLogChunk = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (IsLogLevel(line))
                    {
                        if (!string.IsNullOrEmpty(currentLogChunk))
                        {
                            logChunks.Add(currentLogChunk);
                            currentLogChunk = "";
                        }
                    }

                    currentLogChunk += line + "\n";
                }

                if (!string.IsNullOrEmpty(currentLogChunk))
                {
                    logChunks.Add(currentLogChunk);
                }
            }

            foreach (var chunk in logChunks)
            {
                try
                {
                    LogEntry parsedLog = LogParser.ParseLog(chunk);
                    if (parsedLog != null)
                    {
                        PrintLog(parsedLog);
                    }
                    else
                    {
                        Console.WriteLine($"Log parsing failed for log: {chunk}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ParseException occurred: {ex.Message}");
                }
            }
        }

        private bool IsLogLevel(string line)
        {
            return line.Contains("[ERR]") || line.Contains("[WRN]") || line.Contains("[INF]");
        }

        private void PrintLog(LogEntry log)
        {
            Console.WriteLine($"Source: {log.Source}");
            Console.WriteLine($"Date: {log.Date}, Time: {log.Time}");
            Console.WriteLine($"Level: {log.Level}");
            Console.WriteLine($"Message: {log.Message}");
            Console.WriteLine();
        } 
    }
}