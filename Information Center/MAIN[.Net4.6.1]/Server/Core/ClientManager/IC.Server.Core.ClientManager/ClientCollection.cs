using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;

using IC.SDK;
using IC.Server.Core.Base;
using IC.Server.Core.Interfaces;

namespace IC.Server.Core.ClientManager
{
    /// <summary>
    /// Implements Client Collection
    /// 
    /// 2016/12/15 - Created, VTyagunov
    /// </summary>
    public class ClientCollection : ISimpleCollection<ClientData>
    {
        #region Variables

        /// <summary>Client dictionary</summary>
        private readonly ConcurrentDictionary<IPAddress, ClientData> _clientDic;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ClientCollection()
        {
            Logger.Log.Debug("ClientCollection. Ctr. Enter");

            _clientDic = new ConcurrentDictionary<IPAddress, ClientData>();

            Logger.Log.Debug("ClientCollection. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for add ClientData to the collection
        /// </summary>
        /// <param name="clientData">ClientData object</param>
        public bool Add(ClientData clientData)
        {
            Logger.Log.Debug("Add. Enter");

            try
            {
                ClientData client;
                var clientIPAddress =
                    ((IPEndPoint)clientData.TcpClientConnection.Client.RemoteEndPoint).Address;

                var values = _clientDic.Values;
                var clientUID = values.FirstOrDefault(x => x.ClientUID == clientData.ClientUID);
                if (clientUID != null)
                {
                    Logger.Log.InfoFormat("Add. Client with IP:[{0}] contains yet. Try remove",
                        clientIPAddress.ToString());

                    var ipAddress = _clientDic.FirstOrDefault(x => x.Value.ClientUID == clientUID.ClientUID).Key;
                    if (ipAddress != null)
                    {
                        if (_clientDic.TryRemove(ipAddress, out client))
                        {
                            Logger.Log.InfoFormat("Add. Client with IP:[{0}] was removed",
                                clientIPAddress.ToString());
                            return TryAdd(clientIPAddress, clientData);
                        }
                    }
                    return false;
                }

                var macAddress = values.FirstOrDefault(x => x.MACAddress == clientData.MACAddress);
                if (macAddress != null)
                {
                    Logger.Log.InfoFormat("Add. Client with IP:[{0}] contains yet. Try remove",
                        clientIPAddress.ToString());

                    var ipAddress = _clientDic.FirstOrDefault(x => x.Value.MACAddress == macAddress.MACAddress).Key;
                    if (ipAddress != null)
                    {
                        if (_clientDic.TryRemove(ipAddress, out client))
                        {
                            Logger.Log.InfoFormat("Add. Client with IP:[{0}] was removed",
                                clientIPAddress.ToString());
                            return TryAdd(clientIPAddress, clientData);
                        }
                    }
                    return false;
                }

                var isAdded = TryAdd(clientIPAddress, clientData);

                Logger.Log.InfoFormat("Add. Client with IP:[{0}] contains yet. Exit",
                    clientIPAddress.ToString());
                return isAdded;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Add", ex);
                return false;
            }
        }

        /// <summary>
        /// Use for Try To Add a ClientData in the Client Collection
        /// </summary>
        /// <param name="clientIPAddress">Client IP-Address</param>
        /// <param name="clientData">Client Data</param>
        /// <returns></returns>
        private bool TryAdd(IPAddress clientIPAddress, ClientData clientData)
        {
            Logger.Log.Debug("TryAdd. Enter");

            try
            {
                ClientData client;
                if (!_clientDic.TryGetValue(clientIPAddress, out client))
                {
                    _clientDic.TryAdd(clientIPAddress, clientData);

                    Logger.Log.InfoFormat("TryAdd. Added client with IP:[{0}]. Exit",
                        clientIPAddress.ToString());
                    return true;
                }

                Logger.Log.InfoFormat("TryAdd. Client with IP:[{0}] contains yet. Exit",
                    clientIPAddress.ToString());
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("TryAdd", ex);
                return false;
            }
        }

        /// <summary>
        /// Use for get ClientData by IP-Address
        /// </summary>
        /// <param name="ipAddress">IP-Address of client</param>
        /// <returns></returns>
        public ClientData Get(object ipAddress)
        {
            Logger.Log.Debug("Get. Enter");

            try
            {
                ClientData clientData;
                if (_clientDic.TryGetValue((IPAddress)ipAddress, out clientData))
                {
                    Logger.Log.Debug("Get. Exit");
                    return clientData;
                }

                Logger.Log.Debug("Get. Exit");
                return null;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Get", ex);
                return null;
            }
        }

        /// <summary>
        /// Use for delete ClientData from collection
        /// </summary>
        /// <param name="clientData">ClientData object</param>
        /// <returns></returns>
        public bool Remove(ClientData clientData)
        {
            Logger.Log.Debug("Remove. Enter");
                        
            try
            {
                ClientData client;
                var clientIPAddress = ((IPEndPoint)clientData.TcpClientConnection.Client.RemoteEndPoint).Address;

                if (_clientDic.TryRemove(clientIPAddress, out client))
                {
                    Logger.Log.InfoFormat("Remove. Client with IP:[{0}] was deleted. Exit", 
                        clientIPAddress.ToString());
                    return true;
                }

                Logger.Log.InfoFormat("Remove. Client with IP:[{0}] is not found. Exit", 
                    clientIPAddress.ToString());
                return false;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("Remove", ex);
                return false;
            }
        }
        
        #endregion
    }
}