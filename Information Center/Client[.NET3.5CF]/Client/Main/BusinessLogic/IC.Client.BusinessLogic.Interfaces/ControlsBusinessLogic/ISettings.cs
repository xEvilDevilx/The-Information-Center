using IC.Client.DataLayer;
using IC.Client.FormModel.Base.EventHandlers;

namespace IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic
{
    /// <summary>
    /// Presents Settings Business Logic interface
    /// 
    /// 2017/08/14 - Created, VTyagunov
    /// </summary>
    public interface ISettings : IControlBusinessLogic
    {
        /// <summary>Send Language and Currency Data Event</summary>
        event ControlEventHandlers.SendLangCurrDataEventHandler SendLangCurrDataEvent;

        /// <summary>
        /// Use for add new item to Language ListView
        /// </summary>
        /// <param name="languageData">Language Data object</param>
        void AddItemToLanguageListView(LanguageData languageData);

        /// <summary>
        /// Use for add new item to Currency ListView
        /// </summary>
        /// <param name="currencyData">Currency Data object</param>
        void AddItemToCurrencyListView(CurrencyData currencyData);

        /// <summary>
        /// Use for clear currency list
        /// </summary>
        void ClearCurrencyList();

        /// <summary>
        /// Use for clear language list
        /// </summary>
        void ClearLanguageList();
    }
}