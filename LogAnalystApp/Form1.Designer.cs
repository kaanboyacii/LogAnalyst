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
            this.lblLogFileName = new System.Windows.Forms.Label();
            this.dataGridViewLogEntries = new System.Windows.Forms.DataGridView();
            this.OpenFile = new System.Windows.Forms.MenuStrip();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchInFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LogLevelCartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.LogLevelPieChart = new LiveCharts.WinForms.PieChart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
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
            this.tabControl1.Size = new System.Drawing.Size(1305, 728);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BackgroundImage = global::LogAnalystApp.Properties.Resources.LogoAnalystapp_1_;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPage1.Controls.Add(this.lblLogFileName);
            this.tabPage1.Controls.Add(this.dataGridViewLogEntries);
            this.tabPage1.Controls.Add(this.OpenFile);
            this.tabPage1.ForeColor = System.Drawing.Color.Coral;
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(1297, 693);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log Parser";
            // 
            // lblLogFileName
            // 
            this.lblLogFileName.AutoSize = true;
            this.lblLogFileName.ForeColor = System.Drawing.Color.Black;
            this.lblLogFileName.Location = new System.Drawing.Point(9, 35);
            this.lblLogFileName.Name = "lblLogFileName";
            this.lblLogFileName.Size = new System.Drawing.Size(49, 22);
            this.lblLogFileName.TabIndex = 2;
            this.lblLogFileName.Text = "File: ";
            // 
            // dataGridViewLogEntries
            // 
            this.dataGridViewLogEntries.AllowUserToDeleteRows = false;
            this.dataGridViewLogEntries.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLogEntries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewLogEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogEntries.Location = new System.Drawing.Point(14, 68);
            this.dataGridViewLogEntries.Name = "dataGridViewLogEntries";
            this.dataGridViewLogEntries.ReadOnly = true;
            this.dataGridViewLogEntries.RowHeadersWidth = 62;
            this.dataGridViewLogEntries.RowTemplate.Height = 28;
            this.dataGridViewLogEntries.Size = new System.Drawing.Size(1264, 422);
            this.dataGridViewLogEntries.TabIndex = 1;
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
            this.searchInFilesToolStripMenuItem});
            this.OpenFile.Location = new System.Drawing.Point(3, 3);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.OpenFile.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.OpenFile.Size = new System.Drawing.Size(1291, 32);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "OpenFile";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFileToolStripMenuItem.Image")));
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(128, 28);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openFolderToolStripMenuItem.Image")));
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(150, 28);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            // 
            // searchInFilesToolStripMenuItem
            // 
            this.searchInFilesToolStripMenuItem.Image = global::LogAnalystApp.Properties.Resources._3979425;
            this.searchInFilesToolStripMenuItem.Name = "searchInFilesToolStripMenuItem";
            this.searchInFilesToolStripMenuItem.Size = new System.Drawing.Size(169, 28);
            this.searchInFilesToolStripMenuItem.Text = "Search in Files";
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
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(1297, 693);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Visualizer";
            // 
            // LogLevelCartesianChart
            // 
            this.LogLevelCartesianChart.Location = new System.Drawing.Point(606, 8);
            this.LogLevelCartesianChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogLevelCartesianChart.Name = "LogLevelCartesianChart";
            this.LogLevelCartesianChart.Size = new System.Drawing.Size(684, 462);
            this.LogLevelCartesianChart.TabIndex = 2;
            this.LogLevelCartesianChart.Text = "cartesianChart1";
            // 
            // LogLevelPieChart
            // 
            this.LogLevelPieChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LogLevelPieChart.Location = new System.Drawing.Point(9, 8);
            this.LogLevelPieChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogLevelPieChart.Name = "LogLevelPieChart";
            this.LogLevelPieChart.Size = new System.Drawing.Size(589, 462);
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
            this.tabPage3.Size = new System.Drawing.Size(1297, 693);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Settings";
            // 
            // LogAnalystApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1300, 533);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogAnalystApp";
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
        private System.Windows.Forms.ToolStripMenuItem searchInFilesToolStripMenuItem;
        private System.Windows.Forms.Label lblLogFileName;
        private LiveCharts.WinForms.PieChart LogLevelPieChart;
        private LiveCharts.WinForms.CartesianChart LogLevelCartesianChart;
    }
}

