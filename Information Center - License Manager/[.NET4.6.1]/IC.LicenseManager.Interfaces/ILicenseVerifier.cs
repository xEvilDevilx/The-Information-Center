using IC.LicenseManager.BusinessObjects;

namespace IC.LicenseManager.Interfaces
{
    /// <summary>
    /// Presents License Verifier interface
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public interface ILicenseVerifier
    {
        /// <summary>
        /// Use for License Key Verify
        /// </summary>
        /// <param name="clientLicenseData">Client License Data</param>
        /// <param name="licenseKeyHash">License Key Hash</param>
        /// <returns></returns>
        bool LicenseKeyVerify(ClientLicenseData clientLicenseData, byte[] licenseKeyHash);

        /// <summary>
        /// Use for Get Client License Data From Key
        /// </summary>
        /// <param name="licenseKeyHash">License Key Hash</param>
        /// <returns></returns>
        ClientLicenseData GetClientLicenseDataFromKey(byte[] licenseKeyHash);
    }
}