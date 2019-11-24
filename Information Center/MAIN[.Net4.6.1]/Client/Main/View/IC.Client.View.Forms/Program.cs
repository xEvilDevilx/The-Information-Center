using System;
using System.Windows.Forms;

using IC.SDK;

namespace IC.Client.View.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.InitLogger();
            Logger.Log.Info("++++++++++++++ Information Center Client starting! ++++++++++++++");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}