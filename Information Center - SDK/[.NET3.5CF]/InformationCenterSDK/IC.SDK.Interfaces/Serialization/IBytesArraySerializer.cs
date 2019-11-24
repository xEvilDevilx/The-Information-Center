using IC.SDK.Base.Enums;

namespace IC.SDK.Interfaces.Serialization
{
    /// <summary>
    /// Presents Bytes Array Serializer
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface IBytesArraySerializer
    {
        /// <summary>
        /// Use for serialize object to bytes array
        /// </summary>
        /// <param name="obj">Serializable object</param>
        /// <param name="serializeType">Serializable object's type</param>
        /// /// <returns></returns>
        byte[] SerializeToBytesArray(object obj, UdpSerializeTypes serializeType);

        /// <summary>
        /// Use for deserialize object from bytes array
        /// </summary>
        /// <param name="bytesArray">Client bytes array</param>
        /// <returns></returns>
        object DeserializeFromBytesArray(byte[] bytesArray);
    }
}