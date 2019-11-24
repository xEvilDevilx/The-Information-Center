using System;
using System.IO;

using IC.SDK.Base.Enums;

namespace IC.SDK.Interfaces.Serialization
{
    /// <summary>
    /// Presents Read from Stream methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface IReadFromStream
    {
        /// <summary>
        /// Use for define object's type and for set up stream parameter values to returning object
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="type">Deserializable type</param>
        /// <param name="dataLayerNamespaceName">Data Layer namespace name</param>
        /// <param name="dataLayerLibName">Data Layer library name</param>
        /// <returns></returns>
        object ReadObject(Stream stream, TcpSerializeTypes type,
            string dataLayerNamespaceName, string dataLayerLibName);

        /// <summary>
        /// Use for read value from stream
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="type">Deserializable type</param>
        /// <returns></returns>
        object Read(Stream stream, Type type);

        /// <summary>
        /// Use for Read Byte
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        byte ReadByte(Stream stream);

        /// <summary>
        /// Use for Read Bytes Array
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        byte[] ReadBytesArray(Stream stream);

        /// <summary>
        /// Use for Read Int32
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        Int32 ReadInt32(Stream stream);

        /// <summary>
        /// Use for Read Int64
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        Int64 ReadInt64(Stream stream);

        /// <summary>
        /// Use for Read Boolean
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        Boolean ReadBoolean(Stream stream);

        /// <summary>
        /// Use for Read Double
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        Double ReadDouble(Stream stream);

        /// <summary>
        /// Use for Read Decimal
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        Decimal ReadDecimal(Stream stream);

        /// <summary>
        /// Use for Read String
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        string ReadString(Stream stream);

        /// <summary>
        /// Use for Read DateTime
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        DateTime ReadDateTime(Stream stream);

        /// <summary>
        /// Use for Read Guid
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        Guid ReadGuid(Stream stream);

        /// <summary>
        /// Use for Read Version
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        Version ReadVersion(Stream stream);
    }
}