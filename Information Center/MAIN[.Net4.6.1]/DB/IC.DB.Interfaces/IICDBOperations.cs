using System.Collections.Generic;

namespace IC.DB.Interfaces
{
    /// <summary>
    /// Presents the IC DB Operations functionality interface
    /// 
    /// 2018/04/16 - Created, VTyagunov
    /// </summary>
    public interface IICDBOperations : IDBOperations
    {
        /// <summary>
        /// Use for Set active status of the Terminal by IP address
        /// </summary>
        /// <param name="ip">Terminal IP Address</param>
        /// <param name="status">Active status of the Terminal</param>
        void SetTerminalActiveStatus(string ip, byte status);

        /// <summary>
        /// Use for Set Non Active status for all Terminals
        /// </summary>
        void SetTerminalsNonActiveStatus();

        /// <summary>
        /// Use for Get Terminal information object by IP addresas
        /// </summary>
        /// <typeparam name="T">Terminal type</typeparam>
        /// <param name="ip">IP addresas string</param>
        /// <returns></returns>
        T GetTerminal<T>(string ip);

        /// <summary>
        /// Use for Get Currency Rate
        /// </summary>
        /// <typeparam name="T">CurrencyRate type</typeparam>
        /// <param name="storeID">Store ID</param>
        /// <param name="currencyCode">Currency Code</param>
        /// <returns></returns>
        T GetCurrencyRate<T>(string storeID, string currencyCode);

        /// <summary>
        /// Use for Update Currency Rate
        /// </summary>
        /// <typeparam name="T">CurrencyRate type</typeparam>
        /// <param name="t">T type object</param>
        void UpdateCurrencyRate<T>(T t) where T : class;

        /// <summary>
        /// Use for Get Store Currency Config List from db
        /// </summary>
        /// <typeparam name="T">Config type</typeparam>
        /// <returns></returns>
        List<T> GetStoreCurrencyConfigList<T>();

        /// <summary>
        /// Use for Get Store List from db
        /// </summary>
        /// <typeparam name="T">Store type</typeparam>
        /// <returns></returns>
        List<T> GetStoreList<T>();
    }
}