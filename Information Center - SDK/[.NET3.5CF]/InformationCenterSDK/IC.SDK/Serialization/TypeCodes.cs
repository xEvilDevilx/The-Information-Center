using System;

using IC.SDK.Interfaces.Serialization;

namespace IC.SDK.Serialization
{
    /// <summary>
    /// Implements Codes of Type
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public class TypeCodes : ITypeCodes
    {
        /// <summary>
        /// Use for return type's code
        /// </summary>
        /// <param name="obj">object for define type</param>
        /// <returns></returns>
        public byte GetCodeFromType(object obj)
        {
            Logger.Log.Debug("GetCodeFromType. Enter/Exit");

            try
            {
                if (obj is Guid)
                    return 1;
                if (obj is byte[])
                    return 2;
                if (obj is Int32)
                    return 3;
                if (obj is Boolean)
                    return 4;
                if (obj is Double)
                    return 5;
                if (obj is Decimal)
                    return 6;
                if (obj is string)
                    return 7;
                if (obj is DateTime)
                    return 8;
                if (obj is Version)
                    return 9;

                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetCodeFromType.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for return type by code
        /// </summary>
        /// <param name="code">Code of type</param>
        /// <returns></returns>
        public Type GetTypeFromCode(int code)
        {
            Logger.Log.Debug("GetTypeFromCode. Enter/Exit");

            try
            {
                if (code == 1)
                    return typeof(Guid);
                if (code == 2)
                    return typeof(byte[]);
                if (code == 3)
                    return typeof(Int32);
                if (code == 4)
                    return typeof(Boolean);
                if (code == 5)
                    return typeof(Double);
                if (code == 6)
                    return typeof(Decimal);
                if (code == 7)
                    return typeof(string);
                if (code == 8)
                    return typeof(DateTime);
                if (code == 9)
                    return typeof(Version);

                return null;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetTypeFromCode.", ex);
                throw;
            }
        }
    }
}