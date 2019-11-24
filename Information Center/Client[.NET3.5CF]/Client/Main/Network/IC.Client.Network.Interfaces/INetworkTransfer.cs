namespace IC.Client.Network.Interfaces
{
    /// <summary>
    /// Presents Network Transfer interface
    /// 
    /// 2017/03/06 - Created, VTyagunov
    /// </summary>
    public interface INetworkTransfer
    {
        /// <summary>Store default language</summary>
        string DefaultLanguage { get; set; }
        /// <summary>Store default currency</summary>
        string DefaultCurrency { get; set; }
        /// <summary>Store current language</summary>
        string CurrentLanguage { get; set; }
        /// <summary>Store current currency</summary>
        string CurrentCurrency { get; set; }
        /// <summary>Flag to show the Localized/Not Localized status</summary>
        bool IsLocalized { get; }
        /// <summary>Flag to show the Logo Setted/Not Setted status</summary>
        bool IsLogoSetted { get; }

        /// <summary>
        /// Use for work with received UDP packet
        /// </summary>
        /// <param name="bytesArray">UDP packet bytes array</param>
        void UDPProcess(byte[] bytesArray);

        /// <summary>
        /// Use for work with received TCP packet
        /// </summary>
        /// <param name="obj">TCP packet object</param>
        void TCPProcess(object obj);

        /// <summary>
        /// Use for start thread with UDP Notification
        /// </summary>
        void StartUDPNotifyThread();

        /// <summary>
        /// Use for start thread with TCP Notification
        /// </summary>
        void StartTCPNotifyThread();

        /// <summary>
        /// Use for start thread with TCP License Verifing
        /// </summary>
        void StartTCPLicenseVerifyThread();
    }
}