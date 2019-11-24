using System;
using System.Drawing;
using System.Windows.Forms;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Implements IC Advanced Item component functionality
    /// 
    /// 2017/08/07 - Created, VTyagunov
    /// </summary>
    public partial class ICAdvancedItem : UserControl
    {
        #region Variables

        /// <summary>Store the accessable state of AdvancedItem</summary>
        private bool _inaccessable;
        /// <summary>Component max text length</summary>
        private int _maxTextLength;
        
        #endregion

        #region Properties
        
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
                    _lblText.Text = string.Empty;
                    this.Invalidate();
                }
                _inaccessable = value;
            }
        }
        
        /// <summary>Get/Set Custom PictureBox size</summary>
        public Size ImageSize
        {
            get { return _image.Size; }
            set
            {
                _image.Size = value;
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
            InitializeComponent();
            
            if (_maxTextLength < 1)
                _maxTextLength = 200;
            
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
                _lblText.Text = text.Remove(_maxTextLength, text.Length - _maxTextLength);
            else _lblText.Text = text;
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
                _image.Image = image;
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
            try
            {
                if (IsShowRectangle)
                {
                    e.Graphics.DrawRectangle(
                        new Pen(Color.Green, 4f), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion
    }
}
