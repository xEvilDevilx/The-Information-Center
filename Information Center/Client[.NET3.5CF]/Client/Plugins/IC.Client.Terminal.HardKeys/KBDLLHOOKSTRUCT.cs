using System;
using System.Runtime.InteropServices;

namespace IC.Client.Plugins.Terminal.HardKeys
{
    /// <summary>
    /// Presents KB Dll Hook Structore
    /// 
    /// 2017/08/11 - Created, VTyagunov
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct KBDLLHOOKSTRUCT
    {
        /// <summary>VK Code</summary>
        public readonly int vkCode;
        /// <summary>Scan Code</summary>
        public readonly int scanCode;
        /// <summary>Flags</summary>
        public readonly int flags;
        /// <summary>Time</summary>
        public readonly int time;
        /// <summary>DW Extra Info</summary>
        public readonly IntPtr dwExtraInfo;
    }
}