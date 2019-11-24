using IC.SDK;
using System.Windows.Forms;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Implements IC PictureBox component
    /// 
    /// 2017/02/25 - created VTyagunov
    /// </summary>
    public class ICPictureBox : PictureBox
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ICPictureBox()
        {
            Logger.Log.Debug("ICPictureBox. Ctr. Enter");

            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            this.Cursor = null;
            this.Enabled = true;
            this.SizeMode = PictureBoxSizeMode.Normal;

            Logger.Log.Debug("ICPictureBox. Ctr. Exit");
        }

        /// <summary>
        /// Processes Windows messages
        /// </summary>
        /// <param name="m">Message</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Win32Constants.WM_LBUTTONDOWN
                || m.Msg == Win32Constants.WM_RBUTTONDOWN
                || m.Msg == Win32Constants.WM_LBUTTONDBLCLK
                || m.Msg == Win32Constants.WM_MOUSELEAVE
                || m.Msg == Win32Constants.WM_MOUSEMOVE)
            {
                Win32Constants.PostMessage(this.Parent.Handle, (uint)m.Msg, m.WParam, m.LParam);
            }

            else if (m.Msg == Win32Constants.WM_LBUTTONUP)
                this.Parent.Invalidate();

            base.WndProc(ref m);
        }
    }
}