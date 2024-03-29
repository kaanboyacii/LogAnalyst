namespace LogAnalystApp.Business.LogParser
{
    public class LogEntry
    {
        public string Source { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}
