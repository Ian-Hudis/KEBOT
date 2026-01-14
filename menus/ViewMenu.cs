using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEBOT
{
    public partial class KEBOT
    {
        private void ReportSelectreset()
        {
            System.Drawing.Color color;
            System.Drawing.Color fontcolor;
            color =  System.Drawing.Color.Transparent;
            if (theme == "default"|| theme == "")
            {
                MachineList.BackColor =  System.Drawing.Color.DimGray;
                fontcolor =  System.Drawing.Color.Black;
            }
            else
            {

                MachineList.BackColor =  System.Drawing.Color.White;

                fontcolor = System.Drawing.Color.Black;
            }

            aboutToolStripMenuItem.BackColor = color;
            dataToolStripMenuItem.BackColor = color;
            addComment.BackColor = color;
            runtimeToolStripMenuItem.BackColor = color;
            cycleTimeAnalysis.BackColor = color;

            aboutToolStripMenuItem.ForeColor = fontcolor;
            dataToolStripMenuItem.ForeColor = fontcolor;
            addComment.ForeColor = fontcolor;
            runtimeToolStripMenuItem.ForeColor = fontcolor;
            cycleTimeAnalysis.ForeColor = fontcolor;

        }

        private void ViewTypeStripMenuItem_Click(object sender, EventArgs e)
        {
            pagetype = "";
            ReportSelectreset();
            PageLoad();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pagetype = "About";
            ReportSelectreset();
            PageLoad();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pagetype = "DataLog";
            ReportSelectreset();
            PageLoad();
        }

        private void addComment_Click(object sender, EventArgs e)
        {
            pagetype = "Comment";
            ReportSelectreset();
            PageLoad();
        }

        private void runtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pagetype = "Runtime";
            ReportSelectreset();
            PageLoad();
        }

        private void cycleTimeAnalysis_Click(object sender, EventArgs e)
        {
            pagetype = "CycletimeAnalysis";
            ReportSelectreset();
            PageLoad();
        }

    }
}
