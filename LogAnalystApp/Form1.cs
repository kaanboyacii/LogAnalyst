using LiveCharts.Wpf;
using LiveCharts;
using LogAnalystApp.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LogAnalystApp
{
    public partial class LogAnalystApp : Form
    {
        private LogParserService logParserService;

        public LogAnalystApp()
        {
            InitializeComponent();
            logParserService = new LogParserService();
            dataGridViewLogEntries.AutoResizeColumns();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Select a Log File";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                string fileName = $"File: {Path.GetFileName(filePath)}";
                lblLogFileName.Text = fileName;

                List<LogEntry> logEntries = logParserService.ParseLogFile(filePath);

                dataGridViewLogEntries.DataSource = logEntries;
                AdjustDataGridViewColumns();
                AddLogLevelsToPieChart(logEntries);
                AddLogLevelsToCartesianChart(logEntries);
            }
        }
        private void AdjustDataGridViewColumns()
        {
            dataGridViewLogEntries.Columns["Source"].Width = 100;
            dataGridViewLogEntries.Columns["Date"].Width = 80;
            dataGridViewLogEntries.Columns["Time"].Width = 80;
            dataGridViewLogEntries.Columns["Level"].Width = 80;
            dataGridViewLogEntries.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewLogEntries.Columns["Source"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLogEntries.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLogEntries.Columns["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewLogEntries.Columns["Level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void AddLogLevelsToPieChart(List<LogEntry> logEntries)
        {
            Dictionary<string, int> logLevelCounts = new Dictionary<string, int>();
            foreach (var logEntry in logEntries)
            {
                if (!logLevelCounts.ContainsKey(logEntry.Level))
                {
                    logLevelCounts[logEntry.Level] = 0;
                }
                logLevelCounts[logEntry.Level]++;
            }

            LiveCharts.SeriesCollection pieSeries = new LiveCharts.SeriesCollection();
            foreach (var kvp in logLevelCounts)
            {
                pieSeries.Add(new PieSeries
                {
                    Title = kvp.Key,
                    Values = new ChartValues<int> { kvp.Value },
                    DataLabels = true
                });
            }

            LogLevelPieChart.Series = pieSeries;
            LogLevelPieChart.LegendLocation = LegendLocation.Bottom;
        }
        private void AddLogLevelsToCartesianChart(List<LogEntry> logEntries)
        {
            Dictionary<string, int> logLevelCounts = new Dictionary<string, int>();
            foreach (var logEntry in logEntries)
            {
                if (!logLevelCounts.ContainsKey(logEntry.Level))
                {
                    logLevelCounts[logEntry.Level] = 0;
                }
                logLevelCounts[logEntry.Level]++;
            }

            LiveCharts.SeriesCollection cartesianSeries = new LiveCharts.SeriesCollection();
            cartesianSeries.Add(new ColumnSeries
            {
                Title = "Log Levels",
                Values = new ChartValues<int>(logLevelCounts.Values),
                DataLabels = true
            });

            LogLevelCartesianChart.Series = cartesianSeries;

            LogLevelCartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis { Title = "Log Levels" });
            LogLevelCartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis { Title = "Count", LabelFormatter = value => value.ToString() });
        }
    }
}
