using System;
using System.Drawing;
using System.Runtime.InteropServices;

using IC.Client.View.Components.Enum;
using IC.Client.View.Components.Structs;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Implements Graphics Extensions
    /// 
    /// 2017/06/10 - created VTyagunov
    /// </summary>
    public static class GraphicsExtensions
    {
        /// <summary>
        /// AlphaBlend coredll function
        /// </summary>
        /// <param name="hdcDest"></param>
        /// <param name="xDest"></param>
        /// <param name="yDest"></param>
        /// <param name="cxDest"></param>
        /// <param name="cyDest"></param>
        /// <param name="hdcSrc"></param>
        /// <param name="xSrc"></param>
        /// <param name="ySrc"></param>
        /// <param name="cxSrc"></param>
        /// <param name="cySrc"></param>
        /// <param name="blendfunction"></param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        static extern bool AlphaBlend(IntPtr hdcDest, int xDest, int yDest, int cxDest, int cyDest,
            IntPtr hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, BlendFunction blendfunction);

        /// <summary>
        /// Use for Set alpha color
        /// </summary>
        /// <param name="graphics">Graphics component</param>
        /// <param name="image">Image</param>
        /// <param name="opacity"></param>
        public static void AlphaBlend(this Graphics graphics, Image image, byte opacity)
        {
            AlphaBlend(graphics, image, opacity, Point.Empty);
        }

        /// <summary>
        /// Use for Set alpha color
        /// </summary>
        /// <param name="graphics">Graphics component</param>
        /// <param name="image">Image</param>
        /// <param name="opacity">Opacity</param>
        /// <param name="location">Location</param>
        public static void AlphaBlend(this Graphics graphics, Image image, byte opacity, Point location)
        {
            using (var imageSurface = Graphics.FromImage(image))
            {
                var hdcDst = graphics.GetHdc();
                var hdcSrc = imageSurface.GetHdc();

                try
                {
                    var blendFunction = new BlendFunction
                    {
                        BlendOp = ((byte)BlendOperation.AC_SRC_OVER),
                        BlendFlags = ((byte)BlendFlags.Zero),
                        SourceConstantAlpha = opacity,
                        AlphaFormat = 0
                    };
                    AlphaBlend(
                        hdcDst,
                        location.X == 0 ? 0 : -location.X,
                        location.Y == 0 ? 0 : -location.Y,
                        800, //image.Width,
                        480, //image.Height,
                        hdcSrc,
                        0,
                        0,
                        image.Width,
                        image.Height,
                        blendFunction);
                }
                finally
                {
                    graphics.ReleaseHdc(hdcDst);
                    imageSurface.ReleaseHdc(hdcSrc);
                }
            }
        }
    }
}