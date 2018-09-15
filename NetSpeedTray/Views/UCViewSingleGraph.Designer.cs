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
            ((System.ComponentModel.ISupportInitialize)(this.netChart)).BeginInit();
            this.SuspendLayout();
            // 
            // netChart
            // 
            chartArea1.Name = "netChartTraffice";
            this.netChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.netChart.Legends.Add(legend1);
            this.netChart.Location = new System.Drawing.Point(3, 3);
            this.netChart.Name = "netChart";
            series1.ChartArea = "netChartTraffice";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Download";
            series2.ChartArea = "netChartTraffice";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Upload";
            this.netChart.Series.Add(series1);
            this.netChart.Series.Add(series2);
            this.netChart.Size = new System.Drawing.Size(507, 193);
            this.netChart.TabIndex = 0;
            this.netChart.Text = "chart1";
            // 
            // UCNetInterfaceGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.netChart);
            this.Name = "UCNetInterfaceGraph";
            this.Size = new System.Drawing.Size(513, 247);
            ((System.ComponentModel.ISupportInitialize)(this.netChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart netChart;
    }
}
