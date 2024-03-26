using LogAnalystApp.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LogAnalystApp
{
    public partial class LogAnalystApp : Form
    {
        private LogParserService logParserService;

        public LogAnalystApp()
        {
            InitializeComponent();
            logParserService = new LogParserService();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Select a Log File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<LogEntry> logEntries = logParserService.ParseLogFile(filePath);

                string logText = string.Join(Environment.NewLine, logEntries.Select(entry => $"Source: {entry.Source}, Date: {entry.Date}, Time: {entry.Time}, Level: {entry.Level}, Message: {entry.Message}"));
                MessageBox.Show(logText, "Parsed Log Entries", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
