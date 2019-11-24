namespace IC.Client.Network.Interfaces
{
    /// <summary>
    /// Presents Notification transfer
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    public interface INetworkNotification
    {        
        /// <summary>
        /// Use for start send notification
        /// </summary>
        /// <param name="sendTimePeriod">Time period to send notification</param>
        void StartSend(int sendTimePeriod);

        /// <summary>
        /// Use for stop send notification
        /// </summary>
        void StopSend();
    }
}