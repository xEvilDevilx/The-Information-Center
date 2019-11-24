using System;
using System.Drawing;
using System.Windows.Forms;

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
    /// Implements Wait Control
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.Wait)]
    public partial class WaitControl : UserControl, IWaitControl, IControlBackground
    {
        #region Variables

        /// <summary>Control background image</summary>
        private Image _background;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public WaitControl()
        {
            InitializeComponent();

            _background = ((System.Drawing.Image)(Resources.imgProductNotFoundBackground));
            var img = Extensions.Resize(_background, new Size(this.ClientSize.Width,
                this.ClientSize.Height));
            _background = img;
            lblWaitPlease.SetText("Wait Please", ICLabelTextAlign.Center);
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
                    Logger.Log.Info("SetFont. For Advertising control is not implemented");
                }));
            else Logger.Log.Info("SetFont. For Advertising control is not implemented");
        }

        /// <summary>
        /// Use for Set Default Font to all Control text
        /// </summary>
        public void SetDefaultFont()
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    Logger.Log.Info("SetDefaultFont. For Wait control is not implemented");
                }));
            else Logger.Log.Info("SetDefaultFont. For Wait control is not implemented");
        }

        /// <summary>
        /// Actions for handle paint event
        /// </summary>
        /// <param name="e">Paint event args</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(_background, 0, 0);
            this.lblWaitPlease.Refresh();
        }

        /// <summary>
        /// Background Image
        /// </summary>
        public Image BackgroundImage
        {
            get { return _background; }
        }

        #endregion
    }
}