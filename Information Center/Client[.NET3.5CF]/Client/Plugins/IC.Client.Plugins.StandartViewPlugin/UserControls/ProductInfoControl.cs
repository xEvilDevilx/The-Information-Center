using System;
using System.Drawing;
using System.Windows.Forms;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.Client.Plugins.StandartViewPlugin.Properties;
using IC.Client.Plugins.Terminal.HardKeys;
using IC.Client.View.Components;
using IC.Client.View.Components.Enum;
using IC.SDK;
using IC.SDK.Base.Enums;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Presents ProductInfo control interface
    /// 
    /// 2017/02/18 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.ProductInfo)]
    public partial class ProductInfoControl : UserControl, IProductInfoControl, IControlBackground
    {
        #region Variables

        /// <summary>Control background image</summary>
        private Image _background;
        /// <summary>Default Font for ProductName</summary>
        private Font _defaultProductNameFont;
        /// <summary>Default Font for </summary>
        private Font _defaultProductInfoFont;
        /// <summary>Default Font for ProductInfo</summary>
        private Font _defaultPriceFont;
        /// <summary>Default Font for Price</summary>
        private Font _defaultPriceValueFont;
        /// <summary>Default Font for Article</summary>
        private Font _defaultArticleFont;
        /// <summary>Default Font for ArticleValue</summary>
        private Font _defaultArticleValueFont;
        /// <summary>Default Font for Barcode</summary>
        private Font _defaultBarcodeFont;
        /// <summary>Default Font for BarcodeValue</summary>
        private Font _defaultBarcodeValueFont;
        /// <summary>Default Font for ButtonUp</summary>
        private Font _defaultButtonUpFont;
        /// <summary>Default Font for ButtonDown</summary>
        private Font _defaultButtonDownFont;
        /// <summary>Default Font for ButtonShares</summary>
        private Font _defaultButtonSharesFont;
        /// <summary>Default Font for ButtonSettings</summary>
        private Font _defaultButtonSettingsFont;

        #endregion

        #region Properties

        /// <summary>Key Hook manage</summary>
        public IKeyHook KeyHook { get; set; }

        #endregion

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

            _background = ((System.Drawing.Image)(Resources.imgBackground));
            var img = Extensions.Resize(_background, new Size(this.ClientSize.Width,
                this.ClientSize.Height));
            _background = img;

            _defaultProductNameFont = lblProductName.Font;
            _defaultProductInfoFont = txtProductInfo.Font;
            _defaultPriceFont = lblPrice.Font;
            _defaultPriceValueFont = txtPriceValue.Font;
            _defaultArticleFont = lblArticle.Font;
            _defaultArticleValueFont = txtArticleValue.Font;
            _defaultBarcodeFont = lblBarcode.Font;
            _defaultBarcodeValueFont = txtBarcodeValue.Font;
            _defaultButtonUpFont = buttonUp.Font;
            _defaultButtonDownFont = buttonDown.Font;
            _defaultButtonSharesFont = buttonShares.Font;
            _defaultButtonSettingsFont = buttonSettings.Font;
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
                    KeyHookStart();
                }));
            else
            {
                Show();
                KeyHookStart();
            }
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    KeyHookStop();
                    Hide();
                }));
            else
            {
                KeyHookStop();
                Hide();
            }
        }

        /// <summary>
        /// Use for Set Font to all Control text
        /// </summary>
        /// <param name="fontName">Name of Font</param>
        public void SetFont(string fontName)
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    SetFontInvoke(fontName);
                }));
            else
            {
                SetFontInvoke(fontName);
            }
        }

        /// <summary>
        /// Use for Set Font to all Control text
        /// </summary>
        /// <param name="fontName">Name of Font</param>
        private void SetFontInvoke(string fontName)
        {
            lblProductName.Font =
                new Font(fontName, _defaultProductNameFont.Size, _defaultProductNameFont.Style);
            txtProductInfo.Font =
                new Font(fontName, _defaultProductInfoFont.Size, _defaultProductInfoFont.Style);
            lblPrice.Font =
                new Font(fontName, _defaultPriceFont.Size, _defaultPriceFont.Style);
            txtPriceValue.Font =
                new Font(fontName, _defaultPriceValueFont.Size, _defaultPriceValueFont.Style);
            lblArticle.Font =
                new Font(fontName, _defaultArticleFont.Size, _defaultArticleFont.Style);
            txtArticleValue.Font =
                new Font(fontName, _defaultArticleValueFont.Size, _defaultArticleValueFont.Style);
            lblBarcode.Font =
                new Font(fontName, _defaultBarcodeFont.Size, _defaultBarcodeFont.Style);
            txtBarcodeValue.Font =
                new Font(fontName, _defaultBarcodeValueFont.Size, _defaultBarcodeValueFont.Style);
            buttonUp.Font =
                new Font(fontName, _defaultButtonUpFont.Size, _defaultButtonUpFont.Style);
            buttonDown.Font =
                new Font(fontName, _defaultButtonDownFont.Size, _defaultButtonDownFont.Style);
            buttonShares.Font =
                new Font(fontName, _defaultButtonSharesFont.Size, _defaultButtonSharesFont.Style);
            buttonSettings.Font =
                new Font(fontName, _defaultButtonSettingsFont.Size, _defaultButtonSettingsFont.Style);
        }

        /// <summary>
        /// Use for Set Default Font to all Control text
        /// </summary>
        public void SetDefaultFont()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { SetDefaultFontInvoke(); }));
            else SetDefaultFontInvoke();
        }

        /// <summary>
        /// Use for Set Default Font to all Control text
        /// </summary>
        private void SetDefaultFontInvoke()
        {
            lblProductName.Font = _defaultProductNameFont;
            txtProductInfo.Font = _defaultProductInfoFont;
            lblPrice.Font = _defaultPriceFont;
            txtPriceValue.Font = _defaultPriceValueFont;
            lblArticle.Font = _defaultArticleFont;
            txtArticleValue.Font = _defaultArticleValueFont;
            lblBarcode.Font = _defaultBarcodeFont;
            txtBarcodeValue.Font = _defaultBarcodeValueFont;
            buttonUp.Font = _defaultButtonUpFont;
            buttonDown.Font = _defaultButtonDownFont;
            buttonShares.Font = _defaultButtonSharesFont;
            buttonSettings.Font = _defaultButtonSettingsFont;
        }

        /// <summary>
        /// Use for Start Key Hook
        /// </summary>
        private void KeyHookStart()
        {
            if (KeyHook != null)
                KeyHook.HookEvent += HardKeyPressEvent;
        }

        /// <summary>
        /// Use for Stop Key Hook
        /// </summary>
        private void KeyHookStop()
        {
            if (KeyHook != null)
                KeyHook.HookEvent -= HardKeyPressEvent;
        }

        /// <summary>
        /// Actions for handle paint event
        /// </summary>
        /// <param name="e">Paint event args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(_background, 0, 0);
            this.buttonDown.Refresh();
            this.buttonSettings.Refresh();
            this.buttonShares.Refresh();
            this.buttonUp.Refresh();
            this.pictureBoxLogo.Refresh();
            this.lblProductName.Refresh();
            this.imgProducImage.Refresh();
            this.txtProductInfo.Refresh();
            this.lblPrice.Refresh();
            this.txtPriceValue.Refresh();
            this.lblArticle.Refresh();
            this.txtArticleValue.Refresh();
            this.lblBarcode.Refresh();
            this.txtBarcodeValue.Refresh();
        }

        /// <summary>
        /// Background Image
        /// </summary>
        public Image BackgroundImage
        {
            get { return _background; }
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
            txtArticleValue.SetText("", ICLabelTextAlign.Center);
            lblProductName.SetText("", ICLabelTextAlign.Center);
            txtProductInfo.SetText("", ICLabelTextAlign.Left);
            txtBarcodeValue.SetText("", ICLabelTextAlign.Center);
            txtPriceValue.SetText("", ICLabelTextAlign.Center);
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
                Invoke(new Action(() => { txtArticleValue.SetText(vendorCode, ICLabelTextAlign.Center); }));
            else txtArticleValue.SetText(vendorCode, ICLabelTextAlign.Center);
        }

        /// <summary>
        /// Use for set Product info
        /// </summary>
        /// <param name="productInfo">Product Info string</param>
        public void SetProductInfo(string productInfo)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtProductInfo.SetText(productInfo, ICLabelTextAlign.Left); }));
            else txtProductInfo.SetText(productInfo, ICLabelTextAlign.Left);
        }

        /// <summary>
        /// Use for set Product name
        /// </summary>
        /// <param name="productName">Product Name string</param>
        public void SetProductName(string productName)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { lblProductName.SetText(productName, ICLabelTextAlign.Left); }));
            else lblProductName.SetText(productName, ICLabelTextAlign.Left);
        }

        /// <summary>
        /// Use for set barcode value
        /// </summary>
        /// <param name="barCode">BarCode string</param>
        public void SetBarCode(string barCode)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtBarcodeValue.SetText(barCode, ICLabelTextAlign.Center); }));
            else txtBarcodeValue.SetText(barCode, ICLabelTextAlign.Center);
        }

        /// <summary>
        /// Use for set product price
        /// </summary>
        /// <param name="price">Price string</param>
        public void SetPrice(string price)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtPriceValue.SetText(price, ICLabelTextAlign.Center); }));
            else txtPriceValue.SetText(price, ICLabelTextAlign.Center);
        }

        /// <summary>
        /// Use for set Product image
        /// </summary>
        /// <param name="productImage">Product Image</param>
        public void SetProductImage(System.Drawing.Image productImage)
        {
            if (productImage == null)
                SetProductNoImage();

            if (InvokeRequired)
            {
                Invoke(new Action(() => 
                {
                    var newRect = Extensions.ImageRectangleFromSizeMode(ClientRectangle,
                        ICPictureSizeMode.Zoom, productImage.Size);
                    var newSize = new Size(newRect.Width, newRect.Height);
                    var newProductImage = Extensions.Resize(productImage, newSize);
                    imgProducImage.Image = (Bitmap)newProductImage; 
                }));
            }
            else
            {
                var newRect = Extensions.ImageRectangleFromSizeMode(ClientRectangle,
                        ICPictureSizeMode.Zoom, productImage.Size);
                var newSize = new Size(newRect.Width, newRect.Height);
                var newProductImage = Extensions.Resize(productImage, newSize);
                imgProducImage.Image = (Bitmap)newProductImage; 
            }
        }

        /// <summary>
        /// Use for Set Product NoImage picture
        /// </summary>
        public void SetProductNoImage()
        {
            var noImage = Resources.imgNoImage;
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    var newRect = Extensions.ImageRectangleFromSizeMode(ClientRectangle,
                        ICPictureSizeMode.Zoom, noImage.Size);
                    var newSize = new Size(newRect.Width, newRect.Height);
                    var newProductImage = Extensions.Resize(noImage, newSize);
                    imgProducImage.Image = (Bitmap)newProductImage;
                }));
            }
            else
            {
                var newRect = Extensions.ImageRectangleFromSizeMode(ClientRectangle,
                        ICPictureSizeMode.Zoom, noImage.Size);
                var newSize = new Size(newRect.Width, newRect.Height);
                var newProductImage = Extensions.Resize(noImage, newSize);
                imgProducImage.Image = (Bitmap)newProductImage;
            }
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
                lblArticle.SetText(systemTranslationData.LblVendorCodeText, ICLabelTextAlign.Center);
            else lblArticle.SetText("Article", ICLabelTextAlign.Center);

            if (!string.IsNullOrEmpty(systemTranslationData.LblPriceText))
                lblPrice.SetText(systemTranslationData.LblPriceText, ICLabelTextAlign.Center);
            else lblPrice.SetText("Price", ICLabelTextAlign.Center);

            if (!string.IsNullOrEmpty(systemTranslationData.LblBarCodeText))
                lblBarcode.SetText(systemTranslationData.LblBarCodeText, ICLabelTextAlign.Center);
            else lblBarcode.SetText("Barcode", ICLabelTextAlign.Center);

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
                        pictureBoxLogo.Image = (Bitmap)image;
                }));
            }
            else
            {
                if (image != null)
                    pictureBoxLogo.Image = (Bitmap)image;
            }
        }

        /// <summary>
        /// Use for to do Press Hard Key action
        /// </summary>
        /// <param name="key">Key</param>
        private void HardKeyPressEvent(int key)
        {
            if (!KeyHook.KeyHandled)
            {
                if (InvokeRequired)
                    Invoke(new Action(() => { HardKeyPress(key); }));
                else HardKeyPress(key);
            }
        }

        /// <summary>
        /// Use for to do Hard Key Press action by Key
        /// </summary>
        /// <param name="key">Key</param>
        private void HardKeyPress(int key)
        {
            if (Visible)
            {
                KeyHook.KeyHandled = true;

                switch (key)
                {
                    case 0x10:
                        BtnUp();
                        break;
                    case 0x35:
                        BtnDown();
                        break;
                    case 0x30:
                        if (buttonShares.Visible)
                        {
                            if (ClickButtonSharesEvent != null)
                                ClickButtonSharesEvent.Invoke();
                        }
                        break;
                    case 0x40:
                        if (ClickButtonSettingsEvent != null)
                            ClickButtonSettingsEvent.Invoke();
                        break;
                }
            }
        }

        #endregion        
    }
}