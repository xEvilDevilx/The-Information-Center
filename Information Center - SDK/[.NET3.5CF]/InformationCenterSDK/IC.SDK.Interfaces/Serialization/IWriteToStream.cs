using System;
using System.IO;

namespace IC.SDK.Interfaces.Serialization
{
    /// <summary>
    /// Presents Write to Stream methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface IWriteToStream
    {
        /// <summary>
        /// Use for define type of object and write to stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="obj">Object for write to client stream</param>
        void Write(Stream stream, object obj);

        /// <summary>
        /// Use for Write Byte to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="b">Byte</param>
        void Write(Stream stream, byte b);

        /// <summary>
        /// Use for Write Bytes Array to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="bytesArray">Bytes Array</param>
        void Write(Stream stream, byte[] bytesArray);

        /// <summary>
        /// Use for Write Int32 to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="i">Int32</param>
        void Write(Stream stream, Int32 i);

        /// <summary>
        /// Use for Write Int64 to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="i">Int64</param>
        void Write(Stream stream, Int64 i);

        /// <summary>
        /// Use for Write Boolean to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="b">Boolean</param>
        void Write(Stream stream, Boolean b);

        /// <summary>
        /// Use for Write Double to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="d">Double</param>
        void Write(Stream stream, Double d);

        /// <summary>
        /// Use for Write Decimal to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="d">Decimal</param>
        void Write(Stream stream, Decimal d);

        /// <summary>
        /// Use for Write String to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="s">String</param>
        void Write(Stream stream, string s);

        /// <summary>
        /// Use for Write DateTime to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="dateTime">DateTime</param>
        void Write(Stream stream, DateTime dateTime);
        
        /// <summary>
        /// Use for Write Guid to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="guid">Guid</param>
        void Write(Stream stream, Guid guid);

        /// <summary>
        /// Use for Write Version to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="version">Version</param>
        void Write(Stream stream, Version version);
    }
}