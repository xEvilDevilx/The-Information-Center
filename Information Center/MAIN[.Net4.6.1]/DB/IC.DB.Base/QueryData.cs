using System.Net;

namespace IC.DB.Base
{
    /// <summary>
    /// Presents DB Query Data
    /// 
    /// 2018/04/16 - Created, VTyagunov
    /// </summary>
    /// <typeparam name="T">Object of the T type</typeparam>
    public class QueryData<T> where T : class
    {
        /// <summary>Object of the Query</summary>
        public T QueryObject { get; set; }
        /// <summary>Client IP Address</summary>
        public IPAddress ClientIP { get; set; }
        /// <summary>Parameters of the Query</summary>
        public string QueryParams { get; set; }
    }
}