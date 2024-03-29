using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Windows.Controls;
using LogAnalystApp.Business.LogParser;

namespace LogAnalystApp
{
    public partial class LogAnalystApp : Form
    {
        private LogParserService logParserService;

        public LogAnalystApp()
        {
            InitializeComponent();
            logParserService = new LogParserService();
            //dataGridViewLogEntries.AutoResizeColumns();
        }

        private void LoadLogEntries(List<LogEntry> logEntries)
        {
            dataGridViewLogEntries.Rows.Clear();

            foreach (var logEntry in logEntries)
            {
                int rowIndex = dataGridViewLogEntries.Rows.Add();
                dataGridViewLogEntries.Rows[rowIndex].Cells["Source"].Value = logEntry.Source;
                dataGridViewLogEntries.Rows[rowIndex].Cells["Date"].Value = logEntry.Date;
                dataGridViewLogEntries.Rows[rowIndex].Cells["Time"].Value = logEntry.Time;
                dataGridViewLogEntries.Rows[rowIndex].Cells["Level"].Value = logEntry.Level;
                dataGridViewLogEntries.Rows[rowIndex].Cells["Message"].Value = logEntry.Message;

                if (logEntry.Level == "ERR")
                {
                    dataGridViewLogEntries.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Red;
                }
                else if (logEntry.Level == "WRN")
                {
                    dataGridViewLogEntries.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Orange;
                }
                else if (logEntry.Level == "INF")
                {
                    dataGridViewLogEntries.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    dataGridViewLogEntries.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }

            //dataGridViewLogEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLogEntries.Refresh();

            AddLogLevelsToPieChart(logEntries);
            AddDatesToCartesianChart(logEntries);
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
                LoadLogEntries(logEntries);
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select a Folder Containing Log Files";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog.SelectedPath;
                string folderName = new DirectoryInfo(folderPath).Name;
                lblLogFileName.Text = $"Folder: {folderName}";

                string[] fileNames = Directory.GetFiles(folderPath, "*.txt");

                List<LogEntry> logEntries = new List<LogEntry>();

                foreach (string fileName in fileNames)
                {
                    List<LogEntry> entries = logParserService.ParseLogFile(fileName);
                    logEntries.AddRange(entries);
                }

                LoadLogEntries(logEntries);
            }
        }

        private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewLogEntries.Rows.Clear();
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

            SeriesCollection pieSeries = new SeriesCollection();
            foreach (var kvp in logLevelCounts)
            {
                PieSeries series = new PieSeries
                {
                    Title = kvp.Key,
                    Values = new ChartValues<int> { kvp.Value },
                    DataLabels = true
                };

                switch (kvp.Key)
                {
                    case "ERR":
                        series.Fill = System.Windows.Media.Brushes.Red;
                        break;
                    case "WRN":
                        series.Fill = System.Windows.Media.Brushes.Orange;
                        break;                    
                    case "INF":
                        series.Fill = System.Windows.Media.Brushes.Blue;
                        break;
                    default:
                        series.Fill = System.Windows.Media.Brushes.Black;
                        break;
                }

                pieSeries.Add(series);
            }

            LogLevelPieChart.Series = pieSeries;
            LogLevelPieChart.LegendLocation = LegendLocation.Bottom;
        }

        private void AddDatesToCartesianChart(List<LogEntry> logEntries)
        {
            LogLevelCartesianChart.Series.Clear();
            LogLevelCartesianChart.AxisX.Clear();
            LogLevelCartesianChart.AxisY.Clear();
            Dictionary<string, Dictionary<string, int>> monthlyLogCountsByLevel = new Dictionary<string, Dictionary<string, int>>();

            foreach (var logEntry in logEntries)
            {
                string month = DateTime.ParseExact(logEntry.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("MMMM");
                string level = logEntry.Level;

                if (!monthlyLogCountsByLevel.ContainsKey(month))
                {
                    monthlyLogCountsByLevel[month] = new Dictionary<string, int>();
                }

                if (!monthlyLogCountsByLevel[month].ContainsKey(level))
                {
                    monthlyLogCountsByLevel[month][level] = 0;
                }

                monthlyLogCountsByLevel[month][level]++;
            }

            SeriesCollection cartesianSeries = new SeriesCollection();

            Dictionary<string, System.Windows.Media.Color> levelColors = new Dictionary<string, System.Windows.Media.Color>()
            {
                { "ERR", System.Windows.Media.Colors.Red },
                { "WRN", System.Windows.Media.Colors.Orange },
                { "INF", System.Windows.Media.Colors.Blue }
            };

            foreach (var level in monthlyLogCountsByLevel.First().Value.Keys)
            {
                LineSeries series = new LineSeries
                {
                    Title = level,
                    Values = new ChartValues<int>(),
                    DataLabels = true,
                    Stroke = new System.Windows.Media.SolidColorBrush(levelColors.ContainsKey(level) ? levelColors[level] : System.Windows.Media.Colors.Black)
                };

                cartesianSeries.Add(series);
            }

            foreach (var month in monthlyLogCountsByLevel.Keys)
            {
                var logCountsForMonth = monthlyLogCountsByLevel[month];
                foreach (var series in cartesianSeries)
                {
                    string level = series.Title;
                    int count = logCountsForMonth.ContainsKey(level) ? logCountsForMonth[level] : 0;
                    ((LineSeries)series).Values.Add(count);
                }
            }

            LogLevelCartesianChart.AxisX.Add(new Axis
            {
                Title = "Months",
                Labels = monthlyLogCountsByLevel.Keys.ToArray()
            });

            LogLevelCartesianChart.AxisY.Add(new Axis
            {
                Title = "Log Entries Count",
                LabelFormatter = value => value.ToString()
            });

            LogLevelCartesianChart.Series = cartesianSeries;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtBoxSearch.Text.ToLower();
            foreach (DataGridViewRow row in dataGridViewLogEntries.Rows)
            {
                bool found = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                    {
                        found = true;
                        break;
                    }
                }
                row.Visible = found;
            }
        }
    }
}
