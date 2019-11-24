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

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Presents Shares and Sales control interface
    /// 
    /// 2017/02/24 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.SharesSales)]
    public partial class SharesSalesControl : UserControl, ISharesSalesControl, IControlBackground
    {
        #region Variables

        /// <summary>Control background image</summary>
        private Image _background;
        /// <summary>Default Shares Sales Font</summary>
        private Font _defaultSharesSalesFont;
        /// <summary>Default Shares Sales Capture Font</summary>
        private Font _defaultSharesSalesCaptureFont;
        /// <summary>Default Shares Sales Descriptions Font</summary>
        private Font _defaultSharesSalesDescriptionsFont;
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
        /// <summary>Click Button Previous Event</summary>
        public event ControlEventHandlers.ClickButtonPreviousEventHandler ClickButtonPreviousEvent;
        /// <summary>Click Button Next Event</summary>
        public event ControlEventHandlers.ClickButtonNextEventHandler ClickButtonNextEvent;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public SharesSalesControl()
        {
            InitializeComponent();

            _background = ((System.Drawing.Image)(Resources.imgProductNotFoundBackground));
            var img = Extensions.Resize(_background, new Size(this.ClientSize.Width,
                this.ClientSize.Height));
            _background = img;

            _defaultSharesSalesFont = lblSharesSales.Font;
            _defaultSharesSalesCaptureFont = lblSharesSalesCapture.Font;
            _defaultSharesSalesDescriptionsFont = txtSharesSalesDescriptions.Font;
            _defaultButtonUpFont = buttonUp.Font;
            _defaultButtonDownFont = buttonDown.Font;
            _defaultButtonBackFont = buttonBack.Font;
            _defaultButtonSettingsFont = buttonSettings.Font;
        }

        #endregion

        #region Methods

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
            lblSharesSales.Font =
                new Font(fontName, _defaultSharesSalesFont.Size, _defaultSharesSalesFont.Style);
            lblSharesSalesCapture.Font =
                new Font(fontName, _defaultSharesSalesCaptureFont.Size, _defaultSharesSalesCaptureFont.Style);
            txtSharesSalesDescriptions.Font =
                new Font(fontName, _defaultSharesSalesDescriptionsFont.Size,
                    _defaultSharesSalesDescriptionsFont.Style);
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
            lblSharesSales.Font = _defaultSharesSalesFont;
            lblSharesSalesCapture.Font = _defaultSharesSalesCaptureFont;
            txtSharesSalesDescriptions.Font = _defaultSharesSalesDescriptionsFont;
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
            this.btnNext.Refresh();
            this.btnPrevious.Refresh();
            this.buttonBack.Refresh();
            this.buttonDown.Refresh();
            this.buttonSettings.Refresh();
            this.buttonUp.Refresh();
            this.pictureBoxLogo.Refresh();
            this.lblSharesSales.Refresh();
            this.lblSharesSalesCapture.Refresh();
            this.txtSharesSalesDescriptions.Refresh();
        }

        /// <summary>
        /// Background Image
        /// </summary>
        public Image BackgroundImage
        {
            get { return _background; }
        }

        /// <summary>
        /// Use for does button up action
        /// </summary>  
        public void BtnUp()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtSharesSalesDescriptions.ScrollUp(); }));
            else txtSharesSalesDescriptions.ScrollUp();
        }

        /// <summary>
        /// Use for does button down action
        /// </summary> 
        public void BtnDown()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { txtSharesSalesDescriptions.ScrollDown(); }));
            else txtSharesSalesDescriptions.ScrollDown();
        }

        /// <summary>
        /// Button Back click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (ClickButtonBackEvent != null)
                ClickButtonBackEvent.Invoke();
        }

        /// <summary>
        /// Use for set Shares and Sales data
        /// </summary>
        /// <param name="sharesSalesData">Shares Sales Data object</param>
        public void SetSharesSalesData(SharesSalesData sharesSalesData)
        {
            if (sharesSalesData != null)
            {
                if (InvokeRequired)
                    Invoke(new Action(() => 
                    {
                        lblSharesSalesCapture.SetText(sharesSalesData.ShareName, ICLabelTextAlign.Left);
                        txtSharesSalesDescriptions.SetText(sharesSalesData.ShareDesription, 
                            ICLabelTextAlign.Left);
                    }));
                else
                {
                    lblSharesSalesCapture.SetText(sharesSalesData.ShareName, ICLabelTextAlign.Left);
                    txtSharesSalesDescriptions.SetText(sharesSalesData.ShareDesription,
                        ICLabelTextAlign.Left);
                }
            }
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
        /// Button Previous click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, System.EventArgs e)
        {
            if (ClickButtonPreviousEvent != null)
                ClickButtonPreviousEvent.Invoke();
        }

        /// <summary>
        /// Button Next click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (ClickButtonNextEvent != null)
                ClickButtonNextEvent.Invoke();
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
            if (!string.IsNullOrEmpty(systemTranslationData.LblSharesAndSalesText))
                lblSharesSales.SetText(systemTranslationData.LblSharesAndSalesText, 
                    ICLabelTextAlign.Center);
            else lblSharesSales.SetText("Shares and Sales", ICLabelTextAlign.Center);

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
            else buttonSettings.Text = "Settings";
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