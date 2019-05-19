namespace PSeminar
{
    partial class Höhen
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.heightChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.heightChart)).BeginInit();
            this.SuspendLayout();
            // 
            // heightChart
            // 
            chartArea1.AxisY.Title = "Höhe in Meter";
            chartArea1.Name = "ChartArea1";
            this.heightChart.ChartAreas.Add(chartArea1);
            this.heightChart.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "legende";
            legend1.Title = "Legende";
            this.heightChart.Legends.Add(legend1);
            this.heightChart.Location = new System.Drawing.Point(10, 9);
            this.heightChart.Name = "heightChart";
            this.heightChart.Size = new System.Drawing.Size(556, 336);
            this.heightChart.TabIndex = 5;
            title1.Name = "chartTitle";
            title1.Text = "Wanderweg Höhen";
            this.heightChart.Titles.Add(title1);
            // 
            // Höhen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 354);
            this.Controls.Add(this.heightChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Höhen";
            this.Text = "Höhen";
            this.Load += new System.EventHandler(this.Höhen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heightChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart heightChart;
    }
}