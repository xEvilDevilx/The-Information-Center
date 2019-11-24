namespace IC.Client.Network.Interfaces
{
    /// <summary>
    /// Presents work with data requests interface
    /// 
    /// 2017/01/29 - Created, VTyagunov
    /// </summary>
    public interface INetworkRequests
    {
        /// <summary>
        /// Use for send system date require
        /// </summary>
        void RequireSystemData();

        /// <summary>
        /// Use for send default localization require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <param name="currencyCode">Currency code string</param>
        void RequireDefaultLocalizationData(string languageCode, string currencyCode);

        /// <summary>
        /// Use for send localization require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <returns></returns>
        bool RequireLocalization(string languageCode);

        /// <summary>
        /// Use for send default settings require
        /// </summary>
        /// <returns></returns>
        bool RequireDefaultSettings();

        /// <summary>
        /// Use for send language require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <returns></returns>
        bool RequireLanguage(string languageCode);

        /// <summary>
        /// Use for send currency require
        /// </summary>
        /// <param name="currencyCode">Currency code string</param>
        /// <returns></returns>
        bool RequireCurrency(string currencyCode);

        /// <summary>
        /// Use for send Shares and Sales require
        /// </summary>
        /// <param name="languageCode">Language code string</param>
        /// <returns></returns>
        bool RequireShares(string languageCode);

        /// <summary>
        /// Use for send Product info require
        /// </summary>
        /// <param name="barCodeData">BarCode string</param>
        /// <param name="languageCode">Language code string</param>
        /// <param name="currencyCode">Currency code string</param>
        /// <returns></returns>
        bool RequireProductInfo(string barCodeData, string languageCode, string currencyCode);
    }
}