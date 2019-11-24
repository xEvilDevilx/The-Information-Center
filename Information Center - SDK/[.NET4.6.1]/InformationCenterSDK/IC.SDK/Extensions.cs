using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace IC.SDK
{
    /// <summary>
    /// Implements Extension methods
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public static class Extensions
    {
        #region Methods

        /// <summary>
        /// Extension for remove item from Array by index
        /// </summary>
        /// <typeparam name="T">T Type</typeparam>
        /// <param name="source">T object</param>
        /// <param name="index">Index</param>
        /// <returns></returns>
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            Logger.Log.Debug("RemoveAt. Enter");

            var dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            Logger.Log.Debug("RemoveAt. Exit");
            return dest;
        }

        /// <summary>
        /// Use for Get Connection State
        /// </summary>
        /// <param name="tcpClient">TcpClient object</param>
        /// <returns></returns>
        public static TcpState GetState(TcpClient tcpClient)
        {
            Logger.Log.Debug("GetState. Enter");

            var foo = IPGlobalProperties.GetIPGlobalProperties()
              .GetActiveTcpConnections()
              .SingleOrDefault(x => x.LocalEndPoint.Equals(tcpClient.Client.LocalEndPoint));

            Logger.Log.Debug("GetState. Exit");
            return foo != null ? foo.State : TcpState.Unknown;
        }

        #endregion
    }
}