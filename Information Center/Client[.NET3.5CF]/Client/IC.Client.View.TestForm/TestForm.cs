using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IC.Client.FormModel;
using IC.Client.DataLayer;
using IC.Client.View.Components;
using IC.Client.View.TestForm.Properties;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.SDK;

namespace IC.Client.View.TestForm
{
    internal enum LangType
    {
        Eng,
        Ch,
        Rus
    }

    public partial class TestForm : Form, IControlBackground
    {
        /// <summary>Control background image</summary>
        private Image _background;
        private ICAdvancedItem icAdvancedItem;
        private string testType = "PControl";

        private IPluginManager Plugins { get; set; }
        private UserControlTypes ControlType { get; set; }
        private LangType Lang = LangType.Eng;
        private string _testText { get; set; }
        private string _testTextEng = "Doctor Alexandre Manette A doctor from Beauvais, France, who was secretly imprisoned in the Bastille for 18 years and suffers some mental trauma from the experience. After being released, he is nursed back to health by his daughter, Lucie, in England. During the Revolution, he tries to save his son-in-law, Charles Darnay, from the guillotine. Lucie Manette, later Darnay A beautiful young woman recognized for her kindness and compassion. After being reunited with her father, she cares for him and remains devoted to him, even after her marriage to Charles Darnay.";
        private string _testTextCh = "亞歷山大·馬內特醫生來自法國博韋的一名醫生，他在巴士底獄中秘密監禁了18年，經歷了一些心理創傷。 被釋放後，他的女兒，露西，在英國被護理恢復健康。 在革命期間，他試圖挽救他的女，查爾斯·達爾奈，從斷頭台。 Lucie Manette，後來Darnay一個美麗的年輕女子，因為她的善良和同情而認可。 在與父親重聚後，她關心他，並且仍然致力於他，即使她與查爾斯·達爾奈結婚。";
        private string _testTextRus = "Доктор Александр Манетт Доктор из Бове, Франция, который был тайно заключен в тюрьму в Бастилии в течение 18 лет и страдает некоторой психологической травмой от этого опыта. После освобождения он вернулся к здоровью своей дочерью, Люси, в Англии. Во время Революции он пытается спасти своего зятя Чарльза Дарнея от гильотины. Люси Манетт, позже Дарней Красивая молодая женщина признала за ее доброту и сострадание. После воссоединения с отцом она заботится о нем и остается преданным ему, даже после ее брака с Чарльзом Дарнеем.";
        private string _testNameText { get; set; }
        private string _testNameTextEng = "Manette A doctor";
        private string _testNameTextCh = "馬內特醫生";
        private string _testNameTextRus = "Врач Манетте";
        private SystemTranslationData systemTranslationData { get; set; }
        private SystemTranslationData systemTranslationDataEng = new SystemTranslationData()
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
            LblSharesAndSalesText = "Sh\nares\r\n An\nd Sa\n\rles",
            LblVendorCodeText = "Vendor Code"
        };
        private SystemTranslationData systemTranslationDataCh = new SystemTranslationData()
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
            LblSharesAndSalesText = "股\r份和\n\r銷\n售\n",
            LblVendorCodeText = "供應商代碼"
        };
        private SystemTranslationData systemTranslationDataRus = new SystemTranslationData()
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
            LblSharesAndSalesText = "Ра\rспр\n\rодажи\n и акц\nии\r",
            LblVendorCodeText = "Артикул"
        };

        //LawnGreen;//Lime;//LimeGreen;//MediumSpringGreen;//SpringGreen;

        public TestForm()
        {
            InitializeComponent();

            // PControl - Plugin Controls
            // CControl - Component Control  
            if (testType == "PControl")
            {
                ControlType = UserControlTypes.Settings;
                switch (Lang)
                {
                    case LangType.Eng:
                        _testText = _testTextEng;
                        _testNameText = _testNameTextEng;
                        systemTranslationData = systemTranslationDataEng;
                        break;
                    case LangType.Ch:
                        _testText = _testTextCh;
                        systemTranslationData = systemTranslationDataCh;
                        _testNameText = _testNameTextCh;
                        break;
                    case LangType.Rus:
                        _testText = _testTextRus;
                        systemTranslationData = systemTranslationDataRus;
                        _testNameText = _testNameTextRus;
                        break;
                }
                Plugins = new PluginManager(this.Controls);
                Plugins.HideAllControls();

                //switch (ControlType)
                //{
                    //case UserControlTypes.Wait:
                    //    Plugins.WaitControl.ShowControl();
                    //    break;
                    //case UserControlTypes.UnAvailable:
                    //    Plugins.UnAvailableControl.ShowControl();
                    //    break;
                    //case UserControlTypes.SharesSales:
                    //    Plugins.SharesSalesControl.SetSharesSalesData(new SharesSalesData()
                    //    {
                    //        ShareDesription = _testText,
                    //        ShareName = _testNameText,
                    //        SharesID = 0
                    //    });
                    //    Plugins.SharesSalesControl.Localize(systemTranslationData);
                    //    Plugins.SharesSalesControl.ShowControl();
                    //    break;
                    //case UserControlTypes.Settings:
                    //    Plugins.SettingsControl.SetItemToAdvancedItem(
                    //        new AdvancedItem()
                    //        {
                    //            Code = "RUB",
                    //            ItemName = "Ruble",
                    //            ItemImage = Resources.rusFlag
                    //        }, 0, AdvancedListTypes.Currency);
                    //    Plugins.SettingsControl.SetItemToAdvancedItem(
                    //        new AdvancedItem()
                    //        {
                    //            Code = "CAD",
                    //            ItemName = "Canadian Dollar",
                    //            ItemImage = Resources.rusFlag
                    //        }, 1, AdvancedListTypes.Currency);
                    //    Plugins.SettingsControl.SetItemToAdvancedItem(
                    //        new AdvancedItem()
                    //        {
                    //            Code = "USD",
                    //            ItemName = "USA USD",
                    //            ItemImage = Resources.rusFlag
                    //        }, 2, AdvancedListTypes.Currency);                        
                    //    Plugins.SettingsControl.SetItemToAdvancedItem(
                    //        new AdvancedItem()
                    //        {
                    //            Code = "RU",
                    //            ItemName = "Russian",
                    //            ItemImage = Resources.rusFlag
                    //        }, 0, AdvancedListTypes.Language);
                    //    Plugins.SettingsControl.SetItemToAdvancedItem(
                    //        new AdvancedItem()
                    //        {
                    //            Code = "ENG",
                    //            ItemName = "English",
                    //            ItemImage = Resources.rusFlag
                    //        }, 1, AdvancedListTypes.Language);
                    //    Plugins.SettingsControl.SetEmptyItem(3, AdvancedListTypes.Language);
                    //    Plugins.SettingsControl.SetLblMoreItemsVisibility(true, 
                    //        AdvancedListTypes.Currency);
                    //    Plugins.SettingsControl.SetLblMoreItemsVisibility(false, 
                    //        AdvancedListTypes.Language);
                    //    Plugins.SettingsControl.Localize(systemTranslationData);
                    //    Plugins.SettingsControl.ShowControl();
                    //    break;
                    //case UserControlTypes.Scan:
                    //    Plugins.ScanControl.Localize(systemTranslationData);
                    //    Plugins.ScanControl.ShowControl();
                    //    break;
                    //case UserControlTypes.ProductNotFound:
                    //    Plugins.ProductNotFoundControl.Localize(systemTranslationData);
                    //    Plugins.ProductNotFoundControl.ShowControl();
                    //    break;
                    //case UserControlTypes.ProductInfo:
                    //    Plugins.ProductInfoControl.Localize(systemTranslationData);
                    //    Plugins.ProductInfoControl.SetBarCode("IC605365 132854");
                    //    Plugins.ProductInfoControl.SetBtnSharesVisibility(true);
                    //    Plugins.ProductInfoControl.SetPrice("1 354 546");
                    //    Plugins.ProductInfoControl.SetProductInfo(_testText);
                    //    Plugins.ProductInfoControl.SetProductName(_testNameText);
                    //    Plugins.ProductInfoControl.SetVendorCode("13248463521354");
                    //    Plugins.ProductInfoControl.ShowControl();
                    //    break;
                    //case UserControlTypes.ProductByShare:
                    //    Plugins.ProductByShareControl.Localize(systemTranslationData);
                    //    Plugins.ProductByShareControl.SetBarCode("IC605365 132854");
                    //    Plugins.ProductByShareControl.SetProductByShareInfo(_testText);
                    //    Plugins.ProductByShareControl.SetPrice("1 354 546");
                    //    Plugins.ProductByShareControl.SetProductName(_testNameText);
                    //    Plugins.ProductByShareControl.SetVendorCode("13248463521354");
                    //    Plugins.ProductByShareControl.ShowControl();
                    //    break;
                //}
            }
            else if (testType == "CControl")
            {
                _background = ((System.Drawing.Image)(Resources.imgProductNotFoundBackground)); //(Bitmap)img; 
                var img = Extensions.Resize(_background, new Size(this.ClientSize.Width,
                this.ClientSize.Height));
                _background = img;

                //icAdvancedItem = new ICAdvancedItem();
                //icAdvancedItem.SetImage(Resources.rusFlag); 
                //this.Controls.Add(icAdvancedItem);
                //icAdvancedItem.Visible = true;

                //icAdvancedItem1.SetImage(Resources.rusFlag); 
            }
        }

        /// <summary>
        /// Actions for handle paint event
        /// </summary>
        /// <param name="e">Paint event args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (testType == "CControl")
            {
                e.Graphics.DrawImage(_background, 0, 0);
                //this.icAdvancedItem.Refresh();
                //this.icAdvancedItem1.Refresh();
            }
        }

        /// <summary>
        /// Background Image
        /// </summary>
        public Image BackgroundImage
        {
            get { return _background; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //switch (ControlType)
            //{
            //    case UserControlTypes.SharesSales:
            //        Plugins.SharesSalesControl.BtnUp();
            //        break;
            //    case UserControlTypes.ProductInfo:
            //        Plugins.ProductInfoControl.BtnUp();
            //        break;
            //    case UserControlTypes.ProductByShare:
            //        Plugins.ProductByShareControl.BtnUp();
            //        break;
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //switch (ControlType)
            //{
            //    case UserControlTypes.SharesSales:
            //        Plugins.SharesSalesControl.BtnDown();
            //        break;
            //    case UserControlTypes.ProductInfo:
            //        Plugins.ProductInfoControl.BtnDown();
            //        break;
            //    case UserControlTypes.ProductByShare:
            //        Plugins.ProductByShareControl.BtnDown();
            //        break;
            //}
        }
    }
}