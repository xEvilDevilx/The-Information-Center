using System;
using System.Windows.Forms;

using IC.Client.BusinessLogic;
using IC.Client.BusinessLogic.Interfaces;
using IC.Client.FormModel;
using IC.Client.FormModel.Interfaces;
using IC.Client.Network.Interfaces;
using IC.SDK;

namespace IC.Client.Network
{
    /// <summary>
    /// Presents Client Main Entry
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public class MainEntry : IMainEntry
    {
        #region Variables
        
        /// <summary>Unique Client License Key</summary>
        internal static string _uniqueClientLicenseKey = "6CC0A14F07402B77516D5118000000B001873E1D0CCD950B1FA6C14A800B116B3F1279A5490043002000530079007300740065006D007300F422A222000000DCFEF3FE7F000000D8000C010C000000006C008600800DC010C010000C";

        #endregion
        
        #region Properties

        /// <summary>Presents work with UDP</summary>
        public INetworkService UdpService { get; set; }
        /// <summary>Presents work with TCP</summary>
        public INetworkService TcpService { get; private set; }
        /// <summary>Presents work with plugins</summary>
        public IPluginManager ControlsPlugin { get; private set; }
        /// <summary>UDP notification transfer</summary>
        public INetworkNotification UdpNotification { get; set; }
        /// <summary>TCP notification transfer</summary>
        public INetworkNotification TcpNotification { get; set; }
        /// <summary>Presents TCP License Verify work</summary>
        public INetworkNotification TcpLicenseVerify { get; set; }
        /// <summary>Presents work with data requests</summary>
        public INetworkRequests Requests { get; private set; }
        /// <summary>Work with all UDP and TCP data</summary>
        public INetworkTransfer Transfer { get; private set; }
        /// <summary>Presents Business Logic Entry</summary>
        public IBusinessLogicEntry Logic { get; private set; }
        /// <summary>Flag to show connection status</summary>
        public bool IsConnected { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controls">Control collection</param>
        public MainEntry(Control.ControlCollection controls)
        {
            Logger.Log.Debug("MainEntry. Ctr. Enter");

            if (controls == null)
                throw new ArgumentNullException("controls");

            ControlsPlugin = new PluginManager(controls);            
            
            Logger.Log.Debug("MainEntry. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for Run app Engine
        /// </summary>
        public void Run()
        {
            Logger.Log.Debug("Run. Enter");

            try
            {
                //var timer = new SimpleTimer();
                //timer.Start(1, () =>
                //{
                    if (ControlsPlugin.IsPluginLoaded)
                    {
                        Logic = new BusinessLogicEntry(this.ControlsPlugin);
                        UdpService = new UDPClientService(this);
                        TcpService = new TCPClientService(this);
                        Requests = new NetworkRequests(this);
                        Transfer = new NetworkTransfer(this);

                        UdpService.Start(null);
                        //timer.Stop();
                    }
                //});
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Run.", ex);
            }

            Logger.Log.Debug("Run. Exit");
        }

        /// <summary>
        /// Use for full stop client work
        /// </summary>
        public void FullStop()
        {
            Logger.Log.Debug("FullStop. Enter");
            
            try
            {
                UdpService.Stop();
                TcpService.Stop();                
                IsConnected = false;
                UdpNotification.StopSend();
                TcpNotification.StopSend();
                TcpLicenseVerify.StopSend();
                KillProcess();                
            }
            catch (Exception ex)
            {
                Logger.Log.Error("FullStop.", ex);
            }

            Logger.Log.Debug("FullStop. Exit");

            Application.Exit();
        }

        /// <summary>
        /// Use for kill client process
        /// </summary>
        private void KillProcess()
        {
            Logger.Log.Debug("KillProcess. Enter");

            using (var currentProcess = System.Diagnostics.Process.GetCurrentProcess())
            {
                currentProcess.Kill();
            }

            Logger.Log.Debug("KillProcess. Exit");
        }

        #endregion
    }
}