using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using IC.DB.ICSQL.Base;

namespace IC.DB.ICSQL.Interfaces
{
    /// <summary>
    /// Presents Database operations functionality interface
    /// 
    /// 2018/02/01- Created, VTyagunov
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Use for Open connection
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// Use for Open connection
        /// </summary>
        /// <param name="connectionString"></param>
        void OpenConnection(string connectionString);

        /// <summary>
        /// Use for Close connection
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Use for start Begin Transaction actions
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Use for Commit transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// Use for RollBack transaction
        /// </summary>
        void Rollback();

        /// <summary>
        /// Use for Execute Non Query sql
        /// </summary>
        /// <param name="sql">Sql query</param>
        void ExecuteNonQuery(string sql);

        /// <summary>
        /// Use for Execute sql query
        /// </summary>
        /// <typeparam name="T">Type of returning object</typeparam>
        /// <param name="sql">Sql query</param>
        /// <param name="cmdType">Sql Command Type</param>
        /// <param name="parameters">Sql Parameters</param>
        /// <param name="populator">Populator method link</param>
        /// <returns>T type object</returns>
        T Execute<T>(string sql, CommandType cmdType, SqlParameter[] parameters, Populator<T> populator);

        /// <summary>
        /// Use for Execute sql query to List
        /// </summary>
        /// <typeparam name="T">Type of returning object</typeparam>
        /// <param name="sql">Sql query</param>
        /// <param name="cmdType">Sql Command Type</param>
        /// <param name="parameters">Sql Parameters</param>
        /// <param name="populator">Populator method link</param>
        /// <returns>T type object</returns>
        List<T> ExecuteList<T>(string sql, CommandType cmdType, SqlParameter[] parameters,
            Populator<T> populator) where T : new();
    }
}