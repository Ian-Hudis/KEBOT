using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Linq.Expressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using static KEBOT.Runtime;

namespace KEBOT
{
    public partial class KEBOT : Form
    {
        public static SQL_Client sql_Client = new SQL_Client();

        public static string Datrowcontext = "";

        public static int pagenumber = 0; // the location number work center
        public static string brand = ""; // machine type

        public static string pagetype = ""; // report type

        // values for detecting a change requiring a new sql query of the data
        public static int prev_pagenumber = 0; // work center
        public static string prev_brand = ""; //machine type
        public static string prev_pagetype = ""; // report type
        public static string prev_dataloglisttype = "";
        public static DateTime prev_starttime = DateTime.MinValue;
        public static DateTime prev_endtime = DateTime.MinValue;

        public static bool RuntimeChartGenerated = false;
        public static bool DataGridGenerated = false;

        public KEBOT()
        {
            InitializeComponent();
            //AboutText.Text = System.IO.File.ReadAllText(Environment.CurrentDirectory + "/Data/General/UpdateLog.txt");
            pagetype = "";

            //PageLoad();
        }

        public static Int64 rownumber;
        Runtime runtime = new Runtime(); // Runtime class

        private async void PageLoad()
        {
            // DialogueBox.AppendText(pagetype);
            // DialogueBox.AppendText(Environment.NewLine);
            //  DialogueBox.AppendText("Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
            //  DialogueBox.AppendText(Environment.NewLine);

            System.Drawing.Color WCColor = System.Drawing.Color.Cyan;
            System.Drawing.Color fontcolor = System.Drawing.Color.Black;
            switch (pagenumber)
            {
                case 2102:
                    HAAS2012L.BackColor = WCColor;
                    HAAS2012L.ForeColor = fontcolor;
                    break;
                case 2103:
                    HAAS2012M.BackColor = WCColor;
                    HAAS2012M.ForeColor = fontcolor;
                    break;
                case 2105:
                    HAAS2105.BackColor = WCColor;
                    HAAS2105.ForeColor = fontcolor;
                    break;
                case 2107:
                    Doosan2107.BackColor = WCColor;
                    Doosan2107.ForeColor = fontcolor;
                    break;
                case 2111:
                    mazak2111.BackColor = WCColor;
                    mazak2111.ForeColor = fontcolor;
                    break;
                case 2112:
                    mazak2112.BackColor = WCColor;
                    mazak2112.ForeColor = fontcolor;
                    break;
                case 2260:
                    mazak2260.BackColor = WCColor;
                    mazak2260.ForeColor = fontcolor;
                    break;
                case 2271:
                    DOOSAN2271.BackColor = WCColor;
                    DOOSAN2271.ForeColor = fontcolor;
                    break;
                case 2272:
                    mazak2272.BackColor = WCColor;
                    mazak2272.ForeColor = fontcolor;
                    break;
                case 2280:
                    mazak2280.BackColor = WCColor;
                    mazak2280.ForeColor = fontcolor;
                    break;
                case 2281:
                    mazak2281.BackColor = WCColor;
                    mazak2281.ForeColor = fontcolor;
                    break;
                case 2282:
                    mazak2282.BackColor = WCColor;
                    mazak2282.ForeColor = fontcolor;
                    break;
                case 2283:
                    mazak2283.BackColor = WCColor;
                    mazak2283.ForeColor = fontcolor;
                    break;
                case 2321:
                    lAPMASTER2321.BackColor = WCColor;
                    lAPMASTER2321.ForeColor = fontcolor;
                    break;
                case 3111:
                    amada3111.BackColor = WCColor;
                    amada3111.ForeColor = fontcolor;
                    break;
                case 3112:
                    amada3112.BackColor = WCColor;
                    amada3112.ForeColor = fontcolor;
                    break;
                case 3321:
                    BDTRONIC3321.BackColor = WCColor;
                    BDTRONIC3321.ForeColor = fontcolor;
                    break;
            }

            System.Drawing.Color ViewColor = System.Drawing.Color.Red;
            switch (pagetype)
            {
                case "":
                    ZoomIn.Visible = false;
                    ZoomOut.Visible = false;
                    YZoomOut.Visible = false;
                    YZoomIn.Visible = false;
                    RuntimeScrollbar.Visible = false;

                    AboutText.Visible = true;
                    myDataTable.Visible = false;
                    RuntimeBackground.Visible = false;
                    BarChart1.Visible = false;
                    PieChart1.Visible = false;
                    try
                    {
                        string workingDirectory = Environment.CurrentDirectory;
                        AboutText.Text = System.IO.File.ReadAllText(workingDirectory + "/Data/General/UpdateLog.txt");
                    }
                    catch (Exception exception)
                    {
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    break;
                case "About":

                    ZoomIn.Visible = false;
                    ZoomOut.Visible = false;
                    YZoomOut.Visible = false;
                    YZoomIn.Visible = false;
                    RuntimeScrollbar.Visible = false;

                    aboutToolStripMenuItem.BackColor = ViewColor;
                    AboutText.Visible = true;
                    myDataTable.Visible = false;
                    RuntimeBackground.Visible = false;
                    BarChart1.Visible = false;
                    PieChart1.Visible = false;

                    try
                    {
                        string workingDirectory = Environment.CurrentDirectory;
                        AboutText.Text = System.IO.File.ReadAllText(workingDirectory + "/Data/" + pagenumber + "/about.txt");
                    }
                    catch (Exception exception)
                    {
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    break;
                case "DataLog":
                    ZoomIn.Visible = false;
                    ZoomOut.Visible = false;
                    YZoomOut.Visible = false;
                    YZoomIn.Visible = false;
                    RuntimeScrollbar.Visible = false;

                    dataToolStripMenuItem.BackColor = ViewColor;
                    AboutText.Visible = false;
                    myDataTable.Visible = true;
                    RuntimeBackground.Visible = false;
                    BarChart1.Visible = false;
                    PieChart1.Visible = false;

                    try
                    {
                        if (dt == null || pagenumber != prev_pagenumber || prev_starttime != dateTimePicker1.Value || prev_endtime != dateTimePicker2.Value || prev_dataloglisttype != Dataloglistype)
                        {
                            Splashscreen loadscreen = new Splashscreen();
                            loadscreen.Show();
                            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
                            DialogueBox.AppendText(Environment.NewLine);
                            dt.Clear();
                            dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                            DataGridGenerated = false;
                            RuntimeChartGenerated = false;
                            //myDataTable.Refresh();
                            loadscreen.Close();
                        }

                        if (!DataGridGenerated)
                        {
                            MakeGridView(dt);
                            myDataTable.DataSource = dt;
                            DataGridGenerated = true;
                        }

                    }
                    catch (Exception exception)
                    {
                       // dt.Clear();
                       // myDataTable.DataSource = dt;
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }

                    break;
                case "Comment":

                    ZoomIn.Visible = false;
                    ZoomOut.Visible = false;
                    YZoomOut.Visible = false;
                    YZoomIn.Visible = false;
                    RuntimeScrollbar.Visible = false;

                    addComment.BackColor = ViewColor;
                    AboutText.Visible = false;
                    myDataTable.Visible = true;
                    RuntimeBackground.Visible = false;
                    BarChart1.Visible = false;
                    PieChart1.Visible = false;

                    try
                    {
                        if (dt == null || pagenumber != prev_pagenumber || prev_starttime != dateTimePicker1.Value || prev_endtime != dateTimePicker2.Value || prev_dataloglisttype != Dataloglistype)
                        {
                            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
                            DialogueBox.AppendText(Environment.NewLine);

                            Splashscreen loadscreen = new Splashscreen();
                            loadscreen.Show();
                            dt.Clear();
                            dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                            DataGridGenerated = false;
                            RuntimeChartGenerated = false;
                            loadscreen.Close();
                        }


                        if (!DataGridGenerated)
                        {
                            MakeGridView(dt);
                            myDataTable.DataSource = dt;
                            DataGridGenerated = true;
                        }
                    }
                    catch (Exception exception)
                    {
                        //dt.Clear();
                       // myDataTable.DataSource = dt;
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }

                    break;
                case "Runtime":

                    ZoomIn.Visible = true;
                    ZoomOut.Visible = true;
                    YZoomOut.Visible = true;
                    YZoomIn.Visible = true;
                    RuntimeBackground.Visible = false;

                    BarChart1.Visible = true;
                    PieChart1.Visible = true;
                    RuntimeBackground.Visible = true;
                    runtimeToolStripMenuItem.BackColor = ViewColor;
                    AboutText.Visible = false;
                    myDataTable.Visible = false;

                    Splashscreen Runtimeloadscreen = new Splashscreen();
                    Runtimeloadscreen.Show();

                    try
                    {
                        if (dt == null || pagenumber != prev_pagenumber || prev_starttime != dateTimePicker1.Value || prev_endtime != dateTimePicker2.Value)
                        {
                            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
                            DialogueBox.AppendText(Environment.NewLine);
                            dt.Clear();
                            dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                            MakeGridView(dt); //myDataTable.DataSource = dt;
                            myDataTable.DataSource = dt;
                            DataGridGenerated = false;
                            RuntimeChartGenerated = false;
                        }
                        if (!RuntimeChartGenerated)
                        {
                            BarChart1.Series.Clear();
                            BarChart1.Titles.Clear();

                            BarChart1.Titles.Add("Runtime Timeline");

                            BarChart1.Series.Clear();
                            runtime.MakeRuntimeGraph(BarChart1, dt, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                            RuntimeChartGenerated = true;

                            for (int row = 0; row< runtime.BarSequance.Count; row++)
                            {
                                DialogueBox.AppendText(runtime.BarSequance[row].ID + "  " + runtime.BarSequance[row].State + "  " + runtime.BarSequance[row].Starttime + "  " + runtime.BarSequance[row].Endtime + "  " + runtime.BarSequance[row].color.ToString() + "  " +runtime.BarSequance[row].Carryover + ";"); // debug
                                DialogueBox.AppendText(Environment.NewLine); // debug
                            }
                        }

                        //reset your chart series and legends
                        PieChart1.Series.Clear();

                        runtime.piesums = runtime.Summation(runtime.BarSequance);

                        //Add a new Legend(if needed) and do some formating
                        PieChart1.Legends[0].LegendStyle = LegendStyle.Table;
                        //PieChart1.Legends[0].Docking = Docking.Bottom;
                        PieChart1.Legends[0].Alignment = StringAlignment.Center;
                        PieChart1.Legends[0].Title = "Runtime States";
                        PieChart1.Legends[0].BorderColor = System.Drawing.Color.Black;

                        string seriesname = "MySeriesName";
                        PieChart1.Series.Add(seriesname);
                        PieChart1.Series[seriesname].ChartType = SeriesChartType.Pie;

                        PieChart1.Series[seriesname].Points.AddXY("Inspect", 5 /*runtime.piesums.Inspect_Per*/);
                        PieChart1.Series[seriesname].Points[0].Color = System.Drawing.Color.DarkBlue;
                     
                        PieChart1.Series[seriesname].Points.AddXY("Setup", 10/*runtime.piesums.Setup_Per*/);
                        PieChart1.Series[seriesname].Points[1].Color = System.Drawing.Color.Cyan;
                        
                        PieChart1.Series[seriesname].Points.AddXY("Ready", 15 /*runtime.piesums.Ready_Per*/);
                        PieChart1.Series[seriesname].Points[2].Color = System.Drawing.Color.Yellow;
                       
                        PieChart1.Series[seriesname].Points.AddXY("Running", 30 /*runtime.piesums.Ready_Per*/);
                        PieChart1.Series[seriesname].Points[3].Color = System.Drawing.Color.LimeGreen;

                        PieChart1.Series[seriesname].Points.AddXY("No Job or Operator", 60 /*runtime.piesums.NoJob_Per*/);
                        PieChart1.Series[seriesname].Points[4].Color = System.Drawing.Color.DarkRed;

                        PieChart1.Series[seriesname].Points.AddXY("Maintenance", 10/*runtime.piesums.Maintanence_Per*/);
                        PieChart1.Series[seriesname].Points[5].Color = System.Drawing.Color.Red;
                    }
                    catch (Exception exception)
                    {
                       // dt.Clear();
                        BarChart1.Series.Clear();
                        BarChart1.Titles.Clear();
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    finally
                    {
                        Runtimeloadscreen.Close();
                    }
                    break;
                case "CycletimeAnalysis":

                    ZoomIn.Visible = true;
                    ZoomOut.Visible = true;
                    YZoomOut.Visible = true;
                    YZoomIn.Visible = true;
                    RuntimeScrollbar.Visible = false;

                    RuntimeBackground.Visible = true;

                    cycleTimeAnalysis.BackColor = ViewColor;
                    AboutText.Visible = false;
                    myDataTable.Visible = false;

                    BarChart1.Visible = false;
                    PieChart1.Visible = false;
                    break;
                default: // "" 
                    RuntimeScrollbar.Visible = false;
                    ZoomIn.Visible = false;
                    ZoomOut.Visible = false;
                    YZoomOut.Visible = false;
                    YZoomIn.Visible = false;
                    AboutText.Visible = false;
                    myDataTable.Visible = false;
                    RuntimeBackground.Visible = false;
                    break;
            }

            // coloring for the data grid.
            DataGridColoring(theme);

            // reset the triggers
            prev_pagenumber = pagenumber;
            prev_brand = brand;
            prev_pagetype = pagetype;
            prev_dataloglisttype = Dataloglistype;
            prev_starttime = dateTimePicker1.Value;
            prev_endtime = dateTimePicker2.Value;

        }

        public static string Dataloglistype = "full";
        System.Data.DataTable dt = new System.Data.DataTable();

        // The Get data button 
        private async void Get_Data_Click(object sender, EventArgs e)
        {
            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
            
            DialogueBox.AppendText(Environment.NewLine);
            try
            {
                Splashscreen loadscreen = new Splashscreen();
                loadscreen.Show();
                dt.Clear();

                if (pagetype == "DataLog" || pagetype == "Comment")
                {
                    dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                    MakeGridView(dt); //myDataTable.DataSource = dt;
                    DataGridColoring(theme);
                }
                else if (pagetype == "Runtime")
                {
                    dt = await sql_Client.SQL_Import_Datatable("mcstate", brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);

                    BarChart1.Titles.Clear();
                    BarChart1.Titles.Add("Runtime Timeline");                   
                    BarChart1.Series.Clear();
                    runtime.MakeRuntimeGraph(BarChart1, dt, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);

                    for (int row = 0; row< runtime.BarSequance.Count; row++)
                    {
                        DialogueBox.AppendText(runtime.BarSequance[row].ID + "  " + runtime.BarSequance[row].State + "  " + runtime.BarSequance[row].Starttime + "  " + runtime.BarSequance[row].Endtime + "  " + runtime.BarSequance[row].color.ToString() + "  " +runtime.BarSequance[row].Carryover + ";"); // debug
                        DialogueBox.AppendText(Environment.NewLine); // debug
                    }
                }


                loadscreen.Close();
            }
            catch (Exception exception)
            {
                dt.Clear();
                myDataTable.DataSource = dt;
                DialogueBox.AppendText(exception.ToString());
                DialogueBox.AppendText(Environment.NewLine);
            }
        }

        // the enter comment option
        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pagetype == "Comment")
            {
                rownumber = Int64.Parse(dt.Rows[e.RowIndex][0].ToString());
                Datrowcontext = dt.Rows[e.RowIndex][0].ToString() + ": " + dt.Rows[e.RowIndex].Field<string>("Event").ToString().Trim(' ') + ": " + dt.Rows[e.RowIndex].Field<string>("Stime").ToString();

                sql_Client.CommentRust = sql_Client.GetCommentEntry(pagenumber.ToString(), rownumber.ToString()); // grab comment data if any

                CommentEnter form = new CommentEnter();
                form.Show();
            }
        }

        private async void fullDataLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dataloglistype = "full";
            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
            DialogueBox.AppendText(Environment.NewLine);
            try
            {
                Splashscreen loadscreen = new Splashscreen();
                loadscreen.Show();
                dt.Clear();
                dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                MakeGridView(dt); //myDataTable.DataSource = dt;
                DataGridColoring(theme);
                loadscreen.Close();
            }
            catch (Exception exception)
            {
                dt.Clear();
                myDataTable.DataSource = dt;
                DialogueBox.AppendText(exception.ToString());
                DialogueBox.AppendText(Environment.NewLine);
            }
        }

        private async void machineStateDataLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dataloglistype = "mcstate";
            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
            DialogueBox.AppendText(Environment.NewLine);
            try
            {
                Splashscreen loadscreen = new Splashscreen();
                loadscreen.Show();
                dt.Clear();
                dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                MakeGridView(dt);
                DataGridColoring(theme);
                loadscreen.Close();
            }
            catch (Exception exception)
            {
                dt.Clear();
                myDataTable.DataSource = dt;
                DialogueBox.AppendText(exception.ToString());
                DialogueBox.AppendText(Environment.NewLine);
            }
        }

        private void MakeGridView(System.Data.DataTable DT)
        {
            if (DT != null)
            {

                switch (Dataloglistype)
                {
                    case "mcstate":
                        myDataTable.DataSource = DT;
                        // correct the order
                        myDataTable.Columns["ID"].DisplayIndex = 0;
                        myDataTable.Columns["Stime"].DisplayIndex= 1;
                        myDataTable.Columns["Event"].DisplayIndex = 2;
                        myDataTable.Columns["Value"].DisplayIndex = 3;
                        myDataTable.Columns["WorkCenterState"].DisplayIndex = 4;
                        myDataTable.Columns["Kiosk_State"].DisplayIndex = 5;
                        myDataTable.Columns["MTConnect_State"].DisplayIndex = 6;
                        myDataTable.Columns["ProductionOrder"].DisplayIndex = 7;
                        myDataTable.Columns["Material"].DisplayIndex = 8;
                        myDataTable.Columns["Kiosk_Op"].DisplayIndex = 9;
                        myDataTable.Columns["Kiosk_CN"].DisplayIndex = 10;
                        myDataTable.Columns["MT_pc1"].DisplayIndex = 11;
                        myDataTable.Columns["MTConnect_State_H2"].DisplayIndex = 12;
                        myDataTable.Columns["MT_pc2"].DisplayIndex = 13;
                        myDataTable.Columns["Override"].DisplayIndex = 14;
                        myDataTable.Columns["Comment"].DisplayIndex = 15;
                        break;
                    default: // full
                        myDataTable.DataSource = DT;
                        // correct the order
                        myDataTable.Columns["ID"].DisplayIndex = 0;
                        myDataTable.Columns["WorkCenter"].DisplayIndex = 1;
                        myDataTable.Columns["Machine"].DisplayIndex = 2;
                        myDataTable.Columns["Stime"].DisplayIndex= 3;
                        myDataTable.Columns["Event"].DisplayIndex = 4;
                        myDataTable.Columns["Value"].DisplayIndex = 5;
                        myDataTable.Columns["WorkCenterState"].DisplayIndex = 6;
                        myDataTable.Columns["ProductionOrder"].DisplayIndex = 7;
                        myDataTable.Columns["Material"].DisplayIndex = 8;
                        myDataTable.Columns["Kiosk_Op"].DisplayIndex = 9;
                        myDataTable.Columns["Kiosk_CN"].DisplayIndex = 10;
                        myDataTable.Columns["Operator"].DisplayIndex = 11;
                        myDataTable.Columns["ProdSupervisor"].DisplayIndex = 11;
                        myDataTable.Columns["Actual_Cycletime"].DisplayIndex = 13;
                        myDataTable.Columns["SAP_Info1"].DisplayIndex = 14;
                        myDataTable.Columns["Actual_Loadtime"].DisplayIndex = 15;
                        myDataTable.Columns["SAP_Info2"].DisplayIndex = 16;
                        myDataTable.Columns["Setuptime"].DisplayIndex = 17;
                        myDataTable.Columns["SAP_Setuptime"].DisplayIndex = 18;
                        myDataTable.Columns["SAP_Machine_Cycletime"].DisplayIndex = 19;
                        myDataTable.Columns["SAP_Base_Quantity"].DisplayIndex = 20;
                        myDataTable.Columns["Kiosk_State"].DisplayIndex = 21;
                        myDataTable.Columns["MTConnect_State"].DisplayIndex = 22;
                        myDataTable.Columns["MT_pc1"].DisplayIndex = 23;
                        myDataTable.Columns["MTConnect_State_H2"].DisplayIndex = 24;
                        myDataTable.Columns["MT_pc2"].DisplayIndex = 25;
                        myDataTable.Columns["SAP_Quantity"].DisplayIndex = 26;
                        myDataTable.Columns["MT_H1Rapid"].DisplayIndex = 27;
                        myDataTable.Columns["MT_H1Feed"].DisplayIndex = 28;
                        myDataTable.Columns["MT_H1Spindle"].DisplayIndex = 29;
                        myDataTable.Columns["MT_H2Rapid"].DisplayIndex = 30;
                        myDataTable.Columns["MT_H2Feed"].DisplayIndex = 31;
                        myDataTable.Columns["MT_H2Spindle"].DisplayIndex = 32;
                        myDataTable.Columns["Gantry"].DisplayIndex = 33;
                        myDataTable.Columns["Override"].DisplayIndex = 34;
                        myDataTable.Columns["DAY_OF_WEEK"].DisplayIndex = 35;
                        myDataTable.Columns["LinkAddress"].DisplayIndex = 36;
                        myDataTable.Columns["Comment"].DisplayIndex = 37;
                        break;
                }
            }
            //myDataTable.Visible = true;
        }

        private void DataGridColoring(string theme)
        {
            int overridecolumn = 0;
            int Statecolumn = 5;
            // find columns we care about
            foreach (DataGridViewColumn col in myDataTable.Columns)
            {
                if (col.Name == "Override")
                {
                    overridecolumn = col.Index;
                }
                if (col.Name == "WorkCenterState")
                {
                    Statecolumn = col.Index;
                }
            }
            // color the override
            if (theme == "" || theme == "default")
            {
                foreach (DataGridViewRow row in myDataTable.Rows)
                {
                    if (myDataTable.Rows[row.Index].Cells[overridecolumn].Value!= null)
                    {
                        //  DialogueBox.AppendText(DataTable.Rows[row.Index].Cells[col.Index].Value.ToString()); // debug
                        //  DialogueBox.AppendText(Environment.NewLine);
                        //  
                        if (myDataTable.Rows[row.Index].Cells[overridecolumn].Value.ToString().Contains("1"))
                        {
                            myDataTable.Rows[row.Index].Cells[overridecolumn].Style.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            myDataTable.Rows[row.Index].Cells[overridecolumn].Style.BackColor = System.Drawing.Color.LightBlue;
                        }
                    }
                }
                // color the rest  of the table
                foreach (DataGridViewRow row in myDataTable.Rows)
                {
                    if (myDataTable.Rows[row.Index].Cells[Statecolumn].Value!= null)
                    {

                        if (myDataTable.Rows[row.Index].Cells[Statecolumn].Value.ToString().Contains("Ready") ||
                            myDataTable.Rows[row.Index].Cells[Statecolumn].Value.ToString().Contains("Inspect") ||
                                myDataTable.Rows[row.Index].Cells[Statecolumn].Value.ToString().Contains("Setup"))
                        {
                            myDataTable.Rows[row.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                        }
                        else if (myDataTable.Rows[row.Index].Cells[Statecolumn].Value.ToString().Contains("Running"))
                        {
                            myDataTable.Rows[row.Index].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                        }
                        else if (myDataTable.Rows[row.Index].Cells[Statecolumn].Value.ToString().Contains("No Job or Operator")||
                                myDataTable.Rows[row.Index].Cells[Statecolumn].Value.ToString().Contains("Maintenance"))
                        {
                            myDataTable.Rows[row.Index].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }

                    }
                }

            }
            else if (theme == "light")
            {
                // uncolor the table
                foreach (DataGridViewRow row in myDataTable.Rows)
                {
                    myDataTable.Rows[row.Index].DefaultCellStyle.BackColor = System.Drawing.Color.White;

                    if (myDataTable.Rows[row.Index].Cells[overridecolumn].Value!= null)
                    {
                        myDataTable.Rows[row.Index].Cells[overridecolumn].Style.BackColor = System.Drawing.Color.White;
                    }

                }
            }

        }

        public static string theme = "default";

        private void ThemeMenu_DefaultThemeSelect_Click(object sender, EventArgs e)
        {
            theme = "default";

            RuntimeBackground.BackColor = System.Drawing.Color.FromArgb((int)(byte)(10), (int)(byte)(25), (int)(byte)(35));
            BarChart1.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            BarChart1.Legends["Legend1"].BorderColor = System.Drawing.Color.WhiteSmoke;
            BarChart1.Legends["Legend1"].BackColor = System.Drawing.Color.AntiqueWhite;
            PieChart1.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            PieChart1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            PieChart1.Legends["Legend1"].BackColor = System.Drawing.Color.AntiqueWhite;

            DialogueBox.BackColor = System.Drawing.Color.Black; 

            AboutText.BackColor = System.Drawing.Color.DarkSlateGray;
            AboutText.ForeColor = System.Drawing.Color.WhiteSmoke;

            myDataTable.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            myDataTable.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MintCream;
            myDataTable.DefaultCellStyle.BackColor = System.Drawing.Color.MintCream;
            // DataTable.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.LightCoral; // how to do alternating rows

            // DataTable.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.Red;
            ReportMenu.BackgroundImage = new Bitmap(Properties.Resources.blue_background2);

            MachineList.BackColor = System.Drawing.Color.DimGray;

            System.Drawing.Color txtcolor = System.Drawing.Color.WhiteSmoke;
            DialogueBox.ForeColor = txtcolor;

            //Color backcolor = System.Drawing.Color.Gray;

            HAAS2012L.ForeColor = txtcolor;
            HAAS2012M.ForeColor = txtcolor;
            HAAS2105.ForeColor = txtcolor;
            Doosan2107.ForeColor = txtcolor;
            mazak2111.ForeColor = txtcolor;
            mazak2112.ForeColor = txtcolor;
            mazak2260.ForeColor = txtcolor;
            DOOSAN2271.ForeColor = txtcolor;
            mazak2272.ForeColor = txtcolor;
            mazak2280.ForeColor = txtcolor;
            mazak2281.ForeColor = txtcolor;
            mazak2282.ForeColor = txtcolor;
            mazak2283.ForeColor = txtcolor;
            lAPMASTER2321.ForeColor = txtcolor;
            amada3111.ForeColor = txtcolor;
            amada3112.ForeColor = txtcolor;
            BDTRONIC3321.ForeColor = txtcolor;

            DataGridColoring(theme);
        }

        private void ThemeMenu_PrinterFriendlyThemeSelect_Click(object sender, EventArgs e)
        {
            theme = "light";

            RuntimeBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            BarChart1.BackColor = System.Drawing.Color.White;
            BarChart1.Legends["Legend1"].BorderColor = System.Drawing.Color.Black;
            BarChart1.Legends["Legend1"].BackColor = System.Drawing.Color.White;
            PieChart1.BackColor = System.Drawing.Color.White;
            PieChart1.ChartAreas[0].BackColor = System.Drawing.Color.White;
            PieChart1.Legends["Legend1"].BackColor = System.Drawing.Color.White;

            DialogueBox.BackColor = System.Drawing.Color.White;

            AboutText.BackColor = System.Drawing.Color.White;
            AboutText.ForeColor = System.Drawing.Color.Black;

            myDataTable.BackgroundColor = System.Drawing.Color.White;
            myDataTable.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            myDataTable.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            ReportMenu.BackgroundImage = null;

            MachineList.BackColor = System.Drawing.Color.WhiteSmoke;

            System.Drawing.Color txtcolor = System.Drawing.Color.Black;
            DialogueBox.ForeColor = txtcolor;

            // Color backcolor = System.Drawing.Color.WhiteSmoke;

            HAAS2012L.ForeColor = txtcolor;
            HAAS2012M.ForeColor = txtcolor;
            HAAS2105.ForeColor = txtcolor;
            Doosan2107.ForeColor = txtcolor;
            mazak2111.ForeColor = txtcolor;
            mazak2112.ForeColor = txtcolor;
            mazak2260.ForeColor = txtcolor;
            DOOSAN2271.ForeColor = txtcolor;
            mazak2272.ForeColor = txtcolor;
            mazak2280.ForeColor = txtcolor;
            mazak2281.ForeColor = txtcolor;
            mazak2282.ForeColor = txtcolor;
            mazak2283.ForeColor = txtcolor;
            lAPMASTER2321.ForeColor = txtcolor;
            amada3111.ForeColor = txtcolor;
            amada3112.ForeColor = txtcolor;
            BDTRONIC3321.ForeColor = txtcolor;

            DataGridColoring(theme);
        }


        private void ActiveRead_CheckedChanged(object sender, EventArgs e)
        {

            //Thread ReadThread = new Thread();

            if (ActiveRead.Checked)
            {
                Get_Data.Visible = false;

            }
            else
            {
                Get_Data.Visible = true;

            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (pagetype)
            {
                case "DataLog":
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DialogueBox.AppendText("File Exported;");
                            DialogueBox.AppendText(Environment.NewLine);
                            ExportToPdf(dt, pagenumber.ToString());
                        }
                        else
                        {
                            DialogueBox.AppendText("Export Failed: No data available;");
                            DialogueBox.AppendText(Environment.NewLine);
                        }
                    }
                    catch (Exception ex)
                    {
                        DialogueBox.AppendText("Export Failed: " + ex);
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    break;
            }
        }

        private static int i = 0;

        private void ExportToPdf(System.Data.DataTable Data, string Name)
        {
            i++;
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("C:/Users/hudis/Downloads/" + Name + "_" + i.ToString()+".pdf", FileMode.Create));
            document.Open();


            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(new Chunk("Work Station " + Name+ "\n", font));

            document.Add(p1);


            PdfPTable pdfTable = new PdfPTable(Data.Columns.Count)
            {
                WidthPercentage = 100

                // TotalWidth = Data.Columns.Count * 4
            };

            pdfTable.SetWidths(new float[] { 1f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f });

            // Add table headers
            for (int i = 0; i < Data.Columns.Count; i++)
            {

                PdfPCell cell = new PdfPCell(new Phrase(Data.Columns[i].ColumnName))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY

                };
                //pdfTable.D= cell.Colspan;

                pdfTable.AddCell(cell);
            }

            // Add table rows
            for (int row = 0; row < Data.Rows.Count; row++)
            {
                for (int column = 0; column < Data.Columns.Count; column++)
                {
                    pdfTable.AddCell(Data.Rows[row][column].ToString());
                }
            }

            document.Add(pdfTable);
            document.Close();

            MessageBox.Show("Data has been Exported.");
        }

        private void exportAsXcel_Click(object sender, EventArgs e)
        {

            switch (pagetype)
            {
                case "DataLog":
                    try
                    {
                        i++;
                        ExportToExcel(myDataTable, pagenumber.ToString() + "_" + i);
                        MessageBox.Show("Data has been Exported.");
                    }
                    catch (Exception ex)
                    {
                        DialogueBox.AppendText("Export Failed: " + ex);
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    break;
            }

        }

        private void ExportToExcel(System.Windows.Forms.DataGridView Data, string FileName)
        {
            object oMissing = System.Reflection.Missing.Value;

            Excel.Application excelApp = null;
           // Excel.Range range = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            int worksheetCount = 0;

            try
            {
                //create new instance
                excelApp = new Excel.Application
                {
                    //suppress displaying alerts (such as prompting to overwrite existing file)
                    DisplayAlerts = false,
                    //set Excel visability
                    Visible = false
                };
                //create new workbook
                workbook = excelApp.Workbooks.Add();    
                //get number of existing worksheets
                worksheetCount = workbook.Sheets.Count;
                //add a worksheet and set the value to the new worksheet
                worksheet = workbook.Sheets.Add();

                // table
                Excel.Range SourceRange = (Excel.Range)worksheet.Cells[1, 1];//(Excel.Range)worksheet.get_Range("A1", "X10"); // or whatever range you want here
                FormatAsTable(SourceRange, FileName, "TableStyleMedium5");

                // get headers
                for (int col = 0; col< myDataTable.Columns.Count; col++)
                {
                    string header = myDataTable.Columns[col].DataPropertyName;
                    if (header != null)
                    {
                        worksheet.Cells[1, col+1] = header;
                    }

                }

                // copy
                copyAlltoClipboard(); 
                
                // select 
                Excel.Range CR = (Excel.Range)worksheet.Cells[2, 1];
                CR.Select();
                // paste Data
                worksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                
                // save
                workbook.SaveAs(FileName, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);

            }
            catch (Exception ex)
            {
                string errMsg = "Error (WriteToExcel) - " + ex.Message;
                System.Diagnostics.Debug.WriteLine(errMsg);
                if (ex.Message.StartsWith("Cannot access read-only document"))
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message + "Please close the workbook, before trying again.", "Error - Unable To Write To Workbook", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                DialogueBox.AppendText("Export Failed: " + ex);
                DialogueBox.AppendText(Environment.NewLine);
            }
            finally
            {
                if (workbook != null)
                {
                    
                    //close workbook
                    workbook.Close();

                    //release all resources
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(workbook);
                }

                if (excelApp != null)
                {
                    //close Excel
                    excelApp.Quit();
                    DialogueBox.AppendText(pagenumber + ": Export Completed");
                    DialogueBox.AppendText(Environment.NewLine);
                    //release all resources
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
                }
            }
        }

        private void copyAlltoClipboard()
        {   
            myDataTable.SelectAll();
            DataObject dataObj = myDataTable.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }
            myDataTable.ClearSelection();
        }

        public void FormatAsTable(Excel.Range SourceRange, string TableName, string TableStyleName)
        {
            SourceRange.Worksheet.ListObjects.Add(XlListObjectSourceType.xlSrcRange,
            SourceRange, System.Type.Missing, XlYesNoGuess.xlYes, System.Type.Missing).Name =
                TableName;
            SourceRange.Select();
            SourceRange.Worksheet.ListObjects[TableName].TableStyle = TableStyleName;
        }

        private void BarChart1_Click(object sender, EventArgs e)
        {

        }
        
        private void ZoomIn_Click(object sender, EventArgs e)
        {
            Runtime.zoomfactor++;
            if (Runtime.zoomfactor > 10)
            {
                Runtime.zoomfactor = 10;
            }
            BarChart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            BarChart1.ChartAreas[0].CursorX.AutoScroll = true;
            //BarChart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
          //  BarChart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, zoomfactor);
            BarChart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
            BarChart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            BarChart1.ChartAreas[0].AxisX.ScaleView.Zoom(Runtime.min, Runtime.max-Runtime.zoomfactor);
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            Runtime.zoomfactor--;
            if (Runtime.zoomfactor <1)
            {
                BarChart1.ChartAreas[0].AxisX.ScaleView.Zoom(Runtime.min,Runtime.max);

                Runtime.zoomfactor = 1;
                BarChart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
            }
            else
            {
                BarChart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                BarChart1.ChartAreas[0].CursorX.AutoScroll = true;
              //  BarChart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
              //  BarChart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, zoomfactor);
            }
            BarChart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
            BarChart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            BarChart1.ChartAreas[0].AxisX.ScaleView.Zoom(Runtime.min, Runtime.max-Runtime.zoomfactor);
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
                    BarChart1.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).ToOADate();
                    BarChart1.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddDays(1).ToOADate();
                    RuntimeScrollbar.Visible = false;
                    break;
                case 2:
                    RuntimeScrollbar.Visible = true;
                    BarChart1.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).ToOADate();
                    BarChart1.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(12).ToOADate();
                    break;
                case 3:
                    RuntimeScrollbar.Visible = true;
                    BarChart1.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).ToOADate();
                    BarChart1.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(6).ToOADate();
                    break;
                case 4:
                    RuntimeScrollbar.Visible = true;
                    BarChart1.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).ToOADate();
                    BarChart1.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(3).ToOADate();
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
                    BarChart1.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(RuntimeScrollbar.Value).ToOADate();
                    BarChart1.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(RuntimeScrollbar.Value + 12).ToOADate();
                    break;
                case 3:
                    RuntimeScrollbar.Visible = true;
                    RuntimeScrollbar.Maximum = 18;
                    BarChart1.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(RuntimeScrollbar.Value).ToOADate();
                    BarChart1.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(RuntimeScrollbar.Value + 6).ToOADate();
                    break;
                case 4:
                    RuntimeScrollbar.Visible = true;
                    RuntimeScrollbar.Maximum = 24;
                    BarChart1.ChartAreas[0].AxisY.Minimum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(RuntimeScrollbar.Value).ToOADate();
                    BarChart1.ChartAreas[0].AxisY.Maximum = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day).AddHours(RuntimeScrollbar.Value + 3).ToOADate();
                    break;
            }
        }

        private void PieChart1_Click(object sender, EventArgs e)
        {

        }
    }
}