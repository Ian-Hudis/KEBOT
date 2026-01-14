using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KEBOT
{
    public partial class RuntimeDisplay : Form
    {

        public DateTime dateTimePicker1 { get; set; }

        public readonly Runtime runtime = new Runtime(); // Runtime class

        public RuntimeDisplay()
        {
            InitializeComponent();
        }

        public void GetData(DateTime datetime)
        {
            dateTimePicker1 = datetime;
        }
        
        public void MakePieChart(List<Runtime.BarStatePoint> values)
        {

            //reset your chart series and legends
            PieChart1.Series.Clear();

            Runtime.PieSums piesum = new Runtime.PieSums();
            piesum = runtime.Summation(values);
            
            RuntimeBackground.Clear();
            RuntimeBackground.AppendText("Time in Running: " + Math.Round(piesum.Running.TotalHours, 2).ToString() + " Hours " + Math.Round(piesum.Running_Per) + "%");
            RuntimeBackground.AppendText(Environment.NewLine);
            RuntimeBackground.AppendText("Time in Ready: " + Math.Round(piesum.Ready.TotalHours, 2).ToString() + " Hours " + Math.Round(piesum.Ready_Per) + "%");
            RuntimeBackground.AppendText(Environment.NewLine);
            RuntimeBackground.AppendText("Time in Setup: " + Math.Round(piesum.Setup.TotalHours, 2).ToString() + " Hours " + Math.Round(piesum.Setup_Per) + "%");
            RuntimeBackground.AppendText(Environment.NewLine);
            RuntimeBackground.AppendText("Time in Inspect: " + Math.Round(piesum.Inspect.TotalHours, 2).ToString() + " Hours " + Math.Round(piesum.Inspect_Per) + "%");
            RuntimeBackground.AppendText(Environment.NewLine);
            RuntimeBackground.AppendText("Time in No Job/Operator: " + Math.Round(piesum.NoJob.TotalHours, 2).ToString() + " Hours "+ Math.Round(piesum.NoJob_Per) + "%");
            RuntimeBackground.AppendText(Environment.NewLine);
            RuntimeBackground.AppendText("Time in Maintanence: " + Math.Round(piesum.Maintanence.TotalHours, 2).ToString() + " Hours " + Math.Round(piesum.Maintanence_Per) + "%");
            RuntimeBackground.AppendText(Environment.NewLine);
            
            //Add a chart Legend
            PieChart1.Legends[0].LegendStyle = LegendStyle.Table;
            //PieChart1.Legends[0].Docking = Docking.Bottom;
            PieChart1.Legends[0].Alignment = StringAlignment.Center;
            PieChart1.Legends[0].Title = "Runtime States";
            PieChart1.Legends[0].BorderColor = System.Drawing.Color.Black;

            PieChart1.Series.Clear();

            string seriesname = "P1";
            PieChart1.Series.Add(seriesname);
            PieChart1.Series[seriesname].ChartType = SeriesChartType.Pie;

            PieChart1.Series[seriesname].Points.AddXY("Running", Math.Round(piesum.Running_Per));
            PieChart1.Series[seriesname].Points.AddXY("Ready", Math.Round(piesum.Ready_Per));
            PieChart1.Series[seriesname].Points.AddXY("Setup", Math.Round(piesum.Setup_Per));
            PieChart1.Series[seriesname].Points.AddXY("Inspect", Math.Round(piesum.Inspect_Per));
            PieChart1.Series[seriesname].Points.AddXY("No Job or Operator", Math.Round(piesum.NoJob_Per));
            PieChart1.Series[seriesname].Points.AddXY("Maintenance", Math.Round(piesum.Maintanence_Per));

            PieChart1.Series[seriesname].Points[0].Color = System.Drawing.Color.LimeGreen;
            PieChart1.Series[seriesname].Points[1].Color = System.Drawing.Color.Yellow;
            PieChart1.Series[seriesname].Points[2].Color = System.Drawing.Color.Cyan;
            PieChart1.Series[seriesname].Points[3].Color = System.Drawing.Color.DarkBlue;
            PieChart1.Series[seriesname].Points[4].Color = System.Drawing.Color.DarkRed;
            PieChart1.Series[seriesname].Points[5].Color = System.Drawing.Color.Red;

        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            Runtime.zoomfactor++;
            if (Runtime.zoomfactor > 50)
            {
                Runtime.zoomfactor = 50;
            }
            BarChart11.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            BarChart11.ChartAreas[0].CursorX.AutoScroll = true;
            BarChart11.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
            BarChart11.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            BarChart11.ChartAreas[0].AxisX.ScaleView.Zoom(Runtime.min, Runtime.max-Runtime.zoomfactor);
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            Runtime.zoomfactor--;
            if (Runtime.zoomfactor <2)
            {
                BarChart11.ChartAreas[0].AxisX.ScaleView.Zoom(Runtime.min, Runtime.max);

                Runtime.zoomfactor = 1;
                BarChart11.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            }
            else
            {
                BarChart11.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                BarChart11.ChartAreas[0].CursorX.AutoScroll = true;
            }
            BarChart11.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
            BarChart11.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            BarChart11.ChartAreas[0].AxisX.ScaleView.Zoom(Runtime.min, Runtime.max-Runtime.zoomfactor);
        }

        private void YZoomIn_Click(object sender, EventArgs e)
        {
            Runtime.YZoomFactor++;
            if (Runtime.YZoomFactor > 4)
            {
                Runtime.YZoomFactor = 4;
            }
            YZoomer(Runtime.YZoomFactor);
        }

        private void YZoomOut_Click(object sender, EventArgs e)
        {
            Runtime.YZoomFactor--;
            if (Runtime.YZoomFactor < 1)
            {
                Runtime.YZoomFactor = 1;
            }
            YZoomer(Runtime.YZoomFactor);
        }

        private void YZoomer(int Zoom)
        {
            switch (Zoom)
            {
                case 1:
                    BarChart11.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).ToOADate();
                    BarChart11.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddDays(1).ToOADate();
                    RuntimeScrollbar.Visible = false;
                    break;
                case 2:
                    RuntimeScrollbar.Visible = true;
                    BarChart11.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).ToOADate();
                    BarChart11.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(12).ToOADate();
                    break;
                case 3:
                    RuntimeScrollbar.Visible = true;
                    BarChart11.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).ToOADate();
                    BarChart11.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(6).ToOADate();
                    break;
                case 4:
                    RuntimeScrollbar.Visible = true;
                    BarChart11.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).ToOADate();
                    BarChart11.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(3).ToOADate();
                    break;
            }
        }

        private void RuntimeScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            switch (Runtime.YZoomFactor)
            {
                case 1:
                    RuntimeScrollbar.Value = 0;
                    RuntimeScrollbar.Visible = false;
                    break;
                case 2:
                    RuntimeScrollbar.Visible = true;
                    RuntimeScrollbar.Maximum = 12;
                    BarChart11.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(RuntimeScrollbar.Value).ToOADate();
                    BarChart11.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(RuntimeScrollbar.Value + 12).ToOADate();
                    break;
                case 3:
                    RuntimeScrollbar.Visible = true;
                    RuntimeScrollbar.Maximum = 18;
                    BarChart11.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(RuntimeScrollbar.Value).ToOADate();
                    BarChart11.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(RuntimeScrollbar.Value + 6).ToOADate();
                    break;
                case 4:
                    RuntimeScrollbar.Visible = true;
                    RuntimeScrollbar.Maximum = 24;
                    BarChart11.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(RuntimeScrollbar.Value).ToOADate();
                    BarChart11.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Year, dateTimePicker1.Month, dateTimePicker1.Day).AddHours(RuntimeScrollbar.Value + 3).ToOADate();
                    break;
            }
        }

    }
}
