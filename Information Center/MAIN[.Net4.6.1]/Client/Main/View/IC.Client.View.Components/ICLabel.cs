using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using IC.SDK;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Implements IC Label component
    /// 
    /// 2017/02/17 - created VTyagunov
    /// </summary>
    public class ICLabel : Label
    {
        /// <summary>Outline ForeColor</summary>
        public Color OutlineForeColor { get; set; }
        /// <summary>Outline Width</summary>
        public float OutlineWidth { get; set; }
        /// <summary>Outline Alignment</summary>
        public StringAlignment OutlineAlignment { get; set; }
        /// <summary>Outline Line Alignment</summary>
        public StringAlignment OutlineLineAlignment { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ICLabel()
        {
            Logger.Log.Debug("ICLabel. Ctr. Enter");

            OutlineForeColor = Color.Green;
            OutlineWidth = 2;

            Logger.Log.Debug("ICLabel. Ctr. Exit");
        }
        
        /// <summary>
        /// OnPaint Event Actions
        /// </summary>
        /// <param name="e">event args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Logger.Log.Debug("OnPaint. Enter");
            
            try
            {
                e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
                using (GraphicsPath gp = new GraphicsPath())
                {
                    using (Pen outline = new Pen(OutlineForeColor, OutlineWidth)
                    {
                        LineJoin = LineJoin.Round
                    })
                    {
                        using (StringFormat sf = new StringFormat())
                        {
                            sf.Alignment = OutlineAlignment;
                            sf.LineAlignment = OutlineLineAlignment;
                            using (Brush foreBrush = new SolidBrush(ForeColor))
                            {
                                gp.AddString(Text, Font.FontFamily, (int)Font.Style,
                                    Font.Size, ClientRectangle, sf); //Font.Size                            
                                                                     //e.Graphics.ScaleTransform(1.3f, 1.35f);
                                                                     //e.Graphics.ScaleTransform(1.05f, 1.05f);
                                e.Graphics.ScaleTransform(1.0f, 1.0f);
                                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                                e.Graphics.DrawPath(outline, gp);
                                e.Graphics.FillPath(foreBrush, gp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("OnPaint.", ex);
            }

            Logger.Log.Debug("OnPaint. Exit");
        }
    }
}