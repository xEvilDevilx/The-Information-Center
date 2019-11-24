using System;

namespace IC.SDK.Interfaces.Serialization
{
    /// <summary>
    /// Presents Write to Bytes Array methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface IWriteToBytesArray
    {
        /// <summary>
        /// Use for define type of object and return defined object's bytes array
        /// </summary>
        /// <param name="obj">Object for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(object obj);

        /// <summary>
        /// Use for Write Guid to Bytes Array
        /// </summary>
        /// <param name="guid">Guid for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(Guid guid);

        /// <summary>
        /// Use for Write Bytes Array to Bytes Array
        /// </summary>
        /// <param name="bytes">Bytes array for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(byte[] bytes);

        /// <summary>
        /// Use for Write Int32 to Bytes Array
        /// </summary>
        /// <param name="i">Int32 for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(Int32 i);

        /// <summary>
        /// Use for Write Boolean to Bytes Array
        /// </summary>
        /// <param name="b">Boolean for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(Boolean b);

        /// <summary>
        /// Use for Write Double to Bytes Array
        /// </summary>
        /// <param name="d">Double for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(Double d);

        /// <summary>
        /// Use for Write Decimal to Bytes Array
        /// </summary>
        /// <param name="d">Decimal for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(Decimal d);

        /// <summary>
        /// Use for Write String to Bytes Array
        /// </summary>
        /// <param name="str">String for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(string str);

        /// <summary>
        /// Use for Write DateTime to Bytes Array
        /// </summary>
        /// <param name="dateTime">DateTime for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(DateTime dateTime);

        /// <summary>
        /// Use for Write Version to Bytes Array
        /// </summary>
        /// <param name="version">Version for convert to bytes array</param>
        /// <returns></returns>
        byte[] Write(Version version);
    }
}