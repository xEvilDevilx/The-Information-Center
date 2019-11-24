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
    /// Presents Shares and Sales control interface
    /// 
    /// 2017/02/24 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.SharesSales)]
    public partial class SharesSalesControl : UserControl, ISharesSalesControl
    {
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
                        lblSharesSalesCapture.Text = sharesSalesData.ShareName;
                        txtSharesSalesDescriptions.Text = sharesSalesData.ShareDesription;
                    }));
                else
                {
                    lblSharesSalesCapture.Text = sharesSalesData.ShareName;
                    txtSharesSalesDescriptions.Text = sharesSalesData.ShareDesription;
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
                lblSharesSales.Text = systemTranslationData.LblSharesAndSalesText;
            else lblSharesSales.Text = "Shares and Sales";

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
                        pictureBoxLogo.Image = image;
                }));
            else
            {
                if (image != null)
                    pictureBoxLogo.Image = image;
            }
        }

        #endregion
    }
}