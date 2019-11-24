using System;

namespace IC.Client.FormModel.Base
{
    /// <summary>
    /// Presents Terminal Hard Keys delegates
    /// 
    /// 2017/08/25 - Created, VTyagunov
    /// </summary>
    public class HardwareDelegates
    {
        /// <summary>
        /// Hook Process delegate
        /// </summary>
        /// <param name="code"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Hook Event Handler delegate
        /// </summary>
        /// <param name="key"></param>
        public delegate void HookEventHandler(int key);
    }
}