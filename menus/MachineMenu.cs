using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEBOT
{
    public partial class KEBOT
    {
        private void WCMenureset()
        {
            Color color;
            Color fontcolor;
            color = Color.Transparent;
            if (theme == "default"|| theme == "")
            {
                MachineList.BackColor = Color.DimGray;
                fontcolor = Color.White;
            }
            else
            {
                
                MachineList.BackColor = Color.White;

                fontcolor = Color.Black;
            }
            
            HAAS2012L.BackColor = color;
            HAAS2012M.BackColor = color;
            HAAS2105.BackColor = color;
            Doosan2107.BackColor = color;
            mazak2111.BackColor = color;
            mazak2112.BackColor = color;
            mazak2260.BackColor = color;
            DOOSAN2271.BackColor = color;
            mazak2272.BackColor = color;
            mazak2280.BackColor = color;
            mazak2281.BackColor = color;
            mazak2282.BackColor = color;
            mazak2283.BackColor = color;
            lAPMASTER2321.BackColor = color;
            amada3111.BackColor = color;
            amada3112.BackColor = color;
            BDTRONIC3321.BackColor = color;
            
            HAAS2012L.ForeColor = fontcolor;
            HAAS2012M.ForeColor = fontcolor;
            HAAS2105.ForeColor = fontcolor;
            Doosan2107.ForeColor = fontcolor;
            mazak2111.ForeColor = fontcolor;
            mazak2112.ForeColor = fontcolor;
            mazak2260.ForeColor = fontcolor;
            DOOSAN2271.ForeColor = fontcolor;
            mazak2272.ForeColor = fontcolor;
            mazak2280.ForeColor = fontcolor;
            mazak2281.ForeColor = fontcolor;
            mazak2282.ForeColor = fontcolor;
            mazak2283.ForeColor = fontcolor;
            lAPMASTER2321.ForeColor = fontcolor;
            amada3111.ForeColor = fontcolor;
            amada3112.ForeColor = fontcolor;
            BDTRONIC3321.ForeColor = fontcolor;

        }


        // work center 
        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)// home button
        {
            pagenumber = 0;
            brand = "";
            WCMenureset();
            PageLoad();
        }

        private void HAAS2012L_Click_1(object sender, EventArgs e)
        {
            pagenumber = 2102;
            brand = "HAAS_";
            WCMenureset();
            PageLoad();
        }

        private void HAAS2012M_Click_1(object sender, EventArgs e)
        {
            pagenumber = 2103;
            brand = "HAAS_";
            WCMenureset();
            PageLoad();
        }

        private void hAAS2105ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pagenumber = 2105;
            brand = "HAAS_";
            WCMenureset();
            PageLoad();
        }

        private void dOOSAN2107ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pagenumber = 2107;
            brand = "Doosan";
            WCMenureset();
            PageLoad();
        }

        private void mazak2111_Click(object sender, EventArgs e)
        {
            pagenumber = 2111;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void mazak2112_Click(object sender, EventArgs e)
        {
            pagenumber = 2112;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void mazak2260_Click(object sender, EventArgs e)
        {
            pagenumber = 2260;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void DOOSAN2271_Click(object sender, EventArgs e)
        {
            pagenumber = 2271;
            brand = "Doosan";
            WCMenureset();
            PageLoad();
        }

        private void mazak2272_Click(object sender, EventArgs e)
        {
            pagenumber = 2272;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void mazak2280_Click(object sender, EventArgs e)
        {
            pagenumber = 2280;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void mazak2281_Click(object sender, EventArgs e)
        {
            pagenumber = 2281;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void mazak2282_Click(object sender, EventArgs e)
        {
            pagenumber = 2282;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void mazak2283_Click(object sender, EventArgs e)
        {
            pagenumber = 2283;
            brand = "Mazak";
            WCMenureset();
            PageLoad();
        }

        private void lAPMASTER2321_Click(object sender, EventArgs e)
        {
            pagenumber = 2321;
            brand = "LapMast";
            WCMenureset();
            PageLoad();
        }

        private void amada3111_Click(object sender, EventArgs e)
        {
            pagenumber = 3111;
            brand = "Amada";
            WCMenureset();
            PageLoad();
        }

        private void amada3112_Click(object sender, EventArgs e)
        {
            pagenumber = 3112;
            brand = "Amada";
            WCMenureset();
            PageLoad();
        }

        private void BDTRONIC3321_Click(object sender, EventArgs e)
        {
            pagenumber = 3321;
            brand = "BDTRON";
            WCMenureset();
            PageLoad();
        }
    }
}

