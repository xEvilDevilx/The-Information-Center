using System.Drawing;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces.ControlModel.Base;

namespace IC.Client.FormModel.Interfaces.ControlModel
{
    /// <summary>
    /// Presents SharesSalesControl interface
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    public interface ISharesSalesControl : IControl
    {
        /// <summary>Click Control Event</summary>
        event ControlEventHandlers.ClickControlEventHandler ClickControlEvent;
        /// <summary>Click Button Up Event</summary>
        event ControlEventHandlers.ClickButtonUpEventHandler ClickButtonUpEvent;
        /// <summary>Click Button Down Event</summary>
        event ControlEventHandlers.ClickButtonDownEventHandler ClickButtonDownEvent;
        /// <summary>Click Button Settings Event</summary>
        event ControlEventHandlers.ClickButtonSettingsEventHandler ClickButtonSettingsEvent;
        /// <summary>Click Button Previous Event</summary>
        event ControlEventHandlers.ClickButtonPreviousEventHandler ClickButtonPreviousEvent;
        /// <summary>Click Button Next Event</summary>
        event ControlEventHandlers.ClickButtonNextEventHandler ClickButtonNextEvent;
        /// <summary>Click Button Back Event</summary>
        event ControlEventHandlers.ClickButtonBackEventHandler ClickButtonBackEvent;
        /// <summary>Key Hook functionality</summary>
        IKeyHook KeyHook { get; set; }

        /// <summary>
        /// Use for does button up action
        /// </summary>  
        void BtnUp();

        /// <summary>
        /// Use for does button down action
        /// </summary> 
        void BtnDown();

        /// <summary>
        /// Use for set Shares and Sales data
        /// </summary>
        /// <param name="sharesSalesData">Shares and Sales Data object</param>
        void SetSharesSalesData(SharesSalesData sharesSalesData);

        /// <summary>
        /// Use for set system localization
        /// </summary>
        /// <param name="systemTranslationData">System Translation Data object</param>
        void Localize(SystemTranslationData systemTranslationData);

        /// <summary>
        /// Use for set image to Logo
        /// </summary>
        /// <param name="image">Image object</param>
        void SetLogoImage(Image image);
    }
}