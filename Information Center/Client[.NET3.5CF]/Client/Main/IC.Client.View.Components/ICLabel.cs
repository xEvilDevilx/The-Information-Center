using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using IC.Client.View.Components.Enum;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Implements IC Label component
    /// 
    /// 2017/06/01 - created, VTyagunov
    /// </summary>
    public class ICLabel : Control
    {
        #region Variables

        /// <summary>Back image</summary>
        private Bitmap _offScreen;
        /// <summary>Basic text line list</summary>
        private List<string> _basicTextLineList;
        /// <summary>Current line ID</summary>
        private int _currentLineID;
        /// <summary>Rectangle Height</summary>
        private int _rectHeight;
        /// <summary>Rectangle Width</summary>
        private int _rectWidth;
        /// <summary>Client Size Height</summary>
        private int _clientSizeHeight;
        /// <summary>Count of text lines for Fit text font</summary>
        private int _countOfLinesForFit;

        #endregion

        #region Properties

        /// <summary>Text Align</summary>
        public ICLabelTextAlign TextAlign { get; set; }
        /// <summary>Flag use for set fit text font size to text area or not</summary>
        public bool IsFitTextFontSize { get; set; }
        /// <summary>Count of text lines for Fit text font</summary>
        public int CountOfLinesForFit 
        {
            get { return _countOfLinesForFit; }
            set 
            {
                if(value > 0)
                    _countOfLinesForFit = value; 
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ICLabel()
        {
            _currentLineID = 0;
            _rectHeight = 0;
            _rectWidth = 0;
            _clientSizeHeight = 0;
            _countOfLinesForFit = 1;
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
            OnPaintAction(e.Graphics);
        }

        /// <summary>
        /// OnPaint action
        /// </summary>
        private void OnPaintAction(Graphics graphics)
        {
            if (_offScreen == null)
                _offScreen = new Bitmap(ClientSize.Width, ClientSize.Height);

            try
            {
                using (var attributes = new ImageAttributes())
                using (var g = Graphics.FromImage(_offScreen))
                {
                    if (_basicTextLineList == null)
                        SetText(Text, ICLabelTextAlign.Left);

                    Font newFont = this.Font;
                    var textSize = g.MeasureString(Text, newFont);

                    if (IsFitTextFontSize)
                    {
                        int textHeight = 0;
                        if (_basicTextLineList.Count > 1)
                            textHeight = (int)textSize.Height * _countOfLinesForFit;
                        else textHeight = (int)textSize.Height;

                        while (textHeight > ClientSize.Height)
                        {
                            if (newFont.Size < 11f)
                                break;

                            var fontName = newFont.Name;
                            var newFontSize = newFont.Size - 1f;
                            var fontStyle = newFont.Style;
                            newFont = new Font(fontName, newFontSize, fontStyle);

                            textSize = g.MeasureString(Text, newFont);
                            if (_basicTextLineList.Count > 1)
                                textHeight = (int)textSize.Height * _countOfLinesForFit;
                            else textHeight = (int)textSize.Height;
                        }
                    }

                    float newTextHeight = ((float)_basicTextLineList.Count - _currentLineID) * 
                        textSize.Height;
                    if (newTextHeight > textSize.Height)
                        textSize.Height = newTextHeight;
                    textSize.Width = ClientSize.Width;
                    var textArea = GetTextArea(textSize);

                    switch (TextAlign)
                    {
                        case ICLabelTextAlign.Center:
                            if (!IsFitTextFontSize)
                            {
                                var stringFormat = new StringFormat()
                                {
                                    Alignment = StringAlignment.Center
                                };
                                using (var brush = new SolidBrush(ForeColor))
                                    g.DrawString(Text, newFont, brush, textArea, stringFormat);
                            }
                            else
                            {
                                using (var brush = new SolidBrush(ForeColor))
                                    g.DrawString(Text, newFont, brush, textArea);
                            }
                            break;
                        case ICLabelTextAlign.Left:
                        default:
                            using (var brush = new SolidBrush(ForeColor))
                                g.DrawString(Text, newFont, brush, textArea);
                            break;
                    }

                    graphics.DrawImage(
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
        /// Use for Get text area
        /// </summary>
        /// <param name="textSize">Text size</param>
        /// <returns></returns>
        private RectangleF GetTextArea(SizeF textSize)
        {
            RectangleF textArea;
            switch (TextAlign)
            {
                case ICLabelTextAlign.Left:
                    textArea = GetLeftTextArea(textSize);
                    break;
                case ICLabelTextAlign.Center:
                    textArea = GetCenterTextArea(textSize);
                    break;
                default:
                    textArea = GetLeftTextArea(textSize);
                    break;
            }

            return textArea;
        }

        /// <summary>
        /// Use for Get left text area
        /// </summary>
        /// <param name="textSize">Text size</param>
        /// <returns></returns>
        private RectangleF GetLeftTextArea(SizeF textSize)
        {
            var textArea = new RectangleF(0, 0, textSize.Width, textSize.Height);
            return textArea;
        }

        /// <summary>
        /// Use for Get center text area
        /// </summary>
        /// <param name="textSize">Text size</param>
        /// <returns></returns>
        private RectangleF GetCenterTextArea(SizeF textSize)
        {
            var textArea = new RectangleF((ClientSize.Width / 2) - (textSize.Width / 2),
                            (ClientSize.Height / 2) - (textSize.Height / 2),
                            textSize.Width, textSize.Height);
            return textArea;
        }

        /// <summary>
        /// OnMouseDown event action
        /// </summary>
        /// <param name="e">Mouse event args</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Invalidate();
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

        /// <summary>
        /// Use for Set text to component
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="textAlign"> Text align</param>
        public void SetText(string text, ICLabelTextAlign textAlign)
        {
            if (string.IsNullOrEmpty(text))
                return;
            
            try
            {
                text = text.Replace("\n", "");
                text = text.Replace("\r", "");

                if (_offScreen == null)
                    _offScreen = new Bitmap(ClientSize.Width, ClientSize.Height);

                using (var g = Graphics.FromImage(_offScreen))
                {
                    var textSize = g.MeasureString(text, Font);

                    float clientSizeHeight = (float)ClientSize.Height / textSize.Height;  
                    var clientSizeHeightCeiled = (int)Math.Ceiling((double)clientSizeHeight);
                    if ((clientSizeHeight + 0.2f) > clientSizeHeightCeiled)
                        _clientSizeHeight = clientSizeHeightCeiled;
                    else _clientSizeHeight = clientSizeHeightCeiled - 1;

                    double rowCount = Math.Ceiling((double)(textSize.Width / ClientSize.Width));
                    float newTextHeight = ((float)rowCount) * textSize.Height;

                    _rectHeight = (int)(newTextHeight / textSize.Height);
                    _rectWidth = ClientSize.Width;

                    _basicTextLineList = WrapTextWithGraphics(g, text, _rectWidth, this.Font);
                }
                
                TextAlign = textAlign;
                Text = text;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Use for wrap text with using Graphics
        /// </summary>
        /// <param name="g">Graphics</param>
        /// <param name="original">Original text string</param>
        /// <param name="width">Text width</param>
        /// <param name="font">Text font</param>
        /// <returns></returns>
        public static List<string> WrapTextWithGraphics(Graphics g, string original, int width, Font font)
        {
            var wrappedLines = new List<string>();
            string currentLine = string.Empty;

            for (int i = 0; i < original.Length; i++)
            {
                char currentChar = original[i];
                currentLine += currentChar;
                if (g.MeasureString(currentLine, font).Width > width)
                {
                    int moveback = 0;
                    if (currentLine.Contains(" "))
                    {
                        while (currentChar != ' ')
                        {
                            if (currentChar == '-')
                            {
                                var newCurrentLine = currentLine.Substring(0, currentLine.Length - moveback);
                                var currentLineWidth = g.MeasureString(newCurrentLine, font).Width;
                                if (currentLineWidth <= width)
                                    break;
                            }
                            moveback++;
                            i--;
                            currentChar = original[i];
                        }
                        string lineToAdd = currentLine.Substring(0, currentLine.Length - moveback);
                        wrappedLines.Add(lineToAdd);
                        currentLine = string.Empty;
                    }
                }
            }

            if (currentLine.Length > 0)
                wrappedLines.Add(currentLine);

            return wrappedLines;
        }

        /// <summary>
        /// Use for Scroll Up text
        /// </summary>
        public void ScrollUp()
        {
            try
            {
                if (_currentLineID > 0)
                {
                    string text = "";
                    int counter = 0;
                    _currentLineID--;
                    for (int i = _currentLineID; i < _basicTextLineList.Count; i++)
                    {
                        text += _basicTextLineList[i];
                        counter++;
                        if (counter == _rectHeight)
                            break;
                    }
                    Text = text;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Use for Scroll Down text
        /// </summary>
        public void ScrollDown()
        {
            try
            {
                if (_currentLineID < (_basicTextLineList.Count - _clientSizeHeight)) // + Line count in rectangle
                {
                    string text = "";
                    int counter = 0;
                    _currentLineID++;
                    for (int i = _currentLineID; i < _basicTextLineList.Count; i++)
                    {
                        text += _basicTextLineList[i];
                        counter++;
                        if (counter == _rectHeight)
                            break;
                    }
                    Text = text;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}