using StoreManagementSystem.Forms;
using StoreMS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardForm());
      
            //try
            //{
            //    Application.Run(new LoignForm());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error on Startup: " + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }

}
