using System;

using IC.SDK.Base.Enums;

namespace IC.SDK.Interfaces.Serialization
{
    /// <summary>
    /// Presents Read from Bytes Array methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface IReadFromBytesArray
    {
        /// <summary>
        /// Use for define object's type and set up bytes array parameter values to returning object
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="type">Deserializable type</param>
        /// <returns></returns>
        object ReadObjectFromBytesArray(byte[] bytesArray, UdpSerializeTypes type);

        /// <summary>
        /// Use for read value of deserializable type from bytes array
        /// Считывает значение указанного типа данных из массива байт
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <param name="type">Deserializable type</param>
        /// <returns></returns>
        object Read(byte[] bytesArray, ref int pos, Type type);

        /// <summary>
        /// Use for Read Guid From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        Guid ReadGuidFromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read Bytes Array From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        byte[] ReadBytesArrayFromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read Int32 From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        Int32 ReadInt32FromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read Boolean From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        Boolean ReadBooleanFromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read Double From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        Double ReadDoubleFromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read Decimal From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        Decimal ReadDecimalFromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read String From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        string ReadStringFromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read DateTime From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        DateTime ReadDateTimeFromBytesArray(byte[] bytesArray, ref int pos);

        /// <summary>
        /// Use for Read Version From Bytes Array
        /// </summary>
        /// <param name="bytesArray">Bytes Array</param>
        /// <param name="pos">Current position in bytes array</param>
        /// <returns></returns>
        Version ReadVersionFromBytesArray(byte[] bytesArray, ref int pos);
    }
}