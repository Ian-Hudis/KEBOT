using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEBOT
{
    public partial class Search : Form
    {

        public Search()
        {
            InitializeComponent();
        }

        private void search(object sender, EventArgs e)
        {
            
        }

        private void FindPrevious_Click(object sender, EventArgs e)
        {

        }

        private void FindNext_Click(object sender, EventArgs e)
        {
            string text = searchtext.Text;

            var frm = (KEBOT)this.Owner;
            if (frm != null) {
                //frm.Get_Data_Click().PerformClick();
            }
           // Program.kebot.datalogform.myDataTable.SelectAll();
           // Program.kebot.datalogform.myDataTable.Rows[0].DefaultCellStyle.BackColor = System.Drawing.Color.White;
        

            //datalogform.myDataTable
        }

        private void CapOption_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void searchtext_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
