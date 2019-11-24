using System;

using IC.DB.Base;

namespace IC.DB.Interfaces
{
    /// <summary>
    /// Presents the DB Operations functionality interface
    /// 
    /// 2018/04/15 - Created, VTyagunov
    /// </summary>
    public interface IDBOperations : IDisposable
    {
        /// <summary>
        /// Use for Add T object to the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        void Add<T>(QueryData<T> queryData) where T : class;

        /// <summary>
        /// Use for Get T object from the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        /// <returns></returns>
        T Get<T>(QueryData<T> queryData) where T : class;

        /// <summary>
        /// Use for Update T object in the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        void Update<T>(QueryData<T> queryData) where T : class;

        /// <summary>
        /// Use for Remove T object from the DB
        /// </summary>
        /// <typeparam name="T">Type for to do Add operations with the DB</typeparam>
        /// <param name="queryData">Object of the type</param>
        void Remove<T>(QueryData<T> queryData) where T : class;
    }
}