using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IC.LicenseManager.CryptoService;
using IC.LicenseManager.Interfaces;
using IC.LicenseManager.BusinessObjects;

namespace IC.LicenseManager.Tests
{
    [TestClass]
    public class CryptoServiceTests
    {
        private string _macAddress = "FF00AA66";
        private Version _version = Version.Parse("1.0.0.0");
        private string _uid = "0a1s2d3f2g1h0";
        private string _password = "Test666Password";

        private ILicenseCreator _licenseCreator = new LicenseCreator();
        private ILicenseVerifier _licenseVerifier = new LicenseVerifier();

        [TestMethod]
        public void TestLecinseVerifier()
        {
            var clientLicenseData = new ClientLicenseData(_macAddress, _version, _uid, _password);
            var licenseKeySignature = _licenseCreator.CreateLicenseKeySignature(_macAddress, _version, _uid, _password);            
            var isLicenseKeyValid = _licenseVerifier.LicenseKeyVerify(clientLicenseData, licenseKeySignature);

            Assert.IsTrue(isLicenseKeyValid);
        }

        [TestMethod]
        public void TestGetClientLicenseDataFromKey()
        {
            var clientLicenseData = new ClientLicenseData(_macAddress, _version, _uid, _password);
            clientLicenseData.Generate();
            var licenseKeySignature = _licenseCreator.CreateLicenseKeySignature(_macAddress, _version, _uid, _password);
            var newClientLicenseData = _licenseVerifier.GetClientLicenseDataFromKey(licenseKeySignature);

            Assert.AreEqual(clientLicenseData.LicenseKeyHash.Length, newClientLicenseData.LicenseKeyHash.Length);
            for (int i = 0; i < clientLicenseData.LicenseKeyHash.Length; i++)
            {
                Assert.AreEqual(clientLicenseData.LicenseKeyHash[i], newClientLicenseData.LicenseKeyHash[i]);
            }

            Assert.AreEqual(clientLicenseData.MACAddress, newClientLicenseData.MACAddress);
            Assert.AreEqual(clientLicenseData.Password, newClientLicenseData.Password);
            Assert.AreEqual(clientLicenseData.UID, newClientLicenseData.UID);
            Assert.AreEqual(clientLicenseData.Version, newClientLicenseData.Version);
        }
    }
}