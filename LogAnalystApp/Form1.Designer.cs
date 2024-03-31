namespace LogAnalystApp
{
    partial class LogAnalystApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogAnalystApp));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.lblLogFileName = new System.Windows.Forms.Label();
            this.dataGridViewLogEntries = new System.Windows.Forms.DataGridView();
            this.Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenFile = new System.Windows.Forms.MenuStrip();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LogLevelCartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.LogLevelPieChart = new LiveCharts.WinForms.PieChart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblTotalLog = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogEntries)).BeginInit();
            this.OpenFile.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1624, 728);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BackgroundImage = global::LogAnalystApp.Properties.Resources.LogoAnalystapp_1_;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.lblTotalLog);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.txtBoxSearch);
            this.tabPage1.Controls.Add(this.lblLogFileName);
            this.tabPage1.Controls.Add(this.dataGridViewLogEntries);
            this.tabPage1.Controls.Add(this.OpenFile);
            this.tabPage1.ForeColor = System.Drawing.Color.Black;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1616, 693);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log Parser";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 5;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(692, 38);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(139, 28);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search Text";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(317, 38);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(372, 28);
            this.txtBoxSearch.TabIndex = 3;
            // 
            // lblLogFileName
            // 
            this.lblLogFileName.AutoSize = true;
            this.lblLogFileName.ForeColor = System.Drawing.Color.Black;
            this.lblLogFileName.Location = new System.Drawing.Point(10, 41);
            this.lblLogFileName.Name = "lblLogFileName";
            this.lblLogFileName.Size = new System.Drawing.Size(49, 22);
            this.lblLogFileName.TabIndex = 2;
            this.lblLogFileName.Text = "File: ";
            // 
            // dataGridViewLogEntries
            // 
            this.dataGridViewLogEntries.AllowUserToAddRows = false;
            this.dataGridViewLogEntries.AllowUserToDeleteRows = false;
            this.dataGridViewLogEntries.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLogEntries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLogEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Source,
            this.Date,
            this.Time,
            this.Level,
            this.Message});
            this.dataGridViewLogEntries.Location = new System.Drawing.Point(14, 72);
            this.dataGridViewLogEntries.Name = "dataGridViewLogEntries";
            this.dataGridViewLogEntries.RowHeadersWidth = 62;
            this.dataGridViewLogEntries.RowTemplate.Height = 28;
            this.dataGridViewLogEntries.Size = new System.Drawing.Size(1589, 605);
            this.dataGridViewLogEntries.TabIndex = 1;
            // 
            // Source
            // 
            this.Source.HeaderText = "Source";
            this.Source.MinimumWidth = 8;
            this.Source.Name = "Source";
            this.Source.Width = 165;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.Width = 150;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 8;
            this.Time.Name = "Time";
            this.Time.Width = 150;
            // 
            // Level
            // 
            this.Level.HeaderText = "Level";
            this.Level.MinimumWidth = 8;
            this.Level.Name = "Level";
            this.Level.Width = 140;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.MinimumWidth = 8;
            this.Message.Name = "Message";
            this.Message.Width = 900;
            // 
            // OpenFile
            // 
            this.OpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenFile.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.OpenFile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.OpenFile.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.OpenFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.clearLogsToolStripMenuItem});
            this.OpenFile.Location = new System.Drawing.Point(3, 3);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.OpenFile.Size = new System.Drawing.Size(1610, 36);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "OpenFile";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileToolStripMenuItem.Image")));
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(128, 32);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFolderToolStripMenuItem.Image")));
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(150, 32);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // clearLogsToolStripMenuItem
            // 
            this.clearLogsToolStripMenuItem.Image = global::LogAnalystApp.Properties.Resources._979773;
            this.clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
            this.clearLogsToolStripMenuItem.Size = new System.Drawing.Size(137, 32);
            this.clearLogsToolStripMenuItem.Text = "Clear Logs";
            this.clearLogsToolStripMenuItem.Click += new System.EventHandler(this.clearLogsToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage2.Controls.Add(this.LogLevelCartesianChart);
            this.tabPage2.Controls.Add(this.LogLevelPieChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1616, 693);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Visualizer";
            // 
            // LogLevelCartesianChart
            // 
            this.LogLevelCartesianChart.Location = new System.Drawing.Point(602, 8);
            this.LogLevelCartesianChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogLevelCartesianChart.Name = "LogLevelCartesianChart";
            this.LogLevelCartesianChart.Size = new System.Drawing.Size(1010, 578);
            this.LogLevelCartesianChart.TabIndex = 2;
            this.LogLevelCartesianChart.Text = "cartesianChart1";
            // 
            // LogLevelPieChart
            // 
            this.LogLevelPieChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LogLevelPieChart.Location = new System.Drawing.Point(9, 8);
            this.LogLevelPieChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogLevelPieChart.Name = "LogLevelPieChart";
            this.LogLevelPieChart.Size = new System.Drawing.Size(598, 578);
            this.LogLevelPieChart.TabIndex = 1;
            this.LogLevelPieChart.Text = "Log Level Pie Chart";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.BackgroundImage = global::LogAnalystApp.Properties.Resources.LogoAnalystapp_1_;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1616, 693);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            // 
            // lblTotalLog
            // 
            this.lblTotalLog.AutoSize = true;
            this.lblTotalLog.ForeColor = System.Drawing.Color.Black;
            this.lblTotalLog.Location = new System.Drawing.Point(850, 41);
            this.lblTotalLog.Name = "lblTotalLog";
            this.lblTotalLog.Size = new System.Drawing.Size(100, 22);
            this.lblTotalLog.TabIndex = 5;
            this.lblTotalLog.Text = "Total Logs:";
            // 
            // LogAnalystApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1619, 720);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogAnalystApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogAnalystApp";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogEntries)).EndInit();
            this.OpenFile.ResumeLayout(false);
            this.OpenFile.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.MenuStrip OpenFile;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewLogEntries;
        private System.Windows.Forms.Label lblLogFileName;
        private LiveCharts.WinForms.PieChart LogLevelPieChart;
        private LiveCharts.WinForms.CartesianChart LogLevelCartesianChart;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripMenuItem clearLogsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.Label lblTotalLog;
    }
}

