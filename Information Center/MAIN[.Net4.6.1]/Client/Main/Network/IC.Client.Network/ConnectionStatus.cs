using System;

namespace IC.Client.Network
{
    /// <summary>
    /// Store Connection Status
    /// 
    /// 2017/04/27 - Created, VTyagunov
    /// </summary>
    public sealed class ConnectionStatus
    {
        /// <summary>ConnectionStatus instance</summary>
        private static volatile ConnectionStatus _instance;
        /// <summary>Object for locks</summary>
        private static object _syncRoot = new Object();

        /// <summary>Flag show connected/disconnected client status</summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        private ConnectionStatus() { }

        /// <summary>ConnectionStatus instance</summary>
        public static ConnectionStatus Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new ConnectionStatus();
                    }
                }

                return _instance;
            }
        }
    }
}