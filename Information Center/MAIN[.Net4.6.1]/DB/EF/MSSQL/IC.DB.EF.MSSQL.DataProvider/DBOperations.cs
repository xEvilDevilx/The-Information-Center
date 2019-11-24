using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using IC.Client.DataLayer;
using IC.DB.Base;
using IC.DB.DataLayer;
using IC.DB.Interfaces;
using IC.SDK;
using IC.SDK.Base.Constants;

namespace IC.DB.EF.MSSQL.DataProvider
{
    /// <summary>
    /// Implements the DB Operations functionality
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    public class DBOperations : IICDBOperations
    {
        #region Variables

        /// <summary>Flag for IDisposable pattern</summary>
        private bool _disposed = false;
        /// <summary>Activity status</summary>
        private const int _notActive = 0;
        /// <summary>Presents DB Context</summary>
        private readonly ICDBModel _context;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public DBOperations()
        {
            Logger.Log.Debug("DBOperations. Ctr. Enter");

            _context = new ICDBModel();

            Logger.Log.Debug("DBOperations. Ctr. Exit");
        }

        #endregion

        #region Destructors

        /// <summary>
        /// Destructor
        /// </summary>
        ~DBOperations()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

        #region IDisposable implementation

        /// <summary>
        /// Implements IDisposable interface
        /// </summary>
        public void Dispose()
        {
            Logger.Log.Debug("DBOperations. Dispose. Enter");

            Dispose(true);
            GC.SuppressFinalize(this);

            Logger.Log.Debug("DBOperations. Dispose. Exit");
        }

        /// <summary>
        /// Implements IDisposable interface
        /// </summary>
        /// <param name="disposing">Flag shows is need dispose or not need</param>
        protected virtual void Dispose(bool disposing)
        {
            Logger.Log.Debug("DBOperations. Dispose. Enter");

            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();

                _disposed = true;
            }

            Logger.Log.Debug("DBOperations. Dispose. Exit");
        }

        #endregion

        #region IICDBOperations implementation

        /// <summary>
        /// Use for Set active status of the Terminal by IP address
        /// </summary>
        /// <param name="ip">Terminal IP Address</param>
        /// <param name="status">Active status of the Terminal</param>
        public void SetTerminalActiveStatus(string ip, byte status)
        {
            Logger.Log.Debug("DBOperations. SetTerminalActiveStatus. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. SetTerminalsNonActiveStatus. Database is not exists!");

            var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
            terminal.OnlineStatus = status;
            _context.SaveChanges();

            Logger.Log.Debug("DBOperations. SetTerminalActiveStatus. Exit");
        }
        
        /// <summary>
        /// Use for Set Non Active status for all Terminals
        /// </summary>
        public void SetTerminalsNonActiveStatus()
        {
            Logger.Log.Debug("DBOperations. SetTerminalsNonActiveStatus. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. SetTerminalsNonActiveStatus. Database is not exists!");

            var terminalList = _context.Terminal.ToList();
            foreach (var device in terminalList)
                device.OnlineStatus = 0;
            _context.SaveChanges();
            
            Logger.Log.Debug("DBOperations. SetTerminalsNonActiveStatus. Exit");
        }

        /// <summary>
        /// Use for Get Terminal information object by IP addresas
        /// </summary>
        /// <param name="ip">IP addresas string</param>
        /// <returns></returns>
        public T GetTerminal<T>(string ip)
        {
            Logger.Log.Debug("DBOperations. GetTerminal. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. GetTerminal. Database is not exists!");

            var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
            
            Logger.Log.Debug("DBOperations. GetTerminal. Exit");
            return (T)(object)terminal;
        }

        /// <summary>
        /// Use for Get Currency Rate
        /// </summary>
        /// <typeparam name="T">CurrencyRate type</typeparam>
        /// <param name="storeID">Store ID</param>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns></returns>
        public T GetCurrencyRate<T>(string storeID, string currencyCode)
        {
            Logger.Log.Debug("DBOperations. GetCurrencyRate. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. GetCurrencyRate. Database is not exists!");

            var currencyRate = _context.CurrencyRate.Where(s => (s.CurrencyCode == currencyCode) 
            && (s.StoreID == storeID)).FirstOrDefault();

            Logger.Log.Debug("DBOperations. GetCurrencyRate. Exit");
            return (T)(object)currencyRate;
        }

        /// <summary>
        /// Use for Update Currency Rate
        /// </summary>
        /// <typeparam name="T">CurrencyRate type</typeparam>
        /// <param name="t">T type object</param>
        public void UpdateCurrencyRate<T>(T t) where T : class
        {
            Logger.Log.Debug("DBOperations. UpdateCurrencyRate. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. UpdateCurrencyRate. Database is not exists!");

            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();

            Logger.Log.Debug("DBOperations. UpdateCurrencyRate. Exit");
        }

        /// <summary>
        /// Use for Get Store Currency Config List from db
        /// </summary>
        /// <typeparam name="T">Config type</typeparam>
        /// <returns></returns>
        public List<T> GetStoreCurrencyConfigList<T>()
        {
            Logger.Log.Debug("DBOperations. GetStoreConfigList. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. GetStoreConfigList. Database is not exists!");

            var storeConfigList = _context.Config.Where(s => (s.ConfigID == 2)).ToList();

            Logger.Log.Debug("DBOperations. GetStoreConfigList. Exit");
            return (List<T>)(object)storeConfigList;
        }

        /// <summary>
        /// Use for Get Store List from db
        /// </summary>
        /// <typeparam name="T">Store type</typeparam>
        /// <returns></returns>
        public List<T> GetStoreList<T>()
        {
            Logger.Log.Debug("DBOperations. GetStoreList. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. GetStoreList. Database is not exists!");

            var storeList = _context.Store.ToList();

            Logger.Log.Debug("DBOperations. GetStoreList. Exit");
            return (List<T>)(object)storeList;
        }

        #endregion

        #region IDBOperations implementation

        /// <summary>
        /// Use for Add T object to the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        public void Add<T>(QueryData<T> queryData) where T : class
        {
            Logger.Log.Debug("DBOperations. Add. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. Add. Database is not exists!");

            if (queryData is QueryData<EventLog>)
            {
                var castedQuery = queryData as QueryData<EventLog>;
                AddEventLog(castedQuery);
            }
            else if (queryData is QueryData<ProductLog>)
            {
                var castedQuery = queryData as QueryData<ProductLog>;
                AddLogItemScan(castedQuery);
            }
            else if (queryData is QueryData<CurrencyRate>)
            {
                var castedQuery = queryData as QueryData<CurrencyRate>;
                AddCurrencyRate(castedQuery);
            }

            Logger.Log.Debug("DBOperations. Add. Exit");
        }

        /// <summary>
        /// Use for Get T object from the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        /// <returns></returns>
        public T Get<T>(QueryData<T> queryData) where T : class
        {
            Logger.Log.Debug("DBOperations. Get. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. Get. Database is not exists!");

            if (queryData is QueryData<SystemTranslationData>)
            {
                var castedQuery = queryData as QueryData<SystemTranslationData>;
                var systemTranslationData = GetClientSystemLocalization(castedQuery);
                return (T)(object)systemTranslationData;
            }
            else if (queryData is QueryData<DefaultLangCurr>)
            {
                var castedQuery = queryData as QueryData<DefaultLangCurr>;
                var defaultLangCurr = GetDefaultLangCurr(castedQuery);
                return (T)(object)defaultLangCurr;
            }
            else if (queryData is QueryData<ProductInfoData>)
            {
                var castedQuery = queryData as QueryData<ProductInfoData>;
                var productInfoData = GetProductInfoData(castedQuery);
                return (T)(object)productInfoData;
            }
            else if (queryData is QueryData<List<AdvertisingData>>)
            {
                var castedQuery = queryData as QueryData<List<AdvertisingData>>;
                var advertisingDataList = GetAdvertisingInfoList(castedQuery);
                return (T)(object)advertisingDataList;
            }
            else if (queryData is QueryData<List<SharesSalesData>>)
            {
                var castedQuery = queryData as QueryData<List<SharesSalesData>>;
                var sharesSalesDataList = GetRetailActionInfoList(castedQuery);
                return (T)(object)sharesSalesDataList;
            }
            else if (queryData is QueryData<List<LanguageData>>)
            {
                var castedQuery = queryData as QueryData<List<LanguageData>>;
                var languageDataList = GetLanguageDataList(castedQuery);
                return (T)(object)languageDataList;
            }
            else if (queryData is QueryData<List<CurrencyData>>)
            {
                var castedQuery = queryData as QueryData<List<CurrencyData>>;
                var currencyDataList = GetCurrencyDataList(castedQuery);
                return (T)(object)currencyDataList;
            }
            else if (queryData is QueryData<LogoData>)
            {
                var castedQuery = queryData as QueryData<LogoData>;
                var logoData = GetStoreLogo(castedQuery);
                return (T)(object)logoData;
            }

            Logger.Log.Debug("DBOperations. Get. Exit");

            return null;
        }

        /// <summary>
        /// Use for Update T object in the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        public void Remove<T>(QueryData<T> queryData) where T : class
        {
            Logger.Log.Debug("DBOperations. Remove. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. Remove. Database is not exists!");
            
            Logger.Log.Debug("DBOperations. Remove. Exit");
        }

        /// <summary>
        /// Use for Remove T object from the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        public void Update<T>(QueryData<T> queryData) where T : class
        {
            Logger.Log.Debug("DBOperations. Update. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. Update. Database is not exists!");
            
            Logger.Log.Debug("DBOperations. Update. Exit");
        }

        #region Add

        /// <summary>
        /// Use for Log Information to database
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        public void AddCurrencyRate(QueryData<CurrencyRate> queryData)
        {
            Logger.Log.Debug("DBOperations. AddCurrencyRate. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. AddCurrencyRate. Database is not exists!");

            try
            {
                var currencyRateObject = queryData.QueryObject;
                _context.CurrencyRate.Add(currencyRateObject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. AddCurrencyRate.", ex);
                throw;
            }

            Logger.Log.Debug("DBOperations. AddCurrencyRate. Exit");
        }

        /// <summary>
        /// Use for Log Information to database
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        public void AddEventLog(QueryData<EventLog> queryData)
        {
            Logger.Log.Debug("DBOperations. AddEventLog. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. AddEventLog. Database is not exists!");

            try
            {
                var eventObject = queryData.QueryObject;
                _context.EventLog.Add(eventObject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. AddEventLog.", ex);
                throw;
            }

            Logger.Log.Debug("DBOperations. AddEventLog. Exit");
        }

        /// <summary>
        /// Use for write log of product request to db
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        private void AddLogItemScan(QueryData<ProductLog> queryData)
        {
            Logger.Log.Debug("DBOperations. AddLogItemScan. Enter");

            if (!_context.Database.Exists())
                throw new Exception("DBOperations. AddLogItemScan. Database is not exists!");

            try
            {
                var itemLog = queryData.QueryObject;
                _context.ProductLog.Add(itemLog);
                _context.SaveChanges();

                Logger.Log.Debug("DBOperations. AddLogItemScan. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. AddLogItemScan.", ex);
                throw;
            }
        }

        #endregion

        #region Get

        /// <summary>
        /// Use for Get SystemTranslationData from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private SystemTranslationData GetClientSystemLocalization(QueryData<SystemTranslationData> queryData)
        {
            Logger.Log.Debug("DBOperations. GetClientSystemLocalization. Enter");

            try
            {
                var systemTranslationData = new SystemTranslationData();
                var language = GetLanguage(queryData);
                var translationList = _context.SystemTranslation.
                    Where(x => x.LanguageCode == language).ToList();

                for (int i = 0; i < translationList.Count; i++)
                {
                    switch (translationList[i].TranslationID)
                    {
                        case SystemTranslationConstants.BtnBackText:
                            systemTranslationData.BtnBackText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnCancelText:
                            systemTranslationData.BtnCancelText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnChooseText:
                            systemTranslationData.BtnChooseText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnCurrencyText:
                            systemTranslationData.BtnCurrency = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnDownText:
                            systemTranslationData.BtnDownText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnLangText:
                            systemTranslationData.BtnLang = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnSettingsText:
                            systemTranslationData.BtnSettingsText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnSharesText:
                            systemTranslationData.BtnSharesText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.BtnUpText:
                            systemTranslationData.BtnUpText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.LblBarCodeText:
                            systemTranslationData.LblBarCodeText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.LblSettingsText:
                            systemTranslationData.LblSettingsText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.LblPriceText:
                            systemTranslationData.LblPriceText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.LblProductNotFoundInDBText:
                            systemTranslationData.LblProductNotFoundInDBText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.LblScanBarCodeText:
                            systemTranslationData.LblScanBarCodeText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.LblSharesAndSalesText:
                            systemTranslationData.LblSharesAndSalesText = translationList[i].TranslationValue;
                            break;
                        case SystemTranslationConstants.LblVendorCodeText:
                            systemTranslationData.LblVendorCodeText = translationList[i].TranslationValue;
                            break;
                    }
                }

                Logger.Log.Debug("DBOperations. GetClientSystemLocalization. Exit");

                return systemTranslationData;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetClientSystemLocalization. ", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Get Default Language and Currency data from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private DefaultLangCurr GetDefaultLangCurr(QueryData<DefaultLangCurr> queryData)
        {
            Logger.Log.Debug("DBOperations. GetDefaultLangCurr. Enter");

            try
            {
                var language = GetLanguage(queryData);
                var currency = GetCurrency(queryData);
                var defaultLangCurr = new DefaultLangCurr()
                {
                    Language = language,
                    Currency = currency
                };

                Logger.Log.Debug("DBOperations. GetDefaultLangCurr. Exit");

                return defaultLangCurr;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetDefaultLangCurr. ", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Get Product Info data from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private ProductInfoData GetProductInfoData(QueryData<ProductInfoData> queryData)
        {
            Logger.Log.Debug("DBOperations. GetProductInfoData. Enter");

            try
            {
                var productInfoObject = new ProductInfoData();
                var strArray = queryData.QueryParams.Split(BaseConstants.TypeSplitter, StringSplitOptions.None);
                var barcode = strArray[0];
                var language = strArray[1];
                var currency = strArray[2];
                var currencyQuery = new QueryData<Currency>()
                {
                    ClientIP = queryData.ClientIP,
                    QueryParams = ""
                };
                var storeCurrency = GetCurrency(currencyQuery);

                if (string.IsNullOrEmpty(language))
                {
                    queryData.QueryParams = "";
                    language = GetLanguage(queryData);
                }

                if (string.IsNullOrEmpty(currency))
                    currency = storeCurrency;

                var ip = queryData.ClientIP.ToString();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                var product = _context.Product.Where(x => x.BarcodeValue == barcode).First();

                if (product == null)
                    return GetProductNotFound();

                var productLogQueryData = new QueryData<ProductLog>()
                {
                    QueryObject = new ProductLog()
                    {
                        CurrencyCode = currency,
                        LanguageCode = language,
                        ProductID = product.ProductID,
                        ScanDate = DateTime.Now,
                        TerminalID = terminal.TerminalID
                    }
                };
                Add(productLogQueryData);

                productInfoObject.TextBoxBarCode = product.BarcodeValue;
                productInfoObject.TextBoxVendorCode = product.Article;

                var captionTranslation = _context.ContentTranslation.
                    Where(x => ((x.TranslationID == product.CaptionID) && (x.LanguageCode == language))).First();
                productInfoObject.TextBoxProductName = captionTranslation.TranslationValue;

                var translationDesription = _context.ContentTranslation.
                    Where(x => ((x.TranslationID == product.DescriptionID) && (x.LanguageCode == language))).First();
                productInfoObject.TextBoxProductInfo = translationDesription.TranslationValue;

                if (product.Image != null)
                    productInfoObject.PictureBoxProductImage = product.Image;

                var productPriceArray = _context.ProductPrice.
                    Where(x => ((x.ProductID == product.ProductID) && (x.StoreID == terminal.StoreID) &&
                    (x.DateBegin <= DateTime.Now))).ToArray();
                var lastData = productPriceArray.Max(x => x.DateBegin);
                var actualProduct = productPriceArray.First(x => x.DateBegin == lastData);

                var currencyRateArray = _context.CurrencyRate.
                    Where(x => (x.CurrencyCode == currency)&&(x.StoreID == terminal.StoreID)).ToArray();
                var maxDateBegin = currencyRateArray.Max(x => x.DateBegin);
                var currencyRate = currencyRateArray.First(x => x.DateBegin == maxDateBegin);

                if (storeCurrency == "EUR")
                {
                    productInfoObject.TextBoxPrice = (actualProduct.PriceValue *
                        currencyRate.RateValue).ToString("F");
                }
                else if (storeCurrency == "RUB")
                {
                    productInfoObject.TextBoxPrice = (actualProduct.PriceValue /
                        currencyRate.RateValue).ToString("F");
                }
                productInfoObject.TextBoxPrice += currency;

                var productActions = _context.ProductAction.Where(x => x.ProductID == product.ProductID);
                productInfoObject.ProductSharesNames = "";
                productInfoObject.ProductSharesDesriptions = "";
                foreach (var productAction in productActions)
                {
                    var retailAction = _context.RetailAction.
                        Where(x => x.RetailActionID == productAction.RetailActionID).First();
                    if ((retailAction.AccessStatus != _notActive) &&
                        (((DateTime)retailAction.DateEnd).CompareTo(DateTime.Now) >= 0))
                    {
                        var retailActionTranslationCaption = _context.ContentTranslation.
                            Where(x => ((x.TranslationID == retailAction.CaptionID) && (x.LanguageCode == language))).First();
                        productInfoObject.ProductSharesNames += retailActionTranslationCaption.TranslationValue +
                            BaseConstants.TypeSplitter[0];

                        var retailActionTranslationDescription = _context.ContentTranslation.
                            Where(x => ((x.TranslationID == retailAction.DescriptionID) && (x.LanguageCode == language))).First();
                        productInfoObject.ProductSharesDesriptions += retailActionTranslationDescription.TranslationValue +
                            BaseConstants.TypeSplitter[0];
                    }
                }

                if (!string.IsNullOrEmpty(productInfoObject.ProductSharesNames))
                    productInfoObject.ProductSharesNames = productInfoObject.ProductSharesNames.
                        Remove(productInfoObject.ProductSharesNames.Length -
                        BaseConstants.TypeSplitter[0].Length);
                if (!string.IsNullOrEmpty(productInfoObject.ProductSharesDesriptions))
                    productInfoObject.ProductSharesDesriptions =
                        productInfoObject.ProductSharesDesriptions.
                        Remove(productInfoObject.ProductSharesDesriptions.Length -
                        BaseConstants.TypeSplitter[0].Length);

                Logger.Log.Debug("DBOperations. GetProductInfoData. Exit");

                return productInfoObject;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetProductInfoData. ", ex);
                return GetProductNotFound();
            }
        }

        /// <summary>
        /// Use for Get Product Info Data object with Product Not Found status
        /// </summary>
        /// <returns></returns>
        private ProductInfoData GetProductNotFound()
        {
            Logger.Log.Debug("DBOperations. GetProductNotFound. Enter");

            var productInfoObject = new ProductInfoData()
            {
                PictureBoxProductImage = new byte[0],
                ProductSharesDesriptions = "",
                ProductSharesNames = "",
                TextBoxBarCode = "",
                TextBoxPrice = "",
                TextBoxProductInfo = "",
                TextBoxProductName = "",
                TextBoxVendorCode = ""
            };

            Logger.Log.Debug("DBOperations. GetProductNotFound. Exit");

            return productInfoObject;
        }

        /// <summary>
        /// Use for Get Advertising data from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private List<AdvertisingData> GetAdvertisingInfoList(QueryData<List<AdvertisingData>> queryData)
        {
            Logger.Log.Debug("DBOperations. GetAdvertisingInfoList. Enter");

            try
            {
                var advertisingDataList = new List<AdvertisingData>();
                var ip = queryData.ClientIP.ToString();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                var terminalAdArray = _context.StoreAdvertising.
                    Where(x => (x.TerminalID == terminal.TerminalID) &&
                    (x.StoreID == terminal.StoreID)).ToArray();

                foreach (var terminalAd in terminalAdArray)
                {
                    var ad = _context.Advertising.
                        Where(x => x.AdvertisingID == terminalAd.AdvertisingID).FirstOrDefault();
                    if ((ad != null) && (ad.AccessStatus != _notActive))
                    {
                        var advertisingData = new AdvertisingData()
                        {
                            Picture = ad.Image
                        };
                        advertisingDataList.Add(advertisingData);
                    }
                }

                Logger.Log.Debug("DBOperations. GetAdvertisingInfoList. Exit");

                return advertisingDataList;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetAdvertisingInfoList.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Get Retail Action data from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private List<SharesSalesData> GetRetailActionInfoList(QueryData<List<SharesSalesData>> queryData)
        {
            Logger.Log.Debug("DBOperations. GetRetailActionInfoList. Enter");

            try
            {
                var sharesSalesDataList = new List<SharesSalesData>();
                var language = GetLanguage(queryData);
                var ip = queryData.ClientIP.ToString();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                var storeActions = _context.StoreAction.Where(x => x.StoreID == terminal.StoreID).ToArray();
                if (storeActions != null)
                {
                    for (int i = 0; i < storeActions.Length; i++)
                    {
                        var retailActionID = storeActions[i].RetailActionID;
                        var retailAction = _context.RetailAction.
                            Where(x => ((x.RetailActionID == retailActionID) &&
                            (x.DateBegin <= DateTime.Now) && ((x.DateEnd >= DateTime.Now) &&
                            (x.AccessStatus != _notActive)))).FirstOrDefault();
                        var sharesSalesData = new SharesSalesData();
                        sharesSalesData.SharesID = retailActionID;
                        var translationCaption = _context.ContentTranslation.
                            Where(x => ((x.TranslationID == retailAction.CaptionID) &&
                            (x.LanguageCode == language))).First();

                        sharesSalesData.ShareName = translationCaption.TranslationValue;

                        var translationDescription = _context.ContentTranslation.
                            Where(x => (x.TranslationID == retailAction.DescriptionID &&
                                x.LanguageCode == language)).First();
                        sharesSalesData.ShareDesription = translationDescription.TranslationValue;

                        sharesSalesDataList.Add(sharesSalesData);
                    }
                }

                Logger.Log.Debug("DBOperations. GetRetailActionInfoList. Exit");

                return sharesSalesDataList;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetRetailActionInfoList.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Get language data from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private List<LanguageData> GetLanguageDataList(QueryData<List<LanguageData>> queryData)
        {
            Logger.Log.Debug("DBOperations. GetLanguageDataList. Enter");

            try
            {
                var languageDataList = new List<LanguageData>();
                var language = GetLanguage(queryData);
                var ip = queryData.ClientIP.ToString();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                var terminalLanguages = _context.TerminalLanguage.
                    Where(x => (x.TerminalID == terminal.TerminalID) &&
                    (x.StoreID == terminal.StoreID)).ToArray();

                foreach (var terminalLanguage in terminalLanguages)
                {
                    var languageData = new LanguageData()
                    {
                        LanguageCode = terminalLanguage.LanguageCode
                    };
                    var languageRow = _context.Language.
                        Where(x => x.LanguageCode == terminalLanguage.LanguageCode).First();
                    if ((languageRow.CaptionID != 0) && (languageRow.Image != null))
                    {
                        var translation = _context.ContentTranslation.
                            Where(x => (x.TranslationID == languageRow.CaptionID &&
                            x.LanguageCode == language)).First();
                        languageData.LanguageText = translation.TranslationValue;
                        languageData.LanguagePicture = languageRow.Image;

                        languageDataList.Add(languageData);
                    }
                }

                Logger.Log.Debug("DBOperations. GetLanguageDataList. Exit");

                return languageDataList;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetLanguageDataList.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Get Currency data from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private List<CurrencyData> GetCurrencyDataList(QueryData<List<CurrencyData>> queryData)
        {
            Logger.Log.Debug("DBOperations. GetCurrencyDataList. Enter");

            try
            {
                var currencyDataList = new List<CurrencyData>();
                var language = GetLanguage(queryData);
                var ip = queryData.ClientIP.ToString();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                var terminalCurrencies = _context.TerminalCurrency.
                    Where(x => (x.TerminalID == terminal.TerminalID) &&
                    (x.StoreID == terminal.StoreID)).ToArray();

                foreach (var terminalCurrency in terminalCurrencies)
                {
                    var currencyData = new CurrencyData()
                    {
                        CurrencyCode = terminalCurrency.CurrencyCode
                    };
                    var currency = _context.Currency.
                        Where(x => x.CurrencyCode == terminalCurrency.CurrencyCode).First();
                    if ((currency.CaptionID != 0) && (currency.Image != null))
                    {
                        var translation = _context.ContentTranslation.
                            Where(x => (x.TranslationID == currency.CaptionID &&
                            x.LanguageCode == language)).First();
                        currencyData.CurrencyText = translation.TranslationValue;
                        currencyData.CurrencyPicture = currency.Image;

                        currencyDataList.Add(currencyData);
                    }
                }

                Logger.Log.Debug("DBOperations. GetCurrencyDataList. Exit");

                return currencyDataList;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetCurrencyDataList.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Get Logo image from DB
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        /// <returns></returns>
        private LogoData GetStoreLogo(QueryData<LogoData> queryData)
        {
            Logger.Log.Debug("DBOperations. GetStoreLogo. Enter");

            try
            {
                var logoData = new LogoData();
                var ip = queryData.ClientIP.ToString();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                var store = _context.Store.Where(x => x.StoreID == terminal.StoreID).First();
                if (store.Image != null)
                    logoData.LogoPicture = store.Image;

                Logger.Log.Debug("DBOperations. GetStoreLogo. Exit");

                return logoData;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetStoreLogo.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for get actual language from client query
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        /// <returns></returns>
        private string GetLanguage<T>(QueryData<T> queryData) where T : class
        {
            Logger.Log.Debug("DBOperations. GetLanguage. Enter");

            string language;
            try
            {
                if (string.IsNullOrEmpty(queryData.QueryParams))
                {
                    var ip = queryData.ClientIP.ToString();
                    var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                    var config = _context.Config.Where(x => ((x.ConfigID == 1) &&
                    (x.StoreID == terminal.StoreID))).First();
                    language = config.ConfigValue;
                }
                else language = queryData.QueryParams;

                Logger.Log.Debug("DBOperations. GetLanguage. Enter");
                return language;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetLanguage.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for get actual currency from client query
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        /// <returns></returns>
        private string GetCurrency<T>(QueryData<T> queryData) where T : class
        {
            Logger.Log.Debug("DBOperations. GetCurrency. Enter");

            string currency;
            try
            {
                if (string.IsNullOrEmpty(queryData.QueryParams))
                {
                    var ip = queryData.ClientIP.ToString();
                    var terminal = _context.Terminal.Where(x => x.IPAddress == ip).First();
                    var config = _context.Config.Where(x => ((x.ConfigID == 2) &&
                    (x.StoreID == terminal.StoreID))).First();
                    currency = config.ConfigValue;
                }
                else currency = queryData.QueryParams;

                Logger.Log.Debug("DBOperations. GetCurrency. Exit");
                return currency;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("DBOperations. GetCurrency.", ex);
                throw;
            }
        }

        #endregion

        #region Remove

        #endregion

        #region Update

        #endregion

        #endregion

        #endregion
    }
}