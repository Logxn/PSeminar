﻿namespace PSeminar
{
    partial class Wegbeschaffenheit
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 14D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 19D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 41D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 21D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.heightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.heightChart)).BeginInit();
            this.SuspendLayout();
            // 
            // heightChart
            // 
            chartArea1.Name = "ChartArea1";
            this.heightChart.ChartAreas.Add(chartArea1);
            this.heightChart.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "legende";
            legend1.Title = "Legende";
            this.heightChart.Legends.Add(legend1);
            this.heightChart.Location = new System.Drawing.Point(16, 12);
            this.heightChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.heightChart.Name = "heightChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "legende";
            series1.Name = "Beschaffenheit";
            dataPoint1.Label = "14%";
            dataPoint1.LegendText = "Befestigt (Asphalt + Pflaster)";
            dataPoint2.Label = "19%";
            dataPoint2.LegendText = "Pfad";
            dataPoint3.Label = "41%";
            dataPoint3.LegendText = "Feldweg";
            dataPoint4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataPoint4.Label = "21%";
            dataPoint4.LegendText = "Schotter";
            dataPoint5.Label = "5%";
            dataPoint5.LegendText = "Ickelheim";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            this.heightChart.Series.Add(series1);
            this.heightChart.Size = new System.Drawing.Size(741, 414);
            this.heightChart.TabIndex = 5;
            title1.Name = "chartTitle";
            title1.Text = "Wanderweg Beschaffenheit";
            this.heightChart.Titles.Add(title1);
            // 
            // Wegbeschaffenheit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 441);
            this.Controls.Add(this.heightChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Wegbeschaffenheit";
            this.Text = "P-Seminar Projekt: Wanderweg Ickeheim - github.com/Logxn - www.loganthompson.de -" +
    " Beschaffenheit";
            ((System.ComponentModel.ISupportInitialize)(this.heightChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart heightChart;
    }
}