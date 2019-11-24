using System;
using System.Text;

using IC.SDK.Interfaces.Serialization;

namespace IC.SDK.Serialization
{
    /// <summary>
    /// Implements Write to Bytes Array methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    class WriteToBytesArray : IWriteToBytesArray
    {
        #region Methods

        /// <summary>
        /// Use for define type of object and return defined object's bytes array
        /// </summary>
        /// <param name="obj">Object for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(object obj)
        {
            Logger.Log.Debug("Write. Enter/Exit");

            if (obj is Guid)
                return Write((Guid)obj);
            if (obj is byte[])
                return Write((byte[])obj);
            if (obj is Int32)
                return Write((Int32)obj);
            if (obj is Boolean)
                return Write((Boolean)obj);
            if (obj is Double)
                return Write((Double)obj);
            if (obj is Decimal)
                return Write((Decimal)obj);
            if (obj is string)
                return Write((string)obj);
            if (obj is DateTime)
                return Write((DateTime)obj);
            if (obj is Version)
                return Write((Version)obj);

            return null;
        }

        /// <summary>
        /// Use for Write Guid to Bytes Array
        /// </summary>
        /// <param name="guid">Guid for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(Guid guid)
        {
            Logger.Log.Debug("Write. Enter/Exit");
            return guid.ToByteArray();
        }

        /// <summary>
        /// Use for Write Bytes Array to Bytes Array
        /// </summary>
        /// <param name="bytes">Bytes array for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(byte[] bytes)
        {
            Logger.Log.Debug("Write. Enter");

            var bytesArraySize = Write(bytes.Length);
            var bytesArray = new byte[bytes.Length + bytesArraySize.Length];
            bytesArraySize.CopyTo(bytesArray, 0);
            bytes.CopyTo(bytesArray, bytesArraySize.Length);

            Logger.Log.Debug("Write. Exit");
            return bytesArray;
        }

        /// <summary>
        /// Use for Write Int32 to Bytes Array
        /// </summary>
        /// <param name="i">Int32 for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(Int32 i)
        {
            Logger.Log.Debug("Write. Enter/Exit");
            return BitConverter.GetBytes(i);
        }

        /// <summary>
        /// Use for Write Boolean to Bytes Array
        /// </summary>
        /// <param name="b">Boolean for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(Boolean b)
        {
            Logger.Log.Debug("Write. Enter/Exit");
            return BitConverter.GetBytes(b);
        }

        /// <summary>
        /// Use for Write Double to Bytes Array
        /// </summary>
        /// <param name="d">Double for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(Double d)
        {
            Logger.Log.Debug("Write. Enter/Exit");
            return BitConverter.GetBytes(d);
        }

        /// <summary>
        /// Use for Write Decimal to Bytes Array
        /// </summary>
        /// <param name="d">Decimal for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(Decimal d)
        {
            Logger.Log.Debug("Write. Enter");

            var bits = Decimal.GetBits(d);
            var bytesArray = Write(bits.Length);

            for (int i = 0; i < bits.Length; i++)
            {
                var tempBytesArray = bytesArray;
                var bytes = Write(bits[i]);
                bytesArray = new byte[tempBytesArray.Length + bytes.Length];
                tempBytesArray.CopyTo(bytesArray, 0);
                bytes.CopyTo(bytesArray, tempBytesArray.Length);
            }

            Logger.Log.Debug("Write. Exit");
            return bytesArray;
        }

        /// <summary>
        /// Use for Write String to Bytes Array
        /// </summary>
        /// <param name="str">String for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(string str)
        {
            Logger.Log.Debug("Write. Enter");

            if (str == null)
                return Write(-1);

            var bytesArray = Encoding.Default.GetBytes(str);
            var bytesArraySize = Write(bytesArray.Length);
            var bytes = new byte[bytesArray.Length + bytesArraySize.Length];
            bytesArraySize.CopyTo(bytes, 0);
            bytesArray.CopyTo(bytes, bytesArraySize.Length);

            Logger.Log.Debug("Write. Exit");
            return bytes;
        }

        /// <summary>
        /// Use for Write DateTime to Bytes Array
        /// </summary>
        /// <param name="dateTime">DateTime for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(DateTime dateTime)
        {
            Logger.Log.Debug("Write. Enter");

            var bytesArray = BitConverter.GetBytes(dateTime.Ticks);
            var bytesArraySize = Write(bytesArray.Length);
            var bytes = new byte[bytesArray.Length + bytesArraySize.Length];
            bytesArraySize.CopyTo(bytes, 0);
            bytesArray.CopyTo(bytes, bytesArraySize.Length);

            Logger.Log.Debug("Write. Exit");
            return bytes;
        }

        /// <summary>
        /// Use for Write Version to Bytes Array
        /// </summary>
        /// <param name="version">Version for convert to bytes array</param>
        /// <returns></returns>
        public byte[] Write(Version version)
        {
            Logger.Log.Debug("Write. Enter/Exit");
            return Write(version.ToString());
        }

        #endregion
    }
}