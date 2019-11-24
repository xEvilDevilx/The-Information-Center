namespace IC.Client.DataLayer
{
    /// <summary>
    /// Store all Client System translations
    /// 
    /// 2017/03/16 - Created, VTyagunov
    /// </summary>
    public class SystemTranslationData
    {
        /// <summary>Button Up name</summary>
        public string BtnUpText { get; set; }
        /// <summary>Button Down name</summary>
        public string BtnDownText { get; set; }
        /// <summary>Button Settings name</summary>
        public string BtnSettingsText { get; set; }
        /// <summary>Button Shares name</summary>
        public string BtnSharesText { get; set; }
        
        /// <summary>Settings Label name</summary>
        public string LblSettingsText { get; set; }
        /// <summary>Button Language name</summary>
        public string BtnLang { get; set; }
        /// <summary>Button Currency name</summary>
        public string BtnCurrency { get; set; }
        /// <summary>Button Choose name</summary>
        public string BtnChooseText { get; set; }
        /// <summary>Button Cancel name</summary>
        public string BtnCancelText { get; set; }
        
        /// <summary>Vendor Code Label name</summary>
        public string LblVendorCodeText { get; set; }
        /// <summary>BarCode Label name</summary>
        public string LblBarCodeText { get; set; }
        /// <summary>Price Label name</summary>
        public string LblPriceText { get; set; }
        
        /// <summary>Button Back name</summary>
        public string BtnBackText { get; set; }
        
        /// <summary>Scan Bar Code Label text</summary>
        public string LblScanBarCodeText { get; set; }
        
        /// <summary>Shares And Sales Label name</summary>
        public string LblSharesAndSalesText { get; set; }
        
        /// <summary>Product Not Found In DB Label text</summary>
        public string LblProductNotFoundInDBText { get; set; }
    }
}