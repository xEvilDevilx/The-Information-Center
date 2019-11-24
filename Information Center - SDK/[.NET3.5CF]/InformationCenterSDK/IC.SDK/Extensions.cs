using System;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;

using IC.SDK;
using IC.SDK.Base.Enums;

namespace IC.SDK
{
    /// <summary>
    /// Implements Extension methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Extension for remove item from Array by index
        /// </summary>
        /// <typeparam name="T">T Type</typeparam>
        /// <param name="source">T object</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            Logger.Log.Debug("RemoveAt. Enter");

            var dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            Logger.Log.Debug("RemoveAt. Exit");
            return dest;
        }

        /// <summary>
        /// Use for Resize Image
        /// </summary>
        /// <param name="image">Image for resize</param>
        /// <param name="size">New size</param>
        /// <returns></returns>
        public static Image Resize(Image image, Size size)
        {
            Image bmp = new Bitmap(size.Width, size.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.DrawImage(
                    image,
                    new Rectangle(0, 0, size.Width, size.Height),
                    new Rectangle(0, 0, image.Width, image.Height),
                    GraphicsUnit.Pixel);
            }

            return bmp;
        }

        /// <summary>
        /// Use for get new Rectangle size from old image size
        /// </summary>
        /// <param name="clientRectangle">Current image control rectangle</param>
        /// <param name="mode">Picture size mode</param>
        /// <param name="imgSize">Old image size</param>
        /// <returns></returns>
        public static Rectangle ImageRectangleFromSizeMode(Rectangle clientRectangle, 
            ICPictureSizeMode mode,
            Size imgSize)
        {
            Rectangle result = new Rectangle(0, 0, 0, 0);

            if (imgSize != null)
            {
                switch (mode)
                {
                    case ICPictureSizeMode.Normal:
                    case ICPictureSizeMode.AutoSize:
                        result.Size = imgSize;
                        break;

                    case ICPictureSizeMode.StretchImage:
                        break;

                    case ICPictureSizeMode.CenterImage:
                        result.X += (result.Width - imgSize.Width) / 2;
                        result.Y += (result.Height - imgSize.Height) / 2;
                        result.Size = imgSize;
                        break;

                    case ICPictureSizeMode.Zoom:
                        Size imageSize = imgSize;
                        float ratio = Math.Min((float)clientRectangle.Width / 
                            (float)imageSize.Width,
                            (float)clientRectangle.Height / (float)imageSize.Height);
                        result.Width = (int)(imageSize.Width * ratio);
                        result.Height = (int)(imageSize.Height * ratio);
                        result.X = (clientRectangle.Width - result.Width) / 2;
                        result.Y = (clientRectangle.Height - result.Height) / 2;
                        break;

                    default:
                        break;
                }
            }

            return result;
        }
    }
}