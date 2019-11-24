using System;

namespace IC.Client.Network
{
    /// <summary>
    /// Implements work with Assembly
    /// 
    /// 2017/04/27 - Created, VTyagunov
    /// </summary>
    public sealed class AssemblyWorker
    {
        /// <summary>AssemblyWorker instance</summary>
        private static volatile AssemblyWorker _instance;
        /// <summary>Object for locks</summary>
        private static object _syncRoot = new Object();

        /// <summary>Client Version</summary>
        public Version Version { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        private AssemblyWorker() { }

        /// <summary>AssemblyWorker instance</summary>
        public static AssemblyWorker Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new AssemblyWorker();
                    }
                }

                return _instance;
            }
        }
    }
}