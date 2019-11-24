using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using IC.Client.DataLayer;
using IC.DB.Base;
using IC.DB.DataLayer;
using IC.DB.ICSQL.Base;
using IC.DB.ICSQL.Interfaces;
using IC.DB.Interfaces;
using IC.SDK;
using IC.SDK.Base.Constants;

namespace IC.DB.ICSQL.MSSQL.DataProvider
{
    /// <summary>
    /// Implements work with preparing data and send to client
    /// 
    /// 2017/04/21 - Created, VTyagunov
    /// </summary>
    public class DBOperations : IICDBOperations
    {
        #region Variables

        /// <summary>Flag for IDisposable pattern</summary>
        private bool _disposed = false;
        /// <summary>DB connection string</summary>
        private readonly string _connectionString;
        /// <summary></summary>
        private IDatabase _database;
        /// <summary>Activity status</summary>
        private const int _notActive = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public DBOperations()
        {
            Logger.Log.Debug("DBOperations. Ctr. Enter");

            _connectionString = ConfigurationManager.ConnectionStrings["StoredProcDPConnection"].
                ConnectionString;
            _database = new Database(_connectionString);

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
                    _database = null;

                _disposed = true;
            }

            Logger.Log.Debug("DBOperations. Dispose. Exit");
        }

        #endregion

        #region Execute

        /// <summary>
        /// Use for Execute Non Query
        /// </summary>
        /// <param name="sqlQuery">Sql Query</param>
        private void ExecuteNonQuery(string sqlQuery)
        {
            Logger.Log.Debug("DBOperations. ExecuteNonQuery. Enter");

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            _database.ExecuteNonQuery(sqlQuery);
            _database.Commit();
            _database.CloseConnection();

            Logger.Log.Debug("DBOperations. ExecuteNonQuery. Exit");
        }

        /// <summary>
        /// Use for Execute Query
        /// </summary>
        /// <param name="sqlQuery">Sql Query</param>
        private T Execute<T>(string sqlQuery, Populator<T> populator)
        {
            Logger.Log.Debug("DBOperations. Execute. Enter");

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var obj = _database.Execute<T>(sqlQuery, CommandType.Text, new SqlParameter[0], populator);
            _database.Commit();
            _database.CloseConnection();

            Logger.Log.Debug("DBOperations. Execute. Enter");
            return obj;
        }

        /// <summary>
        /// Use for Execute List Query
        /// </summary>
        /// <param name="sqlQuery">Sql Query</param>
        private List<T> ExecuteList<T>(string sqlQuery, Populator<T> populator) where T : new()
        {
            Logger.Log.Debug("DBOperations. Execute. Enter");

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var obj = _database.ExecuteList<T>(sqlQuery, CommandType.Text, new SqlParameter[0], populator);
            _database.Commit();
            _database.CloseConnection();

            Logger.Log.Debug("DBOperations. Execute. Enter");
            return obj;
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
            
            var query = string.Format("UPDATE [dbo].[Terminal] SET [OnlineStatus] = {0} WHERE [IPAddress] = '{1}'",
                status, ip);
            ExecuteNonQuery(query);

            Logger.Log.Debug("DBOperations. SetTerminalActiveStatus. Exit");
        }

        /// <summary>
        /// Use for Set Non Active status for all Terminals
        /// </summary>
        public void SetTerminalsNonActiveStatus()
        {
            Logger.Log.Debug("DBOperations. SetTerminalsNonActiveStatus. Enter");

            var query = "UPDATE [dbo].[Terminal] SET [OnlineStatus] = 0";
            ExecuteNonQuery(query);

            Logger.Log.Debug("DBOperations. SetTerminalsNonActiveStatus. Exit");
        }

        #region GetTerminal

        /// <summary>
        /// Use for Get Terminal information object by IP addresas
        /// </summary>
        /// <param name="ip">IP addresas string</param>
        /// <returns></returns>
        public T GetTerminal<T>(string ip)
        {
            Logger.Log.Debug("DBOperations. GetTerminal. Enter");

            var query = string.Format("SELECT * FROM [dbo].[Terminal] WHERE [IPAddress]='{0}'", ip);
            var terminal = Execute<Terminal>(query, PopulateTerminal);

            Logger.Log.Debug("DBOperations. GetTerminal. Exit");            
            return (T)(object)terminal;
        }

        /// <summary>
        /// Use for Populate Terminal
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private Terminal PopulateTerminal(SqlDataReader reader)
        {
            return new Terminal()
            {
                StoreID = reader["StoreID"] as string,
                TerminalID = reader["TerminalID"] as string,
                IPAddress = reader["IPAddress"] as string,
                MacAddress = reader["MacAddress"] as string,
                OnlineStatus = (byte)reader["OnlineStatus"],
                TerminalUID = reader["TerminalUID"] as string,
                TerminalVersion = reader["TerminalVersion"] as string
            };
        }

        #endregion

        #region GetCurrencyRate

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

            var query = string.Format("SELECT * FROM [dbo].[CurrencyRate] WHERE [CurrencyCode] = '{0}' AND [StoreID] = '{1}'",
                currencyCode, storeID);
            var currencyRate = Execute<CurrencyRate>(query, PopulateCurrencyRate);
            
            Logger.Log.Debug("DBOperations. GetCurrencyRate. Exit");
            return (T)(object)currencyRate;
        }

        /// <summary>
        /// Use for Populate CurrencyRate
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private CurrencyRate PopulateCurrencyRate(SqlDataReader reader)
        {
            return new CurrencyRate()
            {
                CurrencyCode = reader["CurrencyCode"] as string,
                StoreID = reader["StoreID"] as string,
                DateBegin = (DateTime)reader["DateBegin"],
                RateValue = (decimal)reader["RateValue"]
            };
        }

        #endregion

        /// <summary>
        /// Use for Update Currency Rate
        /// </summary>
        /// <typeparam name="T">CurrencyRate type</typeparam>
        /// <param name="t">T type object</param>
        public void UpdateCurrencyRate<T>(T t) where T : class
        {
            Logger.Log.Debug("DBOperations. UpdateCurrencyRate. Enter");

            var currencyRate = t as CurrencyRate;
            if (currencyRate == null)
            {
                Logger.Log.Warn("DBOperations. UpdateCurrencyRate. T is not the CurrencyRate type");
                return;
            }

            var query = string.Format(
                "UPDATE [dbo].[CurrencyRate] SET [DateBegin] = '{0}', [RateValue] = {1} WHERE [StoreID] = '{2}' AND [CurrencyCode] = '{3}'",
                currencyRate.DateBegin.ToString("yyyy.MM.dd HH:mm:ss"), currencyRate.RateValue, currencyRate.StoreID, currencyRate.CurrencyCode);
            ExecuteNonQuery(query);

            Logger.Log.Debug("DBOperations. UpdateCurrencyRate. Exit");
        }

        #region GetStoreCurrencyConfigList

        /// <summary>
        /// Use for Get Store Currency Config List from db
        /// </summary>
        /// <typeparam name="T">Config type</typeparam>
        /// <returns></returns>
        public List<T> GetStoreCurrencyConfigList<T>()
        {
            Logger.Log.Debug("DBOperations. GetStoreCurrencyConfigList. Enter");

            var query = "SELECT * FROM [dbo].[Config] WHERE [ConfigID] = 2";
            var storeConfigList = ExecuteList<Config>(query, PopulateConfig);
            
            Logger.Log.Debug("DBOperations. GetStoreCurrencyConfigList. Exit");
            return (List<T>)(object)storeConfigList;
        }

        /// <summary>
        /// Use for Populate Config
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private Config PopulateConfig(SqlDataReader reader)
        {
            return new Config()
            {
                ConfigID = (int)reader["ConfigID"],
                StoreID = reader["StoreID"] as string,
                ConfigValue = reader["ConfigValue"] as string
            };
        }

        #endregion

        #region GetStoreList

        /// <summary>
        /// Use for Get Store List from db
        /// </summary>
        /// <typeparam name="T">Store type</typeparam>
        /// <returns></returns>
        public List<T> GetStoreList<T>()
        {
            Logger.Log.Debug("DBOperations. GetStoreList. Enter");

            var query = "SELECT * FROM [dbo].[Store]";
            var storeList = ExecuteList<Store>(query, PopulateStore);

            Logger.Log.Debug("DBOperations. GetStoreList. Exit");
            return (List<T>)(object)storeList;
        }

        /// <summary>
        /// Use for Populate Store
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private Store PopulateStore(SqlDataReader reader)
        {
            return new Store()
            {
                StoreID = reader["StoreID"] as string,
                CaptionID = (int)reader["CaptionID"],
                Image = (byte[])reader["Image"]
            };
        }

        #endregion

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

            if (queryData is QueryData<SystemTranslationData>)
            {
                var castedQuery = queryData as QueryData<SystemTranslationData>;
                var ip = castedQuery.ClientIP.ToString();
                var systemTranslationData = GetSystemTranslationData(castedQuery.QueryParams, ip);
                return (T)(object)systemTranslationData;
            }
            else if (queryData is QueryData<DefaultLangCurr>)
            {
                var castedQuery = queryData as QueryData<DefaultLangCurr>;
                var ip = castedQuery.ClientIP.ToString();
                var defaultLangCurr = GetDefaultLangCurrData(ip);
                return (T)(object)defaultLangCurr;
            }
            else if (queryData is QueryData<ProductInfoData>)
            {
                var castedQuery = queryData as QueryData<ProductInfoData>;
                var ip = castedQuery.ClientIP.ToString();
                var productInfoData = GetProductInfoData(castedQuery.QueryParams, ip);
                if (productInfoData != null)
                    return (T)(object)productInfoData;
                else return (T)(object)GetProductNotFound();
            }
            else if (queryData is QueryData<List<AdvertisingData>>)
            {
                var castedQuery = queryData as QueryData<List<AdvertisingData>>;
                var ip = castedQuery.ClientIP.ToString();
                var advertisingDataList = GetAdvertisingDataList(ip);
                return (T)(object)advertisingDataList;
            }
            else if (queryData is QueryData<List<SharesSalesData>>)
            {
                var castedQuery = queryData as QueryData<List<SharesSalesData>>;
                var ip = castedQuery.ClientIP.ToString();
                var sharesSalesDataList = GetSharesSalesDataList(ip, castedQuery.QueryParams);
                return (T)(object)sharesSalesDataList;
            }
            else if (queryData is QueryData<List<LanguageData>>)
            {
                var castedQuery = queryData as QueryData<List<LanguageData>>;
                var ip = castedQuery.ClientIP.ToString();
                var languageDataList = GetLanguageDataList(ip, castedQuery.QueryParams);
                return (T)(object)languageDataList;
            }
            else if (queryData is QueryData<List<CurrencyData>>)
            {
                var castedQuery = queryData as QueryData<List<CurrencyData>>;
                var ip = castedQuery.ClientIP.ToString();
                var currencyDataList = GetCurrencyDataList(ip, castedQuery.QueryParams);
                return (T)(object)currencyDataList;
            }
            else if (queryData is QueryData<LogoData>)
            {
                var castedQuery = queryData as QueryData<LogoData>;
                var ip = castedQuery.ClientIP.ToString();
                var logoData = GetLogoData(ip);
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
            
            Logger.Log.Debug("DBOperations. Update. Exit");
        }

        #endregion

        #region Add

        /// <summary>
        /// Use for Log Information to database
        /// </summary>
        /// <param name="queryData">Object of the QueryData</param>
        public void AddCurrencyRate(QueryData<CurrencyRate> queryData)
        {
            Logger.Log.Debug("DBOperations. AddCurrencyRate. Enter");

            try
            {
                var currencyRateObject = queryData.QueryObject;
                var dt = DateTime.Parse(currencyRateObject.DateBegin.ToString("yyyy.MM.dd HH:mm:ss"));
                var query = string.Format(@"
    INSERT INTO [dbo].[CurrencyRate]
               ([StoreID]
               ,[CurrencyCode]
               ,[DateBegin]
               ,[RateValue])
         VALUES
               ('{0}'
               ,'{1}'
               ,'{2}'
               ,{3})",
               currencyRateObject.StoreID,
               currencyRateObject.CurrencyCode,
               dt,
               currencyRateObject.RateValue);

                ExecuteNonQuery(query);
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
            
            try
            {                
                var eventObject = queryData.QueryObject;
                var dt = DateTime.Parse(eventObject.EventDataTime.ToString("yyyy.MM.dd HH:mm:ss"));
                var query = string.Format(@"
    INSERT INTO [dbo].[EventLog]
               ([TerminalID]
               ,[EventDataTime]
               ,[EventType]
               ,[EventSource]
               ,[EventDetails])
             VALUES
               ('{0}'
               ,'{1}'
               ,{2}
               ,'{3}'
               ,'{4}')",
               eventObject.TerminalID,
               dt,
               eventObject.EventType,
               eventObject.EventSource,
               eventObject.EventDetails);

                ExecuteNonQuery(query);
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
            
            try
            {
                var itemLog = queryData.QueryObject;
                var dt = DateTime.Parse(itemLog.ScanDate.ToString("yyyy.MM.dd HH:mm:ss"));
                var query = string.Format(@"
    INSERT INTO [dbo].[ProductLog]
               ([ProductID]
               ,[ScanDate]
               ,[LanguageCode]
               ,[CurrencyCode]
               ,[TerminalID])
             VALUES
               ({0}
               ,'{1}'
               ,'{2}'
               ,'{3}'
               ,'{4}')",
               itemLog.ProductID,
               dt,
               itemLog.LanguageCode,
               itemLog.CurrencyCode,
               itemLog.TerminalID);

                ExecuteNonQuery(query);

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
        /// Use for Create IP Parameters
        /// </summary>
        /// <param name="ipAddress">Client IP Address</param>
        /// <returns></returns>
        private SqlParameter[] CreateIPParameters(string ipAddress)
        {
            var ipParam = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
            ipParam.Value = ipAddress ?? SqlString.Null;

            var parameters = new SqlParameter[]
            {
                ipParam
            };
            return parameters;
        }

        #region SystemTranslationData

        /// <summary>
        /// Use for Create SystemTranslationData Parameters
        /// </summary>
        /// <param name="currentLang">Current language</param>
        /// <param name="ipAddress">Client IP Address</param>
        /// <returns></returns>
        private SqlParameter[] CreateSystemTranslationDataParameters(string currentLang, string ipAddress)
        {
            var ipParam = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
            var langParam = new SqlParameter("@Lang", SqlDbType.NVarChar);

            ipParam.Value = ipAddress ?? SqlString.Null;
            langParam.Value = currentLang ?? SqlString.Null;
            
            var parameters = new SqlParameter[]
            {
                ipParam,
                langParam
            };
            return parameters;
        }

        /// <summary>
        /// Use for Populate SystemTranslationData
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private SystemTranslationData PopulateSystemTranslationData(SqlDataReader reader)
        {
            return new SystemTranslationData()
            {
                BtnBackText = reader["BtnBackText"] as string,
                BtnCancelText = reader["BtnCancelText"] as string,
                BtnChooseText = reader["BtnChooseText"] as string,
                BtnCurrency = reader["BtnCurrency"] as string,
                BtnDownText = reader["BtnDownText"] as string,
                BtnLang = reader["BtnLang"] as string,
                BtnSettingsText = reader["BtnSettingsText"] as string,
                BtnSharesText = reader["BtnSharesText"] as string,
                BtnUpText = reader["BtnUpText"] as string,
                LblBarCodeText = reader["LblBarCodeText"] as string,
                LblPriceText = reader["LblPriceText"] as string,
                LblProductNotFoundInDBText = reader["LblProductNotFoundInDBText"] as string,
                LblScanBarCodeText = reader["LblScanBarCodeText"] as string,
                LblSettingsText = reader["LblSettingsText"] as string,
                LblSharesAndSalesText = reader["LblSharesAndSalesText"] as string,
                LblVendorCodeText = reader["LblVendorCodeText"] as string
            };
        }

        /// <summary>
        /// Use for Get SystemTranslationData
        /// </summary>
        /// <param name="currentLang">Current language</param>
        /// <param name="ipAddress">Client IP Address</param>
        /// <returns></returns>
        private SystemTranslationData GetSystemTranslationData(string currentLang, string ipAddress)
        {
            var parameters = CreateSystemTranslationDataParameters(currentLang, ipAddress);
            var storeProcName = "SystemTranslationData_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var systemTranslationData = _database.Execute<SystemTranslationData>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateSystemTranslationData);
            _database.Commit();
            _database.CloseConnection();
            
            return systemTranslationData;
        }

        #endregion

        #region DefaultLangCurr

        /// <summary>
        /// Use for Populate DefaultLangCurr
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private DefaultLangCurr PopulateDefaultLangCurr(SqlDataReader reader)
        {
            return new DefaultLangCurr()
            {
                Language = reader["LanguageCode"] as string,
                Currency = reader["CurrencyCode"] as string
            };
        }

        /// <summary>
        /// Use for Get DefaultLangCurr Data
        /// </summary>
        /// <param name="ipAddress">Client IP Address</param>
        /// <returns></returns>
        private DefaultLangCurr GetDefaultLangCurrData(string ipAddress)
        {
            var parameters = CreateIPParameters(ipAddress);
            var storeProcName = "DefaultLangCurr_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var defaultLangCurr = _database.Execute<DefaultLangCurr>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateDefaultLangCurr);
            _database.Commit();
            _database.CloseConnection();
            
            return defaultLangCurr;
        }

        #endregion

        #region ProductInfoData

        /// <summary>
        /// Use for Create ProductInfoData Parameters
        /// </summary>
        /// <param name="ipAddress">Client IP Address parameter</param>
        /// <param name="barcode">Product Barcode parameter</param>
        /// <param name="language">Language parameter</param>
        /// <param name="currency">Currency parameter</param>
        /// <returns></returns>
        private SqlParameter[] CreateProductInfoDataParameters(string ipAddress, string barcode, string language, string currency)
        {
            var ipParam = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
            var barcodeParam = new SqlParameter("@Barcode", SqlDbType.NVarChar);
            var langParam = new SqlParameter("@Language", SqlDbType.NVarChar);
            var currencyParam = new SqlParameter("@Currency", SqlDbType.NVarChar);
            ipParam.Value = ipAddress ?? SqlString.Null;
            barcodeParam.Value = barcode ?? SqlString.Null;
            langParam.Value = language ?? SqlString.Null;
            currencyParam.Value = currency ?? SqlString.Null;

            var parameters = new SqlParameter[]
            {
                ipParam,
                barcodeParam,
                langParam,
                currencyParam
            };
            return parameters;
        }

        /// <summary>
        /// Use for Populate ProductInfoData
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private ProductInfoData PopulateProductInfoData(SqlDataReader reader)
        {
            return new ProductInfoData()
            {
                TextBoxVendorCode = reader["TextBoxVendorCode"] as string,
                TextBoxBarCode = reader["TextBoxBarCode"] as string,                
                TextBoxProductName = reader["TextBoxProductName"] as string,
                TextBoxPrice = reader["TextBoxPrice"] as string,
                TextBoxProductInfo = reader["TextBoxProductInfo"] as string,
                PictureBoxProductImage = (byte[])reader["PictureBoxProductImage"],
                ProductSharesDesriptions = reader["ProductSharesDesriptions"] as string,
                ProductSharesNames = reader["ProductSharesNames"] as string
            };
        }

        /// <summary>
        /// Use for Get ProductInfoData Data
        /// </summary>
        /// <param name="queryString">Query string from Client for parse to query parameters</param>
        /// <param name="ipAddress">Client IP Address</param>
        /// <returns></returns>
        private ProductInfoData GetProductInfoData(string queryString, string ipAddress)
        {
            var strArray = queryString.Split(BaseConstants.TypeSplitter, StringSplitOptions.None);
            var barcode = strArray[0];
            var language = strArray[1];
            var currency = strArray[2];

            var parameters = CreateProductInfoDataParameters(ipAddress, barcode, language, currency);
            var storeProcName = "ProductInfoData_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var productInfoData = _database.Execute<ProductInfoData>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateProductInfoData);
            _database.Commit();
            _database.CloseConnection();

            return productInfoData;
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

        #endregion

        #region List<AdvertisingData>
        
        /// <summary>
        /// Use for Populate AdvertisingData
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private AdvertisingData PopulateAdvertisingData(SqlDataReader reader)
        {
            return new AdvertisingData()
            {
                Picture = (byte[])reader["AdImage"]
            };
        }

        /// <summary>
        /// Use for Get AdvertisingData List
        /// </summary>
        /// <param name="ipAddress">Client IP Address</param>
        /// <returns></returns>
        private List<AdvertisingData> GetAdvertisingDataList(string ipAddress)
        {
            var parameters = CreateIPParameters(ipAddress);
            var storeProcName = "AdvertisingData_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var advertisingData = _database.ExecuteList<AdvertisingData>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateAdvertisingData);
            _database.Commit();
            _database.CloseConnection();

            return advertisingData;
        }

        #endregion

        #region List<SharesSalesData>

        /// <summary>
        /// Use for Create SharesSalesData Parameters
        /// </summary>
        /// <param name="ipAddress">Client IP Address parameter</param>
        /// <param name="language">Language parameter</param>
        /// <returns></returns>
        private SqlParameter[] CreateSharesSalesDataParameters(string ipAddress, string language)
        {
            var ipParam = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
            var langParam = new SqlParameter("@Language", SqlDbType.NVarChar);
            ipParam.Value = ipAddress ?? SqlString.Null;
            langParam.Value = language ?? SqlString.Null;

            var parameters = new SqlParameter[]
            {
                ipParam,
                langParam,
            };
            return parameters;
        }

        /// <summary>
        /// Use for Populate SharesSalesData
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private SharesSalesData PopulateSharesSalesData(SqlDataReader reader)
        {
            return new SharesSalesData()
            {
                SharesID = (int)reader["SharesID"],
                ShareName = reader["ShareName"] as string,
                ShareDesription = reader["ShareDesription"] as string
            };
        }

        /// <summary>
        /// Use for Get SharesSalesData List
        /// </summary>
        /// <param name="ipAddress">Client IP Address</param>
        /// <param name="language">Language parameter</param>
        /// <returns></returns>
        private List<SharesSalesData> GetSharesSalesDataList(string ipAddress, string language)
        {
            var parameters = CreateSharesSalesDataParameters(ipAddress, language);
            var storeProcName = "SharesSalesData_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var sharesSalesData = _database.ExecuteList<SharesSalesData>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateSharesSalesData);
            _database.Commit();
            _database.CloseConnection();

            return sharesSalesData;
        }

        #endregion

        #region List<LanguageData>

        /// <summary>
        /// Use for Create LanguageData Parameters
        /// </summary>
        /// <param name="ipAddress">Client IP Address parameter</param>
        /// <param name="language">Language parameter</param>
        /// <returns></returns>
        private SqlParameter[] CreateLanguageDataParameters(string ipAddress, string language)
        {
            var ipParam = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
            var langParam = new SqlParameter("@Language", SqlDbType.NVarChar);
            ipParam.Value = ipAddress ?? SqlString.Null;
            langParam.Value = language ?? SqlString.Null;

            var parameters = new SqlParameter[]
            {
                ipParam,
                langParam,
            };
            return parameters;
        }

        /// <summary>
        /// Use for Populate LanguageData
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private LanguageData PopulateLanguageData(SqlDataReader reader)
        {
            return new LanguageData()
            {
                LanguageCode = reader["LanguageCode"] as string,
                LanguagePicture = (byte[])reader["Image"],
                LanguageText = reader["TranslationValue"] as string
            };
        }

        /// <summary>
        /// Use for Get LanguageData List
        /// </summary>
        /// <param name="ipAddress">Client IP Address</param>
        /// <param name="language">Language parameter</param>
        /// <returns></returns>
        private List<LanguageData> GetLanguageDataList(string ipAddress, string language)
        {
            var parameters = CreateLanguageDataParameters(ipAddress, language);
            var storeProcName = "LanguageData_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var languageData = _database.ExecuteList<LanguageData>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateLanguageData);
            _database.Commit();
            _database.CloseConnection();

            return languageData;
        }

        #endregion

        #region List<CurrencyData>

        /// <summary>
        /// Use for Create CurrencyData Parameters
        /// </summary>
        /// <param name="ipAddress">Client IP Address parameter</param>
        /// <param name="language">Language parameter</param>
        /// <returns></returns>
        private SqlParameter[] CreateCurrencyDataParameters(string ipAddress, string language)
        {
            var ipParam = new SqlParameter("@IPAddress", SqlDbType.NVarChar);
            var langParam = new SqlParameter("@Language", SqlDbType.NVarChar);
            ipParam.Value = ipAddress ?? SqlString.Null;
            langParam.Value = language ?? SqlString.Null;

            var parameters = new SqlParameter[]
            {
                ipParam,
                langParam,
            };
            return parameters;
        }

        /// <summary>
        /// Use for Populate CurrencyData
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private CurrencyData PopulateCurrencyData(SqlDataReader reader)
        {
            return new CurrencyData()
            {
                CurrencyCode = reader["CurrencyCode"] as string,
                CurrencyPicture = (byte[])reader["Image"],
                CurrencyText = reader["TranslationValue"] as string
            };
        }

        /// <summary>
        /// Use for Get CurrencyData List
        /// </summary>
        /// <param name="ipAddress">Client IP Address</param>
        /// <param name="language">Language parameter</param>
        /// <returns></returns>
        private List<CurrencyData> GetCurrencyDataList(string ipAddress, string language)
        {
            var parameters = CreateCurrencyDataParameters(ipAddress, language);
            var storeProcName = "CurrencyData_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var currencyData = _database.ExecuteList<CurrencyData>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateCurrencyData);
            _database.Commit();
            _database.CloseConnection();

            return currencyData;
        }

        #endregion

        #region LogoData

        /// <summary>
        /// Use for Populate LogoData
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private LogoData PopulateLogoData(SqlDataReader reader)
        {
            return new LogoData()
            {
                LogoPicture = (byte[])reader["Image"]
            };
        }

        /// <summary>
        /// Use for Get LogoData Data
        /// </summary>
        /// <param name="ipAddress">Client IP Address</param>
        /// <returns></returns>
        private LogoData GetLogoData(string ipAddress)
        {
            var parameters = CreateIPParameters(ipAddress);
            var storeProcName = "LogoData_ReadProc";

            _database.OpenConnection(_connectionString);
            _database.BeginTransaction();
            var logoData = _database.Execute<LogoData>(storeProcName, CommandType.StoredProcedure,
                parameters, PopulateLogoData);
            _database.Commit();
            _database.CloseConnection();

            return logoData;
        }

        #endregion

        #endregion
        
        #endregion
    }
}