using System;
using System.IO;
using System.Text;

using IC.SDK.Interfaces.Serialization;

namespace IC.SDK.Serialization
{
    /// <summary>
    /// Implements Write to Stream methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public class WriteToStream : IWriteToStream
    {
        #region Methods

        /// <summary>
        /// Use for define type of object and write to stream
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="obj">Object for write to client stream</param>
        public void Write(Stream stream, object obj)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                if (obj == null)
                    stream.Write(BitConverter.GetBytes(-1), 0, sizeof(Int32));
                
                if (obj is byte)
                    Write(stream, (byte)obj);
                if (obj is byte[])
                    Write(stream, (byte[])obj);
                if (obj is Int32)
                    Write(stream, (Int32)obj);
                if (obj is Int64)
                    Write(stream, (Int64)obj);
                if (obj is Boolean)
                    Write(stream, (Boolean)obj);
                if (obj is Double)
                    Write(stream, (Double)obj);
                if (obj is Decimal)
                    Write(stream, (Decimal)obj);
                if (obj is string)
                    Write(stream, (string)obj);
                if (obj is DateTime)
                    Write(stream, (DateTime)obj);
                if (obj is Guid)
                    Write(stream, (Guid)obj);
                if (obj is Version)
                    Write(stream, (Version)obj);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Byte to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="b">Byte</param>
        public void Write(Stream stream, byte b)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                stream.WriteByte(b);
                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Bytes Array to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="bytesArray">Bytes Array</param>
        public void Write(Stream stream, byte[] bytesArray)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                stream.Write(BitConverter.GetBytes(bytesArray.Length), 0, sizeof(Int32));
                stream.Write(bytesArray, 0, bytesArray.Length);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Int32 to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="i">Int32</param>
        public void Write(Stream stream, Int32 i)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                stream.Write(BitConverter.GetBytes(i), 0, sizeof(Int32));
                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Int64 to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="i">Int64</param>
        public void Write(Stream stream, Int64 i)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                var bytesArray = BitConverter.GetBytes(i);
                stream.Write(BitConverter.GetBytes(bytesArray.Length), 0, sizeof(Int32));
                stream.Write(bytesArray, 0, bytesArray.Length);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Boolean to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="b">Boolean</param>
        public void Write(Stream stream, Boolean b)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                stream.Write(BitConverter.GetBytes(b), 0, sizeof(Boolean));
                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Double to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="d">Double</param>
        public void Write(Stream stream, Double d)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                stream.Write(BitConverter.GetBytes(d), 0, sizeof(Double));
                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Decimal to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="d">Decimal</param>
        public void Write(Stream stream, Decimal d)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                int[] bits = Decimal.GetBits(d);
                Write(stream, bits.Length);
                for (int i = 0; i < bits.Length; i++)
                    Write(stream, bits[i]);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write String to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="s">String</param>
        public void Write(Stream stream, string s)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                if (s == null)
                {
                    stream.Write(BitConverter.GetBytes(-1), 0, sizeof(Int32));
                    return;
                }
                var bytesArray = Encoding.BigEndianUnicode.GetBytes(s);
                stream.Write(BitConverter.GetBytes(bytesArray.Length), 0, sizeof(Int32));
                stream.Write(bytesArray, 0, bytesArray.Length);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write DateTime to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="dateTime">DateTime</param>
        public void Write(Stream stream, DateTime dateTime)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                var bytesArray = BitConverter.GetBytes(dateTime.Ticks);
                stream.Write(BitConverter.GetBytes(bytesArray.Length), 0, sizeof(Int32));
                stream.Write(bytesArray, 0, bytesArray.Length);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Guid to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="guid">Guid</param>
        public void Write(Stream stream, Guid guid)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                var bytesArray = guid.ToByteArray();
                stream.Write(BitConverter.GetBytes(bytesArray.Length), 0, sizeof(Int32));
                stream.Write(bytesArray, 0, bytesArray.Length);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Write Version to Stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="version">Version</param>
        public void Write(Stream stream, Version version)
        {
            Logger.Log.Debug("Write. Enter");

            try
            {
                var versionString = version.ToString();
                Write(stream, versionString);

                Logger.Log.Debug("Write. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Write.", ex);
                throw;
            }
        }

        #endregion
    }
}