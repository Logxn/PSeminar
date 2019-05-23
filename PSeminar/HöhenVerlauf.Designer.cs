namespace PSeminar
{
    partial class HöhenVerlauf
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.heightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.heightChart)).BeginInit();
            this.SuspendLayout();
            // 
            // heightChart
            // 
            chartArea1.AxisX.Title = "Entfernung in Wegpunkten";
            chartArea1.AxisY.Maximum = 400D;
            chartArea1.AxisY.Minimum = 300D;
            chartArea1.AxisY.Title = "Höhe in Meter";
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
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "legende";
            series1.Name = "Höhe";
            this.heightChart.Series.Add(series1);
            this.heightChart.Size = new System.Drawing.Size(741, 414);
            this.heightChart.TabIndex = 4;
            title1.Name = "chartTitle";
            title1.Text = "Wanderweg Höhenverlauf";
            this.heightChart.Titles.Add(title1);
            // 
            // HöhenVerlauf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 441);
            this.Controls.Add(this.heightChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HöhenVerlauf";
            this.Text = "P-Seminar Projekt: Wanderweg Ickeheim - github.com/Logxn - www.loganthompson.de -" +
    " Höhenverlauf";
            this.Load += new System.EventHandler(this.TrackData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heightChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart heightChart;
    }
}