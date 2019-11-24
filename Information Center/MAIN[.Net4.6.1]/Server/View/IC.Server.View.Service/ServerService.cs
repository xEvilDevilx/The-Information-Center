using System.Net;
using System.ServiceProcess;

using IC.DB.ICSQL.Interfaces;
using IC.DB.ICSQL.MSSQL.DataProvider;
using IC.DB.ICSQL.MSSQL.SQLScripts;
using IC.DB.Interfaces;
using IC.SDK;
using IC.SDK.Base.Constants;
using IC.SDK.Interfaces.Serialization;
using IC.SDK.Serialization;
using IC.Server.Core.Base;
using IC.Server.Core.ClientManager;
using IC.Server.Core.ClientManager.Interfaces;
using IC.Server.Core.Interfaces;
using IC.Server.Core.Network;

namespace IC.Server.View.Service
{
    /// <summary>
    /// Presents Server Service work
    /// 
    /// 2016/12/11 - Created, VTyagunov
    /// </summary>
    public partial class ServerService : ServiceBase
    {
        #region Variables

        /// <summary>Servere IP-Address</summary>
        private IPAddress _udpIPAddress;
        /// <summary>Server UDP Port</summary>
        private int _udpPort;
        /// <summary>Server TCP Port</summary>
        private int _tcpPort;
        /// <summary>Do work with clients</summary>
        private IClientWorker _clientWorker;
        /// <summary>IAsyncService interface</summary>
        private IAsyncService _tcpService;
        /// <summary>IAsyncService interface</summary>
        private IAsyncService _udpService;
        /// <summary>Client Collection</summary>
        private ISimpleCollection<ClientData> _clients;
        /// <summary>Database manager for db update</summary>
        private IDatabaseManager _databaseManager;
        /// <summary>IC DB Operations</summary>
        private IICDBOperations _icDBOperations;
        /// <summary>Do stream serialize/deserialize work</summary>
        private IStreamSerializer _streamSerializer;
        /// <summary>Do bytes array serialize/deserialize work</summary>
        private IBytesArraySerializer _bytesArraySerializer;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ServerService()
        {
            InitializeComponent();

            _streamSerializer = new Serializer();
            _bytesArraySerializer = new Serializer();
            _databaseManager = new DatabaseManager();
            _icDBOperations = new DBOperations();
            _clientWorker = new ClientWorker(_icDBOperations, _streamSerializer, _bytesArraySerializer);
            _udpIPAddress = IPAddress.Parse("255.255.255.255");
            _udpPort = BaseConstants.UdpServerPort;
            _tcpPort = BaseConstants.TcpServerPort;
            _clients = new ClientCollection();
            _udpService = new UdpAsyncService(_udpPort, _clientWorker);
            _tcpService = new TcpAsyncService(_tcpPort, _clientWorker, _clients);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for Initialize server life cycle
        /// </summary>
        private void Init()
        {
            _databaseManager.UpdateDB();

            _udpService.RunAsync();
            _tcpService.RunAsync();
        }

        /// <summary>
        /// Use for do actions On Start
        /// </summary>
        /// <param name="args">Arguments</param>
        protected override void OnStart(string[] args)
        {
            Init();

            Logger.Log.Info("++++++++++++++ Server started! ++++++++++++++");
        }
        
        /// <summary>
        /// Use for do actions On Stop
        /// </summary>
        protected override void OnStop()
        {
            _udpService.Stop();
            _tcpService.Stop();

            _icDBOperations.SetTerminalsNonActiveStatus();

            Logger.Log.Info("++++++++++++++ Server stoped! ++++++++++++++");
        }

        #endregion
    }
}