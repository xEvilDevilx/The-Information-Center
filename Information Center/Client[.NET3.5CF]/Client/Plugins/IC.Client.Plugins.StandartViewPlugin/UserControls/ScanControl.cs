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
    /// Presents Scan control
    /// 
    /// 2017/02/18 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.Scan)]
    public partial class ScanControl : UserControl, IScanControl, IControlBackground
    {
        #region Variables

        /// <summary>Control background image</summary>
        private Image _background;
        /// <summary>Default Scan Barcode Please Font</summary>
        private Font _defaultScanBarcodePleaseFont;
        /// <summary>Default Button Shares Font</summary>
        private Font _defaultButtonSharesFont;
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
        /// <summary>Click Button Shares Event</summary>
        public event ControlEventHandlers.ClickButtonSharesEventHandler ClickButtonSharesEvent;
        /// <summary>Click Button Settings Event</summary>
        public event ControlEventHandlers.ClickButtonSettingsEventHandler ClickButtonSettingsEvent;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ScanControl()
        {
            InitializeComponent();

            _background = ((System.Drawing.Image)(Resources.imgCleanBackground));
            var img = Extensions.Resize(_background, new Size(this.ClientSize.Width,
                this.ClientSize.Height));
            _background = img;

            _defaultScanBarcodePleaseFont = lblScanBarcodePlease.Font;
            _defaultButtonSharesFont = buttonShares.Font;
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
            lblScanBarcodePlease.Font =
                new Font(fontName, _defaultScanBarcodePleaseFont.Size, _defaultScanBarcodePleaseFont.Style);
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
            lblScanBarcodePlease.Font = _defaultScanBarcodePleaseFont;
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
            this.buttonSettings.Refresh();
            this.buttonShares.Refresh();
            this.pictureBoxLogo.Refresh();
            this.lblScanBarcodePlease.Refresh();
        }

        /// <summary>
        /// Background Image
        /// </summary>
        public Image BackgroundImage
        {
            get { return _background; }
        }

        /// <summary>
        /// Use for set system data of control
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
            if (!string.IsNullOrEmpty(systemTranslationData.LblScanBarCodeText))
                lblScanBarcodePlease.SetText(systemTranslationData.LblScanBarCodeText,
                    ICLabelTextAlign.Center);
            else lblScanBarcodePlease.SetText("Scan Product Barcode Please!", ICLabelTextAlign.Center);

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
        /// Action of Click on control event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOnControl(object sender, EventArgs e)
        {
            if (ClickControlEvent != null)
                ClickControlEvent.Invoke();
        }

        /// <summary>
        /// Action of Click on Shares button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonShares_Click(object sender, EventArgs e)
        {
            if (ClickButtonSharesEvent != null)
                ClickButtonSharesEvent.Invoke();
        }

        /// <summary>
        /// Action of Click on Settings button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (ClickButtonSettingsEvent != null)
                ClickButtonSettingsEvent.Invoke();
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
                        //if (_keyExit < 4)
                        //    _keyExit++;
                        //if (_keyExit > 3)
                        //    _keyExit = 0;
                        break;
                    case 0x35:
                        //if (_keyExit > 2)
                        //    _keyExit++;
                        //if (_keyExit > 5)
                        //{
                        //    if (InvokeRequired)
                        //    {

                        //    }
                        //    else
                        //    {
                        //        if (AppCloseEvent != null)
                        //            AppCloseEvent();
                        //    }

                        //    Application.Exit();
                        //}
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