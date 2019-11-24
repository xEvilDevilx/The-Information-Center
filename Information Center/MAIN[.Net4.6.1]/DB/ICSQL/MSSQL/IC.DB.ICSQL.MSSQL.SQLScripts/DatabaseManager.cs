using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using IC.DB.ICSQL.Interfaces;

namespace IC.DB.ICSQL.MSSQL.SQLScripts
{
    /// <summary>
    /// Implements Database Manager functionality
    /// 
    /// 2018/02/10 - Created, VTyagunov
    /// </summary>
    public class DatabaseManager : IDatabaseManager
    {
        #region Variables

        /// <summary>DB Connection string</summary>
        private readonly string _connectionString;
        /// <summary>Batabase object</summary>
        private readonly IDatabase _database;
        /// <summary>SQL Scripts Manager</summary>
        private readonly ISQLScriptsManager _sqlScriptsManager;

        #endregion

        #region Properties

        /// <summary>DB Version</summary>
        public int Version { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public DatabaseManager()
        {
            _connectionString = ConfigurationManager.ConnectionStrings[InternalConstants.
                DefaultConnectionName].ConnectionString;
            _database = new Database(_connectionString);
            _sqlScriptsManager = new SQLScriptsManager();
            Version = GetDBSqlVersion();
        }

        #endregion

        #region Methods

        #region Get DB Version

        /// <summary>
        /// Use for Get DB SQL Version
        /// </summary>
        /// <returns></returns>
        private int GetDBSqlVersion()
        {
            int dbSqlVersion;

            try
            {
                _database.OpenConnection(_connectionString);
                _database.BeginTransaction();
                var result = _database.Execute<String>(SQLConstants.SelectCurrentDBVersion, 
                    CommandType.Text, new SqlParameter[0], VersionPopulator);
                _database.Commit();
                _database.CloseConnection();

                if (string.IsNullOrEmpty(result))
                    return -1;

                dbSqlVersion = int.Parse(result);
            }
            catch (Exception ex)
            {
                // Log...
                throw;
            }

            return dbSqlVersion;
        }

        /// <summary>
        /// Use for populate Version field
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private String VersionPopulator(SqlDataReader reader)
        {
            var str = reader["VALUE"] as String;
            return str;
        }

        #endregion

        /// <summary>
        /// Use for Database Update
        /// </summary>
        public void UpdateDB()
        {
            try
            {
                var scriptFullNames = _sqlScriptsManager.GetScriptNames();
                var lastSqlScriptVersionString = _sqlScriptsManager.GetCleanScriptName(
                    scriptFullNames[scriptFullNames.Length - 1]);

                if (string.IsNullOrEmpty(lastSqlScriptVersionString))
                    throw new FormatException(lastSqlScriptVersionString);

                var lastSqlScriptVersion = int.Parse(lastSqlScriptVersionString);
                var isNeedUpdate = CheckIsNeedUpdateDB(lastSqlScriptVersion);

                if (!isNeedUpdate)
                    return;

                var intVer = Version + 1;
                var ver = intVer.ToString("D5");

                foreach (var sql in scriptFullNames)
                {
                    if (sql.Contains(ver))
                    {
                        var sqlScript = _sqlScriptsManager.GetScript(sql);
                        ExecuteNonQuery(sqlScript);

                        intVer++;
                        ver = intVer.ToString("D5");
                    }
                }

                if ((intVer - 1) > Version)
                {
                    var sqlQuery = string.Format(SQLConstants.UpdateDBVersion, intVer - 1);
                    ExecuteNonQuery(sqlQuery);
                }
            }
            catch (Exception ex)
            {
                // Log...
                throw;
            }
        }

        /// <summary>
        /// Use for Check is need Update DB or not need
        /// </summary>
        /// <returns></returns>
        private bool CheckIsNeedUpdateDB(int lastSqlScriptVersion)
        {
            if (lastSqlScriptVersion > Version)
                return true;
            else return false;
        }

        /// <summary>
        /// Use for Execute SQL script to DB
        /// </summary>
        /// <param name="sql">SQL script</param>
        private void ExecuteNonQuery(string sql)
        {
            try
            {
                _database.OpenConnection(_connectionString);
                _database.BeginTransaction();

                foreach (string part in GetSqlParts(sql))
                    _database.ExecuteNonQuery(part);

                _database.Commit();
                _database.CloseConnection();
            }
            catch(Exception ex)
            {
                // Log...
                throw;
            }
        }

        /// <summary>
        /// Use for split sql query and get sql parts
        /// </summary>
        /// <param name="sql">Sql query</param>
        /// <returns></returns>
        private IEnumerable<string> GetSqlParts(string sql)
        {
            const string reBatchSeparator = @"^(/\*.\*/)?\s*GO\s*(/\*.*\*/)?\s*(--.*)?$";

            using (var sr = new StringReader(sql))
            {
                string line;
                string part;
                var sb = new StringBuilder();
                var regex = new Regex(reBatchSeparator);
                while ((line = sr.ReadLine()) != null)
                {
                    if (!regex.IsMatch(line))
                        sb.AppendLine(line);
                    else
                    {
                        part = sb.ToString();
                        if (!string.IsNullOrEmpty(part))
                            yield return part;
                        sb.Clear();
                    }
                }

                part = sb.ToString();
                if (!string.IsNullOrEmpty(part))
                    yield return part;
            }
        }

        #endregion
    }
}