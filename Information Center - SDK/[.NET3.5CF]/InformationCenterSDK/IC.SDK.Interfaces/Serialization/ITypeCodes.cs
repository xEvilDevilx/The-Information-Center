using System;

namespace IC.SDK.Interfaces.Serialization
{
    /// <summary>
    /// Presents Codes of Type
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface ITypeCodes
    {
        /// <summary>
        /// Use for return type's code
        /// </summary>
        /// <param name="obj">object for define type</param>
        /// <returns></returns>
        byte GetCodeFromType(object obj);

        /// <summary>
        /// Use for return type by code
        /// </summary>
        /// <param name="code">Code of type</param>
        /// <returns></returns>
        Type GetTypeFromCode(int code);
    }
}