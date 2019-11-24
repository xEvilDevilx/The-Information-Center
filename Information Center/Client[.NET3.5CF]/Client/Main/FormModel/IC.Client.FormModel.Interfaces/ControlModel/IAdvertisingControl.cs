using System.Drawing;

using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces.ControlModel.Base;

namespace IC.Client.FormModel.Interfaces.ControlModel
{
    /// <summary>
    /// Presents Advertising Control interface
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    public interface IAdvertisingControl : IControl
    {
        /// <summary>Close Control Event</summary>
        event ControlEventHandlers.CloseControlEventHandler CloseControlEvent;
        /// <summary>Key Hook functionality</summary>
        IKeyHook KeyHook { get; set; }

        /// <summary>
        /// Use for change advertisement
        /// </summary>
        /// <param name="newImage">New advertising image</param>
        void ChangeAdvertisement(Bitmap newImage);
    }
}