﻿using LiveCharts.Wpf;
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
using System.Threading.Tasks;

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

        private async Task LoadLogEntriesAsync(List<LogEntry> logEntries)
        {
            dataGridViewLogEntries.Rows.Clear();
            int batchSize = 10000;
            int totalLogCount = 0; 

            for (int i = 0; i < logEntries.Count; i += batchSize)
            {
                int remainingCount = Math.Min(batchSize, logEntries.Count - i);
                for (int j = 0; j < remainingCount; j++)
                {
                    int rowIndex = dataGridViewLogEntries.Rows.Add();
                    LogEntry logEntry = logEntries[i + j];
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Source"].Value = logEntry.Source;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Date"].Value = logEntry.Date;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Time"].Value = logEntry.Time;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Level"].Value = logEntry.Level;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Message"].Value = logEntry.Message;

                    DataGridViewCellStyle cellStyle = dataGridViewLogEntries.Rows[rowIndex].Cells["Level"].Style;
                    switch (logEntry.Level)
                    {
                        case "ERR":
                            cellStyle.ForeColor = Color.Red;
                            break;
                        case "WRN":
                            cellStyle.ForeColor = Color.Orange;
                            break;
                        case "INF":
                            cellStyle.ForeColor = Color.Blue;
                            break;
                        default:
                            cellStyle.ForeColor = Color.Black;
                            break;
                    }

                    totalLogCount++;
                }

                dataGridViewLogEntries.Refresh();
                if (i + batchSize < logEntries.Count)
                {
                    await Task.Delay(10);
                }
            }

            lblTotalLog.Text = $"Total Logs: {totalLogCount}";
            MessageBox.Show("Parse operation completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AddLogLevelsToPieChart(logEntries);
            AddDatesToCartesianChart(logEntries);
            AddLogEntriesToTimeCartesianChart(logEntries);
        }

        private async void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Select a Log File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = $"File: {Path.GetFileName(filePath)}";
                lblLogFileName.Text = fileName;

                List<LogEntry> logEntries = await Task.Run(() => logParserService.ParseLogFile(filePath));
                await LoadLogEntriesAsync(logEntries);
            }
        }

        private async void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
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
                    List<LogEntry> entries = await Task.Run(() => logParserService.ParseLogFile(fileName));
                    logEntries.AddRange(entries);
                }

                await LoadLogEntriesAsync(logEntries);
            }
        }

        private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewLogEntries.Rows.Clear();
            LogLevelCartesianChart.Series.Clear();
            LogLevelPieChart.Series.Clear();
            txtBoxSearch.Clear();
            lblLogFileName.Text = "";
            lblTotalLog.Text = "";
            MessageBox.Show("Logs were cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtBoxSearch.Text.ToLower();
            int batchSize = 50;


            foreach (DataGridViewRow row in dataGridViewLogEntries.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

            for (int i = 0; i < dataGridViewLogEntries.Rows.Count; i += batchSize)
            {
                int remainingCount = Math.Min(batchSize, dataGridViewLogEntries.Rows.Count - i);

                for (int j = i; j < i + remainingCount; j++)
                {
                    DataGridViewRow row = dataGridViewLogEntries.Rows[j];
                    bool found = false;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                        {
                            found = true;
                            cell.Style.BackColor = Color.Yellow;
                        }
                    }

                    row.Visible = found;
                }

                await Task.Delay(1);
            }
            MessageBox.Show("Search operation completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void AddLogEntriesToTimeCartesianChart(List<LogEntry> logEntries)
        {
            Dictionary<string, int> logCountsByHour = new Dictionary<string, int>();

            for (int hour = 0; hour < 24; hour++)
            {
                logCountsByHour[hour.ToString("00")] = 0;
            }

            foreach (var logEntry in logEntries)
            {
                string hour = logEntry.Time.Substring(0, 2);
                logCountsByHour[hour]++;
            }
            TimeCartesianChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Log Entries by Hour",
                    Values = new ChartValues<int>(logCountsByHour.Values)
                }
            };

            TimeCartesianChart.AxisX.Clear();
            TimeCartesianChart.AxisX.Add(new Axis
            {
                Title = "Hour",
                Labels = logCountsByHour.Keys.ToArray() 
            });

            TimeCartesianChart.AxisY.Clear();
            TimeCartesianChart.AxisY.Add(new Axis
            {
                Title = "Log Entries Count",
                LabelFormatter = value => value.ToString()
            });
        }
    }
}
