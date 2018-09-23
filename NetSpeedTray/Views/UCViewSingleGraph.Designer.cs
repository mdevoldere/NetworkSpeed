namespace Devoldere.NetSpeedTray.Views
{
    partial class UCViewSingleGraph
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.netChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ucViewMini1 = new Devoldere.NetSpeedTray.Views.UCViewMini();
            ((System.ComponentModel.ISupportInitialize)(this.netChart)).BeginInit();
            this.SuspendLayout();
            // 
            // netChart
            // 
            chartArea1.AxisX.Interval = 10D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.Interval = 10D;
            chartArea1.AxisX.Maximum = 100D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Interval = 2D;
            chartArea1.AxisY.Maximum = 10D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "netChartTraffice";
            this.netChart.ChartAreas.Add(chartArea1);
            this.netChart.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.netChart.Legends.Add(legend1);
            this.netChart.Location = new System.Drawing.Point(0, 38);
            this.netChart.Name = "netChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "netChartTraffice";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series1.CustomProperties = "PixelPointWidth=5";
            series1.Legend = "Legend1";
            series1.LegendText = "Download (KB/s)";
            series1.Name = "Download";
            series2.BorderWidth = 2;
            series2.ChartArea = "netChartTraffice";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Legend = "Legend1";
            series2.LegendText = "Upload (KB/s)";
            series2.Name = "Upload";
            this.netChart.Series.Add(series1);
            this.netChart.Series.Add(series2);
            this.netChart.Size = new System.Drawing.Size(520, 200);
            this.netChart.TabIndex = 0;
            this.netChart.Text = "chart1";
            // 
            // ucViewMini1
            // 
            this.ucViewMini1.BackColor = System.Drawing.SystemColors.Info;
            this.ucViewMini1.Location = new System.Drawing.Point(0, 0);
            this.ucViewMini1.Name = "ucViewMini1";
            this.ucViewMini1.Size = new System.Drawing.Size(180, 36);
            this.ucViewMini1.TabIndex = 1;
            // 
            // UCViewSingleGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucViewMini1);
            this.Controls.Add(this.netChart);
            this.Name = "UCViewSingleGraph";
            this.Size = new System.Drawing.Size(520, 238);
            ((System.ComponentModel.ISupportInitialize)(this.netChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart netChart;
        private UCViewMini ucViewMini1;
    }
}
