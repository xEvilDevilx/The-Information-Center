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
        internal static string _uniqueClientLicenseKey = "018FFA5DD9472B7739E0F3A1000000043CEA7765C953B20B5914084D939659C266362FA65400650073007400200043006C00690065006E00740020004E0061006D006500018F6993000000B0FE6BFE3300000040FF3BFF1F0000000060006200000C400C000E8011";

        #endregion

        #region Properies

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