using IC.Client.FormModel.Interfaces;
using IC.Client.BusinessLogic.Interfaces;

namespace IC.Client.Network.Interfaces
{
    /// <summary>
    /// Presents Client Main Entry interface
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public interface IMainEntry
    {
        /// <summary>Presents work with UDP</summary>
        INetworkService UdpService { get; set; }
        /// <summary>Presents work with TCP</summary>
        INetworkService TcpService { get; }
        /// <summary>Presents work with plugins</summary>
        IPluginManager ControlsPlugin { get; }
        /// <summary>UDP notification transfer</summary>
        INetworkNotification UdpNotification { get; set; }
        /// <summary>TCP notification transfer</summary>
        INetworkNotification TcpNotification { get; set; }
        /// <summary>Presents TCP License Verify work</summary>
        INetworkNotification TcpLicenseVerify { get; set; }
        /// <summary>Presents work with data requests</summary>
        INetworkRequests Requests { get; }
        /// <summary>Work with all UDP and TCP data</summary>
        INetworkTransfer Transfer { get; }
        /// <summary>Presents Business Logic Entry</summary>
        IBusinessLogicEntry Logic { get; }
        /// <summary>Flag to show connection status</summary>
        bool IsConnected { get; set; }

        /// <summary>
        /// Use for Run app Engine
        /// </summary>
        void Run();

        /// <summary>
        /// Use for full stop client work
        /// </summary>
        void FullStop();
    }
}