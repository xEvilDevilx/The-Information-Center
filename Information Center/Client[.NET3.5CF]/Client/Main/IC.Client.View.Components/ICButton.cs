using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Implements IC Button functionality
    /// 
    /// 2017/08/07 - Created, VTyagunov
    /// </summary>
    public class ICButton : Control
    {
        #region Variables

        /// <summary>Button push flag</summary>
        private bool _pushed;
        /// <summary>Component image</summary>
        private Bitmap _image;
        /// <summary>Back image</summary>
        private Bitmap _offScreen;

        #endregion

        #region Properties

        /// <summary>Component image</summary>
        public Bitmap Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// OnResize event action
        /// </summary>
        /// <param name="e">Event args</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (_offScreen != null)
            {
                _offScreen.Dispose();
                _offScreen = null;
            }
            _offScreen = new Bitmap(ClientSize.Width, ClientSize.Height);
        }

        /// <summary>
        /// OnPaint event action
        /// </summary>
        /// <param name="e">Paint event args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_offScreen == null)
                _offScreen = new Bitmap(ClientSize.Width, ClientSize.Height);

            try
            {
                using (var attributes = new ImageAttributes())
                using (var g = Graphics.FromImage(_offScreen))
                {
                    if (_pushed)
                    {
                        //using (var pen = new Pen(SystemColors.Highlight))
                        //    g.DrawThemedGradientRectangle(pen, ClientRectangle, new Size(4, 4));
                    }
                    else
                    {
                        //g.Clear(Parent.BackColor);
                    }

                    var textSize = g.MeasureString(Text, Font);
                    var textArea = new RectangleF(
                        (ClientSize.Width - textSize.Width) / 2,
                        (ClientSize.Height - textSize.Height) / 2,
                        textSize.Width,
                        textSize.Height);

                    if (Image != null)
                    {
                        var imageArea = new Rectangle(
                            0,
                            0,
                            ClientSize.Width,
                            ClientSize.Height);

                        var key = Image.GetPixel(0, 0);
                        attributes.SetColorKey(key, key);

                        g.DrawImage(
                            Image,
                            imageArea,
                            0, 0, Image.Width, Image.Height,
                            GraphicsUnit.Pixel,
                            attributes);
                    }

                    using (var brush = new SolidBrush(ForeColor))
                        g.DrawString(Text, Font, brush, textArea);

                    if (_pushed)
                    {
                        //var key = offScreen.GetPixel(0, 0);
                        //attributes.SetColorKey(key, key);
                    }
                    else
                    {
                        //attributes.ClearColorKey();
                    }

                    e.Graphics.DrawImage(
                        _offScreen,
                        ClientRectangle,
                        0, 0, _offScreen.Width, _offScreen.Height,
                        GraphicsUnit.Pixel,
                        attributes);

                    try
                    {
                        var bgOwner = Parent as IControlBackground;
                        if (bgOwner != null && bgOwner.BackgroundImage != null)
                            g.AlphaBlend(bgOwner.BackgroundImage, 255, Location);
                    }
                    catch (MissingMethodException ex)
                    {
                        throw new PlatformNotSupportedException(
                            "AlphaBlend is not a supported GDI feature on this device",
                            ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OnMouseDown event action
        /// </summary>
        /// <param name="e">Mouse event args</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _pushed = true;
            Invalidate();
        }

        /// <summary>
        /// OnMouseUp event action
        /// </summary>
        /// <param name="e">Mouse event args</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _pushed = false;
            Invalidate();
        }

        /// <summary>
        /// OnParentChanged event action
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Invalidate();
        }

        /// <summary>
        /// OnTextChanged event action
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        #endregion
    }
}