using System.IO;

using IC.SDK.Base.Enums;

namespace IC.SDK.Interfaces.Serialization
{
    /// <summary>
    /// Presents Stream Serializer
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface IStreamSerializer
    {
        /// <summary>
        /// Use for serialize object to client stream
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="obj">Serializable object</param>
        /// <param name="serializeType">Serializable object's type</param>
        void Serialize(Stream stream, object obj, TcpSerializeTypes serializeType);

        /// <summary>
        /// Use for deserialize object from stream
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="dataLayerNamespaceName">DataLayer Namespace Name</param>
        /// <param name="dataLayerLibName">DataLayer Library Name</param>
        /// <returns></returns>
        object Deserialize(Stream stream, string dataLayerNamespaceName, string dataLayerLibName);
    }
}