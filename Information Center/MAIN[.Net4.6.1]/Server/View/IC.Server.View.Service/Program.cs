using System.ServiceProcess;

using IC.SDK;

namespace IC.Server.View.Service
{
    static class Program
    {
        /// <summary>
        /// Main Entry
        /// </summary>
        static void Main()
        {
            Logger.InitLogger();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServerService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}