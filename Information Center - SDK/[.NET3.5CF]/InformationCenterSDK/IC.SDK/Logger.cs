using System.IO;

using log4net;
using log4net.Config;

using IC.SDK.Helpers;

namespace IC.SDK
{
    /// <summary>
    /// Implements static class for log4net using
    /// 
    /// 2017/08/31 - Created, VTyagunov
    /// </summary>
    public static class Logger
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(typeof(Logger));

        /// <summary>
        /// Get logger object
        /// </summary>
        public static ILog Log
        {
            get { return log; }
        }

        /// <summary>
        /// Using for initialization of Logger
        /// </summary>
        public static void InitLogger()
        {
            var path = string.Format("{0}\\Config.xml", Utils.GetCurrentDirectory());
            if(!string.IsNullOrEmpty(path))
            {
                if(File.Exists(path))
                    XmlConfigurator.Configure(new FileInfo(path));
            }
        }
    }
}