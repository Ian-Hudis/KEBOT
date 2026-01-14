using KEBOT.DataLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KEBOT.SQL_Client;

namespace KEBOT
{
    public partial class CommentEnter : Form
    {
        public static bool commentAlreadyExists = false;

        public CommentEnter()
        {
            InitializeComponent();

            RowtextBox.Text = dataLogger.Datrowcontext; // displays the row being commented.
            Author.Text = Writer; // saves the user time so they do not have to re enter their name.
            
            if(KEBOT.sql_Client.CommentRust.comment != "" && KEBOT.sql_Client.CommentRust.comment != null) // if a comment already exists have it show up
            {
                CommentBox.Text = KEBOT.sql_Client.CommentRust.comment;
                commentAlreadyExists = true;
            }
            else
            {
                commentAlreadyExists = false;
            }

        }

        public static bool CommentAdded = false;
        public static string Writer = "";
        public string Comment = "";

        // added name
        private void Author_TextChanged(object sender, EventArgs e)
        {
            Writer = Author.Text; // stores the author name
        }

        private void CommentBox_TextChanged(object sender, EventArgs e)
        {
            Comment = CommentBox.Text;
        }

        // put the comment out into sql
        private void ConfirmCommentButton_Click(object sender, EventArgs e)
        {
            if (CommentBox.Text != "") // dont allow for empty comments
            {
                Int64 ID = dataLogger.rownumber;
                string LocationNumber = KEBOT.pagenumber.ToString();
                string Brand = KEBOT.brand;
                string LinkAddress = LocationNumber +"_"+ ID.ToString();

                if (commentAlreadyExists)
                {
                    KEBOT.sql_Client.SQL_UpdateACommment(LinkAddress, LocationNumber, Writer, Comment); // update the comment in the comment table
                }
                else
                {
                    KEBOT.sql_Client.SQL_InsertAComment(LinkAddress, LocationNumber, Writer, Comment); // put a new entry in the comment table
                } 
                KEBOT.sql_Client.SQL_UpdateMachineTable(LinkAddress, Brand, LocationNumber, ID); // update the machine table with the link address
                CommentAdded = true;

                Dispose();
            }
        }

        // exit window
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
