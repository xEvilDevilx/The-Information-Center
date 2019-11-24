using System;
using System.Security.Cryptography;

namespace IC.LicenseManager.BusinessObjects
{
    /// <summary>
    /// Presents Client License Data functionality
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    [Serializable]
    public class ClientLicenseData
    {
        #region Properties

        /// <summary>Client Hardware MAC Address</summary>
        public string MACAddress { get; set; }
        /// <summary>Client Software Version</summary>
        public Version Version { get; set; }
        /// <summary>Client Software Unique Identificator</summary>
        public string UID { get; set; }
        /// <summary>Client License Key Hash</summary>
        public byte[] LicenseKeyHash { get; set; }
        /// <summary>Client Software Password</summary>
        public string Password { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ClientLicenseData() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="macAddress">Hardware MAC Address</param>
        /// <param name="version">Software Version</param>
        /// <param name="uid">Software Unique Identificator</param>
        /// <param name="password">Software Password</param>
        public ClientLicenseData(string macAddress, Version version, string uid, string password)
        {
            if (string.IsNullOrEmpty(macAddress))
                throw new ArgumentNullException(string.Format("ClientLicenseData. Parameter {0} is empty", 
                    macAddress), "ClientLicenseData");

            if (version == null)
                throw new ArgumentNullException(string.Format("ClientLicenseData. Parameter {0} is empty", 
                    version), "ClientLicenseData");

            if (string.IsNullOrEmpty(uid))
                throw new ArgumentNullException(string.Format("ClientLicenseData. Parameter {0} is empty", 
                    uid), "ClientLicenseData");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(string.Format("ClientLicenseData. Parameter {0} is empty", 
                    password), "ClientLicenseData");

            MACAddress = macAddress;
            Version = version;
            UID = uid;
            Password = password;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for Generate Client License Data
        /// </summary>
        /// <returns></returns>
        public ClientLicenseData Generate()
        {
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                var data = System.Text.Encoding.UTF8.GetBytes(MACAddress + Version.ToString() + UID + Password);
                LicenseKeyHash = md5.ComputeHash(data);
                return this;
            }
            catch(Exception ex)
            {
                // TODO: Log ex!
                throw;
            }
        }

        #endregion
    }
}