using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using IC.SDK;

namespace IC.Client.View.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Logger.InitLogger();
            Logger.Log.Info("++++++++++++++ Information Center Client starting! ++++++++++++++");

            Application.Run(new MainForm());
        }
    }
}