using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents System Translation Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class SystemTranslationRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                #region BtnBack - 1
                var systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 1,
                    TranslationValue = "Назад"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 1,
                    TranslationValue = "Back"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 1,
                    TranslationValue = "背部"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnCancel - 2
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 2,
                    TranslationValue = "Отмена"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 2,
                    TranslationValue = "Cancel"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 2,
                    TranslationValue = "取消"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnChoose - 3
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 3,
                    TranslationValue = "Выбрать"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 3,
                    TranslationValue = "Choose"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 3,
                    TranslationValue = "選擇"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnCurrency - 4
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 4,
                    TranslationValue = "Валюта"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 4,
                    TranslationValue = "Currency"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 4,
                    TranslationValue = "貨幣"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnDown - 5
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 5,
                    TranslationValue = "Вниз"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 5,
                    TranslationValue = "Down"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 5,
                    TranslationValue = "下"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnLang - 6
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 6,
                    TranslationValue = "Язык"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 6,
                    TranslationValue = "Language"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 6,
                    TranslationValue = "語言"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnSettings - 7
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 7,
                    TranslationValue = "Настройки"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 7,
                    TranslationValue = "Settings"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 7,
                    TranslationValue = "设置"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnShares - 8
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 8,
                    TranslationValue = "Акции"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 8,
                    TranslationValue = "Shares"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 8,
                    TranslationValue = "分享"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region BtnUp - 9
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 9,
                    TranslationValue = "Вверх"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 9,
                    TranslationValue = "Up"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 9,
                    TranslationValue = "向上"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion
                
                #region LblBarCode - 10
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 10,
                    TranslationValue = "Штрихкод"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 10,
                    TranslationValue = "Barcode"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 10,
                    TranslationValue = "條碼"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region LblSettings - 11
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 11,
                    TranslationValue = "Настройки"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 11,
                    TranslationValue = "Settings"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 11,
                    TranslationValue = "设置"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region LblPrice - 12
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 12,
                    TranslationValue = "Цена"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 12,
                    TranslationValue = "Price"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 12,
                    TranslationValue = "價錢"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion
                
                #region LblProductNotFound - 13
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 13,
                    TranslationValue = "Товар не найден"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 13,
                    TranslationValue = "Product not found"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 13,
                    TranslationValue = "产品未找到"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region LblScanBarCode - 14
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 14,
                    TranslationValue = "Отсканируйте пожалуйста штрихкод"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 14,
                    TranslationValue = "Scan barcode please"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 14,
                    TranslationValue = "扫描条码"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region LblSharesAndSales - 15
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 15,
                    TranslationValue = "Акции магазина"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 15,
                    TranslationValue = "Shares of store"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 15,
                    TranslationValue = "商店股份"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                #region LblVendorCode - 16
                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "RUS",
                    TranslationID = 16,
                    TranslationValue = "Артикул"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "ENG",
                    TranslationID = 16,
                    TranslationValue = "Vendor code"
                };
                context.SystemTranslation.Add(systemTranslation);

                systemTranslation = new SystemTranslation()
                {
                    LanguageCode = "CN",
                    TranslationID = 16,
                    TranslationValue = "供应商代码"
                };
                context.SystemTranslation.Add(systemTranslation);
                #endregion

                context.SaveChanges();
            }
        }
    }
}