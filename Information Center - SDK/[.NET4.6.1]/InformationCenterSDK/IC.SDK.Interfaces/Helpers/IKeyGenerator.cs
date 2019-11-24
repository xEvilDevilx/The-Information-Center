using System;

namespace IC.SDK.Interfaces.Helpers
{
    /// <summary>
    /// Presents Key Generator interface
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public interface IKeyGenerator
    {
        /// <summary>
        /// Use for Generate Key
        /// </summary>
        /// <param name="clientName">Client name</param>
        /// <param name="date">Deal date</param>
        /// <returns></returns>
        string GenerateKey(string clientName, DateTime date);
    }
}