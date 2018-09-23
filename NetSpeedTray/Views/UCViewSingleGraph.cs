using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Devoldere.NetSpeedTray.Views
{
    public partial class UCViewSingleGraph : UserControl, INetObserver
    {
        static int GridlinesXMax = 60; // num of seconds displayed

        static long dl;
        static long ul;

        static int GridlinesOffset = 0;

        static int i;

        public UCViewSingleGraph()
        {
            InitializeComponent();

            netChart.ChartAreas[0].AxisX.Maximum = GridlinesXMax;
            
            NetListener.NetRegister(this);
        }

        public void NetUpdate()
        {
            if(i < 3)
            {
                i++;
                return;
            }
   
            dl = NetListener.AdapterList.SelectedItem.SpeedDown / 1024;
            ul = NetListener.AdapterList.SelectedItem.SpeedUp / 1024;

            if ((dl > netChart.ChartAreas[0].AxisY.Maximum))
            {
                netChart.ChartAreas[0].AxisY.Maximum = (dl + 10).Round(10);
            }

            if ((ul > netChart.ChartAreas[0].AxisY.Maximum))
            {
                netChart.ChartAreas[0].AxisY.Maximum = (ul + 10).Round(10);
            }

            netChart.ChartAreas[0].AxisY.Interval = ((int)netChart.ChartAreas[0].AxisY.Maximum / 5).Round(10); 

            netChart.Series["Download"].Points.AddY(dl);
            netChart.Series["Upload"].Points.AddY(ul);

            if ((netChart.Series["Download"].Points.Count > GridlinesXMax) || (netChart.Series["Upload"].Points.Count > GridlinesXMax))
            {
                netChart.Series["Download"].Points.RemoveAt(0);
                netChart.Series["Upload"].Points.RemoveAt(0);
                
                // gridlines move.
                netChart.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;

                // Calculate next offset.
                GridlinesOffset++;
                GridlinesOffset %= (int)netChart.ChartAreas[0].AxisX.MajorGrid.Interval;
            }
            
        }

       /* private void cbHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridlinesXMax = Int32.Parse(cbHistory.SelectedItem.ToString());

            netChart.ChartAreas[0].AxisX.Interval = GridlinesXMax / 6;

            netChart.ChartAreas[0].AxisX.Maximum = GridlinesXMax;
        }*/
    }
}
