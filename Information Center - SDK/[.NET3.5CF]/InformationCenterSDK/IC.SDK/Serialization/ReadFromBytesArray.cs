using System;
using System.Reflection;
using System.Text;

using IC.SDK.Base;
using IC.SDK.Base.Enums;
using IC.SDK.Helpers;
using IC.SDK.Interfaces.Helpers;
using IC.SDK.Interfaces.Serialization;

namespace IC.SDK.Serialization
{
    /// <summary>
    /// Implements Read from Bytes Array methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public class ReadFromBytesArray : IReadFromBytesArray
    {
        #region Variables

        /// <summary>Object for work with Properties</summary>
        private IObjectProperties _objectProperties;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ReadFromBytesArray()
        {
            Logger.Log.Debug("ReadFromBytesArray. Ctr. Enter");

            _objectProperties = new ObjectProperties();

            Logger.Log.Debug("ReadFromBytesArray. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for define object's type and set up bytes array parameter values to returning object
        /// </summary>
        /// <param name="bytesArray">Client bytes array</param>
        /// <param name="type">Deserializable type</param>
        /// <returns></returns>
        public object ReadObjectFromBytesArray(byte[] bytesArray, UdpSerializeTypes type)
        {
            Logger.Log.Debug("ReadObjectFromBytesArray. Enter");

            try
            {
                var typeName =
                    string.Format("{0}.{1}", BaseConstants.ManagerLibNamespaceName,
                    type.ToString());
                var objType = Type.GetType(typeName, false, false);
                var obj = Activator.CreateInstance(objType);
                var orderedTypeProperties = _objectProperties.GetOrderedProperties(obj);
                var pos = 1;

                foreach (PropertyInfo property in orderedTypeProperties)
                {
                    var propertyType = property.PropertyType;
                    var propertyValue = Read(bytesArray, ref pos, propertyType);
                    var objProperty = obj.GetType().GetProperty(property.Name);
                    objProperty.SetValue(obj, propertyValue, null);
                }

                Logger.Log.Debug("ReadObjectFromBytesArray. Exit");
                return obj;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadObjectFromBytesArray.", ex);
                return null;
            }
        }

        /// <summary>
        /// Use for read value of deserializable type from bytes array
        /// </summary>
        /// <param name="bytesArray">Client bytes array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <param name="type">Deserializable type</param>
        /// <returns></returns>
        public object Read(byte[] bytesArray, ref int pos, Type type)
        {
            Logger.Log.Debug("Read. Enter/Exit");

            if (type == typeof(Guid))
                return ReadGuidFromBytesArray(bytesArray, ref pos);
            if (type == typeof(byte[]))
                return ReadBytesArrayFromBytesArray(bytesArray, ref pos);
            if (type == typeof(Int32))
                return ReadInt32FromBytesArray(bytesArray, ref pos);
            if (type == typeof(Boolean))
                return ReadBooleanFromBytesArray(bytesArray, ref pos);
            if (type == typeof(Double))
                return ReadDoubleFromBytesArray(bytesArray, ref pos);
            if (type == typeof(Decimal))
                return ReadDecimalFromBytesArray(bytesArray, ref pos);
            if (type == typeof(string))
                return ReadStringFromBytesArray(bytesArray, ref pos);
            if (type == typeof(DateTime))
                return ReadDateTimeFromBytesArray(bytesArray, ref pos);
            if (type == typeof(Version))
                return ReadVersionFromBytesArray(bytesArray, ref pos);

            return null;
        }

        /// <summary>
        /// Use for Read Guid From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public Guid ReadGuidFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadGuidFromBytesArray. Enter");

            var bytes = new byte[16];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = bytesArray[pos + i];
            pos += bytes.Length;

            Logger.Log.Debug("ReadGuidFromBytesArray. Exit");
            return new Guid(bytes);
        }

        /// <summary>
        /// Use for Read Bytes Array From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public byte[] ReadBytesArrayFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadBytesArrayFromBytesArray. Enter");

            int length = ReadInt32FromBytesArray(bytesArray, ref pos);
            var bytes = new byte[length];
            for (int i = 0; i < length; i++)
                bytes[i] = bytesArray[pos + i];
            pos += length;

            Logger.Log.Debug("ReadBytesArrayFromBytesArray. Exit");
            return bytes;
        }

        /// <summary>
        /// Use for Read Int32 From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public Int32 ReadInt32FromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadInt32FromBytesArray. Enter");

            var i = BitConverter.ToInt32(bytesArray, pos);
            pos += sizeof(Int32);

            Logger.Log.Debug("ReadInt32FromBytesArray. Exit");
            return i;
        }

        /// <summary>
        /// Use for Read Boolean From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public Boolean ReadBooleanFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadBooleanFromBytesArray. Enter");

            var b = BitConverter.ToBoolean(bytesArray, pos);
            pos += sizeof(Boolean);

            Logger.Log.Debug("ReadBooleanFromBytesArray. Exit");
            return b;
        }

        /// <summary>
        /// Use for Read Double From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public Double ReadDoubleFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadDoubleFromBytesArray. Enter");

            var d = BitConverter.ToDouble(bytesArray, pos);
            pos += sizeof(Double);

            Logger.Log.Debug("ReadDoubleFromBytesArray. Exit");
            return d;
        }

        /// <summary>
        /// Use for Read Decimal From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public Decimal ReadDecimalFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadDecimalFromBytesArray. Enter");

            int length = ReadInt32FromBytesArray(bytesArray, ref pos);
            int[] bits = new int[length];
            for (int i = 0; i < length; i++)
            {
                bits[i] = ReadInt32FromBytesArray(bytesArray, ref pos);
            }

            Logger.Log.Debug("ReadDecimalFromBytesArray. Exit");
            return new decimal(bits);
        }

        /// <summary>
        /// Use for Read String From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public string ReadStringFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadStringFromBytesArray. Enter");

            int length = ReadInt32FromBytesArray(bytesArray, ref pos);
            if (length == -1)
                return null;
            var str = Encoding.Default.GetString(bytesArray, pos, length);
            pos += length;

            Logger.Log.Debug("ReadStringFromBytesArray. Exit");
            return str;
        }

        /// <summary>
        /// Use for Read DateTime From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public DateTime ReadDateTimeFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadDateTimeFromBytesArray. Enter");

            int length = ReadInt32FromBytesArray(bytesArray, ref pos);
            var bytes = new byte[length];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = bytesArray[pos + i];
            var dateTime = new DateTime(BitConverter.ToInt64(bytesArray, 0));
            pos += length;

            Logger.Log.Debug("ReadDateTimeFromBytesArray. Exit");
            return dateTime;
        }

        /// <summary>
        /// Use for Read Version From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        public Version ReadVersionFromBytesArray(byte[] bytesArray, ref int pos)
        {
            Logger.Log.Debug("ReadVersionFromBytesArray. Enter");

            var str = ReadStringFromBytesArray(bytesArray, ref pos);

            Logger.Log.Debug("ReadVersionFromBytesArray. Exit");
            return new Version(str);
        }

        #endregion
    }
}