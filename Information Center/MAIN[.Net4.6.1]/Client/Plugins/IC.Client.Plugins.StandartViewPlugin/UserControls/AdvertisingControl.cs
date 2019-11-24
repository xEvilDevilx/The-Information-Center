using System;
using System.Drawing;
using System.Windows.Forms;

using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces.ControlModel;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Implements Advertising Control
    /// 
    /// 2017/01/29 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.Advertising)]
    public partial class AdvertisingControl : UserControl, IAdvertisingControl
    {
        #region Variables

        /// <summary>Close control event</summary>
        public event ControlEventHandlers.CloseControlEventHandler CloseControlEvent;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public AdvertisingControl()
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
        /// Use for change advertising image in control
        /// </summary>
        /// <param name="newImage">New advertising image</param>
        public void ChangeAdvertisement(Bitmap newImage)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { ChangeAdvertisementInvoke(newImage); }));
            else ChangeAdvertisementInvoke(newImage);
        }

        /// <summary>
        /// Use for change advertising image in control
        /// </summary>
        /// <param name="newImage">New advertising image</param>
        private void ChangeAdvertisementInvoke(Bitmap newImage)
        {
            advertisingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            if (advertisingPictureBox.Image != null)
                advertisingPictureBox.Image.Dispose();
            advertisingPictureBox.Image = newImage;
        }

        /// <summary>
        /// Advertising Control click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickOnControl(object sender, System.EventArgs e)
        {
            if (CloseControlEvent != null)
                CloseControlEvent.Invoke();
        }
        
        #endregion
    }
}