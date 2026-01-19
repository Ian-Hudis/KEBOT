using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2019.Presentation;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KEBOT
{
    public class SQL_Client
    {
        public SQL_Client() 
        {
             
            
        }
        
        private static List<DataRow> BackfillRows = new List<DataRow>(); // for dealing with the timeout.
        private static bool backfillTrig = false; 

        private static string WorkCenterState = "";

        private static string previoustime;

        private string FindWorkCenterState(string wcstate, string MTC_H1, string MTC_H2, string KioskState, string Event, string time)
        {
            if (time != previoustime /*&& !WorkCenterState.Contains("Timeout")*/)
            {
                switch (Event)
                {
                    case string a when a.Contains("ready"):
                        if (MTC_H1.Contains("RUNNING") || MTC_H2.Contains("RUNNING") || Event.Contains("RUNNING"))
                        {
                            wcstate = "Running";
                        }
                        else if (MTC_H1.Contains("FEEDHOLD") || MTC_H2.Contains("FEEDHOLD")|| Event.Contains("FEEDHOLD"))
                        {
                            wcstate = "Feedhold";
                        }
                        else
                        {
                            wcstate = "Ready";
                        }
                        break;
                    case string a when a.Contains("inspect"):
                        wcstate = "Inspect";
                        break;
                    case string a when a.Contains("setup"):
                        wcstate = "Setup";
                        break;
                    case string a when a.Contains("nojob"):
                        wcstate = "No Job or Operator";
                        break;
                    case string a when a.Contains("unschedm"): // unscheduled maintanence
                        wcstate = "Unscheduled Maintenance";
                        break;
                    case string a when a.Contains("schedm"):  // scheduled maintanence
                        wcstate = "Scheduled Maintenance";
                        break;
                    case string a when a.Contains("timeout"): // timeout
                        wcstate = KioskState.Trim(' ') + " Timeout";
                        break;
                    default:
                        switch (KioskState)
                        {
                            case string a when a.Contains("ready"):
                                if (MTC_H1.Contains("RUNNING") || MTC_H2.Contains("RUNNING") || Event.Contains("RUNNING"))
                                {
                                    wcstate = "Running";
                                }
                                else if (MTC_H1.Contains("FEEDHOLD") || MTC_H2.Contains("FEEDHOLD")|| Event.Contains("FEEDHOLD"))
                                {
                                    wcstate = "Feedhold";
                                }
                                else
                                {
                                    wcstate = "Ready";
                                }
                                break;
                            case string a when a.Contains("inspect"):
                                wcstate = "Inspect";
                                break;
                            case string a when a.Contains("setup"):
                                wcstate = "Setup";
                                break;
                            case string a when a.Contains("nojob"):
                                wcstate = "No Job or Operator";
                                break;
                            case string a when a.Contains("unschedm"): // unscheduled maintanence
                                wcstate = "Unscheduled Maintenance";
                                break;
                            case string a when a.Contains("schedm"):  // scheduled maintanence
                                wcstate = "Scheduled Maintenance";
                                break;
                            case string a when a.Contains("timeout"):
                                wcstate = KioskState.Trim(' ') + " backfill";
                                break;
                        }
                        break;
                }
            }
            return wcstate;
        }

        // read data for datatable
        public async Task<DataTable> SQL_Import_Datatable(string Querytype, string MachineBrand, string machine, DateTime StartDate, DateTime EndDate)
        {
            StartDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0);
            EndDate = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59);

            DataTable DT = new DataTable(MachineBrand+machine);

            if(Querytype == "full" || Querytype == "")
            {
                DT.Columns.Add("ID", typeof(BigInteger)); // 0
                DT.Columns.Add("WorkCenter", typeof(string)); //1
                DT.Columns.Add("Machine", typeof(string)); //2
                DT.Columns.Add("Stime", typeof(string));//typeof(DateTime)); // 3
                DT.Columns.Add("Event", typeof(string)); //  4
                DT.Columns.Add("Value", typeof(int));    // 5

                DT.Columns.Add("WorkCenterState", typeof(string)); //6 // used for the actual state of the work center at any given time

                DT.Columns.Add("ProductionOrder", typeof(string)); // 7
                DT.Columns.Add("Material", typeof(string)); // 8
                DT.Columns.Add("Kiosk_Op", typeof(string));  // 9
                DT.Columns.Add("Kiosk_CN", typeof(string)); // 10
                DT.Columns.Add("Operator", typeof(string)); // 11
                DT.Columns.Add("ProdSupervisor", typeof(string)); // 12

                DT.Columns.Add("Actual_Cycletime", typeof(TimeSpan));  // 13
                DT.Columns.Add("SAP_Info1", typeof(TimeSpan));  // 14
                DT.Columns.Add("Actual_Loadtime", typeof(TimeSpan));   // 15
                DT.Columns.Add("SAP_Info2", typeof(TimeSpan)); // 16

                DT.Columns.Add("Setuptime", typeof(TimeSpan)); // 17
                DT.Columns.Add("SAP_Setuptime", typeof(TimeSpan));  // 18
                DT.Columns.Add("SAP_Machine_Cycletime", typeof(TimeSpan)); // 19
                DT.Columns.Add("SAP_Base_Quantity", typeof(int));  // 20

                DT.Columns.Add("Kiosk_State", typeof(string));  // 21
                DT.Columns.Add("MTConnect_State", typeof(string)); // 22
                DT.Columns.Add("MT_pc1", typeof(int)); // 23
                DT.Columns.Add("MTConnect_State_H2", typeof(string)); // 24 
                DT.Columns.Add("MT_pc2", typeof(int)); // 25
                DT.Columns.Add("SAP_Quantity", typeof(int));  // 26 

                DT.Columns.Add("MT_H1Rapid", typeof(int)); // 27
                DT.Columns.Add("MT_H1Feed", typeof(int)); // 28
                DT.Columns.Add("MT_H1Spindle", typeof(int)); // 29 
                DT.Columns.Add("MT_H2Rapid", typeof(int)); // 30
                DT.Columns.Add("MT_H2Feed", typeof(int));  // 31
                DT.Columns.Add("MT_H2Spindle", typeof(int)); // 32
                DT.Columns.Add("Gantry", typeof(int));  // 33
                DT.Columns.Add("Override", typeof(int)); // 34
                DT.Columns.Add("DAY_OF_WEEK", typeof(string));  // 35

                DT.Columns.Add("LinkAddress", typeof(string)); // 36
                DT.Columns.Add("Operator_Comment", typeof(string)); // 37
                DT.Columns.Add("Comment", typeof (string)); // 38

                var cs = @"Server=SQL_ServerNAME;Database=ProductionMonitor; User ID=SQL_ID;Password=SQL_Password";
                var con = new SqlConnection(cs);
                //con.Open();
                await con.OpenAsync();

                string sql = "SELECT [ID], [WorkCenter], [Machine],  [ServerTime], [Event], [Value], " + // 0 - 5  (6 is wcstate)
                            " [ProductionOrder], [Material], [Kiosk_Op], [Kiosk_CN], [Operator], [ProdSupervisor], " + // 7 - 11
                            " [Actual_Cycletime], [SAP_Cycletime], [Actual_Loadtime], [SAP_Loadtime], " + // 12 - 16
                            " [Kiosk_Setuptime], [SAP_Setuptime], [SAP_Machine_Cycletime], [SAP_Base_Quantity]," + // 17 - 20
                            " [Kiosk_State], [MT_state], [MT_pc1], [MT_State2], [MT_pc2], [SAP_Quantity]," + // 21 - 26
                            " [MT_H1Rapid], [MT_H1Feed], [MT_H1Spindle], [MT_H2Rapid], [MT_H2Feed], [MT_H2Spindle], [MT_Gantry], [Kiosk_Override], [DAY_OF_WEEK]," +  // 27 - 35
                            "  [LinkAddress]"+ // 36
                            " FROM [ProductionMonitor].[dbo].[" + MachineBrand + machine + "_ProdMonitor] where ServerTime" +
                            " between '" + StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY [ID];";
                var cmd = new SqlCommand(sql, con);

                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                
                while (await rdr.ReadAsync())
                {
                    DataRow row = DT.NewRow();
                    // 0 - 5
                    row["ID"] = rdr.GetInt64(0);
                    row["WorkCenter"] = rdr.GetString(1);
                    row["Machine"] = rdr.GetString(2);
                    row["Stime"] = rdr.GetDateTime(3).ToString();
                    row["Event"] =  rdr.GetString(4);
                    row["Value"] = rdr.GetInt32(5);
                    // 7 - 11
                    row["ProductionOrder"] = rdr.GetString(6);
                    row["Material"] = rdr.GetString(7);
                    row["Kiosk_Op"] = rdr.GetString(8);
                    row["Kiosk_CN"] = rdr.GetString(9);
                    row["Operator"] = rdr.GetString(10);
                    row["ProdSupervisor"] = rdr.GetString(11);
                    // 12 - 16
                    row["Actual_Cycletime"] = TimeSpan.FromSeconds(rdr.GetInt64(12));
                    row["SAP_Info1"] = TimeSpan.FromSeconds(rdr.GetInt64(13));
                    row["Actual_Loadtime"] = TimeSpan.FromSeconds(rdr.GetInt64(14));
                    row["SAP_Info2"] = TimeSpan.FromSeconds(rdr.GetInt64(15));
                    // 17 - 20
                    row["Setuptime"] = TimeSpan.FromSeconds(rdr.GetInt64(16));
                    row["SAP_Setuptime"] = TimeSpan.FromSeconds(rdr.GetInt64(17));
                    row["SAP_Machine_Cycletime"] = TimeSpan.FromSeconds(rdr.GetInt64(18));
                    row["SAP_Base_Quantity"] = rdr.GetInt32(19);
                    // 21 - 26
                    row["Kiosk_State"] = rdr.GetString(20);
                    row["MTConnect_State"] = rdr.GetString(21);
                    row["MT_pc1"] = rdr.GetInt32(22);
                    row["MTConnect_State_H2"] = rdr.GetString(23);
                    row["MT_pc2"] = rdr.GetInt32(24);
                    row["SAP_Quantity"] = rdr.GetInt32(25);
                    // 27 - 35
                    row["MT_H1Rapid"] = rdr.GetInt16(26);
                    row["MT_H1Feed"] = rdr.GetInt16(27);
                    row["MT_H1Spindle"] = rdr.GetInt16(28);
                    row["MT_H2Rapid"] = rdr.GetInt16(29);
                    row["MT_H2Feed"] = rdr.GetInt16(30);
                    row["MT_H2Spindle"] = rdr.GetInt16(31);
                    row["Gantry"] = rdr.GetInt16(32);
                    row["Override"] = rdr.GetBoolean(33);
                    row["DAY_OF_WEEK"] = rdr.GetString(34);
                        
                    // comment content
                    string linkaddress;
                    try
                    {
                        linkaddress = rdr.GetString(35);
                    }
                    catch
                    {
                        linkaddress = "";
                    }
                    row["LinkAddress"] = linkaddress;
                    SelectedComment comment_info = await ReadComment(linkaddress, cs);//Task.Run(async () => await ReadComment(linkaddress, cs)).Result;
                    row["Operator_Comment"] = comment_info.Operator_Comment;
                    row["Comment"] = comment_info.comment;
                    /*
                    if (linkaddress == null || linkaddress == "NULL" || linkaddress == "")
                    {
                        row["LinkAddress"] = "";
                        row["Comment"] = "";
                    }
                    else
                    {
                        var con2 = new SqlConnection(cs);
                        con2.Open();
                        string Commentsearch = "SELECT [ID], [LinkAddress], [WorkCenter], [ServerTimeCommented],[Writer], [Comment]" +
                          "FROM[ProductionMonitor].[dbo].[ProdMonitor_Comments]" +
                          "Where LinkAddress = '"+ row["LinkAddress"] + "';";
                        var cmd2 = new SqlCommand(Commentsearch, con2);
                        SqlDataReader rdr2 = cmd2.ExecuteReader();
                        while (rdr2.Read())
                        {
                            row["Comment"] = rdr2.GetString(5);
                        }
                        rdr2.Close();
                        con2.Close();

                    }
                    */
                    // get the actual work center state
                    WorkCenterState = FindWorkCenterState(WorkCenterState, rdr.GetString(21), rdr.GetString(23), rdr.GetString(20), rdr.GetString(4), rdr.GetDateTime(3).ToString());
                    previoustime = rdr.GetDateTime(3).ToString();

                    row["WorkCenterState"] = WorkCenterState;

                    if (WorkCenterState!=null) 
                    { 
                        if (WorkCenterState.Contains("Timeout")|| WorkCenterState.Contains("backfill"))
                        {
                            //  the timeout rows into a list
                            BackfillRows.Add(row);

                            backfillTrig = true;

                        }
                        else if (backfillTrig == true) //  WorkCenterState will be nojob/noop, sched maint, or unscheduled maintanence.
                        {
                            // export the list with the timeout replaced with the later event
                            foreach (DataRow timeoutrow in BackfillRows)
                            {
                                timeoutrow["WorkCenterState"] = WorkCenterState; // change the timeout to the current event
                                //DT.ImportRow(timeoutrow);
                                DT.Rows.Add(timeoutrow);
                            }
                            BackfillRows.Clear();

                            DT.Rows.Add(row);
                            backfillTrig = false;
                        }
                        else
                        {
                            DT.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DT.Rows.Add(row);
                    }
                } // while loop

                if(BackfillRows.Count > 0) // backfill list is not empty
                {
                    foreach (DataRow timeoutrow in BackfillRows)
                    {
                        //timeoutrow["WorkCenterState"] = WorkCenterState; // change the timeout to the current event
                        DT.Rows.Add(timeoutrow);
                    }
                    BackfillRows.Clear();
                }
                
                rdr.Close();
            }
            else if(Querytype == "mcstate")
            {
                DT.Columns.Add("ID", typeof(BigInteger)); // 0

                //DT.Columns.Add("WorkCenter", typeof(string)); 
                DT.Columns.Add("Stime", typeof(string));
                DT.Columns.Add("Event", typeof(string)); 
                DT.Columns.Add("Value", typeof(int));

                DT.Columns.Add("WorkCenterState", typeof(string)); // used for the actual state of the work center at any given time

                DT.Columns.Add("Kiosk_State", typeof(string));
                DT.Columns.Add("MTConnect_State", typeof(string));
                DT.Columns.Add("MT_pc1", typeof(int));
                DT.Columns.Add("MTConnect_State_H2", typeof(string));
                DT.Columns.Add("MT_pc2", typeof(int));
 
                DT.Columns.Add("ProductionOrder", typeof(string)); 
                DT.Columns.Add("Material", typeof(string)); 
                DT.Columns.Add("Kiosk_Op", typeof(string));  
                DT.Columns.Add("Kiosk_CN", typeof(string));
                DT.Columns.Add("Override", typeof(int));

                DT.Columns.Add("Operator_Comment", typeof(string)); // 37
                DT.Columns.Add("Comment", typeof(string));

                var cs = @"SQL_ServerNAME;Database=ProductionMonitor; User ID=SQL_ID;Password=SQL_Password";
                var con = new SqlConnection(cs);
                //con.Open();
                await con.OpenAsync();

                string sql = "SELECT [ID], [WorkCenter],  [Event], [Value], [ServerTime]," + // 0 - 6
                            "[Kiosk_State], [MT_state], [MT_pc1],  [MT_State2], [MT_pc2],[Kiosk_Override]," + // 7 - 10
                            " [Kiosk_Op], [Kiosk_CN], [Material], [ProductionOrder], [LinkAddress]" +
                            " FROM [ProductionMonitor].[dbo].[" + MachineBrand + machine + "_ProdMonitor] where ServerTime" +
                            " between '" + StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "' ORDER BY [ID];";
                var cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();

                while (await rdr.ReadAsync())
                {
                    DataRow row = DT.NewRow();

                    row["ID"] = rdr.GetInt64(0);
                    //row["WorkCenter"] = rdr.GetString(1);
                    row["Event"] =  rdr.GetString(2);
                    row["Value"] = rdr.GetInt32(3);
                    row["Stime"] = rdr.GetDateTime(4).ToString();
                    row["Kiosk_State"] = rdr.GetString(5);
                    row["MTConnect_State"] = rdr.GetString(6);
                    row["MT_pc1"] = rdr.GetInt32(7);
                    row["MTConnect_State_H2"] = rdr.GetString(8);
                    row["MT_pc2"] = rdr.GetInt32(9);
                    row["Override"] = rdr.GetBoolean(10);
                    row["Kiosk_Op"] = rdr.GetString(11);
                    row["Kiosk_CN"] = rdr.GetString(12);
                    row["Material"] = rdr.GetString(13);
                    row["ProductionOrder"] = rdr.GetString(14);
                    string linkaddress;
                    // comment content
                    try
                    {
                        linkaddress = rdr.GetString(15);
                    }
                    catch
                    {
                        linkaddress = "";
                    }
                    
                    SelectedComment comment_info = await ReadComment(linkaddress, cs);//Task.Run(async () => await ReadComment(linkaddress, cs)).Result;
                    row["Operator_Comment"] = comment_info.Operator_Comment;
                    row["Comment"] = comment_info.comment;
                    //row["Comment"] = Task.Run(async () => await ReadComment(LinkAddress, cs)).Result;

                    // get the actual work center state
                    WorkCenterState =  FindWorkCenterState(WorkCenterState, row["MTConnect_State"].ToString(), row["MTConnect_State_H2"].ToString(), row["Kiosk_State"].ToString(),
                        row["Event"].ToString(), row["Stime"].ToString());
                    //previoustime = rdr.GetDateTime(3).ToString();

                    row["WorkCenterState"] = WorkCenterState;

                    if (WorkCenterState!=null)
                    {
                        if (WorkCenterState.Contains("Timeout")|| WorkCenterState.Contains("backfill"))
                        {
                            //  the timeout rows into a list
                            BackfillRows.Add(row);

                            backfillTrig = true;

                        }
                        else if (backfillTrig == true) //  WorkCenterState will be nojob/noop, sched maint, or unscheduled maintanence.
                        {
                            // export the list with the timeout replaced with the later event
                            foreach (DataRow timeoutrow in BackfillRows)
                            {
                                timeoutrow["WorkCenterState"] = WorkCenterState; // change the timeout to the current event

                               // DT.ImportRow(timeoutrow);
                                DT.Rows.Add(timeoutrow);
                            }
                            BackfillRows.Clear();

                            DT.Rows.Add(row);
                           // backfillTrig = false;
                        }
                        else
                        {
                            DT.Rows.Add(row);
                        }
                    }
                    else
                    {
                        DT.Rows.Add(row);
                    }
                } // while loop

                if (BackfillRows.Count > 0) // backfill list is not empty
                {
                    foreach (DataRow timeoutrow in BackfillRows)
                    {
                        //timeoutrow["WorkCenterState"] = WorkCenterState; // change the timeout to the current event
                        DT.ImportRow(timeoutrow);
                        //DT.Rows.Add(timeoutrow);
                    }
                    BackfillRows.Clear();
                }
                rdr.Close();
            }

            //WorkCenterState = ""; // reset the state
           // backfillTrig = false; // reset the backfill trigger
            //BackfillRows.Clear(); // reset the backfill list
            return DT;
        }

        private async Task<SelectedComment> ReadComment(string LinkAddress, string cs)
        {
            SelectedComment commentpackage = new SelectedComment();

            if (LinkAddress == null || LinkAddress == "NULL" || LinkAddress =="")
            {
                commentpackage.comment = "";
            }
            else
            {
                var con2 = new SqlConnection(cs);
                await con2.OpenAsync();
                string Commentsearch = "SELECT [ID], [LinkAddress], [WorkCenter], [ServerTimeCommented],[Writer],[Operator_Comment], [Comment]" +
                  "FROM[ProductionMonitor].[dbo].[ProdMonitor_Comments]" +
                  "Where LinkAddress = '"+ LinkAddress + "';";
                var cmd2 = new SqlCommand(Commentsearch, con2);
                SqlDataReader rdr2 = await cmd2.ExecuteReaderAsync();
                while (await rdr2.ReadAsync())
                {
                    try
                    {
                        commentpackage.Operator_Comment = rdr2.GetString(5);
                    }
                    catch
                    {
                        commentpackage.Operator_Comment = "";
                    }
                    try
                    {
                        commentpackage.comment =  rdr2.GetString(6);
                    }
                    catch
                    {
                        commentpackage.comment = "";
                    }
                }
                rdr2.Close();
                con2.Close();
            }
            return commentpackage;
        }

        // give the machine table a link address
        public void SQL_UpdateMachineTable(string LinkAddress, string MachineBrand, string machine, Int64 id)
        {
            var cs = @"Server=SQL_ServerNAME;Database=ProductionMonitor; User ID=SQL_ID;Password=SQL_Password";
            var con = new SqlConnection(cs);
            try
            {
                con.Open();

                var query = "UPDATE [ProductionMonitor].[dbo].[" + MachineBrand + machine + "_ProdMonitor]" +
                    "SET LinkAddress = @linkaddress WHERE ID = @id";

                var cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@linkaddress", SqlDbType.NVarChar, 64)).Value = LinkAddress;
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.BigInt)).Value = id;

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        // insert a row into the comment table
        public void SQL_InsertAComment(string LinkAddress, string WorkCenter, string writer, string comment)
        {

            var cs = @"Server=SQL_ServerNAME;Database=ProductionMonitor; User ID=SQL_ID;Password=SQL_Password";
            var con = new SqlConnection(cs);
            try
            {
                con.Open();

                var query = "INSERT INTO [ProductionMonitor].[dbo].[ProdMonitor_Comments]" +
                    "(LinkAddress, WorkCenter, ServerTimeCommented, Writer, Comment)" +
                    "VALUES(@linkaddress, @workcenter, @servertimecommented, @writer, @comment)";

                var cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@linkaddress", SqlDbType.NVarChar, 64)).Value = LinkAddress;
                cmd.Parameters.Add(new SqlParameter("@workcenter", SqlDbType.Char, 5)).Value = WorkCenter;
                cmd.Parameters.Add("@servertimecommented", SqlDbType.DateTime).Value = DateTime.Now;

                cmd.Parameters.Add(new SqlParameter("@writer", SqlDbType.NVarChar, 64)).Value = writer;
                cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.NVarChar, 512)).Value = comment;

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

        }
        // update a row in the comment table
        public void SQL_UpdateACommment(string LinkAddress, string WorkCenter, string Writer, string Comment)
        {
            var cs = @"Server=SQL_ServerNAME;Database=ProductionMonitor; User ID=SQL_ID;Password=SQL_Password";
            var con = new SqlConnection(cs);
            try
            {
                con.Open();

                
                var query = "UPDATE [ProductionMonitor].[dbo].[ProdMonitor_Comments]" +
                    "SET ServerTimeCommented = @servertimecommented, WorkCenter = @workcenter, Writer = @writer, Comment = @comment " +
                    "WHERE LinkAddress = @linkaddress";

                var cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("@linkaddress", SqlDbType.NVarChar, 64)).Value = LinkAddress;
                cmd.Parameters.Add("@servertimecommented", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@workcenter", SqlDbType.Char, 5)).Value = WorkCenter;
                cmd.Parameters.Add(new SqlParameter("@writer", SqlDbType.NVarChar, 64)).Value = Writer;
                cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.NVarChar, 512)).Value = Comment;

                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public struct SelectedComment
        {
            public string Link { get; set; }
            public string workcenter {  get; set; }
            public string writer { get; set; }
            public string Commenttime { get; set; }
            public string Operator_Comment {  get; set; } // made by the operator on the plc
            public string comment { get; set; }
        } 
        public SelectedComment CommentRust { get; set; }
       
        public SelectedComment GetCommentEntry(string workcenter,string ID)
        {
            string LinkAddress = workcenter + "_" + ID; // make the link address

            SelectedComment selectedComment = new SelectedComment();

            var cs = @"Server=SQL_ServerNAME;Database=ProductionMonitor; User ID=SQL_ID;Password=SQL_Password";
            var con = new SqlConnection(cs);
            try
            {
                con.Open();

                string sql = "SELECT [ID], [LinkAddress], [WorkCenter], [ServerTimeCommented],[Writer],[Operator_Comment], [Comment]" +
                          "FROM[ProductionMonitor].[dbo].[ProdMonitor_Comments]" +
                          "Where LinkAddress = '"+ LinkAddress + "';";
                var cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    selectedComment.Link = rdr.GetString(1);
                    selectedComment.workcenter = rdr.GetString(2);
                    selectedComment.Commenttime = rdr.GetDateTime(3).ToString();
                    selectedComment.writer = rdr.GetString(4);
                    selectedComment.Operator_Comment = rdr.GetString(5);
                    selectedComment.comment = rdr.GetString(6);
                }
            }
            finally
            {
                con.Close();
            }

            return selectedComment;
        }

    }
}

