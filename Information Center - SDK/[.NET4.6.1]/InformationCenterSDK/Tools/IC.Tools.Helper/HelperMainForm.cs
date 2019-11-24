using System;
using System.Windows.Forms;

using IC.SDK.Helpers;

namespace IC.Tools.Helper
{
    /// <summary>
    /// Presents Helper Main Form
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public partial class HelperMainForm : Form
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public HelperMainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Event action for Get MAX Address of current hardware
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetMACAddress_Click(object sender, EventArgs e)
        {
            var macAddress = Utils.GetMacAddress();
            txtMACAddress.Text = macAddress;
        }

        #endregion
    }
}