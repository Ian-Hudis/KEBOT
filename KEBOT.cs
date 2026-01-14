using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using KEBOT.Cycletime;
using KEBOT.DataLog;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static KEBOT.Runtime;
using Excel = Microsoft.Office.Interop.Excel;

namespace KEBOT
{
    public partial class KEBOT : Form
    {
        public static SQL_Client sql_Client = new SQL_Client();
        //public static string Datrowcontext = "";
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

        public static bool RuntimeChartGenerated = true;
        public static bool DataGridGenerated = true;

        //! report Forms
        public About aboutform = new About()
        {
            TopLevel = false,
            TopMost= true
        };

        public dataLogger datalogform = new dataLogger()
        {
            TopLevel = false,
            TopMost= true
        };

        public RuntimeDisplay runtimeform = new RuntimeDisplay()
        {
            TopLevel = false,
            TopMost= true
        };
        
        public Cycleform cycletimeform = new Cycleform()
        {
            TopLevel = false,
            TopMost= true
        };
        
        //! report Forms

        public KEBOT()
        {
            InitializeComponent();
            
            //about form setup
            aboutform.FormBorderStyle = FormBorderStyle.None;
            paneldisplay.Controls.Add(aboutform);
            aboutform.Dock = DockStyle.Fill;

            // datalog form setup
            datalogform.FormBorderStyle = FormBorderStyle.None;
            paneldisplay.Controls.Add(datalogform);
            datalogform.Dock = DockStyle.Fill;

            // runtime form setup
            runtimeform.FormBorderStyle = FormBorderStyle.None;
            paneldisplay.Controls.Add(runtimeform);
            runtimeform.Dock = DockStyle.Fill;

            // cycletime form setup
            cycletimeform.FormBorderStyle = FormBorderStyle.None;
            paneldisplay.Controls.Add(cycletimeform);
            cycletimeform.Dock = DockStyle.Fill;

            pagetype = "";
            PageLoad();
            datalogform.DataGridColoring(theme);
        }

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
                    aboutform.Show();
                    datalogform.Hide();
                    runtimeform.Hide();
                    cycletimeform.Hide();

                    try
                    {
                        aboutform.ReadData("/Data/General/UpdateLog.txt");
                    }
                    catch (Exception exception)
                    {
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    break;
                case "About":
                    aboutform.Show();
                    datalogform.Hide();
                    runtimeform.Hide();
                    cycletimeform.Hide();

                    aboutToolStripMenuItem.BackColor = ViewColor;

                    try
                    {
                        aboutform.ReadData("/Data/" + pagenumber + "/about.txt");
                    }
                    catch (Exception exception)
                    {
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    break;
                case "DataLog":
                    aboutform.Hide();
                    datalogform.Show();
                    runtimeform.Hide();
                    cycletimeform.Hide();

                    dataToolStripMenuItem.BackColor = ViewColor;

                    if (Dataloglistype == "full")
                    {
                        fullDataLogToolStripMenuItem.BackColor = ViewColor;
                        machineStateDataLogToolStripMenuItem.BackColor= System.Drawing.Color.Transparent;
                    }
                    else
                    {
                        fullDataLogToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
                        machineStateDataLogToolStripMenuItem.BackColor= ViewColor;
                    }

                    try
                    {
                        if (dt == null || pagenumber != prev_pagenumber || prev_starttime != dateTimePicker1.Value || prev_endtime != dateTimePicker2.Value || prev_dataloglisttype != Dataloglistype)
                        {
                            Splashscreen loadscreen = new Splashscreen();
                            if (!ActiveRead.Checked)
                            {
                                loadscreen.Show();
                            }
                            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
                            DialogueBox.AppendText(Environment.NewLine);
                            //dt.Clear();
                            dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                            runtimeform.GetData(dateTimePicker1.Value.Date); // for getting time values for interior widgets
                            DataGridGenerated = false;
                            RuntimeChartGenerated = false;
                            loadscreen.Close();


                            if (!DataGridGenerated)
                            {
                                datalogform.DataImport(Dataloglistype, dt, theme, pagetype, pagenumber, sql_Client);
                                DataGridGenerated = true;

                            }

                        }
                    }
                    catch (Exception exception)
                    {
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }

                    break;
                case "Comment":
                    aboutform.Hide();
                    datalogform.Show();
                    runtimeform.Hide();
                    cycletimeform.Hide();

                    datalogform.updatedatalogger(pagetype);

                    addComment.BackColor = ViewColor;

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
                            runtimeform.GetData(dateTimePicker1.Value.Date); // for getting time values for interior widgets
                            DataGridGenerated = false;
                            RuntimeChartGenerated = false;
                            loadscreen.Close();
                        }


                        if (!DataGridGenerated)
                        {
                            datalogform.DataImport(Dataloglistype, dt, theme, pagetype, pagenumber, sql_Client);
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
                    aboutform.Hide();
                    datalogform.Hide();
                    runtimeform.Show();
                    cycletimeform.Hide();

                    runtimeToolStripMenuItem.BackColor = ViewColor;

                    Splashscreen Runtimeloadscreen = new Splashscreen();
                    Runtimeloadscreen.Show();

                    try
                    {
                        if (dt == null || pagenumber != prev_pagenumber || prev_starttime != dateTimePicker1.Value || prev_endtime != dateTimePicker2.Value)
                        {
                            DialogueBox.AppendText(brand+pagenumber + ": Query from " + dateTimePicker1.Value.ToString() + " to " + dateTimePicker2.Value.ToString());
                            DialogueBox.AppendText(Environment.NewLine);
                            //dt.Clear();
                            dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                            datalogform.DataImport(Dataloglistype, dt, theme, pagetype, pagenumber, sql_Client);
                            RuntimeChartGenerated = false;
                        }
                        if (!RuntimeChartGenerated)
                        {
                            runtimeform.BarChart11.Titles.Clear();
                            runtimeform.BarChart11.Titles.Add("Runtime Timeline");
                            runtimeform.BarChart11.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                            runtimeform.BarChart11.Series.Clear();

                            runtimeform.GetData(dateTimePicker1.Value.Date); // for getting time values for interior widgets
                            runtimeform.runtime.MakeRuntimeGraph(runtimeform.BarChart11, dt, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                            RuntimeChartGenerated = true;
                            for (int row = 0; row< runtimeform.runtime.BarSequance.Count; row++)
                            {
                                DialogueBox.AppendText(runtimeform.runtime.BarSequance[row].ID + "  " + runtimeform.runtime.BarSequance[row].State + "  " +
                                    runtimeform.runtime.BarSequance[row].Starttime + "  " + runtimeform.runtime.BarSequance[row].Endtime + "  " +
                                    runtimeform.runtime.BarSequance[row].color.ToString() + "  " + runtimeform.runtime.BarSequance[row].Carryover + ";"); // debug
                                DialogueBox.AppendText(Environment.NewLine); // debug
                            }
                        }
                        // put values into the pie graph
                        runtimeform.MakePieChart(runtimeform.runtime.BarSequance);

                    }
                    catch (Exception exception)
                    {
                        runtimeform.BarChart11.Series.Clear();
                        runtimeform.BarChart11.Titles.Clear();
                        DialogueBox.AppendText(exception.ToString());
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    finally
                    {
                        Runtimeloadscreen.Close();
                    }
                    break;
                case "CycletimeAnalysis":

                    aboutform.Hide();
                    datalogform.Hide();
                    runtimeform.Hide();
                    cycletimeform.Show();

                    cycleTimeAnalysis.BackColor = ViewColor;

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
                            runtimeform.GetData(dateTimePicker1.Value.Date); // for getting time values for interior widgets
                            DataGridGenerated = false;
                            RuntimeChartGenerated = false;
                            loadscreen.Close();
                        }

                        if (!DataGridGenerated)
                        {
                            datalogform.DataImport(Dataloglistype, dt, theme, pagetype, pagenumber, sql_Client);
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

                    List<string> materiallist = dt.AsEnumerable().Select(row => row.Field<string>("Material")).Distinct().ToList();
                    cycletimeform.MaterialList.DataSource = materiallist;
                    cycletimeform.InputTable = dt; // send data from the main program to the Cycletime page


                    break;
                default: // "" 

                    break;
            }

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

                if (pagetype == "DataLog" || pagetype == "Comment" || pagetype == "Runtime")
                {
                    dt = await sql_Client.SQL_Import_Datatable(Dataloglistype, brand, pagenumber.ToString(), dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                    datalogform.DataImport(Dataloglistype, dt, theme, pagetype, pagenumber, sql_Client);

                    runtimeform.BarChart11.Titles.Clear();
                    runtimeform.BarChart11.Titles.Add("Runtime Timeline");
                    runtimeform.BarChart11.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                    runtimeform.BarChart11.Series.Clear();

                    runtimeform.GetData(dateTimePicker1.Value.Date); // for getting time values for interior widgets
                    runtimeform.runtime.MakeRuntimeGraph(runtimeform.BarChart11, dt, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);

                    // put values into the pie graph
                    runtimeform.MakePieChart(runtimeform.runtime.BarSequance);
                }
                if (pagetype == "Runtime")
                {
                    for (int row = 0; row<  runtimeform.runtime.BarSequance.Count; row++)
                    {
                        DialogueBox.AppendText(runtimeform.runtime.BarSequance[row].ID + "  " +  runtimeform.runtime.BarSequance[row].State + "  " + 
                            runtimeform.runtime.BarSequance[row].Starttime + "  " + runtimeform.runtime.BarSequance[row].Endtime + "  " +
                            runtimeform.runtime.BarSequance[row].color.ToString() + "  " + runtimeform.runtime.BarSequance[row].Carryover + ";"); // debug
                        DialogueBox.AppendText(Environment.NewLine); // debug
                    }
                }

                loadscreen.Close();
            }
            catch (Exception exception)
            {
                dt.Clear();
                //myDataTable.DataSource = dt;
                DialogueBox.AppendText(exception.ToString());
                DialogueBox.AppendText(Environment.NewLine);
            }
        }

        public static string theme = "default";

        private void ThemeMenu_DefaultThemeSelect_Click(object sender, EventArgs e)
        {
            theme = "default";

            //RuntimeBackground.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            runtimeform.BarChart11.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            runtimeform.BarChart11.Legends["Legend1"].BorderColor = System.Drawing.Color.WhiteSmoke;
            runtimeform.BarChart11.Legends["Legend1"].BackColor = System.Drawing.Color.AntiqueWhite;
            runtimeform.PieChart1.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            runtimeform.PieChart1.ChartAreas[0].BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            runtimeform.PieChart1.Legends["Legend1"].BackColor = System.Drawing.Color.AntiqueWhite;
            runtimeform.RuntChartContainer.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            runtimeform.RuntimeContainter2.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            runtimeform.RuntimeBackground.BackColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));

            DialogueBox.BackColor = System.Drawing.Color.Black;

            aboutform.AboutText.BackColor =  System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190)); 
            aboutform.AboutText.ForeColor = System.Drawing.Color.White;

            datalogform.myDataTable.BackgroundColor = System.Drawing.Color.FromArgb((int)(byte)(155), (int)(byte)(180), (int)(byte)(190));
            datalogform.myDataTable.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.MintCream;
            datalogform.myDataTable.BackColor  = System.Drawing.Color.MintCream;
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

            datalogform.DataGridColoring(theme);
        }

        private void ThemeMenu_PrinterFriendlyThemeSelect_Click(object sender, EventArgs e)
        {
            theme = "light";

            //RuntimeBackground.BackColor = System.Drawing.Color.WhiteSmoke;
            runtimeform.BarChart11.BackColor = System.Drawing.Color.White;
            runtimeform.BarChart11.Legends["Legend1"].BorderColor = System.Drawing.Color.Black;
            runtimeform.BarChart11.Legends["Legend1"].BackColor = System.Drawing.Color.White;
            runtimeform.PieChart1.BackColor = System.Drawing.Color.White;
            runtimeform.PieChart1.ChartAreas[0].BackColor = System.Drawing.Color.White;
            runtimeform.PieChart1.Legends["Legend1"].BackColor = System.Drawing.Color.White;
            runtimeform.RuntChartContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            runtimeform.RuntimeContainter2.BackColor = System.Drawing.Color.White;
            runtimeform.RuntimeBackground.BackColor = System.Drawing.Color.White;

            DialogueBox.BackColor = System.Drawing.Color.White;

            aboutform.AboutText.BackColor = System.Drawing.Color.White;
            aboutform.AboutText.ForeColor = System.Drawing.Color.Black;

            datalogform.myDataTable.BackgroundColor = System.Drawing.Color.White;
            datalogform.myDataTable.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            datalogform.myDataTable.BackColor = System.Drawing.Color.LightGray;

            ReportMenu.BackgroundImage = null;

            MachineList.BackColor = System.Drawing.Color.WhiteSmoke;

            System.Drawing.Color txtcolor = System.Drawing.Color.Black;
            DialogueBox.ForeColor = txtcolor;

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

            datalogform.DataGridColoring(theme);
        }

        private void ActiveRead_CheckedChanged(object sender, EventArgs e)
        {
            Thread backgroundThread = new Thread(new ThreadStart(DoWork));
            if (ActiveRead.Checked)
            {
                Get_Data.Visible = false;
                backgroundThread.Start();
            }
            else
            {
                Get_Data.Visible = true;
                backgroundThread.Abort();
            }
        }

        private void DoWork()
        {
            // This code runs on the new background thread
            while (ActiveRead.Checked)
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        dateTimePicker2.Value = DateTime.Now.AddDays(1);

                        PageLoad();    
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    ActiveRead.Checked = false;
                    System.Windows.Forms.Application.Exit();
                }

                Thread.Sleep(5000);
            }
        }

        /*
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
        */
        private static int i = 0;
        /*
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
        */
        private void exportAsXcel_Click(object sender, EventArgs e)
        {

            switch (pagetype)
            {
                case "DataLog":
                    try
                    {
                        i++;
                        datalogform.ExportToExcel(datalogform.myDataTable, pagenumber.ToString() + "_" + i);
                        MessageBox.Show("Data has been Exported.");
                    }
                    catch (Exception ex)
                    {
                        DialogueBox.AppendText("Export Failed: " + ex);
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    finally
                    {
                        DialogueBox.AppendText(pagenumber + ": Export Completed");
                        DialogueBox.AppendText(Environment.NewLine);
                    }
                    break;
            }

        }

        private async void fullDataLogToolStripMenuItem_Click_1(object sender, EventArgs e)
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
                datalogform.DataImport(Dataloglistype, dt, theme, pagetype, pagenumber, sql_Client);
                runtimeform.GetData(dateTimePicker1.Value.Date); // for getting time values for interior widgets
                loadscreen.Close();
            }
            catch (Exception exception)
            {
                dt.Clear();
                DialogueBox.AppendText(exception.ToString());
                DialogueBox.AppendText(Environment.NewLine);
            }
        }

        private async void machineStateDataLogToolStripMenuItem_Click_1(object sender, EventArgs e)
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
                datalogform.DataImport(Dataloglistype, dt, theme, pagetype, pagenumber, sql_Client);
                runtimeform.GetData(dateTimePicker1.Value.Date); // for getting time values for interior widgets
                loadscreen.Close();
            }
            catch (Exception exception)
            {
                dt.Clear();
                DialogueBox.AppendText(exception.ToString());
                DialogueBox.AppendText(Environment.NewLine);
            }
        }

        private void Rversion_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search form = new Search();
            form.Show();
        }

        private void Searcher(object sender, EventArgs e)
        {
            Search frm = new Search();
            frm.Show();
        }

    }
}