using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using IC.Client.DataLayer;
using IC.DB.Base;
using IC.DB.Base.Enums;
using IC.DB.DataLayer;
using IC.DB.Interfaces;
using IC.LicenseManager.BusinessObjects;
using IC.LicenseManager.CryptoService;
using IC.LicenseManager.Interfaces;
using IC.SDK;
using IC.SDK.Base;
using IC.SDK.Base.Constants;
using IC.SDK.Base.Enums;
using IC.SDK.Helpers;
using IC.SDK.Interfaces.Serialization;
using IC.Server.Core.Base;
using IC.Server.Core.Base.Enums;
using IC.Server.Core.ClientManager.Interfaces;
using IC.Server.Core.Interfaces;
using IC.Server.Core.Network.Interfaces;

namespace IC.Server.Core.ClientManager
{
    /// <summary>
    /// Implements work with client
    /// 
    /// 2016/12/11 - Created, VTyagunov
    /// </summary>
    public class ClientWorker : IClientWorker, IWriteClientDeviceStatus, IDisposable
    {
        #region Variables

        /// <summary>Flag for IDisposable pattern</summary>
        private bool _disposed = false;
        /// <summary>Do stream serialize/deserialize work</summary>
        private readonly IStreamSerializer _streamSerializer;
        /// <summary>Do bytes array serialize/deserialize work</summary>
        private readonly IBytesArraySerializer _bytesArraySerializer;
        /// <summary>IC DB Operations</summary>
        private readonly IICDBOperations _icDBOperations;
        /// <summary>License Creator</summary>
        private readonly ILicenseCreator _licenseCreator;
        /// <summary>License Verifier</summary>
        private readonly ILicenseVerifier _licenseVerifier;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ClientWorker(IICDBOperations icDBOperations, IStreamSerializer streamSerializer,
            IBytesArraySerializer bytesArraySerializer)
        {
            Logger.Log.Debug("ClientWorker. Ctr. Enter");

            if (icDBOperations == null)
                throw new ArgumentNullException(nameof(icDBOperations));

            if (streamSerializer == null)
                throw new ArgumentNullException(nameof(streamSerializer));

            if (bytesArraySerializer == null)
                throw new ArgumentNullException(nameof(bytesArraySerializer));

            _streamSerializer = streamSerializer;
            _bytesArraySerializer = bytesArraySerializer;
            _icDBOperations = icDBOperations;
            _licenseCreator = new LicenseCreator();
            _licenseVerifier = new LicenseVerifier();

            Logger.Log.Debug("ClientWorker. Ctr. Exit");
        }

        #endregion

        #region Methods

        #region IDisposable implementation

        /// <summary>
        /// Implements IDisposable interface
        /// </summary>
        public void Dispose()
        {
            Logger.Log.Debug("ClientWorker. Dispose. Enter");

            Dispose(true);
            GC.SuppressFinalize(this);

            Logger.Log.Debug("ClientWorker. Dispose. Exit");
        }

        /// <summary>
        /// Implements IDisposable interface
        /// </summary>
        /// <param name="disposing">Flag shows is need dispose or not need</param>
        protected virtual void Dispose(bool disposing)
        {
            Logger.Log.Debug("ClientWorker. Dispose. Enter");

            if (!_disposed)
            {
                if (disposing)
                    _icDBOperations.Dispose();

                _disposed = true;
            }

            Logger.Log.Debug("ClientWorker. Dispose. Exit");
        }

        #endregion

        /// <summary>
        /// Does work with TcpClient stream
        /// </summary>
        /// <param name="tcpClient">Connected client</param>
        /// <param name="clients">Client collection</param>
        /// <returns></returns>
        public async void TcpProcess(TcpClient tcpClient, ISimpleCollection<ClientData> clients)
        {
            await Task.Factory.StartNew(() =>
            {
                Logger.Log.Debug("TcpProcess. Enter");

                try
                {
                    var timer = new SimpleTimer();
                    int counter = 0;
                    var stream = tcpClient.GetStream();

                    timer.Start(1, () =>
                    {
                        if (counter < 30)
                        {
                            if (stream.DataAvailable)
                            {
                                var obj = _streamSerializer.Deserialize(stream,
                                         BaseConstants.ServerDataLayerNamespaceName,
                                         BaseConstants.ServerDataLayerLibName);
                                var clientData = new ClientData()
                                {
                                    TcpClientConnection = tcpClient
                                };
                                CheckType(obj, clientData, clients);
                                timer.Stop();
                            }
                            counter++;
                        }
                        else
                        {
                            timer.Stop();
                            return;
                        }
                    });
                }
                catch (Exception ex)
                {
                    Logger.Log.Error("TcpProcess.", ex);
                    if (tcpClient.Connected)
                        tcpClient.Close();
                }

                Logger.Log.Debug("TcpProcess. Exit");
            });
        }

        /// <summary>
        /// Does work with received bytes array
        /// </summary>
        /// <param name="bytesArray">Received bytes array</param>
        /// <param name="remoteEndPoint">Client IPEndPoint</param>
        /// <param name="udpClient">UDP Client</param>
        /// <returns></returns>
        public async void UdpProcess(byte[] bytesArray, IPEndPoint remoteEndPoint, UdpClient udpClient)
        {
            Logger.Log.Debug("UdpProcess. Enter");

            var endPoint = remoteEndPoint;

            try
            {
                var clientInfo = (ClientInfo)_bytesArraySerializer.DeserializeFromBytesArray(bytesArray);
                var ip = remoteEndPoint.Address.ToString();
                //var terminal = await _context.Terminal.Where(x => x.IPAddress == ip).FirstAsync();
                var terminal = await Task.Factory.StartNew(() => 
                {
                    return _icDBOperations.GetTerminal<Terminal>(ip);
                });

                if (terminal != null)
                {
                    var ipAddress = Utils.LocalIPAddress();
                    var ipAddressBytes = _bytesArraySerializer.SerializeToBytesArray(ipAddress.ToString(),
                        UdpSerializeTypes.SimpleTypes);

                    SendUDPData(remoteEndPoint, ipAddressBytes, udpClient);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UdpProcess.", ex);
            }

            Logger.Log.Debug("UdpProcess. Exit");
        }

        /// <summary>
        /// Does send data to remote end point
        /// </summary>
        /// <param name="remoteEndPoint">Client ip end point</param>
        /// <param name="bytesArray">Data bytes array</param>
        /// <param name="udpClient">UDP Client</param>
        private void SendUDPData(IPEndPoint remoteEndPoint, byte[] bytesArray, UdpClient udpClient)
        {
            Logger.Log.Debug("SendUDPData. Enter");

            try
            {
                udpClient.Send(bytesArray, bytesArray.Length, remoteEndPoint);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SendUDPData.", ex);
            }

            Logger.Log.Debug("SendUDPData. Exit");
        }

        /// <summary>
        /// Does send data to remote end point
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="obj">Object Data to Send</param>
        /// <param name="tcpSerializeTypes">Object Data to Send</param>
        private void SendTCPData(Stream stream, object obj, TcpSerializeTypes tcpSerializeTypes)
        {
            Logger.Log.Debug("SendTCPData. Enter");

            try
            {
                if (stream.CanWrite)
                {
                    _streamSerializer.Serialize(stream, obj, tcpSerializeTypes);
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SendTCPData.", ex);
            }

            Logger.Log.Debug("SendTCPData. Exit");
        }

        /// <summary>
        /// Use for write client device status to db
        /// </summary>
        /// <param name="ipAddress">Client IP-Address</param>
        /// <param name="status">Client device status for write</param>
        public void WriteClientDeviceStatus(IPAddress ipAddress, byte status)
        {
            Logger.Log.Debug("WriteClientDeviceStatus. Enter");

            var ip = ipAddress.ToString();
            _icDBOperations.SetTerminalActiveStatus(ip, status);

            var terminal = _icDBOperations.GetTerminal<Terminal>(ip);
            var eventLog = new EventLog()
            {
                TerminalID = terminal.TerminalID,
                EventDataTime = DateTime.Now,
                EventType = (byte)ConnectionEventTypes.ClientConnect,
                EventSource = "WriteClientDeviceStatus",
                EventDetails = string.Format("Client[{0}] - Is Connected!", ipAddress)
            };
            var queryData = new QueryData<EventLog>()
            {
                ClientIP = ipAddress,
                QueryObject = eventLog
            };
            _icDBOperations.Add<EventLog>(queryData);

            Logger.Log.InfoFormat("WriteClientDeviceStatus. Client[{0}] is connected!", ipAddress);
            Logger.Log.Debug("WriteClientDeviceStatus. Exit");
        }
        
        /// <summary>
        /// Use for start check client connection status
        /// </summary>
        /// <param name="clientData">Client data</param>
        /// <param name="clients">Client collection</param>
        public void StartCheckClientConnectionStatus(ClientData clientData, ISimpleCollection<ClientData> clients)
        {
            try
            {
                Logger.Log.Debug("StartCheckClientConnectionStatus. Enter");

                var clientIPAddress = ((IPEndPoint)clientData.TcpClientConnection.Client.RemoteEndPoint).Address;
                var checkClientTimer = new System.Timers.Timer(BaseConstants.ClientSendInterval * 1000 + 10000);
                checkClientTimer.AutoReset = true;
                checkClientTimer.Elapsed += (sender, e) =>
                {
                    CheckClientConnectionStatus(clientData, clientIPAddress, checkClientTimer, clients);
                };
                checkClientTimer.Start();

                Logger.Log.Debug("StartCheckClientConnectionStatus. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("StartCheckClientConnectionStatus.", ex);
            }
        }

        /// <summary>
        /// Use for start check client status
        /// </summary>
        /// <param name="clientData">Client data</param>
        /// <param name="clientIPAddress">Client IP-Address</param>
        /// <param name="checkClientTimer">Timer for check client status</param>
        /// <param name="clients">Client collection</param>
        private void CheckClientConnectionStatus(ClientData clientData, IPAddress clientIPAddress,
            System.Timers.Timer checkClientTimer, ISimpleCollection<ClientData> clients)
        {
            Logger.Log.Debug("CheckClientConnectionStatus. Ennter");

            try
            {
                if (!clientData.IsOnLine)
                {
                    Logger.Log.InfoFormat("CheckClientConnectionStatus. Tcp. Client[{0}] is disconnected!", clientIPAddress);
                    WriteClientDeviceStatus(clientIPAddress, 0);
                    clients.Get(clientIPAddress).TcpClientConnection.Client.Shutdown(SocketShutdown.Both);
                    clients.Get(clientIPAddress).TcpClientConnection.Client.Disconnect(true);
                    clients.Get(clientIPAddress).TcpClientConnection.Client.Close();
                    clients.Get(clientIPAddress).TcpClientConnection.GetStream().Close();
                    clients.Remove(clientData);
                    checkClientTimer.Stop();

                    Logger.Log.Debug("CheckClientConnectionStatus. Exit");
                }
                clientData.IsOnLine = false;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("CheckClientConnectionStatus.", ex);
                clients.Remove(clientData);
                checkClientTimer.Stop();
            }
        }

        /// <summary>
        /// Use for start check client stream for available income data
        /// </summary>
        /// <param name="clientData">Client data</param>
        public void StartCheckClientStream(ClientData clientData)
        {
            Logger.Log.Debug("StartCheckClientStream. Enter");

            bool isOnLine = true;
            var stream = clientData.TcpClientConnection.GetStream();

            while (isOnLine)
            {
                if (clientData != null)
                {
                    if (stream.DataAvailable)
                    {
                        var obj = _streamSerializer.Deserialize(stream,
                             BaseConstants.ServerDataLayerNamespaceName, BaseConstants.ServerDataLayerLibName);
                        CheckType(obj, clientData, null);
                    }
                }
                else isOnLine = false;

                Thread.Sleep(100);
            }

            Logger.Log.Debug("StartCheckClientStream. Exit");
        }

        /// <summary>
        /// Use for check type of received object
        /// </summary>
        /// <param name="obj">Received object</param>
        /// <param name="clientData">Client data</param>
        /// <param name="clients">Client Collection</param>
        private void CheckType(object obj, ClientData clientData, ISimpleCollection<ClientData> clients)
        {
            try
            {
                Logger.Log.Debug("CheckType. Enter");

                if (obj == null)
                {
                    Logger.Log.Warn("CheckType. Object obj is null");
                    return;
                }

                var stream = clientData.TcpClientConnection.GetStream();

                if (obj is ClientStatus)
                {
                    clientData.IsOnLine = true;
                    SendTCPData(stream, obj, TcpSerializeTypes.ClientStatus);
                }

                if (obj is DBQuery)
                {
                    var clientIPAddress =
                        ((IPEndPoint)clientData.TcpClientConnection.Client.RemoteEndPoint).Address;
                    var packetTypeByte = ((DBQuery)obj).PacketType;
                    var queryString = ((DBQuery)obj).QueryString;

                    Logger.Log.InfoFormat("CheckType. Client[{0}] sent packet with ID: [{1}]",
                        clientIPAddress, packetTypeByte);
                    
                    switch ((DataTypes)packetTypeByte)
                    {
                        case DataTypes.Advertising:
                            var adQueryData = new QueryData<List<AdvertisingData>>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var adObj = _icDBOperations.Get(adQueryData);
                            foreach(var ad in adObj)
                                SendTCPData(stream, ad, TcpSerializeTypes.AdvertisingData);
                            break;
                        case DataTypes.ClientSystemLocalization:
                            var sysLocalizeQueryData = new QueryData<SystemTranslationData>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var sysLocalizeObj = _icDBOperations.Get(sysLocalizeQueryData);
                            SendTCPData(stream, sysLocalizeObj, TcpSerializeTypes.SystemTranslationData);
                            break;
                        case DataTypes.Currency:
                            var currencyQueryData = new QueryData<List<CurrencyData>>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var currencyObj = _icDBOperations.Get(currencyQueryData);
                            foreach (var currency in currencyObj)
                                SendTCPData(stream, currency, TcpSerializeTypes.CurrencyData);
                            break;
                        case DataTypes.DefaultLangCurr:
                            var defaultLangCurrQueryData = new QueryData<DefaultLangCurr>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var defaultLangCurrObj = _icDBOperations.Get(defaultLangCurrQueryData);
                            SendTCPData(stream, defaultLangCurrObj, TcpSerializeTypes.DefaultLangCurr);
                            break;
                        case DataTypes.Language:
                            var languageQueryData = new QueryData<List<LanguageData>>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var languageObj = _icDBOperations.Get(languageQueryData);
                            foreach (var language in languageObj)
                                SendTCPData(stream, language, TcpSerializeTypes.LanguageData);
                            break;
                        case DataTypes.ProductInfo:
                            var productInfoQueryData = new QueryData<ProductInfoData>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var productInfoObj = _icDBOperations.Get(productInfoQueryData);
                            SendTCPData(stream, productInfoObj, TcpSerializeTypes.ProductInfoData);
                            break;
                        case DataTypes.RetailActionInfo:
                            var sharesSalesQueryData = new QueryData<List<SharesSalesData>>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var sharesSalesObj = _icDBOperations.Get(sharesSalesQueryData);
                            foreach (var sharesSales in sharesSalesObj)
                                SendTCPData(stream, sharesSales, TcpSerializeTypes.SharesSalesData);
                            break;
                        case DataTypes.StoreLogo:
                            var logoQueryData = new QueryData<LogoData>()
                            {
                                ClientIP = clientIPAddress,
                                QueryParams = queryString
                            };
                            var logoObj = _icDBOperations.Get(logoQueryData);
                            SendTCPData(stream, logoObj, TcpSerializeTypes.LogoData);
                            break;
                    }                   
                }

                if (obj is LicenseData)
                {
                    LicenseVerify(stream, ((LicenseData)obj), clientData, clients);
                }

                Logger.Log.Debug("CheckType. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("CheckType. ", ex);
            }
        }

        #region License Verify

        /// <summary>
        /// Use for License Verify
        /// </summary>
        /// <param name="stream">Client stream</param>
        /// <param name="licenseData">License Data</param>
        /// <param name="clientData">Client Data</param>
        /// <param name="clients">Client Collection</param>
        private void LicenseVerify(Stream stream, LicenseData licenseData,
            ClientData clientData, ISimpleCollection<ClientData> clients)
        {
            Logger.Log.Debug("LicenseVerify. Enter");

            try
            {
                var clientIPAddress =
                    ((IPEndPoint)clientData.TcpClientConnection.Client.RemoteEndPoint).Address;
                var clientIPAddressString = clientIPAddress.ToString();
                var terminal = _icDBOperations.GetTerminal<Terminal>(clientIPAddress.ToString());
                if (terminal != null)
                {
                    var licenseKeyBytes = licenseData.LicenseDataArray;
                    var clientLicenseData = _licenseVerifier.GetClientLicenseDataFromKey(licenseKeyBytes);
                    var licenseIsVerifiedKey = BaseConstants.LicenseIsVerified;

                    var clientMACAddress = clientLicenseData.MACAddress;
                    var clientVersion = clientLicenseData.Version;
                    var clientUID = clientLicenseData.UID;
                    var clientPassword = clientLicenseData.Password;

                    var clientMACAddressInDB = terminal.MacAddress;
                    var clientVersionInDB = terminal.TerminalVersion;
                    var clientUIDInDB = terminal.TerminalUID;
                    var clientPasswordInDB = "6test6PassworD6"; // terminal.Password

                    if (string.IsNullOrEmpty(clientMACAddressInDB))
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] MAC Address in database is null or empty!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }
                    else if (clientMACAddress != clientMACAddressInDB)
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] MAC Address is invalid!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }

                    if (string.IsNullOrEmpty(clientVersionInDB))
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] Version in database is null or empty!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }
                    else if (clientVersion.ToString() != clientVersionInDB)
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] Version is invalid!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }

                    if (string.IsNullOrEmpty(clientUIDInDB))
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] UID in database is null or empty!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }
                    else if (clientUID.ToString() != clientUIDInDB)
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] UID is invalid!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }

                    if (string.IsNullOrEmpty(clientPasswordInDB))
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] Password in database is null or empty!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }
                    else if (clientPassword != clientPasswordInDB)
                    {
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] Password is invalid!", clientIPAddressString);
                        SendClientLicenseInvalid(stream);
                        return;
                    }

                    var clientLicense = new ClientLicenseData(clientMACAddressInDB, System.Version.Parse(clientVersionInDB),
                        clientUIDInDB, clientPasswordInDB);
                    var isVerified = _licenseVerifier.LicenseKeyVerify(clientLicense, licenseKeyBytes);
                    if (!isVerified)
                    {
                        SendClientLicenseInvalid(stream);
                        Logger.Log.WarnFormat("LicenseVerify. Client[{0}] license in invalid!", clientIPAddressString);
                        return;
                    }
                    else
                    {
                        clientData.MACAddress = clientMACAddress;
                        clientData.Version = clientVersion;
                        clientData.ClientUID = clientUID;

                        if (clients.Add(clientData))
                        {
                            var licenseKeySignature = _licenseCreator.CreateLicenseKeySignature(clientMACAddressInDB,
                                System.Version.Parse(clientVersionInDB), clientUIDInDB, licenseIsVerifiedKey);
                            var newLicenseData = new LicenseData()
                            {
                                LicenseDataArray = licenseKeySignature
                            };

                            _streamSerializer.Serialize(stream, newLicenseData, TcpSerializeTypes.LicenseData);
                            WriteClientDeviceStatus(clientIPAddress, 1);
                            StartCheckClientConnectionStatus(clientData, clients);
                            StartCheckClientStream(clientData);
                        }
                        else
                        {
                            SendClientLicenseInvalid(stream);
                            Logger.Log.WarnFormat("LicenseVerify. Client[{0}] currently OnLine!", clientIPAddressString);
                            return;
                        }
                    }
                }
                else SendClientLicenseInvalid(stream);

                Logger.Log.Debug("LicenseVerify. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("LicenseVerify. ", ex);
            }
        }

        /// <summary>
        /// Use for Send Client License Invalid status
        /// </summary>
        /// <param name="stream">Client stream</param>
        private void SendClientLicenseInvalid(Stream stream)
        {
            Logger.Log.Debug("SendClientLicenseInvalid. Enter");
            
            var licenseKeySignature = _licenseCreator.CreateLicenseKeySignature("",
                                        System.Version.Parse("0.0.0.0"), "0000", "1");
            var licenseData = new LicenseData()
            {
                LicenseDataArray = licenseKeySignature
            };
            _streamSerializer.Serialize(stream, licenseData, TcpSerializeTypes.LicenseData);

            Logger.Log.Debug("SendClientLicenseInvalid. Exit");
        }

        #endregion

        #endregion
    }
}