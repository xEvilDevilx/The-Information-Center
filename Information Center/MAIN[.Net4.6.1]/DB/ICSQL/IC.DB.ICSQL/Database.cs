using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using IC.DB.ICSQL.Base;
using IC.DB.ICSQL.Interfaces;

namespace IC.DB.ICSQL
{   
    /// <summary>
    /// Implements Database operations functionality
    /// 
    /// 2018/02/01- Created, VTyagunov
    /// </summary>
    public class Database : IDatabase
    {
        #region Variables

        /// <summary>Sql Connection object</summary>
        private SqlConnection _connection = null;
        /// <summary>Sql Transaction object</summary>
        private SqlTransaction _transaction = null;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public Database(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Use for Open connection
        /// </summary>
        public void OpenConnection()
        {            
            _connection.Open();
        }

        /// <summary>
        /// Use for Open connection
        /// </summary>
        /// <param name="connectionString"></param>
        public void OpenConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        /// <summary>
        /// Use for Close connection
        /// </summary>
        public void CloseConnection()
        {
            _connection.Close();
        }

        /// <summary>
        /// Use for start Begin Transaction actions
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Use for Commit transaction
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
            _transaction = null;
        }

        /// <summary>
        /// Use for RollBack transaction
        /// </summary>
        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }

        /// <summary>
        /// Use for Execute Non Query sql
        /// </summary>
        /// <param name="sql">Sql query</param>
        public void ExecuteNonQuery(string sql)
        {
            var command = new SqlCommand(sql, _connection)
            {
                CommandType = CommandType.Text,
                Transaction = _transaction,
                CommandTimeout = 0
            };

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Use for Execute sql query
        /// </summary>
        /// <typeparam name="T">Type of returning object</typeparam>
        /// <param name="sql">Sql query</param>
        /// <param name="cmdType">Sql Command Type</param>
        /// <param name="parameters">Sql Parameters</param>
        /// <param name="populator">Populator method link</param>
        /// <returns>T type object</returns>
        public T Execute<T>(string sql, CommandType cmdType, SqlParameter[] parameters, Populator<T> populator)
        {
            T result;

            try
            {
                var command = new SqlCommand(sql, _connection);

                command.Parameters.AddRange(parameters);
                command.CommandType = cmdType;
                command.Transaction = _transaction;
                command.CommandTimeout = 0;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        result = populator(reader);
                    else throw new ArgumentNullException();
                }
            }
            catch(Exception ex)
            {
                // Log..
                //throw;
                return default(T);
            }

            return result;
        }

        /// <summary>
        /// Use for Execute sql query to List
        /// </summary>
        /// <typeparam name="T">Type of returning object</typeparam>
        /// <param name="sql">Sql query</param>
        /// <param name="cmdType">Sql Command Type</param>
        /// <param name="parameters">Sql Parameters</param>
        /// <param name="populator">Populator method link</param>
        /// <returns>T type object</returns>
        public List<T> ExecuteList<T>(string sql, CommandType cmdType, SqlParameter[] parameters, 
            Populator<T> populator) where T : new()
        {
            List<T> result = new List<T>();

            try
            {
                var command = new SqlCommand(sql, _connection);

                command.Parameters.AddRange(parameters);
                command.CommandType = cmdType;
                command.Transaction = _transaction;
                command.CommandTimeout = 0;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        result.Add(populator(reader));
                }
            }
            catch (Exception ex)
            {
                // Log..
                throw;
            }

            return result;
        }

        #endregion
    }
}