using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using IC.DB.ICSQL.Interfaces;

namespace IC.DB.ICSQL.MSSQL.SQLScripts
{
    /// <summary>
    /// Implements SQL Scripts Manager functionality
    /// 
    /// 2018/02/03 - Created, VTyagunov
    /// </summary>
    public class SQLScriptsManager : ISQLScriptsManager
    {
        /// <summary>
        /// Use for Get Clean script name from Full name
        /// </summary>
        /// <param name="fullScriptName">Full script name</param>
        /// <returns></returns>
        public string GetCleanScriptName(string fullScriptName)
        {
            string result = string.Empty;

            if (!fullScriptName.Contains(InternalConstants.PrefixNamespaceName) ||
                !fullScriptName.Contains(InternalConstants.PostfixExtensionName))
                return fullScriptName;

            result = fullScriptName.Replace(InternalConstants.PrefixNamespaceName, string.Empty).
                Replace(InternalConstants.PostfixExtensionName, string.Empty);

            return result;
        }

        /// <summary>
        /// Use for Get Clean script name from Full name
        /// </summary>
        /// <param name="fullScriptNames">Full script name</param>
        /// <returns></returns>
        public List<int> GetCleanScriptVers(string[] fullScriptNames)
        {
            var result = new List<int>();

            try
            {
                foreach (var fullScriptName in fullScriptNames)
                {
                    var cleanScriptName = GetCleanScriptName(fullScriptName);
                    var scriptVer = int.Parse(cleanScriptName);
                    result.Add(scriptVer);
                }
            }
            catch(Exception ex)
            {
                // Log...
                throw;
            }

            return result;
        }

        /// <summary>
        /// Use for Get script names array
        /// </summary>
        /// <returns></returns>
        public string[] GetScriptNames()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sqlScriptFullNames = assembly.GetManifestResourceNames();
            return sqlScriptFullNames;
        }

        /// <summary>
        /// Use for Get script by script id
        /// </summary>
        /// <param name="scriptID">Script ID</param>
        /// <returns></returns>
        public string GetScript(string scriptID)
        {
            string result = "";
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(scriptID))
            using (var reader = new StreamReader(stream))
                result = reader.ReadToEnd();

            return result;
        }
    }
}