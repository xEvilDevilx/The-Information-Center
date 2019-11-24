using System;
using System.Windows.Forms;

using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces.ControlModel;

namespace IC.Client.Plugins.StandartViewPlugin.UserControls
{
    /// <summary>
    /// Implements Wait Control
    /// 
    /// 2017/03/02 - Created, VTyagunov
    /// </summary>
    [ControlType(UserControlTypes.Wait)]
    public partial class WaitControl : UserControl, IWaitControl
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public WaitControl()
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
        
        #endregion
    }
}