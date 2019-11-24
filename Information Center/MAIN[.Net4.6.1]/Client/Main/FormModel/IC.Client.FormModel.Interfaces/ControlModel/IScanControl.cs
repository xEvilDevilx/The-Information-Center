using System.Drawing;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces.ControlModel.Base;

namespace IC.Client.FormModel.Interfaces.ControlModel
{
    /// <summary>
    /// Presents ScanControl interface
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    public interface IScanControl : IControl
    {
        /// <summary>Click Control Event</summary>
        event ControlEventHandlers.ClickControlEventHandler ClickControlEvent;
        /// <summary>Click Button Shares Event</summary>
        event ControlEventHandlers.ClickButtonSharesEventHandler ClickButtonSharesEvent;
        /// <summary>Click Button Settings Event</summary>
        event ControlEventHandlers.ClickButtonSettingsEventHandler ClickButtonSettingsEvent;
        
        /// <summary>
        /// Use for set system data of control
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