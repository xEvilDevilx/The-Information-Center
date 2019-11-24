using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using IC.SDK;
using IC.SDK.Base.Enums;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Implements IC Advanced Item component functionality
    /// 
    /// 2017/08/07 - Created, VTyagunov
    /// </summary>
    public class ICAdvancedItem : Control
    {
        #region Variables

        /// <summary>Store the accessable state of AdvancedItem</summary>
        private bool _inaccessable;
        /// <summary>Image of component</summary>
        private Bitmap _image;
        /// <summary>Back image</summary>
        private Bitmap _offScreen;
        /// <summary>Component height</summary>
        private int _height;
        /// <summary>Component width</summary>
        private int _width;
        /// <summary>Component max text length</summary>
        private int _maxTextLength;
        /// <summary>Text Size</summary>
        private Size _textSize = new Size(260, 70);
        /// <summary>Picture Size</summary>
        private Size _pictureSize = new Size(100, 70);

        #endregion

        #region Properties

        /// <summary>Image</summary>
        public Bitmap Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Invalidate();
            }
        }

        /// <summary>Max Text Length</summary>
        public int MaxTextLength
        {
            get { return _maxTextLength; }
            set
            {
                _maxTextLength = value;
                Invalidate();
            }
        }

        /// <summary>Flag shows is need show rectangle or not</summary>
        public bool IsShowRectangle { get; set; }

        /// <summary>Use for get/set the accessable state of AdvancedItem</summary>
        public bool Inaccessable
        {
            get { return _inaccessable; }
            set
            {
                if (value)
                {
                    this.Text = string.Empty;
                    this.Image = null;
                    this.Invalidate();
                }
                _inaccessable = value;
            }
        }

        /// <summary>Get/Set Custom PictureBox size</summary>
        public Size ImageSize
        {
            get { return _pictureSize; }
            set 
            {
                _pictureSize = value; 
            }
        }

        /// <summary>Font Size</summary>
        public float FontSize
        {
            get { return this.Font.Size; }
            set
            {
                this.Font = new Font(this.Font.Name, value, this.Font.Style);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ICAdvancedItem()
        {
            _height = 80;
            _width = 370;
            if (_maxTextLength < 1)
                _maxTextLength = 200;

            this.Size = new Size(_width, _height);
            this.ClientSize = new Size(_width, _height);
            this.Location = new Point(100, 100);
            this.Font = new Font("Microsoft Sans Serif", 34f, FontStyle.Bold);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use to set data of AdvancedItem
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="image">Image</param>
        public void SetData(string text, Image image)
        {
            SetText(text);
            SetImage(image);
        }

        /// <summary>
        /// Use for Set text to component
        /// </summary>
        /// <param name="text">Text</param>
        private void SetText(string text)
        {
            if (text.Length > _maxTextLength)
                Text = text.Remove(_maxTextLength, text.Length - _maxTextLength);
            else Text = text;
        }

        /// <summary>
        /// Use for Set image to component
        /// </summary>
        /// <param name="image">Image</param>
        private void SetImage(Image image)
        {
            if (image == null)
                return;

            try
            {
                var newImgRect = new Rectangle(0, 0, _pictureSize.Width, _pictureSize.Height);
                var newRect = Extensions.ImageRectangleFromSizeMode(newImgRect, ICPictureSizeMode.Zoom,
                    image.Size);
                var newSize = new Size(newRect.Width, newRect.Height);
                var newImage = Extensions.Resize(image, newSize);
                Image = (Bitmap)newImage;
            }
            catch (Exception ex)
            {

            }
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
                    var textSize = g.MeasureString(Text, Font);
                    var imageWidth = (Image != null) ? Image.Width : _pictureSize.Width;
                    var textArea = new RectangleF(
                        ((ClientSize.Width - textSize.Width) / 2) - (imageWidth / 2) - 10,
                        (ClientSize.Height - textSize.Height) / 2,
                        _textSize.Width,
                        _textSize.Height);

                    if (Image != null)
                    {
                        var imageArea = new Rectangle(
                            _width - (_pictureSize.Width / 2) - (Image.Width / 2),
                            (_height / 2) - (_pictureSize.Height / 2),
                            Image.Width,
                            Image.Height);

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

                    e.Graphics.DrawImage(
                        _offScreen,
                        ClientRectangle,
                        0, 0, _offScreen.Width, _offScreen.Height,
                        GraphicsUnit.Pixel,
                        attributes);

                    if (IsShowRectangle)
                    {
                        e.Graphics.DrawRectangle(
                            new Pen(Color.Green, 4f), new Rectangle(0, 0, _width - 1, _height - 1));
                    }

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
        /// OnParentChanged event action
        /// </summary>
        /// <param name="e">Event args</param>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            Invalidate();
        }

        /// <summary>
        /// OnTextChanged event action
        /// </summary>
        /// <param name="e">Event args</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        #endregion
    }
}