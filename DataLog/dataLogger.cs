using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Bibliography;

namespace KEBOT.DataLog
{
    public partial class dataLogger : Form
    {
        public static SQL_Client sql_Client;
        public static System.Data.DataTable DataTable { get; set; }
        public static string pagetype = "";
        public static int pagenumber = 0;

        public dataLogger()
        {
            InitializeComponent();
        }
        public void DataImport(string Dataloglistype, System.Data.DataTable datatable, string theme, string Pagetype, int PageNumber, SQL_Client SQL_Client)
        {
            sql_Client = SQL_Client;
            pagetype = Pagetype;
            pagenumber = PageNumber;
            DataTable = datatable;

            MakeGridView(datatable, Dataloglistype);
            myDataTable.DataSource = datatable;


            if (myDataTable.Rows.Count > 0)
            {
                myDataTable.FirstDisplayedScrollingRowIndex = myDataTable.Rows.Count - 1;
            }

            // coloring for the data grid.
            DataGridColoring(theme);
        }

        public void updatedatalogger(string Pagetype) // for going from data log to add comment
        {
            pagetype = Pagetype;
        }

        private void MakeGridView(System.Data.DataTable DT, string Dataloglistype)
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
                       // myDataTable.Columns["Operator_Comment"].DisplayIndex = 15;
                        myDataTable.Columns["Comment"].DisplayIndex = 16;
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
                        myDataTable.Columns["ProdSupervisor"].DisplayIndex = 12;
                        myDataTable.Columns["Actual_Cycletime"].DisplayIndex = 13;
                        myDataTable.Columns["Actual_MachCycle"].DisplayIndex = 14;
                        myDataTable.Columns["SAP_Info1"].DisplayIndex = 15;
                        myDataTable.Columns["Actual_Loadtime"].DisplayIndex = 16;
                        myDataTable.Columns["SAP_Info2"].DisplayIndex = 17;
                        myDataTable.Columns["Setuptime"].DisplayIndex = 18;
                        myDataTable.Columns["SAP_Setuptime"].DisplayIndex = 19;
                        myDataTable.Columns["SAP_Machine_Cycletime"].DisplayIndex = 20;
                        myDataTable.Columns["SAP_Base_Quantity"].DisplayIndex = 21;
                        myDataTable.Columns["Kiosk_State"].DisplayIndex = 22;
                        myDataTable.Columns["MTConnect_State"].DisplayIndex = 23;
                        myDataTable.Columns["MT_pc1"].DisplayIndex = 24;
                        myDataTable.Columns["MTConnect_State_H2"].DisplayIndex = 25;
                        myDataTable.Columns["MT_pc2"].DisplayIndex = 26;
                        myDataTable.Columns["SAP_Quantity"].DisplayIndex = 27;
                        myDataTable.Columns["MT_H1Rapid"].DisplayIndex = 28;
                        myDataTable.Columns["MT_H1Feed"].DisplayIndex = 29;
                        myDataTable.Columns["MT_H1Spindle"].DisplayIndex = 30;
                        myDataTable.Columns["MT_H2Rapid"].DisplayIndex = 31;
                        myDataTable.Columns["MT_H2Feed"].DisplayIndex = 32;
                        myDataTable.Columns["MT_H2Spindle"].DisplayIndex = 33;
                        myDataTable.Columns["Gantry"].DisplayIndex = 34;
                        myDataTable.Columns["Override"].DisplayIndex = 35;
                        myDataTable.Columns["DAY_OF_WEEK"].DisplayIndex = 36;
                        myDataTable.Columns["LinkAddress"].DisplayIndex = 37; 
                        myDataTable.Columns["Operator_Comment"].DisplayIndex = 38;
                        myDataTable.Columns["Comment"].DisplayIndex = 39;
                        break;
                }
            }
        }

        public void DataGridColoring(string theme)
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


        public void ExportToExcel(System.Windows.Forms.DataGridView Data, string FileName)
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


        public static Int64 rownumber;
        public static string Datrowcontext = "";

        private void myDataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pagetype == "Comment")
            {
                rownumber = Int64.Parse(DataTable.Rows[e.RowIndex][0].ToString());
                Datrowcontext = DataTable.Rows[e.RowIndex][0].ToString() + ": " + DataTable.Rows[e.RowIndex].Field<string>("Event").ToString().Trim(' ') + ": " + DataTable.Rows[e.RowIndex].Field<string>("Stime").ToString();

                sql_Client.CommentRust = sql_Client.GetCommentEntry(pagenumber.ToString(), rownumber.ToString()); // grab comment data if any

                CommentEnter form = new CommentEnter();
                form.Show();
            }
            
        }

    }
}
