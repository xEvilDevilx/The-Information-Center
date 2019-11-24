using System.Drawing;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces.ControlModel.Base;

namespace IC.Client.FormModel.Interfaces.ControlModel
{
    /// <summary>
    /// Presents SettingsControl interface
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    public interface ISettingsControl : IControl
    {
        /// <summary>Click Control Event</summary>
        event ControlEventHandlers.ClickControlEventHandler ClickControlEvent;
        /// <summary>Click Button Cancel Event</summary>
        event ControlEventHandlers.ClickButtonCancelEventHandler ClickButtonCancelEvent;
        /// <summary>Click Button Language Event</summary>
        event ControlEventHandlers.ClickButtonLanguageEventHandler ClickButtonLanguageEvent;
        /// <summary>Click Button Currency Event</summary>
        event ControlEventHandlers.ClickButtonCurrencyEventHandler ClickButtonCurrencyEvent;
        /// <summary>Click Button Choose Event</summary>
        event ControlEventHandlers.ClickButtonChooseEventHandler ClickButtonChooseEvent;
        /// <summary>Key Hook functionality</summary>
        IKeyHook KeyHook { get; set; }

        /// <summary>Store old control type</summary>
        UserControlTypes OldControl { get; set; }

        /// <summary>
        /// Use for set visibilities for label MoreItems
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="advancedListType"></param>
        void SetLblMoreItemsVisibility(bool visible, AdvancedListTypes advancedListType);

        /// <summary>
        /// Use for clear Language Items
        /// </summary>
        void ClearListItems(AdvancedListTypes advancedListType);

        /// <summary>
        /// Use for add new item to Advanced Item component
        /// </summary>
        /// <param name="advancedItem">Advanced Item object</param>
        void SetItemToAdvancedItem(AdvancedItem advancedItem, int itemSlotID,
            AdvancedListTypes advancedListType);

        /// <summary>
        /// Use for Set Empty Item
        /// </summary>
        /// <param name="itemSlotID">Item Slot ID</param>
        /// <param name="advancedListType">Advanced List Type</param>
        void SetEmptyItem(int itemSlotID, AdvancedListTypes advancedListType);
    
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