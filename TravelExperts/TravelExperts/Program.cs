using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());

            //Application.Run(new frmMain());// Runs the main program
            //Application.Run(new frmAgents());// Runs the Agent form
            //Application.Run(new frmProduct());// Runs the Product form
        }
    }
}
