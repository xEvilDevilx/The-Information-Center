using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using IC.Client.DataLayer;
using IC.EFDesignLib;
using IC.SDK;
using IC.SDK.Base.Constants;
//using IC.Server;
//using IC.Server.Enums;
//using IC.Server.Interfaces;

namespace IC.UnitTests
{
    [TestClass]
    public class DBTest
    {
        [TestMethod]
        public async Task StartTest()
        {
            await Start();
        }

        private async Task Start()
        {
            var strs = new string[3] { "3380814032419", "5000299601525", "0022548270639" };
            var num = 0;
            var val = 0;

            while (val <= 20)
            {
                await Process(strs[num]);
                num++;
                val++;
                if (num > 2)
                    num = 0;
            }
        }

        private async Task Process(string barcode)
        {
            try
            {
                using (var db = new ICDBContext())
                {
                    if (db.Database.Exists())
                    {
                        //var sqlQueryString =
                        //    string.Format("SELECT * FROM ItemBarcode WHERE BarcodeValue = '{0}';", barcode);
                        //var itemBarCode = await db.Database.SqlQuery<ItemBarcode>(sqlQueryString).FirstAsync();
                        var itemBarCode = await db.Product.FindAsync(barcode);
                        Trace.WriteLine(string.Format("[{0}]: {1};", barcode, itemBarCode.ProductID));
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
    }

    [TestClass]
    public class DBLoggerTest
    {
        [TestMethod]
        public async Task DBLoggerTestStart()
        {
            //IDBLogger dbLogger = new DBLogger();
            //var task1 = Task.Run(() =>
            //{
            //    dbLogger.SaveLog("T001", ConnectionEventTypes.ClientConnect, "TestEventSource1",
            //    "TestEventDetails1");
            //    Trace.WriteLine("1");
            //});
            //var task2 = Task.Run(() =>
            //{
            //    dbLogger.SaveLog("T002", ConnectionEventTypes.ClientConnect, "TestEventSource2",
            //    "TestEventDetails2");
            //    Trace.WriteLine("2");
            //});
            //var task3 = Task.Run(() =>
            //{
            //    dbLogger.SaveLog("T003", ConnectionEventTypes.ClientConnect, "TestEventSource3",
            //    "TestEventDetails3");
            //    Trace.WriteLine("3");
            //});
            //var task4 = Task.Run(() =>
            //{
            //    dbLogger.SaveLog("T004", ConnectionEventTypes.ClientConnect, "TestEventSource4",
            //    "TestEventDetails4");
            //    Trace.WriteLine("4");
            //});
            //var task5 = Task.Run(() =>
            //{
            //    dbLogger.SaveLog("T005", ConnectionEventTypes.ClientConnect, "TestEventSource5",
            //    "TestEventDetails5");
            //    Trace.WriteLine("5");
            //});

            //await Task.WhenAll(new[] { task1, task2, task3, task4, task5 });
        }

        [TestMethod]
        public async Task DBLoggerTestStartT()
        {
            using (var context = new ICDBContext())
            {
                if (context.Database.Exists())
                {
                    for (int i = 0; i < 100; i++)
                    {
                        //var eventObject = new EFDesignLib.EventLog()
                        //{
                        //    TerminalID = i.ToString(),
                        //    EventDataTime = DateTime.Now,
                        //    EventType = (byte)ConnectionEventTypes.ClientConnect,
                        //    EventSource = i.ToString(),
                        //    EventDetails = i.ToString(),
                        //};
                        //context.EventLog.Add(eventObject);
                        //await context.SaveChangesAsync();
                    }
                }
            }
        }
    }

    [TestClass]
    public class DBGetTest
    {
        /// <summary>Presents DB Context</summary>
        private ICDBContext _context = new ICDBContext();
        private int _notActive = 0;
        
        [TestMethod]
        public void PrepareClientSystemLocalization()
        {
            try
            {
                if (!_context.Database.Exists())
                    throw new Exception("Database is not exists!");

                var systemTranslationData = new SystemTranslationData();
                //var language = GetLanguage(queryString, ipAddress);
                var language = "ENG";
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

                // Write to stream
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void PrepareProductInfoToSend()
        {
            try
            {
                //if (string.IsNullOrEmpty(queryString))
                //    return;

                if (!_context.Database.Exists())
                    throw new Exception("Database is not exists!");

                //var strArray = queryString.Split(Constants.TypeSplitter, StringSplitOptions.None);
                var barcode = "IC754873 186442";//strArray[0];
                var language = "ENG";
                var currency = "CNY";
                var productInfoObject = new ProductInfoData();
                var terminal = _context.Terminal.Where(x => x.IPAddress == "127.0.0.1").First();

                var product = _context.Product.Where(x => x.BarcodeValue == barcode).First();

                //if(product == null)
                    //SendProductNotFound(stream);

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
                var actualProduct = productPriceArray.Where(x => x.DateBegin == lastData).First();

                var currencyRateArray = _context.CurrencyRate.
                    Where(x => x.CurrencyCode == currency).ToArray();
                var maxDateBegin = currencyRateArray.Max(x => x.DateBegin);
                var currencyRate = currencyRateArray.Where(x => x.DateBegin == maxDateBegin).First();

                productInfoObject.TextBoxPrice = (actualProduct.PriceValue *
                    currencyRate.RateValue).ToString("F");
                productInfoObject.TextBoxPrice += currency;

                var productActions = _context.ProductAction.Where(x => x.ProductID == product.ProductID);
                productInfoObject.ProductSharesNames = "";
                productInfoObject.ProductSharesDesriptions = "";
                foreach (var productAction in productActions)
                {
                    var retailAction = _context.RetailAction.
                        Where(x => x.RetailActionID == productAction.RetailActionID).First();
                    if ((retailAction.ActivityStatus != _notActive) &&
                        (((DateTime)retailAction.DateEnd).CompareTo(DateTime.Now) >= 0))
                    {
                        var retailActionTranslationCaption = _context.ContentTranslation.
                            Where(x => ((x.TranslationID == retailAction.CaptionID) && (x.LanguageCode == language))).First();
                        productInfoObject.ProductSharesNames +=
                            retailActionTranslationCaption.TranslationValue +
                            BaseConstants.TypeSplitter[0];

                        var retailActionTranslationDescription = _context.ContentTranslation.
                            Where(x => ((x.TranslationID == retailAction.DescriptionID) && (x.LanguageCode == language))).First();
                        productInfoObject.ProductSharesDesriptions +=
                            retailActionTranslationDescription.TranslationValue +
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

                // Write to stream
            }
            catch (Exception ex)
            {
                // Log ex!
                //SendProductNotFound(stream);
            }
        }

        [TestMethod]
        public void PrepareAdvertisingInfoToSend()
        {
            try
            {
                string ipAddress = "127.0.0.1";

                if (!_context.Database.Exists())
                    throw new Exception("Database is not exists!");

                var advertisingData = new AdvertisingData();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ipAddress).First();
                var terminalAdArray = _context.StoreAdvertising.
                    Where(x => (x.TerminalID == terminal.TerminalID) && (x.StoreID == terminal.StoreID)).ToArray();

                foreach (var terminalAd in terminalAdArray)
                {
                    var ad = _context.Advertising.
                        Where(x => x.AdvertisingID == terminalAd.AdvertisingID).FirstOrDefault();
                    if ((ad != null) && (ad.AccessStatus != _notActive))
                    {
                        advertisingData.Picture = ad.Image;
                        // Write AD to stream
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void PrepareRetailActionInfoToSend()
        {
            try
            {
                if (!_context.Database.Exists())
                    throw new Exception("Database is not exists!");

                //var language = GetLanguage(queryString, ipAddress);
                var language = "CN";
                var ipAddress = "127.0.0.1";
                var terminal = _context.Terminal.Where(x => x.IPAddress == ipAddress).First();
                var storeActions = _context.StoreAction.Where(x => x.StoreID == terminal.StoreID).ToArray();
                if (storeActions != null)
                {
                    //var retailActionArray = new RetailAction[storeActions.Length];
                    for (int i = 0; i < storeActions.Length; i++)
                    {
                        var retailActionID = storeActions[i].RetailActionID;
                        var retailAction = _context.RetailAction.
                            Where(x => ((x.RetailActionID == retailActionID) &&
                            (x.DateBegin <= DateTime.Now) && ((x.DateEnd >= DateTime.Now) &&
                            (x.ActivityStatus != _notActive)))).FirstOrDefault();
                        var sharesSalesData = new SharesSalesData();
                        var translationCaption = _context.ContentTranslation.
                            Where(x => ((x.TranslationID == retailAction.CaptionID) && (x.LanguageCode == language))).First();

                        sharesSalesData.ShareName = translationCaption.TranslationValue;

                        var translationDescription = _context.ContentTranslation.
                            Where(x => (x.TranslationID == retailAction.DescriptionID &&
                                x.LanguageCode == language)).First();
                        sharesSalesData.ShareDesription = translationDescription.TranslationValue;

                        //if (stream.CanWrite)
                        //{
                        //    serializer.Serialize(stream, sharesSalesData,
                        //        TcpSerializeTypes.SharesSalesData);
                        //}
                    }
                }

                Logger.Log.Debug("PrepareRetailActionInfoToSend. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("PrepareRetailActionInfoToSend.", ex);
            }
        }

        [TestMethod]
        public void PrepareLanguageToSend()
        {
            try
            {
                Logger.Log.Debug("PrepareLanguageToSend. Enter");

                if (!_context.Database.Exists())
                    throw new Exception("Database is not exists!");

                //var serializer = new Serializer();
                var ipAddress = "127.0.0.1";
                var language = "RUS";//GetLanguage(queryString, ipAddress);
                var terminal = _context.Terminal.Where(x => x.IPAddress == ipAddress).First();
                var terminalLanguages = _context.TerminalLanguage.
                    Where(x => (x.TerminalID == terminal.TerminalID) && 
                    (x.StoreID == terminal.StoreID)).ToArray();

                foreach (var terminalLanguage in terminalLanguages)
                {
                    var languageData = new LanguageData()
                    {
                        LanguageCode = terminalLanguage.LanguageCode
                    };
                    var languageRow = _context.Language.Where(x => x.LanguageCode == terminalLanguage.LanguageCode).First();
                    if ((languageRow.CaptionID != 0) && (languageRow.Image != null))
                    {
                        var translation = _context.ContentTranslation.
                            Where(x => (x.TranslationID == languageRow.CaptionID &&
                            x.LanguageCode == language)).First();
                        languageData.LanguageText = translation.TranslationValue;
                        languageData.LanguagePicture = languageRow.Image;

                        //if (stream.CanWrite)
                        //    serializer.Serialize(stream, languageData, TcpSerializeTypes.LanguageData);
                    }
                }

                Logger.Log.Debug("PrepareLanguageToSend. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("PrepareLanguageToSend.", ex);
            }
        }

        [TestMethod]
        public void PrepareCurrencyToSend()
        {
            try
            {
                Logger.Log.Debug("PrepareCurrencyToSend. Enter");

                if (!_context.Database.Exists())
                    throw new Exception("Database is not exists!");

                //var serializer = new Serializer();
                var ipAddress = "127.0.0.1";
                var language = "RUS";//GetLanguage(queryString, ipAddress);
                var terminal = _context.Terminal.Where(x => x.IPAddress == ipAddress).First();
                var terminalCurrencies = _context.TerminalCurrency.
                    Where(x => (x.TerminalID == terminal.TerminalID) &&
                    (x.StoreID == terminal.StoreID)).ToArray();

                foreach (var terminalCurrency in terminalCurrencies)
                {
                    var currencyData = new CurrencyData()
                    {
                        CurrencyCode = terminalCurrency.CurrencyCode
                    };
                    var currency = _context.Currency.Where(x => x.CurrencyCode == terminalCurrency.CurrencyCode).First();
                    if ((currency.CaptionID != 0) && (currency.Image != null))
                    {
                        var translation = _context.ContentTranslation.
                            Where(x => (x.TranslationID == currency.CaptionID &&
                            x.LanguageCode == language)).First();
                        currencyData.CurrencyText = translation.TranslationValue;
                        currencyData.CurrencyPicture = currency.Image;

                        //if (stream.CanWrite)
                        //{
                        //    serializer.Serialize(stream, currencyData,
                        //        TcpSerializeTypes.CurrencyData);
                        //}
                    }
                }

                Logger.Log.Debug("PrepareCurrencyToSend. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("PrepareCurrencyToSend.", ex);
            }
        }

        [TestMethod]
        public void PrepareStoreLogoToSend()
        {
            try
            {
                Logger.Log.Debug("PrepareStoreLogoToSend. Enter");

                if (!_context.Database.Exists())
                    throw new Exception("Database is not exists!");

                //var serializer = new Serializer();
                var ipAddress = "127.0.0.1";
                var logoData = new LogoData();
                var terminal = _context.Terminal.Where(x => x.IPAddress == ipAddress).First();
                var store = _context.Store.Where(x => x.StoreID == terminal.StoreID).First();
                if (store.Image != null)
                {
                    logoData.LogoPicture = store.Image;
                    //if (stream.CanWrite)
                    //    serializer.Serialize(stream, logoData, TcpSerializeTypes.LogoData);
                }

                Logger.Log.Debug("PrepareStoreLogoToSend. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("PrepareStoreLogoToSend.", ex);
            }
        }

        [TestMethod]
        public void GetLanguage()
        {
            string language = "";
            var ipAddress = "127.0.0.1";
            var queryString = "";

            try
            {
                if (string.IsNullOrEmpty(queryString))
                {
                    if (!_context.Database.Exists())
                        throw new Exception("Database is not exists!");

                    var terminal = _context.Terminal.Where(x => x.IPAddress == ipAddress).First();
                    var config = _context.Config.Where(x => ((x.ConfigID == 1) && (x.TerminalID == terminal.TerminalID))).First();
                    language = config.ConfigValue;
                }
                else language = queryString;
                //return language;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetLanguage.", ex);
                throw;
            }
        }

        [TestMethod]
        public void GetCurrency()
        {
            string currency = "";
            var queryString = "";
            var ipAddress = "127.0.0.1";

            try
            {
                if (string.IsNullOrEmpty(queryString))
                {
                    if (!_context.Database.Exists())
                        throw new Exception("Database is not exists!");

                    var terminal = _context.Terminal.Where(x => x.IPAddress == ipAddress).First();
                    var config = _context.Config.Where(x => ((x.ConfigID == 2) && (x.TerminalID == terminal.TerminalID))).First();
                    currency = config.ConfigValue;
                }
                else currency = queryString;
                //return currency;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetLanguage.", ex);
                throw;
            }
        }
    }
}