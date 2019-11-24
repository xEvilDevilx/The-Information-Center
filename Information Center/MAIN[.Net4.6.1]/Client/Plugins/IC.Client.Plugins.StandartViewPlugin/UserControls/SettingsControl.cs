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
    /// Presents Settings control interface
    /// 
    /// 2017/02/27 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.Settings)]
    public partial class SettingsControl : UserControl, ISettingsControl
    {
        #region Properties

        /// <summary>Store old control type</summary>
        public UserControlTypes OldControl { get; set; }

        #endregion

        #region Events

        /// <summary>Click Control Event</summary>
        public event ControlEventHandlers.ClickControlEventHandler ClickControlEvent;
        /// <summary>Click Button Cancel Event</summary>
        public event ControlEventHandlers.ClickButtonCancelEventHandler ClickButtonCancelEvent;
        /// <summary>Click Button Language Event</summary>
        public event ControlEventHandlers.ClickButtonLanguageEventHandler ClickButtonLanguageEvent;
        /// <summary>Click Button Currency Event</summary>
        public event ControlEventHandlers.ClickButtonCurrencyEventHandler ClickButtonCurrencyEvent;
        /// <summary>Click Button Choose Event</summary>
        public event ControlEventHandlers.ClickButtonChooseEventHandler ClickButtonChooseEvent;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsControl()
        {
            InitializeComponent();

            ClearListItems(AdvancedListTypes.Currency);
            ClearListItems(AdvancedListTypes.Language);
        }

        #endregion

        #region Methods

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
        /// Use for show control
        /// </summary>
        public void ShowControl()
        {
            if (InvokeRequired)
                Invoke(new Action(() => { Show(); }));
            else Show();
        }

        /// <summary>
        /// Use for set visibilities for label MoreItems
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="advancedListType"></param>
        public void SetLblMoreItemsVisibility(bool visible, AdvancedListTypes advancedListType)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { SetLblMoreItemsVisibilityInvoke(visible, advancedListType); }));
            else SetLblMoreItemsVisibilityInvoke(visible, advancedListType);
        }

        /// <summary>
        /// Use for set visibilities for label MoreCurrencyItems
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="advancedListType"></param>
        private void SetLblMoreItemsVisibilityInvoke(bool visible, AdvancedListTypes advancedListType)
        {
            switch (advancedListType)
            {
                case AdvancedListTypes.Currency:
                    SetLblMoreCurrencyVisibilityInvoke(visible);
                    break;
                case AdvancedListTypes.Language:
                    SetLblMoreLanguageVisibilityInvoke(visible);
                    break;
            }
        }

        /// <summary>
        /// Use for set visibilities for label MoreCurrencyItems
        /// </summary>
        /// <param name="visible"></param>
        private void SetLblMoreCurrencyVisibilityInvoke(bool visible)
        {
            imgCurrencyDots.Visible = visible;
        }

        /// <summary>
        /// Use for set visibilities for label MoreLanguageItems
        /// </summary>
        /// <param name="visible"></param>
        private void SetLblMoreLanguageVisibilityInvoke(bool visible)
        {
            imgLanguageDots.Visible = visible;
        }

        /// <summary>
        /// Use for add new item to Advanced Item component
        /// </summary>
        /// <param name="advancedItem">Advanced Item object</param>
        public void SetItemToAdvancedItem(AdvancedItem advancedItem, int itemSlotID,
            AdvancedListTypes advancedListType)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    SetItemToAdvancedItemInvoke(advancedItem,
                        itemSlotID, advancedListType);
                }));
            }
            else SetItemToAdvancedItemInvoke(advancedItem, itemSlotID, advancedListType);
        }

        /// <summary>
        /// Use for add new item to Language Item component
        /// </summary>
        /// <param name="advancedItem">Advanced Item object</param>
        private void SetItemToAdvancedItemInvoke(AdvancedItem advancedItem, int itemSlotID,
            AdvancedListTypes advancedListType)
        {
            switch (advancedListType)
            {
                case AdvancedListTypes.Language:
                    SetItemToLanguageItem(advancedItem, itemSlotID);
                    break;
                case AdvancedListTypes.Currency:
                    SetItemToCurrencyItem(advancedItem, itemSlotID);
                    break;
            }
        }

        /// <summary>
        /// Use for add new item to Currency Item
        /// </summary>
        /// <param name="advancedItem">Advanced Item object</param>
        private void SetItemToLanguageItem(AdvancedItem advancedItem, int itemSlotID)
        {
            switch (itemSlotID)
            {
                case 0:
                    languageItem1.SetData(advancedItem.ItemName, advancedItem.ItemImage);
                    break;
                case 1:
                    languageItem2.SetData(advancedItem.ItemName, advancedItem.ItemImage);
                    break;
                case 2:
                    languageItem3.SetData(advancedItem.ItemName, advancedItem.ItemImage);
                    break;
            }
        }

        /// <summary>
        /// Use for add new item to Currency Item
        /// </summary>
        /// <param name="advancedItem">Advanced Item object</param>
        private void SetItemToCurrencyItem(AdvancedItem advancedItem, int itemSlotID)
        {
            switch (itemSlotID)
            {
                case 0:
                    currencyItem1.SetData(advancedItem.ItemName, advancedItem.ItemImage);
                    break;
                case 1:
                    currencyItem2.SetData(advancedItem.ItemName, advancedItem.ItemImage);
                    break;
                case 2:
                    currencyItem3.SetData(advancedItem.ItemName, advancedItem.ItemImage);
                    break;
            }
        }

        /// <summary>
        /// Use for Set Empty Item
        /// </summary>
        /// <param name="itemSlotID">Item Slot ID</param>
        /// <param name="advancedListType">Advanced List Type</param>
        public void SetEmptyItem(int itemSlotID, AdvancedListTypes advancedListType)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    SetEmptyItemInvoke(itemSlotID, advancedListType);
                }));
            }
            else SetEmptyItemInvoke(itemSlotID, advancedListType);
        }

        /// <summary>
        /// Use for Set empty item
        /// </summary>
        /// <param name="itemSlotID">Item Slot ID</param>
        /// <param name="advancedListType">Advanced List Type</param>
        private void SetEmptyItemInvoke(int itemSlotID, AdvancedListTypes advancedListType)
        {
            switch (advancedListType)
            {
                case AdvancedListTypes.Language:
                    SetEmptyLanguageItem(itemSlotID);
                    break;
                case AdvancedListTypes.Currency:
                    SetEmptyCurrencyItem(itemSlotID);
                    break;
            }
        }

        /// <summary>
        /// Use for Set Empty Language Item
        /// </summary>
        /// <param name="itemSlotID"></param>
        private void SetEmptyLanguageItem(int itemSlotID)
        {
            switch (itemSlotID)
            {
                case 0:
                    languageItem1.Inaccessable = true;
                    break;
                case 1:
                    languageItem2.Inaccessable = true;
                    break;
                case 2:
                    languageItem3.Inaccessable = true;
                    break;
            }
        }

        /// <summary>
        /// Use for Set Empty Currency Item
        /// </summary>
        /// <param name="itemSlotID"></param>
        private void SetEmptyCurrencyItem(int itemSlotID)
        {
            switch (itemSlotID)
            {
                case 0:
                    currencyItem1.Inaccessable = true;
                    break;
                case 1:
                    currencyItem2.Inaccessable = true;
                    break;
                case 2:
                    currencyItem3.Inaccessable = true;
                    break;
            }
        }

        /// <summary>
        /// Use for clear Language Items
        /// </summary>
        /// <param name="advancedListType"></param>
        public void ClearListItems(AdvancedListTypes advancedListType)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { ClearListItemsInvoke(advancedListType); }));
            else ClearListItemsInvoke(advancedListType);
        }

        /// <summary>
        /// Use for clear Language Items
        /// </summary>
        /// <param name="advancedListType"></param>
        private void ClearListItemsInvoke(AdvancedListTypes advancedListType)
        {
            switch (advancedListType)
            {
                case AdvancedListTypes.Currency:
                    ClearCurrencyItemsInvoke();
                    break;
                case AdvancedListTypes.Language:
                    ClearLanguageItemsInvoke();
                    break;
            }
        }

        /// <summary>
        /// Use for clear Currency Items
        /// </summary>
        private void ClearCurrencyItemsInvoke()
        {
            this.currencyItem1.IsShowRectangle = true;
            this.currencyItem1.Inaccessable = false;

            this.currencyItem2.Inaccessable = false;
            this.currencyItem2.FontSize = this.currencyItem1.FontSize / 1.3f;
            var newImageHeight = (float)this.currencyItem1.ImageSize.Height / 1.3f;
            var newImageWidth = (float)this.currencyItem1.ImageSize.Width / 1.3f;
            var newImageSize = new Size((int)newImageWidth, (int)newImageHeight);
            this.currencyItem2.ImageSize = newImageSize;

            this.currencyItem3.Inaccessable = false;
            this.currencyItem3.FontSize = this.currencyItem2.FontSize / 1.3f;
            newImageHeight = (float)this.currencyItem2.ImageSize.Height / 1.3f;
            newImageWidth = (float)this.currencyItem2.ImageSize.Width / 1.3f;
            newImageSize = new Size((int)newImageWidth, (int)newImageHeight);
            this.currencyItem3.ImageSize = newImageSize;

            this.imgCurrencyDots.Visible = false;
        }

        /// <summary>
        /// Use for clear Language Items
        /// </summary>
        private void ClearLanguageItemsInvoke()
        {
            this.languageItem1.IsShowRectangle = true;
            this.languageItem1.Inaccessable = false;

            this.languageItem2.Inaccessable = false;
            this.languageItem2.FontSize = this.languageItem1.FontSize / 1.3f;
            var newImageHeight = (float)this.languageItem1.ImageSize.Height / 1.3f;
            var newImageWidth = (float)this.languageItem1.ImageSize.Width / 1.3f;
            var newImageSize = new Size((int)newImageWidth, (int)newImageHeight);
            this.languageItem2.ImageSize = newImageSize;

            this.languageItem3.Inaccessable = false;
            this.languageItem3.FontSize = this.languageItem1.FontSize / 1.3f;
            newImageHeight = (float)this.languageItem2.ImageSize.Height / 1.3f;
            newImageWidth = (float)this.languageItem2.ImageSize.Width / 1.3f;
            newImageSize = new Size((int)newImageWidth, (int)newImageHeight);
            this.languageItem3.ImageSize = newImageSize;

            this.imgLanguageDots.Visible = false;
        }

        /// <summary>
        /// Action of Click on Cancel button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (ClickButtonCancelEvent != null)
                ClickButtonCancelEvent.Invoke();
        }

        /// <summary>
        /// Action of Click on Language button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            if (ClickButtonLanguageEvent != null)
                ClickButtonLanguageEvent.Invoke();
        }

        /// <summary>
        /// Action of Click on Currency button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCurrency_Click(object sender, EventArgs e)
        {
            if (ClickButtonCurrencyEvent != null)
                ClickButtonCurrencyEvent.Invoke();
        }

        /// <summary>
        /// Action of Click on Choose button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (ClickButtonChooseEvent != null)
                ClickButtonChooseEvent.Invoke();
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
            if (!string.IsNullOrEmpty(systemTranslationData.LblSettingsText))
                lblSettings.Text = systemTranslationData.LblSettingsText;
            else lblSettings.Text = "Settings";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnUpText))
                buttonLanguage.Text = systemTranslationData.BtnLang;
            else buttonLanguage.Text = "Up";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnDownText))
                buttonCurrency.Text = systemTranslationData.BtnCurrency;
            else buttonCurrency.Text = "Down";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnChooseText))
                buttonChoose.Text = systemTranslationData.BtnChooseText;
            else buttonChoose.Text = "Choose";

            if (!string.IsNullOrEmpty(systemTranslationData.BtnCancelText))
                buttonCancel.Text = systemTranslationData.BtnCancelText;
            else buttonCancel.Text = "Cancel";
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