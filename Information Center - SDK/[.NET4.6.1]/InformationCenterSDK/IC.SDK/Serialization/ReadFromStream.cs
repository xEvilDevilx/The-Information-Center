using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using IC.SDK.Base.Enums;
using IC.SDK.Helpers;
using IC.SDK.Interfaces.Helpers;
using IC.SDK.Interfaces.Serialization;

namespace IC.SDK.Serialization
{
    /// <summary>
    /// Implements Read from Stream methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    class ReadFromStream : IReadFromStream
    {
        #region Variables

        /// <summary>Object for work with Properties</summary>
        private IObjectProperties _objectProperties;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ReadFromStream()
        {
            Logger.Log.Debug("ReadFromStream. Ctr. Enter");

            _objectProperties = new ObjectProperties();

            Logger.Log.Debug("ReadFromStream. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for define object's type and for set up stream parameter values to returning object
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="type">Deserializable type</param>
        /// <param name="dataLayerNamespaceName">Data Layer namespace name</param>
        /// <param name="dataLayerLibName">Data Layer library name</param>
        /// <returns></returns>
        public object ReadObject(Stream stream, TcpSerializeTypes type,
            string dataLayerNamespaceName, string dataLayerLibName)
        {
            Logger.Log.Debug("ReadObject. Enter");

            var typeName =
                string.Format("{0}.{1}, {2}", dataLayerNamespaceName,
                type.ToString(), dataLayerLibName);
            try
            {
                var objType = Type.GetType(typeName, false, false);
                var obj = Activator.CreateInstance(objType);
                var orderedTypeProperties = _objectProperties.GetOrderedProperties(obj);

                foreach (PropertyInfo property in orderedTypeProperties)
                {
                    var propertyType = property.PropertyType;
                    var streamValue = Read(stream, propertyType);
                    var objProperty = obj.GetType().GetProperty(property.Name);
                    objProperty.SetValue(obj, streamValue, null);
                }

                Logger.Log.Debug("ReadObject. Exit");
                return obj;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadObject.", ex);
                return null;
            }
        }

        /// <summary>
        /// Use for read value from stream
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="type">Deserializable type</param>
        /// <returns></returns>
        public object Read(Stream stream, Type type)
        {
            Logger.Log.Debug("Read. Enter/Exit");

            try
            {
                if (type == typeof(byte))
                    return ReadByte(stream);
                if (type == typeof(byte[]))
                    return ReadBytesArray(stream);
                if (type == typeof(Int32))
                    return ReadInt32(stream);
                if (type == typeof(Int64))
                    return ReadInt64(stream);
                if (type == typeof(Boolean))
                    return ReadBoolean(stream);
                if (type == typeof(Double))
                    return ReadDouble(stream);
                if (type == typeof(Decimal))
                    return ReadDecimal(stream);
                if (type == typeof(string))
                    return ReadString(stream);
                if (type == typeof(DateTime))
                    return ReadDateTime(stream);
                if (type == typeof(Guid))
                    return ReadGuid(stream);
                if (type == typeof(Version))
                    return ReadVersion(stream);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Read.", ex);
                throw;
            }
            return null;
        }

        /// <summary>
        /// Use for Read Byte
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public byte ReadByte(Stream stream)
        {
            Logger.Log.Debug("ReadByte. Enter");

            try
            {
                var bytesArray = new byte[sizeof(byte)];
                stream.Read(bytesArray, 0, sizeof(byte));

                Logger.Log.Debug("ReadByte. Exit");
                return bytesArray[0];
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadByte.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Bytes Array
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public byte[] ReadBytesArray(Stream stream)
        {
            Logger.Log.Debug("ReadBytesArray. Enter");

            try
            {
                int length = ReadInt32(stream);
                if (length == -1)
                    return null;

                var bytesArray = new byte[length];
                int bytesRead = 0;

                while (bytesRead < length)
                {
                    var count = stream.Read(bytesArray, bytesRead, bytesArray.Length - bytesRead);
                    if (count == 0)
                    {
                        throw new Exception("Unexpected disconnect");
                    }

                    bytesRead += count;
                }

                Logger.Log.Debug("ReadBytesArray. Exit");
                return bytesArray;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadBytesArray.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Int32
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public Int32 ReadInt32(Stream stream)
        {
            Logger.Log.Debug("ReadInt32. Enter");

            try
            {
                var bytesArray = new byte[sizeof(Int32)];
                stream.Read(bytesArray, 0, sizeof(Int32));

                Logger.Log.Debug("ReadInt32. Exit");
                return BitConverter.ToInt32(bytesArray, 0);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadInt32.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Int64
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public Int64 ReadInt64(Stream stream)
        {
            Logger.Log.Debug("ReadInt64. Enter");

            try
            {
                int length = ReadInt32(stream);
                var bytesArray = new byte[length];
                stream.Read(bytesArray, 0, bytesArray.Length);

                Logger.Log.Debug("ReadInt64. Exit");
                return BitConverter.ToInt64(bytesArray, 0);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadInt64.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Boolean
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public Boolean ReadBoolean(Stream stream)
        {
            Logger.Log.Debug("ReadBoolean. Enter");

            try
            {
                var bytesArray = new byte[sizeof(Boolean)];
                stream.Read(bytesArray, 0, sizeof(Boolean));

                Logger.Log.Debug("ReadBoolean. Exit");
                return BitConverter.ToBoolean(bytesArray, 0);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadBoolean.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Double
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public Double ReadDouble(Stream stream)
        {
            Logger.Log.Debug("ReadDouble. Enter");

            try
            {
                var bytesArray = new byte[sizeof(Double)];
                stream.Read(bytesArray, 0, sizeof(Double));

                Logger.Log.Debug("ReadDouble. Exit");
                return BitConverter.ToDouble(bytesArray, 0);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadDouble.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Decimal
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public Decimal ReadDecimal(Stream stream)
        {
            Logger.Log.Debug("ReadDecimal. Enter");

            try
            {
                int l = ReadInt32(stream);
                int[] bits = new int[l];
                for (int i = 0; i < l; i++)
                {
                    bits[i] = ReadInt32(stream);
                }

                Logger.Log.Debug("ReadDecimal. Exit");
                return new decimal(bits);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadDecimal.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read String
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public string ReadString(Stream stream)
        {
            Logger.Log.Debug("ReadString. Enter");

            try
            {
                int length = ReadInt32(stream);
                if (length == -1)
                    return null;

                var bytesArray = new byte[length];
                int bytesRead = 0;

                while (bytesRead < length)
                {
                    var count = stream.Read(bytesArray, bytesRead, bytesArray.Length - bytesRead);
                    if (count == 0)
                    {
                        throw new Exception("Unexpected disconnect");
                    }

                    bytesRead += count;
                }

                Logger.Log.Debug("ReadString. Exit");
                return Encoding.BigEndianUnicode.GetString(bytesArray, 0, bytesArray.Count());
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadString.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read DateTime
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public DateTime ReadDateTime(Stream stream)
        {
            Logger.Log.Debug("ReadDateTime. Enter");

            try
            {
                int length = ReadInt32(stream);
                var bytesArray = new byte[length];
                stream.Read(bytesArray, 0, bytesArray.Length);
                var dateTime = new DateTime(BitConverter.ToInt64(bytesArray, 0), DateTimeKind.Local); //DateTime.FromBinary(BitConverter.ToInt64(bytesArray, 0));
                string timeString = dateTime.ToString().Replace(" PM", "");
                dateTime = DateTime.Parse(timeString);

                Logger.Log.Debug("ReadDateTime. Exit");
                return dateTime;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadDateTime.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Guid
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public Guid ReadGuid(Stream stream)
        {
            Logger.Log.Debug("ReadGuid. Enter");

            try
            {
                int length = ReadInt32(stream);
                var bytesArray = new byte[length];
                stream.Read(bytesArray, 0, bytesArray.Length);                
                var guid = new Guid(bytesArray);

                Logger.Log.Debug("ReadGuid. Exit");
                return guid;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadGuid.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Read Version
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public Version ReadVersion(Stream stream)
        {
            Logger.Log.Debug("ReadVersion. Enter");

            try
            {
                var versionString = ReadString(stream);
                var version = new Version(versionString);

                Logger.Log.Debug("ReadVersion. Exit");
                return version;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ReadVersion.", ex);
                throw;
            }
        }

        #endregion
    }
}