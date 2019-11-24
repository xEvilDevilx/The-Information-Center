namespace IC.SDK.Base.Enums
{
    /// <summary>
    /// Presents TCP Serialize Types
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public enum TcpSerializeTypes : byte
    {
        Advertising,
        ClientStatus,
        Config,
        Currency,
        CurrencyRate,
        DBQuery,
        DeleteTable,
        Image,
        Item,
        ItemAction,
        ItemBarcode,
        ItemImage,
        ItemPrice,
        Language,
        NavReplCounters,
        RetailAction,
        Store,
        StoreAdvertising,
        Translation,

        AdvertisingData,
        SystemTranslationData,
        LanguageData,
        CurrencyData,
        LogoData,
        ProductInfoData,
        SharesSalesData,
        DefaultLangCurr,

        LicenseData,
        ClientLicenseData
    }
}