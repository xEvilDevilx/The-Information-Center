using System;
using System.Drawing;
using System.Windows.Forms;

using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Base.EventHandlers;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.Client.Plugins.Terminal.HardKeys;
using IC.SDK;

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
        #region Properties

        /// <summary>Key Hook manage</summary>
        public IKeyHook KeyHook { get; set; }

        #endregion

        #region Events

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
                    Logger.Log.Info("SetDefaultFont. For Advertising control is not implemented");
                }));
            else Logger.Log.Info("SetDefaultFont. For Advertising control is not implemented");
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
                if (CloseControlEvent != null)
                    CloseControlEvent.Invoke();
            }
        }
        
        #endregion
    }
}