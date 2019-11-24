using System;
using System.Windows.Forms;

using IC.SDK.Interfaces.Helpers;

namespace IC.Tools.UniqueKeyGenerator
{
    /// <summary>
    /// Presents Unique Key Generator Main Form
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public partial class UniqueKeyGeneratorMainForm : Form
    {
        #region Variables

        /// <summary>Key Generator functionality</summary>
        private IKeyGenerator _generator;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public UniqueKeyGeneratorMainForm()
        {
            InitializeComponent();

            _generator = new KeyGenerator();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Action of button Generate click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if(txtClientName.Text.Length < 4)
            {
                MessageBox.Show("You need enter minimum 4 characters!", "Warning!", MessageBoxButtons.OK);
                return;
            }

            var key = _generator.GenerateKey(txtClientName.Text, DateTime.Now);
            if (!string.IsNullOrEmpty(key))
                txtUniqueClientKeyField.Text = key;
            else txtUniqueClientKeyField.Text = "Something went wrong!";
        }

        /// <summary>
        /// Action of button Clear Key Field click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearKeyField_Click(object sender, EventArgs e)
        {
            txtUniqueClientKeyField.Clear();
        }

        #endregion
    }
}