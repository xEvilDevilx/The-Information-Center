using IC.SDK;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace IC.Client.View.Components
{
    /// <summary>
    /// IC TextBox component
    /// 
    /// 2017/02/02 - created VTyagunov
    /// </summary>
    public class ICTextBox : TextBox
    {
        #region Variables

        //#if NETCF
        //        [DllImport("coredll.dll")]
        //#else
        //        [DllImport("user32.dll")]
        //#endif
        //        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //        private const int EM_SCROLL = 0xB5;
        //        private const int SB_UP = 0;
        //        private const int SB_DOWN = 1;

        /// <summary>IC Picture Box</summary>
        private ICPictureBox _icPictureBox;
        /// <summary>Flag show is need Up To Date</summary>
        private bool _upToDate;
        /// <summary>Flag show is need Caret Up To Date</summary>
        private bool _caretUpToDate;
        /// <summary>Bitmap</summary>
        private Bitmap _bitmap;
        /// <summary>Alpha Bitmap</summary>
        private Bitmap _alphaBitmap;
        /// <summary>Font height</summary>
        private int _fontHeight;
        /// <summary>Flag shows a Painted First Time/summary>
        private bool _paintedFirstTime;
        /// <summary>Back Color</summary>
        private Color _backColor;
        /// <summary>Back Alpha</summary>
        private int _backAlpha;
        /// <summary>Required designer variable</summary>
        private Container _components;
        /// <summary>IntPtr for Up</summary>
        private IntPtr _up;
        /// <summary>IntPtr for Down</summary>
        private IntPtr _down;
        /// <summary>IntPtr for Zero</summary>
        private IntPtr _zero;

        #endregion

        #region Proprties

        #region Overrides

        /// <summary>Store Border Style</summary>
        public new BorderStyle BorderStyle
        {
            get { return base.BorderStyle; }
            set
            {
                if (this._paintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.BorderStyle = value;

                if (this._paintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this._bitmap = null;
                this._alphaBitmap = null;
                _upToDate = false;
                this.Invalidate();
            }
        }

        /// <summary>Store Back Color</summary>
        public new Color BackColor
        {
            get
            {
                return Color.FromArgb(base.BackColor.R, base.BackColor.G, base.BackColor.B);
            }
            set
            {
                _backColor = value;
                base.BackColor = value;
                _upToDate = false;
            }
        }

        /// <summary>Multiline</summary>
        public override bool Multiline
        {
            get { return base.Multiline; }
            set
            {
                if (this._paintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, false);

                base.Multiline = value;

                if (this._paintedFirstTime)
                    this.SetStyle(ControlStyles.UserPaint, true);

                this._bitmap = null;
                this._alphaBitmap = null;
                _upToDate = false;
                this.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Back Alpha value
        /// </summary>
        [Category("Appearance"),
        //Description("The alpha value used to blend the control's background. Valid values are 0 through 255."),
        Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BackAlpha
        {
            get { return _backAlpha; }
            set
            {
                int v = value;
                if (v > 255)
                    v = 255;
                _backAlpha = v;
                _upToDate = false;
                Invalidate();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ICTextBox()
        {
            Logger.Log.Debug("ICTextBox. Ctr. Enter");

            InitializeComponent();

            _upToDate = false;
            _caretUpToDate = false;
            _fontHeight = 10;
            _paintedFirstTime = false;
            _backColor = Color.White;
            _backAlpha = 10;
            _components = null;
            _up = new IntPtr(0);
            _down = new IntPtr(1);
            _zero = new IntPtr(0);

            this.BackColor = _backColor;

            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            _icPictureBox = new ICPictureBox();
            this.Controls.Add(_icPictureBox);
            _icPictureBox.Dock = DockStyle.Fill;
            
            Logger.Log.Debug("ICTextBox. Ctr. Exit");
        }

        #endregion

        #region Methods

        #region Overrides

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this._bitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            this._alphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            _upToDate = false;
            this.Invalidate();
        }
        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _upToDate = false;
            this.Invalidate();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            _upToDate = false;
            this.Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            _upToDate = false;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.Invalidate();
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs gfbevent)
        {
            base.OnGiveFeedback(gfbevent);
            _upToDate = false;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            var ptCursor = Cursor.Position;
            var f = this.FindForm();
            ptCursor = f.PointToClient(ptCursor);
            if (!this.Bounds.Contains(ptCursor))
                base.OnMouseLeave(e);
        }
        
        protected override void OnChangeUICues(UICuesEventArgs e)
        {
            base.OnChangeUICues(e);
            _upToDate = false;
            this.Invalidate();
        }
        
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            _caretUpToDate = false;
            _upToDate = false;
            this.Invalidate();
            
            //_timer = new Timer(this._components);
            //_timer.Interval = (int)Win32Constants.GetCaretBlinkTime();
            //_timer.Tick += new EventHandler(Timer1_Tick);
            //_timer.Enabled = true;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            _caretUpToDate = false;
            _upToDate = false;
            this.Invalidate();
            //_timer.Dispose();
        }
        
        protected override void OnFontChanged(EventArgs e)
        {
            if (this._paintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, false);

            base.OnFontChanged(e);

            if (this._paintedFirstTime)
                this.SetStyle(ControlStyles.UserPaint, true);
            
            _fontHeight = GetFontHeight();
            
            _upToDate = false;
            this.Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            _upToDate = false;
            this.Invalidate();
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            if (m.Msg == Win32Constants.WM_PAINT)
            {
                _paintedFirstTime = true;

                if (!_upToDate || !_caretUpToDate)
                    GetBitmaps();
                _upToDate = true;
                _caretUpToDate = true;

                if (_icPictureBox.Image != null) _icPictureBox.Image.Dispose();
                _icPictureBox.Image = (Image)_alphaBitmap.Clone();
            }

            else if (m.Msg == Win32Constants.WM_HSCROLL || m.Msg == Win32Constants.WM_VSCROLL)
            {
                _upToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == Win32Constants.WM_LBUTTONDOWN
                || m.Msg == Win32Constants.WM_RBUTTONDOWN
                || m.Msg == Win32Constants.WM_LBUTTONDBLCLK
                )
            {
                _upToDate = false;
                this.Invalidate();
            }

            else if (m.Msg == Win32Constants.WM_MOUSEMOVE)
            {
                if (m.WParam.ToInt32() != 0)
                {
                    _upToDate = false;
                    this.Invalidate();
                }
            }
        }

        #endregion

        /// <summary>
        /// Use for Initialize Component
        /// </summary>
        private void InitializeComponent()
        {
            Logger.Log.Debug("InitializeComponent. Enter");

            _components = new Container();

            Logger.Log.Debug("InitializeComponent. Exit");
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            Logger.Log.Debug("Dispose. Enter");

            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);

            Logger.Log.Debug("Dispose. Exit");
        }

        /// <summary>
        /// Use for get Font Height
        /// </summary>
        /// <returns></returns>
        private int GetFontHeight()
        {
            Logger.Log.Debug("GetFontHeight. Enter");

            var g = this.CreateGraphics();
            var sf_font = g.MeasureString("X", this.Font);
            g.Dispose();

            Logger.Log.Debug("GetFontHeight. Exit");
            return (int)sf_font.Height;
        }

        /// <summary>
        /// Use for get BitMaps
        /// </summary>
        private void GetBitmaps()
        {
            Logger.Log.Debug("GetBitmaps. Enter");

            if (_bitmap == null
                || _alphaBitmap == null
                || _bitmap.Width != Width
                || _bitmap.Height != Height
                || _alphaBitmap.Width != Width
                || _alphaBitmap.Height != Height)
            {
                _bitmap = null;
                _alphaBitmap = null;
            }

            if (_bitmap == null)
            {
                _bitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
                _upToDate = false;
            }

            if (!_upToDate)
            {
                this.SetStyle(ControlStyles.UserPaint, false);

                Win32Constants.CaptureWindow(this, ref _bitmap);

                this.SetStyle(ControlStyles.UserPaint, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.BackColor = Color.FromArgb(_backAlpha, _backColor);
            }

            var r2 = new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
            var tempImageAttr = new ImageAttributes();
            var tempColorMap = new ColorMap[1];
            tempColorMap[0] = new ColorMap();
            tempColorMap[0].OldColor = Color.FromArgb(255, _backColor);
            tempColorMap[0].NewColor = Color.FromArgb(_backAlpha, _backColor);

            tempImageAttr.SetRemapTable(tempColorMap);

            if (_alphaBitmap != null)
                _alphaBitmap.Dispose();

            _alphaBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);

            var tempGraphics1 = Graphics.FromImage(_alphaBitmap);
                        
            tempGraphics1.DrawImage(_bitmap, r2, 0, 0, this.ClientRectangle.Width,
                this.ClientRectangle.Height, GraphicsUnit.Pixel, tempImageAttr);
            tempGraphics1.ScaleTransform(1.0f, 1.0f);
            tempGraphics1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            tempGraphics1.Dispose();

            //if (this.Focused && (this.SelectionLength == 0))
            //{
            //var tempGraphics2 = Graphics.FromImage(_alphaBitmap);
            //if (_caretState)
            //{
            //    var caret = this.FindCaret();
            //    var p = new Pen(this.ForeColor, 3);
            //    tempGraphics2.DrawLine(p, caret.X, caret.Y + 0, caret.X, caret.Y + _fontHeight);
            //    tempGraphics2.Dispose();
            //}
            //}

            Logger.Log.Debug("GetBitmaps. Exit");
        }
        
        /// <summary>
        /// Use for scroll Up
        /// </summary>
        public void ScrollUp()
        {
            Logger.Log.Debug("ScrollUp. Enter");

            Win32Constants.SendMessage(this.Handle, Win32Constants.WM_VSCROLL, _up, _zero);

            Logger.Log.Debug("ScrollUp. Exit");
        }

        /// <summary>
        /// Use for scroll Down
        /// </summary>
        public void ScrollDown()
        {
            Logger.Log.Debug("ScrollDown. Enter");

            Win32Constants.SendMessage(this.Handle, Win32Constants.WM_VSCROLL, _down, _zero);

            Logger.Log.Debug("ScrollDown. Exit");
        }

        ///// <summary>
        ///// Use for action of pressed button up
        ///// </summary>
        //public void BtnUp()
        //{
        //    SendMessage(this.Handle, EM_SCROLL, SB_UP, 0);
        //}

        ///// <summary>
        ///// Use for action of pressed button down
        ///// </summary>
        //public void BtnDown()
        //{
        //    SendMessage(this.Handle, EM_SCROLL, SB_DOWN, 0);
        //}

        #endregion
    }
}