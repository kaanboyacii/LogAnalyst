using LiveCharts.Wpf;
using LiveCharts;
using LogAnalystApp.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

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
                foreach (var logEntry in logEntries)
                {
                    int rowIndex = dataGridViewLogEntries.Rows.Add();
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Source"].Value = logEntry.Source;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Date"].Value = logEntry.Date;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Time"].Value = logEntry.Time;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Level"].Value = logEntry.Level;
                    dataGridViewLogEntries.Rows[rowIndex].Cells["Message"].Value = logEntry.Message;
                }

                dataGridViewLogEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewLogEntries.Refresh();
                foreach (DataGridViewRow row in dataGridViewLogEntries.Rows)
                {
                    if (row.Cells["Level"].Value != null)
                    {
                        string level = row.Cells["Level"].Value.ToString();
                        if (level == "ERR")
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                        }
                        else if (level == "WRN")
                        {
                            row.DefaultCellStyle.ForeColor = Color.Orange;
                        }
                        else
                        {
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }                   
                    }
                }
                AddLogLevelsToPieChart(logEntries);
                AddDatesToCartesianChart(logEntries);
            }
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
            Dictionary<string, int> monthlyLogCounts = new Dictionary<string, int>();
            foreach (var logEntry in logEntries)
            {
                string month = DateTime.ParseExact(logEntry.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture).ToString("MMMM");
                if (!monthlyLogCounts.ContainsKey(month))
                {
                    monthlyLogCounts[month] = 0;
                }
                monthlyLogCounts[month]++;
            }

            SeriesCollection cartesianSeries = new SeriesCollection();
            ColumnSeries series = new ColumnSeries
            {
                Title = "Log Entries by Month",
                Values = new ChartValues<int>(monthlyLogCounts.Values),
                DataLabels = true
            };

            cartesianSeries.Add(series);
            LogLevelCartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Months", 
                Labels = monthlyLogCounts.Keys.ToArray() 
            });

            LogLevelCartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Log Entries Count", 
                LabelFormatter = value => value.ToString()
            });
            LogLevelCartesianChart.Series = cartesianSeries;
        }

    }
}
