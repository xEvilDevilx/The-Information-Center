using System;
using System.Windows.Forms;

using IC.LicenseManager.BusinessObjects;
using IC.LicenseManager.CryptoService;
using IC.LicenseManager.Interfaces;

namespace IC.LicenseManager.View.Forms
{
    /// <summary>
    /// Presents License Manager Form
    /// 
    /// 2017/08/31 - Created, VTyagunov
    /// </summary>
    public partial class MainForm : Form
    {
        #region Variables

        /// <summary>MAC Address</summary>
        private string _macAddress;
        /// <summary>Version</summary>
        private Version _version;
        /// <summary>Unique identificator</summary>
        private string _uid;
        /// <summary>Password</summary>
        private string _password;
        /// <summary>License Creator</summary>
        private ILicenseCreator _licenseCreator;
        /// <summary>License Verifier</summary>
        private ILicenseVerifier _licenseVerifier;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _macAddress = "FF00AA66";
            _version = new Version("1.0.0.0");
            _uid = "0a1s2d3f2g1h0";
            _password = "Test666Password";
            _licenseCreator = new LicenseCreator();
            _licenseVerifier = new LicenseVerifier();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Action for License Verifier button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestLicenseVerifier_Click(object sender, EventArgs e)
        {
            var clientLicenseData = new ClientLicenseData(_macAddress, _version, _uid, _password);
            var licenseKeySignature = _licenseCreator.CreateLicenseKeySignature(_macAddress, _version, _uid, _password);
            var isLicenseKeyValid = _licenseVerifier.LicenseKeyVerify(clientLicenseData, licenseKeySignature);

            if (isLicenseKeyValid) lblStatus.Text = "TRUE";
            else lblStatus.Text = "FALSE";
        }

        /// <summary>
        /// Action for Get Client License Data From Key button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestGetClientLicenseDataFromKey_Click(object sender, EventArgs e)
        {
            var clientLicenseData = new ClientLicenseData(_macAddress, _version, _uid, _password);
            clientLicenseData.Generate();
            var licenseKeySignature = _licenseCreator.CreateLicenseKeySignature(_macAddress, _version, _uid, _password);
            var newClientLicenseData = _licenseVerifier.GetClientLicenseDataFromKey(licenseKeySignature);

            if (clientLicenseData.LicenseKeyHash.Length != newClientLicenseData.LicenseKeyHash.Length)
            {
                lblStatus.Text = "FALSE";
                return;
            }
            
            for (int i = 0; i < clientLicenseData.LicenseKeyHash.Length; i++)
            {
                if(clientLicenseData.LicenseKeyHash[i] != newClientLicenseData.LicenseKeyHash[i])
                {
                    lblStatus.Text = "FALSE";
                    return;
                }
            }

            if(clientLicenseData.MACAddress != newClientLicenseData.MACAddress)
            {
                lblStatus.Text = "FALSE";
                return;
            }

            if(clientLicenseData.Password != newClientLicenseData.Password)
            {
                lblStatus.Text = "FALSE";
                return;
            }

            if(clientLicenseData.UID != newClientLicenseData.UID)
            {
                lblStatus.Text = "FALSE";
                return;
            }

            if(clientLicenseData.Version != newClientLicenseData.Version)
            {
                lblStatus.Text = "FALSE";
                return;
            }

            lblStatus.Text = "TRUE";
        }

        /// <summary>
        /// Action for Clear Result button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearResult_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "---";
        }

        #endregion
    }
}