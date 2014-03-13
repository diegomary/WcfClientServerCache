using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WCFServiceHost
{
    static class Program
    {
        public static Server starter;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            starter = new Server();
            Application.Run(starter);
        }
    }
}