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

namespace KEBOT.Cycletime
{
    public partial class Cycleform : Form
    {
        public DataTable InputTable { get; set; } // for containing the table

        public Cycleform()
        {
            InitializeComponent();
            // 
            CycletimeData.AllowUserToAddRows = false;
            CycletimeData.RowHeadersVisible = false;
            //
            PivotTable.AllowUserToDeleteRows = false;
            PivotTable.RowHeadersVisible = false;
            //
        }

        private string lastitemtype = "Material";

        private string Materialselected = "";
        // material selection
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastitemtype = "Material";

           try
           {
                Materialselected = MaterialList.SelectedItems[0].ToString();
                TestDisplay.Text = Materialselected;

                if (FilterCheck.Checked) // filter the data
                {
                    PageLoad(InputTable, Materialselected, "Material", true, Convert.ToInt32(ValueFilterNumber.Value));
                }
                else // dont filter the data
                {
                    PageLoad(InputTable, Materialselected, "Material", false, Convert.ToInt32(ValueFilterNumber.Value));
                }
            }
           catch (Exception problem)
           { 
                if (problem.Message != "The source contains no DataRows." && problem.Message != "Sequenc") // this error gets annoying to see 
                {
                   // MessageBox.Show(problem.Message);
                }  
           }
        }

        private string POselected = "";
        // production order selection
        private void Prod_OrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastitemtype = "ProductionOrder";

            try
            {
                POselected = Prod_OrderList.SelectedItems[0].ToString();
                TestDisplay.Text = POselected;
  
                if (FilterCheck.Checked) // filter the data
                {
                    PageLoad(InputTable, POselected, "ProductionOrder", true, Convert.ToInt32(ValueFilterNumber.Value));
                }
                else // dont filter the data
                {
                    PageLoad(InputTable, POselected, "ProductionOrder", false, Convert.ToInt32(ValueFilterNumber.Value));
                }
                /*
                var filteredResults = InputTable.AsEnumerable().Where(row => row.Field<string>("ProductionOrder") == POselected); // make a filter of the table
                DataTable SelectedTable = filteredResults.CopyToDataTable(); // apply the filter onto a new table
                SelectedTable.Columns.Remove("WorkCenter");
                SelectedTable.Columns.Remove("Machine");
                SelectedTable.Columns.Remove("Kiosk_CN");
                SelectedTable.Columns.Remove("Actual_Loadtime");
                SelectedTable.Columns.Remove("SAP_Quantity");
                SelectedTable.Columns.Remove("MT_H1Rapid");
                SelectedTable.Columns.Remove("MT_H1Feed");
                SelectedTable.Columns.Remove("MT_H1Spindle");
                SelectedTable.Columns.Remove("MT_H2Rapid");
                SelectedTable.Columns.Remove("MT_H2Feed");
                SelectedTable.Columns.Remove("MT_H2Spindle");
                SelectedTable.Columns.Remove("Gantry");
                SelectedTable.Columns.Remove("LinkAddress");
                SelectedTable.Columns.Remove("DAY_OF_WEEK");
                SelectedTable.Columns.Remove("Override");

                //  filteredResults = SelectedTable.AsEnumerable().Where(row => row.Field<TimeSpan>("Actual_Cycletime") != TimeSpan.Zero); // get rid of initial part rows
                // SelectedTable = filteredResults.CopyToDataTable(); // apply the filter onto a new table
                filteredResults = SelectedTable.AsEnumerable().Where(row => row.Field<string>("Event").Contains("PART")); // get rid of non part rows
                SelectedTable = filteredResults.CopyToDataTable(); // apply the filter onto a new table

                if (CycletimeData.DataSource != SelectedTable) // prevents refresh issue for resource consumption
                {
                    GraphCycleTimeLine(SelectedTable);

                    DataTable _pivotTable = MakePivotTable(SelectedTable);

                    // convert into an Array
                    List<double> ValueArray = new List<double>(); // wanted to use timespan but c sharp doesnt really have setup operations for it. 

                    TimeSpan SAP_costvalue = TimeSpan.Zero;

                    for (int row = 0; row < _pivotTable.Rows.Count; row++)
                    {
                        DataRow myrow = _pivotTable.Rows[row];
                        for (int i = 0; i < int.Parse(myrow["Occurance"].ToString()); i++)
                        {
                            ValueArray.Add(TimeSpan.Parse(myrow["CycletimeValue"].ToString()).TotalSeconds);// put all the values into an a single dimension list
                        }
                        SAP_costvalue = TimeSpan.Parse(myrow["SAP_Costing"].ToString());
                    }

                    ValueArray.Sort(); // Sort the list in ascending order (default behavior)
                    TimeSpan Median = TimeSpan.FromSeconds(MedianCalculator.FindMedian(ValueArray)); // find median

                    if (QuartileFilter.Checked) // filter the data
                    {

                    }
                    else // dont filter the data
                    {

                    }

                    TimeSpan Average = TimeSpan.FromSeconds(ValueArray.Average()); // find average
                    TimeSpan Min = TimeSpan.FromSeconds(ValueArray.Min()); // find minimum value
                    TimeSpan Max = TimeSpan.FromSeconds(ValueArray.Max()); // find maximum value

                    GraphDistribution(_pivotTable, Min, Max);

                    Summary.Text = ""; // clear the widget
                    Summary.Text = "Fastest Cycletime: " + Min.ToString() + "\n"
                      + "Slowest Cycletime: " + Max.ToString() + "\n"
                      + "Average Cycletime: " + Average.ToString().Remove(8) + "\n"
                      + "Median Cycletime: " + Median.ToString() + "\n";

                    MakeBarChart(Min, Max, Average, Median, SAP_costvalue);
                }
                */
            }
            catch (Exception problem)
            {
                if (problem.Message != "The source contains no DataRows." && problem.Message != "Sequenc") // this error gets annoying to see 
                {
                  //  MessageBox.Show(problem.Message);
                }
            }
        }

        private void PageLoad(DataTable inputtable, string SelectedItem, string searchtype, bool filter, int filternumber)
        {
            DataTable SelectedTable = new DataTable();
            EnumerableRowCollection<DataRow> filteredResults;
            switch (searchtype)
            {
                case "ProductionOrder":
                    filteredResults = inputtable.AsEnumerable().Where(row => row.Field<string>("ProductionOrder") == SelectedItem); // make a filter of the table
                    SelectedTable = filteredResults.CopyToDataTable(); // apply the filter onto a new table
                    break;
                case "Material":
                    filteredResults = InputTable.AsEnumerable().Where(row => row.Field<string>("Material") == SelectedItem); // make a filter of the table
                    SelectedTable = filteredResults.CopyToDataTable(); // apply the filter onto a new table
                    break;
            }

            SelectedTable.Columns.Remove("WorkCenter");
            SelectedTable.Columns.Remove("Machine");
            SelectedTable.Columns.Remove("Kiosk_CN");
            SelectedTable.Columns.Remove("Actual_Loadtime");
            SelectedTable.Columns.Remove("SAP_Quantity");
            SelectedTable.Columns.Remove("MT_H1Rapid");
            SelectedTable.Columns.Remove("MT_H1Feed");
            SelectedTable.Columns.Remove("MT_H1Spindle");
            SelectedTable.Columns.Remove("MT_H2Rapid");
            SelectedTable.Columns.Remove("MT_H2Feed");
            SelectedTable.Columns.Remove("MT_H2Spindle");
            SelectedTable.Columns.Remove("Gantry");
            SelectedTable.Columns.Remove("LinkAddress");
            SelectedTable.Columns.Remove("DAY_OF_WEEK");
            SelectedTable.Columns.Remove("Override");

            //  filteredResults = SelectedTable.AsEnumerable().Where(row => row.Field<TimeSpan>("Actual_Cycletime") != TimeSpan.Zero); // get rid of initial part rows
            // SelectedTable = filteredResults.CopyToDataTable(); // apply the filter onto a new table
            filteredResults = SelectedTable.AsEnumerable().Where(row => row.Field<string>("Event").Contains("PART")); // get rid of non part rows
            SelectedTable = filteredResults.CopyToDataTable(); // apply the filter onto a new table

            if (CycletimeData.DataSource != SelectedTable) // prevents refresh issue for resource consumption
            {
                GraphCycleTimeLine(SelectedTable);
                // initialize the target values
                TimeSpan SAP_costvalue = TimeSpan.Zero;
                TimeSpan lowerlimit = TimeSpan.Zero;
                TimeSpan upperlimit = TimeSpan.Zero;

                DataTable _pivotTable;
                
                if (filter)
                {
                    DataTable initial_pivotTable = MakePivotTable(SelectedTable);
                    // convert into an Array
                    List<double> i_ValueArray = new List<double>(); // wanted to use timespan but c sharp doesnt really have setup operations for it. 

                    for (int row = 0; row < initial_pivotTable.Rows.Count; row++)
                    {
                        DataRow myrow = initial_pivotTable.Rows[row];
                        for (int i = 0; i < int.Parse(myrow["Occurance"].ToString()); i++)
                        {
                            i_ValueArray.Add(TimeSpan.Parse(myrow["CycletimeValue"].ToString()).TotalSeconds);// put all the values into an a single dimension list
                        }
                        SAP_costvalue = TimeSpan.Parse(myrow["SAP_Costing"].ToString());
                    }
                    i_ValueArray.Sort(); // Sort the list in ascending order (default behavior)
                    
                    double initialaverage = i_ValueArray.Average(); // find average
                    double sumOfsquares = i_ValueArray.Sum(d => (d - initialaverage) * (d - initialaverage));// sum of squares
                    // divide by (count - 1) for sample standard deviation and take the square root
                    double standardDeviation = Math.Sqrt(sumOfsquares/ (i_ValueArray.Count - 1));

                    lowerlimit = TimeSpan.FromSeconds(initialaverage - filternumber * standardDeviation);
                    upperlimit = TimeSpan.FromSeconds(initialaverage + filternumber * standardDeviation);

                    //MessageBox.Show(lowerlimit.ToString() + " : " + upperlimit.ToString());

                    filteredResults = SelectedTable.AsEnumerable().Where(row => row.Field<TimeSpan>("Actual_Cycletime") <= upperlimit); // get rid of everything above the upper limit
                    DataTable FilteredTable1 = filteredResults.CopyToDataTable(); // apply the filter onto a new table
                    EnumerableRowCollection<DataRow>  filteredResults2 = FilteredTable1.AsEnumerable().Where(row => row.Field<TimeSpan>("Actual_Cycletime") >= lowerlimit); // get rid of everything below the lower limit
                    DataTable FilteredTable2 = filteredResults2.CopyToDataTable();
                    _pivotTable = MakePivotTable(FilteredTable2);
                }
                else
                {
                    _pivotTable = MakePivotTable(SelectedTable);
                }
                // convert into an Array
                List<double> ValueArray = new List<double>(); // wanted to use timespan but c sharp doesnt really have setup operations for it. 

                for (int row = 0; row < _pivotTable.Rows.Count; row++)
                {
                    DataRow myrow = _pivotTable.Rows[row];
                    for (int i = 0; i < int.Parse(myrow["Occurance"].ToString()); i++)
                    {
                       ValueArray.Add(TimeSpan.Parse(myrow["CycletimeValue"].ToString()).TotalSeconds);// put all the values into an a single dimension list
                    }
                    SAP_costvalue = TimeSpan.Parse(myrow["SAP_Costing"].ToString());
                }

                ValueArray.Sort(); // Sort the list in ascending order (default behavior)
                TimeSpan Median = TimeSpan.FromSeconds(MedianCalculator.FindMedian(ValueArray)); // find median
                TimeSpan Average = TimeSpan.FromSeconds(ValueArray.Average()); // find average
                TimeSpan Min = TimeSpan.FromSeconds(ValueArray.Min()); // find minimum value
                TimeSpan Max = TimeSpan.FromSeconds(ValueArray.Max()); // find maximum value

                GraphDistribution(_pivotTable, Min, Max);
                            
                Summary.Text = ""; // clear the widget
                Summary.Text = "Fastest Cycletime: " + Min.ToString() + "\n"
                  + "Slowest Cycletime: " + Max.ToString() + "\n"
                  + "Average Cycletime: " + Average.ToString().Remove(8) + "\n"
                  + "Median Cycletime: " + Median.ToString() + "\n\n\n\n\n\n"
                  + "Lower Limit: " + lowerlimit.ToString() + "\n"
                  + "Upper Limit: " + upperlimit.ToString() + "\n";
                     
                MakeBarChart(Min, Max, Average, Median, SAP_costvalue);
            }
        }

        private void GraphCycleTimeLine(DataTable dt)
        {
            dt.Columns.Add("time", typeof(double));
            foreach (DataRow row in dt.Rows)
            {
                row["time"] = TimeSpan.Parse(row["Actual_Cycletime"].ToString()).TotalMinutes; // convert the timespan to a relative date time the graph can understand
            }

            CycleTimeline.Series.Clear();
            CycleTimeline.Titles.Clear();
            CycleTimeline.Titles.Add("CycleTime Timeline");

            ChartArea CA = CycleTimeline.ChartAreas[0]; // Access the default chart area
            CA.AxisY.Title = "Cycletime (min)";
            CA.AxisX.ScrollBar.Enabled = true;
            CA.CursorX.AutoScroll = true;
            // Set the maximum number of visible data points on the X-axis
            CA.AxisX.ScaleView.Size = 7; // e.g., show 10 data points at a time
            // Set the scroll increment (optional)
            CA.AxisX.ScaleView.SmallScrollSize = 1;

            CycleTimeline.DataSource = dt;

            CycleTimeline.Series.Add("series");
            Series series = CycleTimeline.Series["series"];
            series.Color = Color.Blue;
            series.ChartType = SeriesChartType.StepLine;
            series.BorderWidth = 2;
            series.XValueMember = "Stime";
            series.XValueType = ChartValueType.DateTime;
            series.YValueMembers = "time";
            series.YValueType = ChartValueType.Auto;

            CycleTimeline.DataBind();

            dt.Columns.Remove("time");
        }

        private void GraphDistribution(DataTable pivottable, TimeSpan Min, TimeSpan Max)
        {
            pivottable.Columns.Add("time", typeof(DateTime));

            foreach(DataRow row in pivottable.AsEnumerable())
            {
                row["time"] = DateTime.Today + TimeSpan.Parse(row["CycletimeValue"].ToString());
            }

            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.Titles.Add("Cycletime Distribution");
            
            pivottable.DefaultView.Sort = "time ASC";
            chart2.DataSource = pivottable.DefaultView;

            // --- Configure the Chart Area Axis X for DateTime formatting and scaling ---
            ChartArea CA = chart2.ChartAreas[0]; // Access the default chart area
            CA.AxisX.Title = "Cycletime (HH:mm:ss)";
            CA.AxisX.LabelStyle.Format = "HH:mm:ss";
            CA.AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Auto;
            CA.AxisX.Minimum = DateTime.Today.ToOADate() + Min.TotalDays;
            CA.AxisX.Maximum = DateTime.Today.ToOADate() + Max.TotalDays;
            CA.AxisY.Title = "Occurance";
            CA.AxisY.Minimum = 0;

            chart2.Series.Add("line");
            Series line = chart2.Series["line"];
            line.Color = Color.MediumPurple;
            line.ChartType = SeriesChartType.Line;
            line.BorderWidth = 2;
            line.XValueMember = "time";
            line.XValueType = ChartValueType.DateTime;
            line.YValueMembers = "Occurance";

            chart2.Series.Add("Datapoint");
            Series series = chart2.Series["Datapoint"];
            series.Color = Color.Black;
            series.ChartType = SeriesChartType.Point;
            series.BorderWidth = 3;
            series.XValueMember = "time";
            series.XValueType = ChartValueType.DateTime;
            series.YValueMembers = "Occurance";

            chart2.DataBind();

            pivottable.Columns.Remove("time");
        }

        private DataTable MakePivotTable(DataTable SelectedTable)
        {
            // make the data table (right table)
            CycletimeData.DataSource = SelectedTable; // show the filtered table
            CycletimeData.Columns["Actual_Cycletime"].DefaultCellStyle.BackColor = Color.LightYellow;
            CycletimeData.EnableHeadersVisualStyles = false;
            CycletimeData.Columns["Actual_Cycletime"].HeaderCell.Style.BackColor = Color.Yellow;

            Dictionary<string, DataRow> uniqueRowMap = new Dictionary<string, DataRow>();

            DataTable _pivotTable = new DataTable(); // for computing the pivot table

            // _pivotTable.Columns.Add("ID");
            _pivotTable.Columns.Add("Occurance");
            _pivotTable.Columns.Add("CycletimeValue");
            _pivotTable.Columns.Add("SAPValue");
            _pivotTable.Columns.Add("SAP_Costing");

            foreach (DataRow info in SelectedTable.AsEnumerable())
            {
                string currentValue = info["Actual_Cycletime"].ToString();
                if (currentValue!=TimeSpan.Zero.ToString())
                {
                    if (!uniqueRowMap.ContainsKey(currentValue))
                    {
                        DataRow newPivotRow = _pivotTable.NewRow();
                        newPivotRow["Occurance"] = 1; // Assuming you have a 'Count' column
                        newPivotRow["CycletimeValue"] = currentValue;
                        newPivotRow["SAPValue"] = (TimeSpan.Parse(info["SAP_Info1"].ToString()) + TimeSpan.Parse(info["SAP_Info2"].ToString())).ToString();
                        newPivotRow["SAP_Costing"] = info["SAP_Machine_Cycletime"];
                        // --- 2. Add the configured row to the DataTable ---
                        _pivotTable.Rows.Add(newPivotRow);
                        // Track this specific DataRow object in map
                        uniqueRowMap.Add(currentValue, newPivotRow);
                    }
                    else
                    {
                        // --- Duplicate Occurrence: Increment Existing Count ---
                        DataRow rowToUpdate = uniqueRowMap[currentValue];

                        // Get the current count value, increment it, and update the row
                        int currentCount = Convert.ToInt32(rowToUpdate["Occurance"]);
                        rowToUpdate["Occurance"] = currentCount + 1;
                    }
                }
            }

            // make the pivot table (left table)
            PivotTable.DataSource = _pivotTable; // show the pivot table info
            PivotTable.Sort(PivotTable.Columns["CycletimeValue"], ListSortDirection.Ascending); // fastest time on top and slowest on the bottum
            PivotTable.Columns["CycletimeValue"].DefaultCellStyle.BackColor = Color.LightYellow;
            PivotTable.EnableHeadersVisualStyles = false;
            PivotTable.Columns["CycletimeValue"].HeaderCell.Style.BackColor = Color.Yellow;

            return _pivotTable;
        }

        private void MakeBarChart(TimeSpan Min, TimeSpan Max, TimeSpan Average, TimeSpan Median, TimeSpan SAP_costvalue)
        {
            //! make the bar graph
            chart1.Titles.Clear();
            chart1.Titles.Add(Materialselected);
            chart1.Series.Clear();

            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = true;
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.Title = "Duration (Minutes)";

            var dataSeries = chart1.Series.Add("Metrics");
            dataSeries.ChartType = SeriesChartType.Column;

            dataSeries.Points.AddXY("Min Value", Min.TotalMinutes);
            dataSeries.Points[0].Color = Color.Green; // Min

            if (Median>Average)
            {
                dataSeries.Points.AddXY("Average", Average.TotalMinutes);
                dataSeries.Points.AddXY("Median", Median.TotalMinutes);
                dataSeries.Points[1].Color = Color.Yellow;
                dataSeries.Points[2].Color = Color.Pink;

            }
            else
            {
                dataSeries.Points.AddXY("Median", Median.TotalMinutes);
                dataSeries.Points.AddXY("Average", Average.TotalMinutes);
                dataSeries.Points[2].Color = Color.Yellow;
                dataSeries.Points[1].Color = Color.Pink;
            }
            dataSeries.Points.AddXY("Max Value", Max.TotalMinutes);
            dataSeries.Points[3].Color = Color.Blue;  // Max

            dataSeries["PointWidth"] = "0.8";

            chart1.ChartAreas[0].AxisY.StripLines.Clear();
            StripLine costline = new StripLine
            {
                IntervalOffset = SAP_costvalue.Minutes // The Y-value where the line will be drawn
            };
            // Set interval to 0 to draw a single line

            if (SAP_costvalue.TotalMinutes>Max.TotalMinutes)
            {
                chart1.ChartAreas[0].AxisY.Maximum = SAP_costvalue.TotalMinutes + 0.1 * SAP_costvalue.TotalMinutes; // size determined by the limit

                costline.StripWidth = 0.01 * SAP_costvalue.TotalMinutes;

            }
            else // size determined by the max value
            {
                chart1.ChartAreas[0].AxisY.Maximum = Max.TotalMinutes + 0.1 * Max.TotalMinutes;


                costline.StripWidth = 0.01 * Max.TotalMinutes;
            }

            costline.Interval = 0;
            costline.BackColor = Color.Red;
            costline.Text = "Pricing";

            chart1.ChartAreas[0].AxisY.StripLines.Add(costline);
        }
        
        private void FilterCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            if (FilterCheck.Checked)
            {
                PageLoad(InputTable, TestDisplay.Text, lastitemtype, true, Convert.ToInt32(ValueFilterNumber.Value));
            }
            else
            {
                PageLoad(InputTable, TestDisplay.Text, lastitemtype, false, Convert.ToInt32(ValueFilterNumber.Value));
            }
        }

        private void ValueFilterNumber_ValueChanged_1(object sender, EventArgs e)
        {
            if (FilterCheck.Checked)
            {
                PageLoad(InputTable, TestDisplay.Text, lastitemtype, true, Convert.ToInt32(ValueFilterNumber.Value));
            }
            else
            {
                PageLoad(InputTable, TestDisplay.Text, lastitemtype, false, Convert.ToInt32(ValueFilterNumber.Value));
            }
        }
    }
}
