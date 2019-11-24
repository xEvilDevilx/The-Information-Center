namespace IC.Client.FormModel.Base.EventHandlers
{
    /// <summary>
    /// Store Control EventHandlers
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    public class ControlEventHandlers
    {
        /// <summary>Close Control Event Handler</summary>
        public delegate void CloseControlEventHandler();
        /// <summary>Click Control Event Handler</summary>
        public delegate void ClickControlEventHandler();
        /// <summary>Click Button Up Event Handler</summary>
        public delegate void ClickButtonUpEventHandler();
        /// <summary>Click Button Down Event Handler</summary>
        public delegate void ClickButtonDownEventHandler();
        /// <summary>Click Button Shares Event Handler</summary>
        public delegate void ClickButtonSharesEventHandler();
        /// <summary>Click Button Settings Event Handler</summary>
        public delegate void ClickButtonSettingsEventHandler();
        /// <summary>Click Button Apply Event Handler</summary>
        public delegate void ClickButtonApplyEventHandler();
        /// <summary>Click Button Cancel Event Handler</summary>
        public delegate void ClickButtonCancelEventHandler();
        /// <summary>Click Button Previous Event Handler</summary>
        public delegate void ClickButtonPreviousEventHandler();
        /// <summary>Click Button Next Event Handler</summary>
        public delegate void ClickButtonNextEventHandler();
        /// <summary>Click Button Language Event Handler</summary>
        public delegate void ClickButtonLanguageEventHandler();
        /// <summary>Click Button Currency Event Handler</summary>
        public delegate void ClickButtonCurrencyEventHandler();
        /// <summary>Click Button Choose Event Handler</summary>
        public delegate void ClickButtonChooseEventHandler();
        /// <summary>Click Button Back Event Handler</summary>
        public delegate void ClickButtonBackEventHandler();
        /// <summary>Send Language Currency Data Event Handler</summary>
        /// <param name="currencyCode">Currency Code string</param>
        /// <param name="languageCode">Language Code string</param>
        /// <param name="showOldControl">Flag to show/no show old control</param>
        public delegate void SendLangCurrDataEventHandler(string currencyCode, string languageCode,
            bool showOldControl);
    }
}