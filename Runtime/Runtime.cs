using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KEBOT
{
    public class Runtime
    {

     // for the Bar Chart
        //! for zooming in and out of the bar chart
        public static int zoomfactor = 1;
        public static double max = 0;
        public static double min = 0;

        public static int YZoomFactor = 1;
        public static double Ymax = 0;
        public static double Ymin = 0;
        //! for zooming in and out of the bar char
        
        public void MakeRuntimeGraph(System.Windows.Forms.DataVisualization.Charting.Chart chart, DataTable dt, DateTime startime, DateTime endtime)
        {
            chart.Series.Clear();
            if (dt != null)
            {
                // filter and organize the data for displaying in history graphs
                BarSequance = ParseforStateInfo(dt, startime, endtime);
                // Set up the bar graphing 
                setUpGantt(chart, startime, endtime);

                System.Windows.Forms.DataVisualization.Charting.Series s = chart.Series[0];

                //s.SetCustomProperty("PixelPointWidth", "32");
               // s.SetCustomProperty("PixelPointWidth", "36"); // width of the bars

                for (int row = 0; row < BarSequance.Count; row++)
                {
                    DateTime Begintime = new DateTime(startime.Year, startime.Month, startime.Day, BarSequance[row].Starttime.Hour, BarSequance[row].Starttime.Minute, BarSequance[row].Starttime.Second);
                    DateTime Finaltime = new DateTime(startime.Year, startime.Month, startime.Day, BarSequance[row].Endtime.Hour, BarSequance[row].Endtime.Minute, BarSequance[row].Endtime.Second);

                    if (BarSequance[row].Carryover) // new day
                    {
                        int days = (BarSequance[row].Endtime.Date - BarSequance[row].Starttime.Date).Days;
                        addGanttTask(s, Begintime, new DateTime(startime.Year, startime.Month, startime.Day, 23, 59, 59, 999), BarSequance[row].color, BarSequance[row].Day1);
                        for (int i = 1; i<days; i++) // multiple days
                        {
                            addGanttTask(s, new DateTime(startime.Year, startime.Month, startime.Day, 0, 0, 0),
                                new DateTime(startime.Year, startime.Month, startime.Day, 23, 59, 59, 999), BarSequance[row].color, BarSequance[row].Day1.AddDays(i));
                        }
                        addGanttTask(s, new DateTime(startime.Year, startime.Month, startime.Day, 0, 0, 0), Finaltime, BarSequance[row].color, BarSequance[row].Day1.AddDays(days));
                        //s.SetCustomProperty("PixelPointWidth", (30-days).ToString()); // width of the bars
                    }
                    else
                    { 
                        addGanttTask(s, Begintime, Finaltime, BarSequance[row].color, BarSequance[row].Day1); // same day
                    }
                }
               // s.SetCustomProperty("PixelPointWidth", "30"); // width of the bars

            }
        }

        private void setUpGantt(System.Windows.Forms.DataVisualization.Charting.Chart chart, DateTime StartTime, DateTime endtime)
        {
            chart.Series.Clear();
            // set up the legend           
            Series Ready = chart.Series.Add("Ready");
                Ready.Color =  GetStateColor(Ready.Name);
                Ready.ChartType = SeriesChartType.RangeBar;
            Series s = chart.Series.Add("Running");
                s.Color = GetStateColor(s.Name);
                s.ChartType = SeriesChartType.RangeBar;
            Series Inspect = chart.Series.Add("Inspect");
                Inspect.Color =  GetStateColor(Inspect.Name);
                Inspect.ChartType = SeriesChartType.RangeBar;
            Series Setup = chart.Series.Add("Setup");
                Setup.Color =  GetStateColor(Setup.Name);
                Setup.ChartType = SeriesChartType.RangeBar;
            Series NoJob = chart.Series.Add("No Job or Operator");
                NoJob.Color = GetStateColor(NoJob.Name);
                NoJob.ChartType = SeriesChartType.RangeBar;
            Series SchedM = chart.Series.Add("Scheduled Maintenance");
                SchedM.Color = GetStateColor(SchedM.Name);
                SchedM.ChartType = SeriesChartType.RangeBar;
            Series UNSchedM = chart.Series.Add("Unscheduled Maintenance");
                UNSchedM.Color = GetStateColor(UNSchedM.Name);
                UNSchedM.ChartType = SeriesChartType.RangeBar;
            Series Undefined = chart.Series.Add("Undefined");
                Undefined.Color = GetStateColor(Undefined.Name);
                Undefined.ChartType = SeriesChartType.RangeBar;

            s.YValueType = ChartValueType.DateTime;
            s.AxisLabel = "Time";
            s.IsVisibleInLegend = true;

            s.SetCustomProperty("MaxPixelPointWidth", "20px"); // width of the bars
            s.SetCustomProperty("MinPixelPointWidth", "20px"); // width of the bars
            s.SetCustomProperty("PixelPointWidth", "20px");

            Axis ax = chart.ChartAreas[0].AxisX;
            ax.MajorGrid.Enabled = false;
            ax.MajorTickMark.Enabled = true;
            ax.MinorGrid.Enabled = false;
            ax.IntervalType = DateTimeIntervalType.Days;
            ax.LabelStyle.Format = "MM-dd";
            ax.Enabled = AxisEnabled.True;

            ax.Minimum = StartTime.AddDays(-0.5).ToOADate();  //
            ax.Maximum = endtime.AddDays(0.5).ToOADate();  // 

            min = ax.ScaleView.ViewMinimum;
            max = ax.ScaleView.ViewMaximum;

            Axis ay = chart.ChartAreas[0].AxisY;
            ay.IntervalType = DateTimeIntervalType.Hours;
            ay.LabelStyle.Format = "HH:mm";
            ay.MajorGrid.Enabled = true;
            ay.MajorTickMark.Enabled = true;
            ay.MinorGrid.Enabled = true;

            /*
            ay.ScaleView.Zoomable = true;
            chart.ChartAreas[0].CursorY.AutoScroll = true;
            ay.ScrollBar.IsPositionedInside = false;
            ay.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            */

            // ay.LineColor = chart.BackColor;
            ay.Minimum = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day).ToOADate();//fromTimeString("0:00").ToOADate();  // we exclude all times..
            ay.Maximum = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day).AddDays(1).ToOADate();

            Ymin = ay.ScaleView.ViewMinimum;
            Ymax = ay.ScaleView.ViewMaximum;
        }
        
        private void addGanttTask(Series s, DateTime start, DateTime end, System.Drawing.Color c, DateTime slot)
        {
            int pt = s.Points.AddXY(slot, start, end);
            s.Points[pt].Color = c;
        }

        public struct BarStatePoint
        {
            public int ID;
            public DateTime Day1;
            public DateTime Starttime;
            public DateTime Endtime;
            public string State; // will be at the start time
            public System.Drawing.Color color;
            public bool Carryover; // true if the event ends on a different date than it starts
        }

        public List<BarStatePoint> BarSequance;

        //System.Windows.Forms.DataVisualization.Charting.Chart BarChart1
        public List<BarStatePoint> ParseforStateInfo(DataTable dt, DateTime previoustime, DateTime DeclaredEndtime)
        {
            int time = 1;
            int WCState = 4;
            int kioskstate = 5; // used on rare occasions
            // find the columns we care about
            foreach (DataColumn colum in dt.Columns)
            {
                if (colum.ColumnName == "Stime")
                {
                    time = colum.Ordinal;
                }
                if (colum.ColumnName == "WorkCenterState")
                {
                    WCState = colum.Ordinal;
                }
                if(colum.ColumnName == "Kiosk_State")
                {
                    kioskstate = colum.Ordinal;
                }
            }
            
            List<BarStatePoint> barstatepoints = new List<BarStatePoint>(); // declare the list

            if (dt != null)
            {               
                int id = 0;
                //DateTime starttime;
                DateTime endtime;
                string state;
                System.Drawing.Color color; // variable for color
                bool co;
                BarStatePoint statechange;

                //! 1st state grab
                string wcState = dt.Rows[0][WCState].ToString();
                string KioskState = dt.Rows[0][kioskstate].ToString();
                //state
                if (KioskState.Contains("nojob"))
                {
                    state = "No Job or Operator";
                }
                else
                {
                    state = wcState;
                }
                string prevWCState = state;
                //! 1st state grab
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    state = dt.Rows[row][WCState].ToString(); // find the WC state
                    
                    if (state != prevWCState) // filter out meaningless rows from the datatable
                    {
                        //starttime = previoustime;
                        endtime = DateTime.Parse(dt.Rows[row][time].ToString());

                        color = GetStateColor(prevWCState); // give the bar a color

                        if (previoustime.DayOfYear != endtime.DayOfYear)
                        {
                            co = true;
                        }
                        else
                        {
                            co = false;
                        }

                        statechange = new BarStatePoint()
                        {
                            ID = id,
                            Day1 = previoustime.Date,
                            Starttime = previoustime,
                            Endtime = endtime,
                            State = prevWCState,
                            color = color,
                            Carryover = co
                        };
                        barstatepoints.Add(statechange);
                        id++;
                        previoustime = endtime; // time trigger
                        prevWCState = state;// state trigger
                    }
                }

                //! last bar
                 if (DateTime.Compare(DeclaredEndtime, DateTime.Now) < 0) // final time is before now
                 {
                    endtime =  DeclaredEndtime;
                    state = prevWCState;
                    color = GetStateColor(state); // give the bar a color
                    if (previoustime.DayOfYear != endtime.DayOfYear)
                    {
                        co = true;
                    }
                    else
                    {
                        co = false;
                    }
                    statechange = new BarStatePoint()
                    {
                        ID = id,
                        Day1 = previoustime.Date,
                        Starttime = previoustime,
                        Endtime = endtime,
                        State = state,
                        color = color,
                        Carryover = co
                    };
                    barstatepoints.Add(statechange);
                   // id++;
                    //previoustime = endtime; // time trigger
                    //prevWCState = state;// state trigger
                 }
                 else // final time is after now
                 {
                    endtime = DateTime.Now;
                    state = prevWCState;
                    color = GetStateColor(state); // give the bar a color  
                    if (previoustime.DayOfYear != endtime.DayOfYear)
                    {
                        co = true;
                    }
                    else
                    {
                        co = false;
                    }
                    statechange = new BarStatePoint()
                    {
                        ID = id,
                        Day1 = previoustime.Date,
                        Starttime = previoustime,
                        Endtime = endtime,
                        State = state,
                        color = color,
                        Carryover = co
                    };
                    barstatepoints.Add(statechange);
                    id++;
                    previoustime = endtime; // time trigger
                   // prevWCState = state;// state trigger

                    endtime = DeclaredEndtime;
                    state = "N/A";
                    color = GetStateColor(state); // give the bar a color
                    if (previoustime.DayOfYear != endtime.DayOfYear)
                    {
                        co = true;
                    }
                    else
                    {
                        co = false;
                    }
                    statechange = new BarStatePoint()
                    {
                        ID = id,
                        Day1 = previoustime.Date,
                        Starttime = previoustime,
                        Endtime = endtime,
                        State = state,
                        color = color,
                        Carryover = co
                    };
                    barstatepoints.Add(statechange);
                    //id++;
                    //previoustime = endtime; // time trigger
                   // prevWCState = state;// state trigger
                }
                //! last bar
            }
            return barstatepoints;
        }

        private System.Drawing.Color GetStateColor(string state)
        {
            System.Drawing.Color color;

            switch (state)
            {
                case string a when a.Contains("Inspect"):
                    color = System.Drawing.Color.DarkBlue;
                    break;
                case string a when a.Contains("Setup"):
                    color = System.Drawing.Color.Cyan;
                    break;
                case string a when a.Contains("Ready"):
                    color = System.Drawing.Color.Yellow;
                    break;
                case string a when a.Contains("Running"):
                    color = System.Drawing.Color.LimeGreen;
                    break;
                case string a when a.Contains("No Job or Operator"):
                    color = System.Drawing.Color.DarkRed;
                    break;
                case string a when a.Contains("Scheduled Maintenance"):
                    color = System.Drawing.Color.Red;
                    break;
                case string a when a.Contains("Unscheduled Maintenance"):
                    color = System.Drawing.Color.Red;
                    break;
                default:
                    color = System.Drawing.Color.Gray;
                    break;
            }

            return color;
        }


     // for the pie chart
        public struct PieSums
        {
            public TimeSpan Inspect;
            public TimeSpan Setup;
            public TimeSpan Ready;
            public TimeSpan Running;
            public TimeSpan NoJob;
            public TimeSpan Maintanence;
            
            public double Inspect_Per;
            public double Setup_Per;
            public double Ready_Per;
            public double Running_Per; 
            public double NoJob_Per;
            public double Maintanence_Per;
            
        }

        public PieSums Summation(List<BarStatePoint> EventSequence)
        {
            PieSums Sum = new PieSums();

            foreach (BarStatePoint Item in EventSequence) 
            {
                TimeSpan ts = Item.Starttime - Item.Endtime;
                TimeSpan change =  ts.Duration();
                
                switch (Item.State)
                {
                    case "Inspect":
                        Sum.Inspect += change;
                        break;
                    case "Setup":
                        Sum.Setup += change;
                        break;
                    case "Ready":
                        Sum.Ready += change;
                        break;
                    case "Running":
                        Sum.Running += change;
                        break;
                    case "No Job or Operator":
                        Sum.NoJob += change;
                        break;
                    case "Scheduled Maintenance":
                        Sum.Maintanence += change;
                        break;
                    case "Unscheduled Maintenance":
                        Sum.Maintanence += change;
                        break;
                }
            }

            double total = Sum.Inspect.TotalMinutes + Sum.Setup.TotalMinutes +Sum.Ready.TotalMinutes + Sum.Running.TotalMinutes + Sum.NoJob.TotalMinutes + Sum.Maintanence.TotalMinutes;
            Sum.Inspect_Per = 100 * Sum.Inspect.TotalMinutes/total;
            Sum.Setup_Per = 100 * Sum.Setup.TotalMinutes/total;
            Sum.Ready_Per = 100 * Sum.Ready.TotalMinutes/total;
            Sum.Running_Per = 100 * Sum.Running.TotalMinutes/total;
            Sum.NoJob_Per = 100 * Sum.NoJob.TotalMinutes/total;
            Sum.Maintanence_Per = 100 * Sum.Maintanence.TotalMinutes/total;

            return Sum;
        }

    }
}
