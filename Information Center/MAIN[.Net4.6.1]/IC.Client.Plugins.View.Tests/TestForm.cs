using IC.Client.DataLayer;
using IC.Client.FormModel;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.Client.Plugins.View.Tests.Properties;
using System.Windows.Forms;

namespace IC.Client.Plugins.View.Tests
{
    public partial class TestForm : Form
    {
        private UserControlTypes _userControlType;
        private IPluginManager _plugins;
        private IProductByShareControl _productByShareControl;
        private IProductInfoControl _productInfoControl;
        private IProductNotFoundControl _productNotFoundControl;
        private IScanControl _scanControl;
        private ISettingsControl _settingsControl;
        private ISharesSalesControl _sharesSalesControl;
        private IUnAvailableControl _unAvailableControl;
        private IWaitControl _waitControl;

        private SystemTranslationData _systemTranslationData;
        private SystemTranslationData _systemTranslationDataEng;
        private SystemTranslationData _systemTranslationDataCh;
        private SystemTranslationData _systemTranslationDataRus;

        private LangTypes _lang;
        private string _testText;
        private string _testTextEng;
        private string _testTextCh;
        private string _testTextRus;
        private string _testNameText;
        private string _testNameTextEng;
        private string _testNameTextCh;
        private string _testNameTextRus;

        private bool _isCheckLength;

        public TestForm()
        {
            InitializeComponent();

            _isCheckLength = true;
            _lang = LangTypes.Eng;
            _userControlType = UserControlTypes.ProductByShare;
            _plugins = new PluginManager(this.Controls);
            _plugins.HideAllControls();
            _systemTranslationDataEng = new SystemTranslationData()
            {
                BtnBackText = "Back",
                BtnCancelText = "Cancel",
                BtnChooseText = "Choose",
                BtnCurrency = "Currency",
                BtnDownText = "Down",
                BtnLang = "Lang",
                BtnSettingsText = "Settings",
                BtnSharesText = "Shares",
                BtnUpText = "Up",
                LblBarCodeText = "BarCode",
                LblPriceText = "Price",
                LblProductNotFoundInDBText = "Product Not Found",
                LblScanBarCodeText = "Scan BarCode Please",
                LblSettingsText = "Settings",
                LblSharesAndSalesText = "Shares And Sales",
                LblVendorCodeText = "Vendor Code"
            };
            _systemTranslationDataCh = new SystemTranslationData()
            {
                BtnBackText = "背部",
                BtnCancelText = "取消",
                BtnChooseText = "選擇",
                BtnCurrency = "貨幣",
                BtnDownText = "下",
                BtnLang = "郎",
                BtnSettingsText = "設置",
                BtnSharesText = "股份",
                BtnUpText = "ÿ",
                LblBarCodeText = "條形碼",
                LblPriceText = "價格",
                LblProductNotFoundInDBText = "產品未找到",
                LblScanBarCodeText = "掃描條形碼請",
                LblSettingsText = "設置",
                LblSharesAndSalesText = "股份和銷售",
                LblVendorCodeText = "供應商代碼"
            };
            _systemTranslationDataRus = new SystemTranslationData()
            {
                BtnBackText = "Назад",
                BtnCancelText = "Отменить",
                BtnChooseText = "Выбрать",
                BtnCurrency = "Валюта",
                BtnDownText = "Вниз",
                BtnLang = "Язык",
                BtnSettingsText = "Настройки",
                BtnSharesText = "Акции",
                BtnUpText = "Вверх",
                LblBarCodeText = "Штрих-код",
                LblPriceText = "Цена",
                LblProductNotFoundInDBText = "Товар не найден",
                LblScanBarCodeText = "Пожалуйста, отсканируйте штрих-код",
                LblSettingsText = "Настройки",
                LblSharesAndSalesText = "Распродажи и акции",
                LblVendorCodeText = "Артикул"
            };            
            _testTextEng = "Doctor Alexandre Manette A doctor from Beauvais, France, who was secretly imprisoned in the Bastille for 18 years and suffers some mental trauma from the experience. After being released, he is nursed back to health by his daughter, Lucie, in England. During the Revolution, he tries to save his son-in-law, Charles Darnay, from the guillotine. Lucie Manette, later Darnay A beautiful young woman recognized for her kindness and compassion. After being reunited with her father, she cares for him and remains devoted to him, even after her marriage to Charles Darnay.";
            _testTextCh = "亞歷山大·馬內特醫生來自法國博韋的一名醫生，他在巴士底獄中秘密監禁了18年，經歷了一些心理創傷。 被釋放後，他的女兒，露西，在英國被護理恢復健康。 在革命期間，他試圖挽救他的女，查爾斯·達爾奈，從斷頭台。 Lucie Manette，後來Darnay一個美麗的年輕女子，因為她的善良和同情而認可。 在與父親重聚後，她關心他，並且仍然致力於他，即使她與查爾斯·達爾奈結婚。";
            _testTextRus = "Доктор Александр Манетт Доктор из Бове, Франция, который был тайно заключен в тюрьму в Бастилии в течение 18 лет и страдает некоторой психологической травмой от этого опыта. После освобождения он вернулся к здоровью своей дочерью, Люси, в Англии. Во время Революции он пытается спасти своего зятя Чарльза Дарнея от гильотины. Люси Манетт, позже Дарней Красивая молодая женщина признала за ее доброту и сострадание. После воссоединения с отцом она заботится о нем и остается преданным ему, даже после ее брака с Чарльзом Дарнеем.";
            _testNameTextEng = "Manette A doctor | Manette A doctor | Manette A doctor | Manette A doctor | Manette A doctor";
            _testNameTextCh = "馬內特醫生 | 馬內特醫生 | 馬內特醫生 | 馬內特醫生";
            _testNameTextRus = "Врач Манетте | Врач Манетте | Врач Манетте | Врач Манетте";

            switch (_lang)
            {
                case LangTypes.Eng:
                    _testText = _testTextEng;
                    _testNameText = _testNameTextEng;
                    _systemTranslationData = _systemTranslationDataEng;
                    break;
                case LangTypes.Ch:
                    _testText = _testTextCh;                    
                    _testNameText = _testNameTextCh;
                    _systemTranslationData = _systemTranslationDataCh;
                    break;
                case LangTypes.Rus:
                    _testText = _testTextRus;                    
                    _testNameText = _testNameTextRus;
                    _systemTranslationData = _systemTranslationDataRus;
                    break;
            }
            
            switch (_userControlType)
            {
                case UserControlTypes.ProductByShare:
                    _productByShareControl = (IProductByShareControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _productByShareControl.Localize(_systemTranslationData);
                    _productByShareControl.SetBarCode("IC605365 132854");
                    _productByShareControl.SetProductByShareInfo(_testText);
                    _productByShareControl.SetPrice("1 354 546");
                    _productByShareControl.SetProductName(_testNameText);
                    _productByShareControl.SetVendorCode("13248463521354");

                    if (_isCheckLength)
                    {
                        _productByShareControl.SetBarCode("MMMMMMMMMMMMMMMMA"); // 16M
                        _productByShareControl.SetPrice("MMMMMMMMMMMMMMMMA"); // 16M
                        _productByShareControl.SetProductName("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMA"); // 32M
                        _productByShareControl.SetVendorCode("MMMMMMMMMMMMMMMMA"); // 16M
                    }

                    _productByShareControl.ShowControl();
                    break;
                case UserControlTypes.ProductInfo:
                    _productInfoControl = (IProductInfoControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _productInfoControl.Localize(_systemTranslationData);
                    _productInfoControl.SetBarCode("IC605365 132854");
                    _productInfoControl.SetBtnSharesVisibility(true);
                    _productInfoControl.SetPrice("1 354 546");
                    _productInfoControl.SetProductInfo(_testText);
                    _productInfoControl.SetProductName(_testNameText);
                    _productInfoControl.SetVendorCode("13248463521354");

                    if (_isCheckLength)
                    {

                    }

                    _productInfoControl.ShowControl();
                    break;
                case UserControlTypes.ProductNotFound:
                    _productNotFoundControl = (IProductNotFoundControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _productNotFoundControl.Localize(_systemTranslationData);
                    _productNotFoundControl.ShowControl();
                    break;
                case UserControlTypes.Scan:
                    _scanControl = (IScanControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _scanControl.Localize(_systemTranslationData);
                    _scanControl.ShowControl();
                    break;
                case UserControlTypes.Settings:
                    _settingsControl = (ISettingsControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _settingsControl.SetItemToAdvancedItem(
                            new AdvancedItem()
                            {
                                Code = "RUB",
                                ItemName = "Ruble",
                                ItemImage = Resources.rusFlag
                            }, 0, AdvancedListTypes.Currency);
                    _settingsControl.SetItemToAdvancedItem(
                        new AdvancedItem()
                        {
                            Code = "CAD",
                            ItemName = "CA Dollar",
                            ItemImage = Resources.rusFlag
                        }, 1, AdvancedListTypes.Currency);
                    _settingsControl.SetItemToAdvancedItem(
                        new AdvancedItem()
                        {
                            Code = "USD",
                            ItemName = "USA USD",
                            ItemImage = Resources.rusFlag
                        }, 2, AdvancedListTypes.Currency);
                    _settingsControl.SetItemToAdvancedItem(
                        new AdvancedItem()
                        {
                            Code = "RU",
                            ItemName = "Russian",
                            ItemImage = Resources.rusFlag
                        }, 0, AdvancedListTypes.Language);
                    _settingsControl.SetItemToAdvancedItem(
                        new AdvancedItem()
                        {
                            Code = "ENG",
                            ItemName = "English",
                            ItemImage = Resources.rusFlag
                        }, 1, AdvancedListTypes.Language);
                    _settingsControl.SetEmptyItem(3, AdvancedListTypes.Language);
                    _settingsControl.SetLblMoreItemsVisibility(true,
                        AdvancedListTypes.Currency);
                    _settingsControl.SetLblMoreItemsVisibility(false,
                        AdvancedListTypes.Language);
                    _settingsControl.Localize(_systemTranslationData);

                    if (_isCheckLength)
                    {

                    }

                    _settingsControl.ShowControl();
                    break;
                case UserControlTypes.SharesSales:
                    _sharesSalesControl = (ISharesSalesControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _sharesSalesControl.SetSharesSalesData(new SharesSalesData()
                    {
                        ShareDesription = _testText,
                        ShareName = _testNameText,
                        SharesID = 0
                    });
                    _sharesSalesControl.Localize(_systemTranslationData);

                    if (_isCheckLength)
                    {

                    }

                    _sharesSalesControl.ShowControl();
                    break;
                case UserControlTypes.UnAvailable:
                    _unAvailableControl = (IUnAvailableControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _unAvailableControl.ShowControl();
                    break;
                case UserControlTypes.Wait:
                    _waitControl = (IWaitControl)_plugins.
                        ControlsDictionary[_userControlType];
                    _waitControl.ShowControl();
                    break;
            }
        }
    }
}