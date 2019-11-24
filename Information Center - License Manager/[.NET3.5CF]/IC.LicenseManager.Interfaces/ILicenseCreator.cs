using System;

namespace IC.LicenseManager.Interfaces
{
    /// <summary>
    /// Presents License Creator interface
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public interface ILicenseCreator
    {
        /// <summary>
        /// Use for Create License Key Signature
        /// </summary>
        /// <param name="macAddress">Hardware MAC Address</param>
        /// <param name="version">Software Version</param>
        /// <param name="uid">Software unique identificator</param>
        /// <param name="password">Software license password</param>
        /// <returns></returns>
        byte[] CreateLicenseKeySignature(string macAddress, Version version, string uid, string password);
    }
}