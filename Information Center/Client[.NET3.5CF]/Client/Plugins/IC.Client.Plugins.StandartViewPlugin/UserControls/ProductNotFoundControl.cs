using System;
using System.Drawing;
using System.Windows.Forms;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.Client.Plugins.StandartViewPlugin.Properties;
using IC.Client.View.Components;
using IC.Client.View.Components.Enum;
using IC.SDK;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Presents ProductNotFound control
    /// 
    /// 2017/02/18 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.ProductNotFound)]
    public partial class ProductNotFoundControl : UserControl, IProductNotFoundControl, IControlBackground
    {
        #region Variables

        /// <summary>Control background image</summary>
        private Image _background;
        /// <summary>Default Product Not Found Font</summary>
        private Font _defaultProductNotFoundFont;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductNotFoundControl()
        {
            InitializeComponent();

            _background = ((System.Drawing.Image)(Resources.imgProductNotFoundBackground));
            var img = Extensions.Resize(_background, new Size(this.ClientSize.Width,
                this.ClientSize.Height));
            _background = img;
            txtProductNotFound.SetText("txtProductNotFound", ICLabelTextAlign.Center);

            _defaultProductNotFoundFont = txtProductNotFound.Font;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for show control
        /// </summary>
        public void ShowControl()
        {
            if (InvokeRequired)
                Invoke(new Action(() => Show()));
            else Show();
        }

        /// <summary>
        /// Use for hide control
        /// </summary>
        public void HideControl()
        {
            if (InvokeRequired)
                Invoke(new Action(() => Hide()));
            else Hide();
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
            txtProductNotFound.Font =
                new Font(fontName, _defaultProductNotFoundFont.Size, _defaultProductNotFoundFont.Style);
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
            txtProductNotFound.Font = _defaultProductNotFoundFont;
        }

        /// <summary>
        /// Actions for handle paint event
        /// </summary>
        /// <param name="e">Paint event args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(_background, 0, 0);
            this.pictureBoxLogo.Refresh();
            this.txtProductNotFound.Refresh();
        }

        /// <summary>
        /// Background Image
        /// </summary>
        public Image BackgroundImage
        {
            get { return _background; }
        }

        /// <summary>
        /// Use for localize system data of control
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
            if (!string.IsNullOrEmpty(systemTranslationData.LblProductNotFoundInDBText))
                txtProductNotFound.SetText(systemTranslationData.LblProductNotFoundInDBText,
                    ICLabelTextAlign.Center);
            else txtProductNotFound.SetText("Sorry! Product not found!", ICLabelTextAlign.Center);
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

        #endregion
    }
}