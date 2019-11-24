using System;
using System.Text;

using IC.SDK.Interfaces.Helpers;

namespace IC.Tools.UniqueKeyGenerator
{
    /// <summary>
    /// Presents Key Generator interface
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public class KeyGenerator : IKeyGenerator
    {
        #region Methods

        /// <summary>
        /// Use for Generate Key
        /// </summary>
        /// <param name="clientName">Client name</param>
        /// <param name="date">Deal date</param>
        /// <returns></returns>
        public string GenerateKey(string clientName, DateTime date)
        {
            string key = "";
            try
            {
                var dateBin = date.ToBinary();
                if (dateBin < 0)
                    dateBin = Math.Abs(dateBin);
                var dateBinBytes = BitConverter.GetBytes(dateBin);
                var dateKey = GetHexString(dateBinBytes);
                key += dateKey;

                var dateKeyHash = dateKey.GetHashCode();
                var dateKeyHashBytes = BitConverter.GetBytes(dateKeyHash);
                var dateKeyHashString = GetHexString(dateKeyHashBytes);
                key += dateKeyHashString;

                var devidedDateKey = dateBin << 666;
                if (devidedDateKey < 0)
                    devidedDateKey = Math.Abs(devidedDateKey);
                var devidedDateKeyBytes = BitConverter.GetBytes(devidedDateKey);
                var devidedDateKeyString = GetHexString(devidedDateKeyBytes);
                key += devidedDateKeyString;

                var guidKey = Guid.NewGuid();
                var guidKeyBytes = guidKey.ToByteArray();
                var guidKeyString = GetHexString(guidKeyBytes);
                key += guidKeyString;

                var clientNameBytes = Encoding.Unicode.GetBytes(clientName);
                var clientNameString = GetHexString(clientNameBytes);
                key += clientNameString;

                var clientNameKeyHash = clientNameString.GetHashCode();
                var clientNameKeyHashBytes = BitConverter.GetBytes(clientNameKeyHash);
                var clientNameKeyHashString = GetHexString(clientNameKeyHashBytes);
                key += clientNameKeyHashString;

                var clientNameBin = BitConverter.ToInt64(clientNameBytes, 0);
                var devidedClientNameKey = clientNameBin << 666;
                if (devidedClientNameKey < 0)
                    devidedClientNameKey = Math.Abs(devidedClientNameKey);
                var devidedClientNameKeyBytes = BitConverter.GetBytes(devidedClientNameKey);
                var devidedClientNameKeyString = GetHexString(devidedClientNameKeyBytes);
                key += devidedClientNameKeyString;

                var keyBytes = Encoding.Unicode.GetBytes(key);
                var keyBytesBin = BitConverter.ToInt64(keyBytes, 0);
                var keyHash = keyBytesBin << 666;
                if (keyHash < 0)
                    keyHash = Math.Abs(keyHash);
                var keyHashKeyBytes = BitConverter.GetBytes(keyHash);
                var keyHashKeyString = GetHexString(keyHashKeyBytes);
                key += keyHashKeyString;

                keyHash = keyBytesBin << 545;
                if (keyHash < 0)
                    keyHash = Math.Abs(keyHash);
                keyHashKeyBytes = BitConverter.GetBytes(keyHash);
                keyHashKeyString = GetHexString(keyHashKeyBytes);
                key += keyHashKeyString;

                keyHash = keyBytesBin << 454;
                if (keyHash < 0)
                    keyHash = Math.Abs(keyHash);
                keyHashKeyBytes = BitConverter.GetBytes(keyHash);
                keyHashKeyString = GetHexString(keyHashKeyBytes);
                key += keyHashKeyString;

                return key;
            }
            catch(Exception ex)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Use for Get Hex String
        /// </summary>
        /// <param name="hexBytes">Hex Bytes Array</param>
        /// <returns></returns>
        private string GetHexString(byte[] hexBytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in hexBytes)
                sb.Append(b.ToString("X2"));

            var key = sb.ToString();
            return key;
        }

        #endregion
    }
}