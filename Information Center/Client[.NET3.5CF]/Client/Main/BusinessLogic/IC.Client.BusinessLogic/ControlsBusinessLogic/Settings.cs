using System;
using System.Drawing;
using System.IO;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic;
using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Components;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.Components;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.SDK;
using IC.SDK.Base;

namespace IC.Client.BusinessLogic.ControlsBusinessLogic
{
    /// <summary>
    /// Settings business logic
    /// 
    /// 2017/02/27 - Created, VTyagunov
    /// </summary>
    public class Settings : ISettings
    {
        #region Events

        /// <summary>Send Language and Currency Data Event</summary>
        public event ControlEventHandlers.SendLangCurrDataEventHandler SendLangCurrDataEvent;

        #endregion

        #region Variables

        /// <summary>Presents Business Logic entry</summary>
        private IBusinessLogicEntry _businessLogicEntry;
        /// <summary>Presents PluginManager work</summary>
        private IPluginManager _pluginManager;
        /// <summary>Settings control</summary>
        private ISettingsControl _settingsControl;
        /// <summary>Settings control timeout timer</summary>
        private System.Threading.Timer _timer;
        /// <summary>Currency List</summary>
        private IAdvancedList _currencyList;
        /// <summary>Language List</summary>
        private IAdvancedList _languageList;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="businessLogicEntry">Business Logic Entry object</param>
        /// <param name="pluginManager">Plugin Manager object</param>
        public Settings(IBusinessLogicEntry businessLogicEntry, IPluginManager pluginManager)
        {
            Logger.Log.Debug("Settings. Ctr. Enter");

            if (businessLogicEntry == null)
                throw new ArgumentNullException("businessLogicEntry");

            if (pluginManager == null)
                throw new ArgumentNullException("pluginManager");

            _businessLogicEntry = businessLogicEntry;
            _pluginManager = pluginManager;
            _settingsControl =
                (ISettingsControl)_pluginManager.ControlsDictionary[UserControlTypes.Settings];
            _settingsControl.KeyHook = _pluginManager.KeyHook;
            _settingsControl.ClickControlEvent += ResetTimer;
            _settingsControl.ClickButtonCancelEvent += () => { ShowOldControl(null); };
            _settingsControl.ClickButtonLanguageEvent += ButtonLanguage;
            _settingsControl.ClickButtonCurrencyEvent += ButtonCurrency;
            _settingsControl.ClickButtonChooseEvent += ButtonChoose;
            _currencyList = new AdvancedList(_settingsControl, AdvancedListTypes.Currency);
            _languageList = new AdvancedList(_settingsControl, AdvancedListTypes.Language);

            Logger.Log.Debug("Settings. Ctr. Exit");
        }

        #endregion

        #region Methods

        #region IControlBusinessLogic

        /// <summary>
        /// Use for show control
        /// </summary>
        public void ShowControl()
        {
            Logger.Log.Debug("ShowControl. Enter");

            StartTimer();
            _pluginManager.ShowControl(UserControlTypes.Settings);

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            Logger.Log.Debug("HideControl. Enter");

            StopTimer();
            _pluginManager.HideControl(UserControlTypes.Settings);

            Logger.Log.Debug("HideControl. Exit");
        }

        /// <summary>
        /// Use for Show Last control
        /// </summary>
        public void ShowLastControl()
        {
            Logger.Log.Debug("ShowLastControl. Enter");

            _businessLogicEntry.ShowLastControl();

            Logger.Log.Debug("ShowLastControl. Exit");
        }

        #endregion

        #region Timers

        /// <summary>
        /// Use for start Settings control timer
        /// </summary>
        private void StartTimer()
        {
            Logger.Log.Debug("StartTimer. Enter");

            _timer = new System.Threading.Timer(ShowOldControl, null,
                BaseConstants.CloseControlTimeOutValue, 0);

            Logger.Log.Debug("StartTimer. Exit");
        }

        /// <summary>
        /// Use for stop Settings control timer
        /// </summary>
        private void StopTimer()
        {
            Logger.Log.Debug("StopTimer. Enter");

            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }

            Logger.Log.Debug("StopTimer. Exit");
        }

        /// <summary>
        /// Use for reset Settings control timer
        /// </summary>
        private void ResetTimer()
        {
            Logger.Log.Debug("ResetTimer. Enter");

            StopTimer();
            StartTimer();

            Logger.Log.Debug("ResetTimer. Exit");
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Use for to do action of button Language
        /// </summary>
        private void ButtonLanguage()
        {
            Logger.Log.Debug("ButtonLanguage. Enter");

            ResetTimer();
            _languageList.MoveItems();

            Logger.Log.Debug("ButtonLanguage. Exit");
        }

        /// <summary>
        /// Use for to do action of button Currency
        /// </summary>
        private void ButtonCurrency()
        {
            Logger.Log.Debug("ButtonCurrency. Enter");

            ResetTimer();
            _currencyList.MoveItems();

            Logger.Log.Debug("ButtonCurrency. Exit");
        }

        /// <summary>
        /// Use for do action of button Choose
        /// </summary>
        private void ButtonChoose()
        {
            Logger.Log.Debug("ButtonChoose. Enter");

            var selectedCurrency = _currencyList.GetSelectedItem();
            var selectedCurrencyCode = selectedCurrency.Code;
            if (selectedCurrencyCode == null)
                selectedCurrencyCode = "";

            var selectedLanguage = _languageList.GetSelectedItem();
            var selectedLanguageCode = selectedLanguage.Code;
            if (selectedLanguage == null)
                selectedLanguageCode = "";

            if (SendLangCurrDataEvent != null)
                SendLangCurrDataEvent.Invoke(selectedCurrencyCode, selectedLanguageCode, true);

            Logger.Log.Debug("ButtonChoose. Exit");
        }

        #endregion

        /// <summary>
        /// Use for add new item to Language ListView
        /// </summary>
        /// <param name="languageData">Language Data object</param>
        public void AddItemToLanguageListView(LanguageData languageData)
        {
            Logger.Log.Debug("AddItemToLanguageListView. Enter");

            if (languageData == null)
            {
                Logger.Log.Warn("AddItemToLanguageListView. LanguageData is null");
                return;
            }

            try
            {
                AdvancedItem item;
                if (languageData.LanguagePicture != null)
                {
                    var imageStream = new MemoryStream(languageData.LanguagePicture);
                    var image = new Bitmap(imageStream);
                    item = new AdvancedItem()
                    {
                        Code = languageData.LanguageCode,
                        ItemName = languageData.LanguageText,
                        ItemImage = image
                    };
                }
                else
                {
                    item = new AdvancedItem()
                    {
                        Code = languageData.LanguageCode,
                        ItemName = languageData.LanguageText
                    };
                }

                _languageList.AddItem(item);
                
                Logger.Log.Debug("AddItemToLanguageListView. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("AddItemToLanguageListView.", ex);
            }
        }

        /// <summary>
        /// Use for add new item to Currency ListView
        /// </summary>
        /// <param name="currencyData">Currency Data object</param>
        public void AddItemToCurrencyListView(CurrencyData currencyData)
        {
            Logger.Log.Debug("AddItemToCurrencyListView. Enter");

            if (currencyData == null)
            {
                Logger.Log.Warn("AddItemToCurrencyListView. CurrencyData is null");
                return;
            }

            try
            {
                AdvancedItem item;
                if (currencyData.CurrencyPicture != null)
                {
                    var imageStream = new MemoryStream(currencyData.CurrencyPicture);
                    var image = new Bitmap(imageStream);
                    item = new AdvancedItem()
                    {
                        Code = currencyData.CurrencyCode,
                        ItemName = currencyData.CurrencyText,
                        ItemImage = image
                    };
                }
                else
                {
                    item = new AdvancedItem()
                    {
                        Code = currencyData.CurrencyCode,
                        ItemName = currencyData.CurrencyText
                    };
                }

                _currencyList.AddItem(item);

                Logger.Log.Debug("AddItemToCurrencyListView. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("AddItemToCurrencyListView", ex);
            }
        }

        /// <summary>
        /// Use for clear currency list
        /// </summary>
        public void ClearCurrencyList()
        {
            Logger.Log.Debug("ClearCurrencyList. Enter");

            _currencyList.ClearList();

            Logger.Log.Debug("ClearCurrencyList. Exit");
        }

        /// <summary>
        /// Use for clear language list
        /// </summary>
        public void ClearLanguageList()
        {
            Logger.Log.Debug("ClearLanguageList. Enter");

            _languageList.ClearList();

            Logger.Log.Debug("ClearLanguageList. Exit");
        }

        /// <summary>
        /// Use for show old control
        /// </summary>
        /// <param name="stateInfo">State info</param>
        private void ShowOldControl(object stateInfo)
        {
            Logger.Log.Debug("ShowOldControl. Enter");

            ShowLastControl();

            Logger.Log.Debug("ShowOldControl. Exit");
        }

        #endregion
    }
}