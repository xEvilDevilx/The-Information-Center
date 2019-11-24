using System;
using System.IO;
using System.Reflection;

using IC.SDK.Base.Enums;
using IC.SDK.Helpers;
using IC.SDK.Interfaces.Helpers;
using IC.SDK.Interfaces.Serialization;

namespace IC.SDK.Serialization
{
    /// <summary>
    /// Implement Serialize/Deserialize
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public class Serializer : IStreamSerializer, IBytesArraySerializer
    {
        #region Variables

        /// <summary>Use for Write To Stream</summary>
        private IWriteToStream _writeToStream;
        /// <summary>Use for Write To Bytes Array</summary>
        private IWriteToBytesArray _writeToBytesArray;
        /// <summary>Use for Read From Stream</summary>
        private IReadFromStream _readFromStream;
        /// <summary>Use for Read From Bytes Array</summary>
        private IReadFromBytesArray _readFromBytesArray;
        /// <summary>Object for work with Properties</summary>
        private IObjectProperties _objectProperties;
        /// <summary>Type Codes</summary>
        private ITypeCodes _typeCodes;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public Serializer()
        {
            Logger.Log.Debug("Serializer. Ctr. Enter");

            _writeToStream = new WriteToStream();
            _writeToBytesArray = new WriteToBytesArray();
            _readFromStream = new ReadFromStream();
            _readFromBytesArray = new ReadFromBytesArray();
            _objectProperties = new ObjectProperties();
            _typeCodes = new TypeCodes();

            Logger.Log.Debug("Serializer. Ctr. Enter");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for serialize object to client stream
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="obj">Serializable object</param>
        /// <param name="serializeType">Serializable object's type</param>
        public void Serialize(Stream stream, object obj, TcpSerializeTypes serializeType)
        {
            try
            {
                Logger.Log.Debug("Serialize. Enter");

                if ((stream == null) || (obj == null))
                {
                    Logger.Log.Warn("Serialize. Empty parameters");
                    return;
                }

                var orderedTypeProperties = _objectProperties.GetOrderedProperties(obj);
                _writeToStream.Write(stream, (byte)serializeType);

                foreach (PropertyInfo property in orderedTypeProperties)
                {
                    var propertyValue = _objectProperties.GetPropertyValue(obj, 
                        property.Name);
                    _writeToStream.Write(stream, propertyValue);
                }

                Logger.Log.Debug("Serialize. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Serialize.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for serialize object to bytes array
        /// </summary>
        /// <param name="obj">Serializable object</param>
        /// <param name="serializeType">Serializable object's type</param>
        /// <returns></returns>
        public byte[] SerializeToBytesArray(object obj, UdpSerializeTypes serializeType)
        {
            Logger.Log.Debug("SerializeToBytesArray. Enter");

            if (obj == null)
            {
                Logger.Log.Warn("SerializeToBytesArray. Empty parameters");
                return null;
            }

            try
            {
                var bytesArray = new byte[1];
                bytesArray[0] = (byte)serializeType;

                if (serializeType == UdpSerializeTypes.SimpleTypes)
                {
                    var tempBuffer = bytesArray;
                    var typeCodeByte = _typeCodes.GetCodeFromType(obj);
                    var objBytes = _writeToBytesArray.Write(obj);
                    bytesArray = new byte[tempBuffer.Length + 1 + objBytes.Length];
                    bytesArray[0] = tempBuffer[0];
                    bytesArray[1] = typeCodeByte;
                    objBytes.CopyTo(bytesArray, 2);
                    return bytesArray;
                }

                var orderedTypeProperties = _objectProperties.GetOrderedProperties(obj);

                foreach (PropertyInfo property in orderedTypeProperties)
                {
                    var propertyValue = _objectProperties.GetPropertyValue(obj, 
                        property.Name);
                    var tempBuffer = bytesArray;
                    var newTempBuffer = _writeToBytesArray.Write(propertyValue);
                    bytesArray = new byte[tempBuffer.Length + newTempBuffer.Length];
                    tempBuffer.CopyTo(bytesArray, 0);
                    newTempBuffer.CopyTo(bytesArray, tempBuffer.Length);
                }

                Logger.Log.Debug("SerializeToBytesArray. Exit");
                return bytesArray;
            }
            catch(Exception ex)
            {
                Logger.Log.Error("SerializeToBytesArray.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for deserialize object from stream
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="dataLayerNamespaceName">DataLayer Namespace Name</param>
        /// <param name="dataLayerLibName">DataLayer Library Name</param>
        /// <returns></returns>
        public object Deserialize(Stream stream, string dataLayerNamespaceName, 
            string dataLayerLibName)
        {
            Logger.Log.Debug("Deserialize. Enter");

            try
            {
                if (stream == null)
                {
                    Logger.Log.Warn("Deserialize. Empty parameters");
                    return null;
                }

                var byteType = _readFromStream.ReadByte(stream);

                foreach (TcpSerializeTypes type in Helpers.Utils.GetValues(
                    new TcpSerializeTypes()))
                {
                    if (byteType == (byte)type)
                    {
                        Logger.Log.Debug("Deserialize. Exit");
                        return _readFromStream.ReadObject(stream, type, 
                            dataLayerNamespaceName, dataLayerLibName);
                    }
                }

                throw new ArgumentException(
                    string.Format("Deserialize. Unknown id of enum type: {0}", byteType));
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Deserialize.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for deserialize object from bytes array
        /// </summary>
        /// <param name="bytesArray">Client bytes array</param>
        /// <returns></returns>
        public object DeserializeFromBytesArray(byte[] bytesArray)
        {
            Logger.Log.Debug("DeserializeFromBytesArray. Enter");

            if (bytesArray == null)
            {
                Logger.Log.Warn("DeserializeFromBytesArray. Empty parameters");
                return null;
            }

            try
            {
                var byteType = bytesArray[0];
                if (byteType == (byte)UdpSerializeTypes.None)
                    return null;

                if (byteType == (byte)UdpSerializeTypes.SimpleTypes)
                {
                    var type = _typeCodes.GetTypeFromCode(bytesArray[1]);
                    int pos = 2;
                    return _readFromBytesArray.Read(bytesArray, ref pos, type);
                }

                foreach (UdpSerializeTypes type in Helpers.Utils.GetValues(
                    new UdpSerializeTypes()))
                {
                    if (byteType == (byte)type)
                    {
                        Logger.Log.Debug("DeserializeFromBytesArray. Exit");
                        return _readFromBytesArray.ReadObjectFromBytesArray(bytesArray, 
                            type);
                    }
                }

                throw new ArgumentException(
                    string.Format("DeserializeFromBytesArray. Unknown id of enum type: {0}", 
                    byteType));
            }
            catch(Exception ex)
            {
                Logger.Log.Error("DeserializeFromBytesArray.", ex);
                throw;
            }
        }

        #endregion
    }
}