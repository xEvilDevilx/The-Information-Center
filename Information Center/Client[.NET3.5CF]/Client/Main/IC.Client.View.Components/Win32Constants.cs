using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Presents Win32 Constants
    /// 
    /// 2017/02/02 - created VTyagunov
    /// </summary>
    public class Win32Constants
    {
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_MOUSELEAVE = 0x02A3;        
        public const int WM_PAINT = 0x000F;
        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_PRINT = 0x0317;
        //const int EN_HSCROLL       =   0x0601;
        //const int EN_VSCROLL       =   0x0602;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;        
        public const int EM_GETSEL = 0x00B0;
        public const int EM_LINEINDEX = 0x00BB;
        public const int EM_LINEFROMCHAR = 0x00C9;
        public const int EM_POSFROMCHAR = 0x00D6;
        const int WM_PRINTCLIENT = 0x0318;
        const long PRF_CHECKVISIBLE = 0x00000001L;
        const long PRF_NONCLIENT = 0x00000002L;
        const long PRF_CLIENT = 0x00000004L;
        const long PRF_ERASEBKGND = 0x00000008L;
        const long PRF_CHILDREN = 0x00000010L;
        const long PRF_OWNED = 0x00000020L;

        [DllImport("USER32.DLL", EntryPoint = "PostMessage")]
        public static extern bool PostMessage(IntPtr hwnd, uint msg,
            IntPtr wParam, IntPtr lParam);
        
        [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam,
            IntPtr lParam);
        
        [DllImport("USER32.DLL", EntryPoint = "GetCaretBlinkTime")]
        public static extern uint GetCaretBlinkTime();
        
        public static bool CaptureWindow(Control control,
                                ref Bitmap bitmap)
        {
            var g2 = Graphics.FromImage(bitmap);            
            int meint = (int)(PRF_CLIENT | PRF_ERASEBKGND);
            var meptr = new IntPtr(meint);
            var hdc = g2.GetHdc();
            Win32Constants.SendMessage(control.Handle, Win32Constants.WM_PRINT, hdc, meptr);

            g2.ReleaseHdc(hdc);
            g2.Dispose();

            return true;
        }
    }
}