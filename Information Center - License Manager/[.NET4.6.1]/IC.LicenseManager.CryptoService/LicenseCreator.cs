using System;
using System.IO;

using IC.SDK.Base.Enums;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;
using IC.LicenseManager.BusinessObjects;
using IC.LicenseManager.Interfaces;

namespace IC.LicenseManager.CryptoService
{
    /// <summary>
    /// Implements License Creator functionality
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public class LicenseCreator : ILicenseCreator
    {
        #region Variables

        /// <summary>Stream Serializer</summary>
        private IStreamSerializer _streamSerializer;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public LicenseCreator()
        {
            _streamSerializer = new Serializer();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for Create License Key Signature
        /// </summary>
        /// <param name="macAddress">Hardware MAC Address</param>
        /// <param name="version">Software Version</param>
        /// <param name="uid">Software Unique Identificator</param>
        /// <param name="password">Software Password</param>
        /// <returns></returns>
        public byte[] CreateLicenseKeySignature(string macAddress, Version version, string uid, string password)
        {
            try
            {
                byte[] data;
                using (var stream = new MemoryStream())
                {
                    var clientLicenseData = new ClientLicenseData(macAddress, version, uid, password);
                    clientLicenseData.Generate();

                    _streamSerializer.Serialize(stream, clientLicenseData, TcpSerializeTypes.ClientLicenseData);
                    data = stream.ToArray();
                }

                return data;         
            }
            catch(Exception ex)
            {
                // Log ex!
                throw;
            }
        }

        #endregion
    }
}