using System;
using System.Drawing;
using System.Windows.Forms;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.Client.Plugins.StandartViewPlugin.Properties;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Presents ProductInfo control interface
    /// 
    /// 2017/02/18 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.ProductInfo)]
    public partial class ProductInfoControl : UserControl, IProductInfoControl
    {
        #region Events

        /// <summary>Click Control Event</summary>
        public event ControlEventHandlers.ClickControlEventHandler ClickControlEvent;
        /// <summary>Click Button Up Event</summary>
        public event ControlEventHandlers.ClickButtonUpEventHandler ClickButtonUpEvent;
        /// <summary>Click Button Down Event</summary>
        public event ControlEventHandlers.ClickButtonDownEventHandler ClickButtonDownEvent;
        /// <summary>Click Button Shares Event</summary>
        public event ControlEventHandlers.ClickButtonSharesEventHandler ClickButtonSharesEvent;
        /// <summary>Click Button Settings Event</summary>
        public event ControlEventHandlers.ClickButtonSettingsEventHandler ClickButtonSettingsEvent;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductInfoControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for does button up action
        /// </summary> 
        public void BtnUp()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtProductInfo.ScrollUp(); }));
            else txtProductInfo.ScrollUp();
        }

        /// <summary>
        /// Use for does button down action
        /// </summary>
        public void BtnDown()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtProductInfo.ScrollDown(); }));
            else txtProductInfo.ScrollDown();
        }
        
        /// <summary>
        /// Use for show control
        /// </summary>
        public void ShowControl()
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    Show();
                    Hide();
                    Show();
                }));
            else
            {
                Show();
                Hide();
                Show();
            }
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { Hide(); }));
            else Hide();
        }

        /// <summary>
        /// Button Up click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUp_Click(object sender, System.EventArgs e)
        {
            if (ClickButtonUpEvent != null)
                ClickButtonUpEvent.Invoke();
        }

        /// <summary>
        /// Button Down click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDown_Click(object sender, System.EventArgs e)
        {
            if (ClickButtonDownEvent != null)
                ClickButtonDownEvent.Invoke();
        }

        /// <summary>
        /// Button Shares click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShares_Click(object sender, System.EventArgs e)
        {
            if (ClickButtonSharesEvent != null)
                ClickButtonSharesEvent.Invoke();
        }

        /// <summary>
        /// Button Settings click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSettings_Click(object sender, System.EventArgs e)
        {
            if (ClickButtonSettingsEvent != null)
                ClickButtonSettingsEvent.Invoke();
        }

        /// <summary>
        /// Action of Click on control event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOnControl(object sender, System.EventArgs e)
        {
            if (ClickControlEvent != null)
                ClickControlEvent.Invoke();
        }

        /// <summary>
        /// Use for clear all control data
        /// </summary>
        public void ClearControlData()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { ClearControlDataInvoke(); }));
            else ClearControlDataInvoke();
        }

        /// <summary>
        /// Use for Clear All Control Data
        /// </summary>
        private void ClearControlDataInvoke()
        {
            txtArticleValue.Text = "";
            lblProductName.Text = "";
            txtProductInfo.Text = "";
            txtBarcodeValue.Text = "";
            txtPriceValue.Text = "";
            if (imgProducImage.Image != null)
                imgProducImage.Image = null;
        }

        /// <summary>
        /// Use for set Article value
        /// </summary>
        /// <param name="vendorCode">Vendor Code string</param>
        public void SetVendorCode(string vendorCode)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtArticleValue.Text = vendorCode; }));
            else txtArticleValue.Text = vendorCode;
        }

        /// <summary>
        /// Use for set Product info
        /// </summary>
        /// <param name="productInfo">Product Info string</param>
        public void SetProductInfo(string productInfo)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtProductInfo.Text = productInfo; }));
            else txtProductInfo.Text = productInfo;
        }

        /// <summary>
        /// Use for set Product name
        /// </summary>
        /// <param name="productName">Product Name string</param>
        public void SetProductName(string productName)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { lblProductName.Text = productName; }));
            else lblProductName.Text = productName;
        }

        /// <summary>
        /// Use for set barcode value
        /// </summary>
        /// <param name="barCode">BarCode string</param>
        public void SetBarCode(string barCode)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtBarcodeValue.Text = barCode; }));
            else txtBarcodeValue.Text = barCode;
        }

        /// <summary>
        /// Use for set product price
        /// </summary>
        /// <param name="price">Price string</param>
        public void SetPrice(string price)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtPriceValue.Text = price; }));
            else txtPriceValue.Text = price;
        }

        /// <summary>
        /// Use for set Product image
        /// </summary>
        /// <param name="productImage">Product Image</param>
        public void SetProductImage(Image productImage)
        {
            if (productImage == null)
                SetProductNoImage();

            if (InvokeRequired)
                Invoke(new Action(() => { imgProducImage.Image = productImage; }));
            else imgProducImage.Image = productImage;
        }

        /// <summary>
        /// Use for Set Product NoImage picture
        /// </summary>
        public void SetProductNoImage()
        {
            var noImage = Resources.imgNoImage;
            if (InvokeRequired)
                Invoke(new Action(() => { imgProducImage.Image = (Bitmap)noImage; }));
            else imgProducImage.Image = (Bitmap)noImage;
        }

        /// <summary>
        /// Use for set Shares button visible
        /// </summary>
        /// <param name="isVisible">Flag to make visible/unvisible button Shares</param>
        public void SetBtnSharesVisibility(bool isVisible)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { buttonShares.Visible = isVisible; }));
            else buttonShares.Visible = isVisible;
        }

        /// <summary>
        /// Use for set system localization
        /// </summary>
        /// <param name="systemTranslationData">System Translation Data object</param>
        public void Localize(SystemTranslationData systemTranslationData)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { LocalizeInvoke(systemTranslationData); }));
            else LocalizeInvoke(systemTranslationData);
        }

        /// <summary>
        /// Use for localize control text
        /// </summary>
        /// <param name="systemTranslationData">System Translation Data object</param>
        private void LocalizeInvoke(SystemTranslationData systemTranslationData)
        {
            if (!string.IsNullOrEmpty(systemTranslationData.LblVendorCodeText))
                lblArticle.Text = systemTranslationData.LblVendorCodeText;
            else lblArticle.Text = "Article";

            if (!string.IsNullOrEmpty(systemTranslationData.LblPriceText))
                lblPrice.Text = systemTranslationData.LblPriceText;
            else lblPrice.Text = "Price";

            if (!string.IsNullOrEmpty(systemTranslationData.LblBarCodeText))
                lblBarcode.Text = systemTranslationData.LblBarCodeText;
            else lblBarcode.Text = "Barcode";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnUpText))
                buttonUp.Text = systemTranslationData.BtnUpText;
            else buttonUp.Text = "Up";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnDownText))
                buttonDown.Text = systemTranslationData.BtnDownText;
            else buttonDown.Text = "Down";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnSharesText))
                buttonShares.Text = systemTranslationData.BtnSharesText;
            else buttonShares.Text = "Shares";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnSettingsText))
                buttonSettings.Text = systemTranslationData.BtnSettingsText;
            else buttonSettings.Text = "Settings";
        }

        /// <summary>
        /// Use for set image to Logo
        /// </summary>
        /// <param name="image">Logo Image</param>
        public void SetLogoImage(Image image)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    if (image != null)
                        pictureBoxLogo.Image = image;
                }));
            }
            else
            {
                if (image != null)
                    pictureBoxLogo.Image = image;
            }
        }

        #endregion        
    }
}