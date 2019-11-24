using System;
using System.Drawing;
using System.Windows.Forms;

using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.Client.DataLayer;
using IC.Client.Plugins.StandartViewPlugin.Properties;
using IC.Client.Plugins.Terminal.HardKeys;
using IC.Client.View.Components;
using IC.Client.View.Components.Enum;
using IC.SDK;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Presents ProductByShare control interface
    /// 
    /// 2017/03/05 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.ProductByShare)]
    public partial class ProductByShareControl : UserControl, IProductByShareControl, IControlBackground
    {
        #region Variables

        /// <summary>Control background image</summary>
        private Image _background;
        /// <summary>Default Product Name Font</summary>
        private Font _defaultProductNameFont;
        /// <summary>Default Product By Share Info Font</summary>
        private Font _defaultProductByShareInfoFont;
        /// <summary>Default Price Font</summary>
        private Font _defaultPriceFont;
        /// <summary>Default Price Value Font</summary>
        private Font _defaultPriceValueFont;
        /// <summary>Default Article Font</summary>
        private Font _defaultArticleFont;
        /// <summary>Default Article Value Font</summary>
        private Font _defaultArticleValueFont;
        /// <summary>Default Barcode Font</summary>
        private Font _defaultBarcodeFont;
        /// <summary>Default Barcode Value Font</summary>
        private Font _defaultBarcodeValueFont;
        /// <summary>Default Button Up Font</summary>
        private Font _defaultButtonUpFont;
        /// <summary>Default Button Down Font</summary>
        private Font _defaultButtonDownFont;
        /// <summary>Default Button Back Font</summary>
        private Font _defaultButtonBackFont;
        /// <summary>Default Button Settings Font</summary>
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
        /// <summary>Click Button Back Event</summary>
        public event ControlEventHandlers.ClickButtonBackEventHandler ClickButtonBackEvent;
        /// <summary>Click Button Settings Event</summary>
        public event ControlEventHandlers.ClickButtonSettingsEventHandler ClickButtonSettingsEvent;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductByShareControl()
        {
            InitializeComponent();

            _background = ((System.Drawing.Image)(Resources.imgBackground));
            var img = Extensions.Resize(_background, new Size(this.ClientSize.Width,
                this.ClientSize.Height));
            _background = img;

            _defaultProductNameFont = lblProductName.Font;
            _defaultProductByShareInfoFont = txtProductByShareInfo.Font;
            _defaultPriceFont = lblPrice.Font;
            _defaultPriceValueFont = txtPriceValue.Font;
            _defaultArticleFont = lblArticle.Font;
            _defaultArticleValueFont = txtArticleValue.Font;
            _defaultBarcodeFont = lblBarcode.Font;
            _defaultBarcodeValueFont = txtBarcodeValue.Font;
            _defaultButtonUpFont = buttonUp.Font;
            _defaultButtonDownFont = buttonDown.Font;
            _defaultButtonBackFont = buttonBack.Font;
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
                Invoke(new Action(() => { txtProductByShareInfo.ScrollUp(); }));
            else txtProductByShareInfo.ScrollUp();
        }

        /// <summary>
        /// Use for does button down action
        /// </summary>
        public void BtnDown()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtProductByShareInfo.ScrollDown(); }));
            else txtProductByShareInfo.ScrollDown();
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
            txtProductByShareInfo.Font = 
                new Font(fontName, _defaultProductByShareInfoFont.Size, _defaultProductByShareInfoFont.Style);
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
            buttonBack.Font =
                new Font(fontName, _defaultButtonBackFont.Size, _defaultButtonBackFont.Style);
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
            txtProductByShareInfo.Font = _defaultProductByShareInfoFont;
            lblPrice.Font = _defaultPriceFont;
            txtPriceValue.Font = _defaultPriceValueFont;
            lblArticle.Font = _defaultArticleFont;
            txtArticleValue.Font = _defaultArticleValueFont;
            lblBarcode.Font = _defaultBarcodeFont;
            txtBarcodeValue.Font = _defaultBarcodeValueFont;
            buttonUp.Font = _defaultButtonUpFont;
            buttonDown.Font = _defaultButtonDownFont;
            buttonBack.Font = _defaultButtonBackFont;
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
            this.buttonBack.Refresh();
            this.buttonDown.Refresh();
            this.buttonSettings.Refresh();
            this.buttonUp.Refresh();
            this.pictureBoxLogo.Refresh();
            this.lblProductName.Refresh();
            this.txtProductByShareInfo.Refresh();
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
        /// Button Back click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, System.EventArgs e)
        {
            if (ClickButtonBackEvent != null)
                ClickButtonBackEvent.Invoke();
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
        /// Use for clear all control data
        /// </summary>
        private void ClearControlDataInvoke()
        {
            txtArticleValue.SetText("", ICLabelTextAlign.Center);
            lblProductName.SetText("", ICLabelTextAlign.Center);
            txtProductByShareInfo.SetText("", ICLabelTextAlign.Left);
            txtBarcodeValue.SetText("", ICLabelTextAlign.Center);
            txtPriceValue.SetText("", ICLabelTextAlign.Center);
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
        public void SetProductByShareInfo(string productInfo)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtProductByShareInfo.SetText(productInfo, 
                    ICLabelTextAlign.Left); }));
            else txtProductByShareInfo.SetText(productInfo, ICLabelTextAlign.Left);
        }

        /// <summary>
        /// Use for set Product name
        /// </summary>
        /// <param name="productName">Product Name string</param>
        public void SetProductName(string productName)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { lblProductName.SetText(productName, 
                    ICLabelTextAlign.Left); }));
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
        /// <param name="price">Product Price string</param>
        public void SetPrice(string price)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtPriceValue.SetText(price, ICLabelTextAlign.Center); }));
            else txtPriceValue.SetText(price, ICLabelTextAlign.Center);
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

            if (!string.IsNullOrEmpty(systemTranslationData.BtnBackText))
                buttonBack.Text = systemTranslationData.BtnBackText;
            else buttonBack.Text = "Back";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnSettingsText))
                buttonSettings.Text = systemTranslationData.BtnSettingsText;
            else buttonSettings.Text = "Language/Currency";
        }

        /// <summary>
        /// Use for set image to Logo
        /// </summary>
        /// <param name="image">Logo Image</param>
        public void SetLogoImage(Image image)
        {
            if (InvokeRequired)
                Invoke(new Action(() => 
                {
                    if (image != null)
                        pictureBoxLogo.Image = (Bitmap)image;
                }));
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
                        if (ClickButtonBackEvent != null)
                            ClickButtonBackEvent.Invoke();
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