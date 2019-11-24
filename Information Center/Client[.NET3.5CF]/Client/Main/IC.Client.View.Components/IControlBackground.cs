using System.Drawing;

namespace IC.Client.View.Components
{
    /// <summary>
    /// Presents IControlBackground interface
    /// 
    /// 2017/06/10 - created VTyagunov
    /// </summary>
    public interface IControlBackground
    {
        /// <summary>Background Image</summary>
        Image BackgroundImage { get; }
    }
}