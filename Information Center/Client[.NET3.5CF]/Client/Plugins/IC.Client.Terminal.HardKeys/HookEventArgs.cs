using System;

namespace IC.Client.Plugins.Terminal.HardKeys
{
    /// <summary>
    /// Presents Hook Event Args
    /// 
    /// 2017/08/11 - Created, VTyagunov
    /// </summary>
    public class HookEventArgs : EventArgs
    {
        /// <summary>Hook code</summary>
        public int Code { get; set; }
        /// <summary>WPARAM argument</summary>
        public IntPtr wParam { get; set; }
        /// <summary>LPARAM argument</summary>
        public IntPtr lParam { get; set; }
    }
}