using System.Collections.Generic;

namespace IC.DB.ICSQL.Interfaces
{
    /// <summary>
    /// Presents SQL Scripts Manager functionality interface
    /// 
    /// 2018/02/03 - Created, VTyagunov
    /// </summary>
    public interface ISQLScriptsManager
    {
        /// <summary>
        /// Use for Get Clean script name from Full name
        /// </summary>
        /// <param name="fullScriptName">Full script name</param>
        /// <returns></returns>
        string GetCleanScriptName(string fullScriptName);

        /// <summary>
        /// Use for Get Clean script name from Full name
        /// </summary>
        /// <param name="fullScriptNames">Full script name</param>
        /// <returns></returns>
        List<int> GetCleanScriptVers(string[] fullScriptNames);

        /// <summary>
        /// Use for Get script names array
        /// </summary>
        /// <returns></returns>
        string[] GetScriptNames();

        /// <summary>
        /// Use for Get script by script id
        /// </summary>
        /// <param name="scriptID">Script ID</param>
        /// <returns></returns>
        string GetScript(string scriptID);
    }
}