using System;
using System.IO;

using IC.LicenseManager.BusinessObjects;
using IC.LicenseManager.Interfaces;
using IC.SDK.Base.Enums;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;

namespace IC.LicenseManager.CryptoService
{
    /// <summary>
    /// Implements License Verifier interface
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public class LicenseVerifier : ILicenseVerifier
    {
        #region Variables

        /// <summary>Stream Serializer</summary>
        private IStreamSerializer _streamSerializer;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public LicenseVerifier()
        {
            _streamSerializer = new Serializer();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for License Key Verify
        /// </summary>
        /// <param name="clientLicenseData">Client License Data</param>
        /// <param name="licenseKeyHash">License Key Hash</param>
        /// <returns></returns>
        public bool LicenseKeyVerify(ClientLicenseData clientLicenseData, byte[] licenseKeyHash)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    var licenseData = new ClientLicenseData(clientLicenseData.MACAddress, clientLicenseData.Version,
                        clientLicenseData.UID, clientLicenseData.Password);
                    licenseData.Generate();

                    _streamSerializer.Serialize(stream, licenseData, TcpSerializeTypes.ClientLicenseData);
                    var data = stream.ToArray();

                    if (!Extensions.ArraysEqual(data, licenseKeyHash))
                    {
                        throw new ApplicationException("License is not valid!");
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw new ApplicationException("License is not valid!");
            }
        }

        /// <summary>
        /// Use for Get Client License Data From Key
        /// </summary>
        /// <param name="licenseKeyHash">License Key Hash</param>
        /// <returns></returns>
        public ClientLicenseData GetClientLicenseDataFromKey(byte[] licenseKeyHash)
        {
            try
            {
                using (var stream = new MemoryStream(licenseKeyHash))
                {
                    var clientLicenseData = (ClientLicenseData)_streamSerializer.Deserialize(stream,
                        "IC.LicenseManager.BusinessObjects", "IC.LicenseManager.BusinessObjects");
                    return clientLicenseData;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("License is not valid! License key is wrong!");
            }
        }

        #endregion
    }
}