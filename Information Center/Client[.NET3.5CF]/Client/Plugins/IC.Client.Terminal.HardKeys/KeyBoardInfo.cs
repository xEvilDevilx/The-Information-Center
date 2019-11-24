namespace IC.Client.Plugins.Terminal.HardKeys
{
    /// <summary>
    /// Presents Key Board Info
    /// 
    /// 2017/08/11 - Created, VTyagunov
    /// </summary>
    public class KeyBoardInfo
    {
        /// <summary>VK Code</summary>
        public int vkCode { get; set; }
        /// <summary>Scan Code</summary>
        public int scanCode { get; set; }
        /// <summary>Flags</summary>
        public int flags { get; set; }
        /// <summary>Time</summary>
        public int time { get; set; }
    }
}