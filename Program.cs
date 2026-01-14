using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEBOT
{
    internal static class Program
    {
        //public const string version = "0.0.1.2 ";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       // public static KEBOT kebot = new KEBOT();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KEBOT());
        }

    }
}
