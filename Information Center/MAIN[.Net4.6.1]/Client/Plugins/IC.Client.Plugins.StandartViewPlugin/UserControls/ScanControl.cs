using System;
using System.Drawing;
using System.Windows.Forms;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces.ControlModel;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Presents Scan control
    /// 
    /// 2017/02/18 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.Scan)]
    public partial class ScanControl : UserControl, IScanControl
    {
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
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for show control
        /// </summary>
        public void ShowControl()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { Show(); }));
            else Show();
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
                lblScanBarcodePlease.Text = systemTranslationData.LblScanBarCodeText;
            else lblScanBarcodePlease.Text = "Scan Product Barcode Please!";

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
                        pictureBoxLogo.Image = image;
                }));
            else
            {
                if (image != null)
                    pictureBoxLogo.Image = image;
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

        #endregion                
    }
}