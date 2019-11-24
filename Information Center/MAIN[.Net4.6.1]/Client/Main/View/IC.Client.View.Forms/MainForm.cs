using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

using IC.Client.FormModel.Base.Enums;
using IC.Client.Network;
using IC.Client.Network.Interfaces;
using IC.Client.View.BarcodeReaderEmuForms;
using IC.SDK;
using IC.SDK.Base.Constants;
using IC.SDK.Helpers;
using IC.SDK.Interfaces;
using System.Diagnostics;

namespace IC.Client.View.Forms
{
    /// <summary>
    /// Presents MainForm of client
    /// 
    /// 2017/03/05 - Created, VTyagunov
    /// </summary>
    public partial class MainForm : Form
    {
        #region Variables

        /// <summary>Client Main Entry</summary>
        private IMainEntry _mainEntry;
        /// <summary>Timer for check connection status</summary>
        private ISimpleTimer _checkConnectionTimer;
        /// <summary>Flag shows an old connection status</summary>
        private bool _oldConnectionStatus;
        /// <summary>BarCode Reader Emulator Form</summary>
        private BarCodeReaderEmuForm _barCodeReaderEmuForm;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            Logger.Log.Debug("MainForm. Ctr. Enter");
            
            InitializeComponent();

            var version = typeof(MainForm).Assembly.GetName().Version;
            AssemblyWorker.Instance.Version = version;
            ConnectionStatus.Instance.IsConnected = false;
            _mainEntry = new MainEntry(Controls);
            _mainEntry.Run();
            if (_mainEntry.ControlsPlugin.CleanBackgroundImage != null)
                BackgroundImage = _mainEntry.ControlsPlugin.CleanBackgroundImage;
            _mainEntry.ControlsPlugin.ShowControl(UserControlTypes.UnAvailable);
            _oldConnectionStatus = false;            
            _checkConnectionTimer = new SimpleTimer();

            Utils.StartSimpleThread(CheckFirstUpdate);

            var signalFolder = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), 
                BaseConstants.SignalFolderName);
            if (!Directory.Exists(signalFolder))
                Directory.CreateDirectory(signalFolder);

            timer1.Interval = BaseConstants.CheckSignalFolderTimeRate;
            timer1.Enabled = false;
            timer1.Enabled = true;

#if (BARCODEEMU)
            _barCodeReaderEmuForm = new BarCodeReaderEmuForm();
            _barCodeReaderEmuForm.BarCodeReadEvent += BarCodeEmuRead;
#endif
            //CheckFirstUpdate();

            Logger.Log.Info("++++++++++++++ Information Center Client started! ++++++++++++++");
            Logger.Log.Debug("MainForm. Ctr. Exit");
        }

#endregion

        #region Methods
        
        /// <summary>
        /// Event of close MainForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            Logger.Log.Debug("MainForm_Closing. Enter");

            ShutdownClient();
            Process.GetCurrentProcess().Kill();

            Logger.Log.Debug("MainForm_Closing. Exit");
            Logger.Log.Info("++++++++++++++ Information Center Client stoped! ++++++++++++++");
        }

        /// <summary>
        /// Use for shutdown client
        /// </summary>
        public void ShutdownClient()
        {
            Logger.Log.Debug("ShutdownClient. Enter");

            try
            {
#if (BARCODEEMU)
                if (_barCodeReaderEmuForm.InvokeRequired)
                    _barCodeReaderEmuForm.Invoke(new Action(() => { _barCodeReaderEmuForm.Close(); }));
                else _barCodeReaderEmuForm.Close();
#endif
                _checkConnectionTimer.Stop();
                _mainEntry.FullStop();                
            }
            catch(Exception ex)
            {
                Logger.Log.Error("ShutdownClient.", ex);
            }

            Logger.Log.Debug("ShutdownClient. Exit");
        }

        /// <summary>
        /// Use for start timer for check first receive system data from server
        /// </summary>
        private void CheckFirstUpdate()
        {
            Logger.Log.Debug("CheckFirstUpdate. Enter");

            try
            {
                var timer = new SimpleTimer();
                timer.Start(1, () => { CheckFirstUpdateAction(timer); });                
            }
            catch (Exception ex)
            {
                Logger.Log.Error("CheckFirstUpdate.", ex);
            }

            Logger.Log.Debug("CheckFirstUpdate. Exit");
        }

        /// <summary>
        /// Do action for check first update 
        /// </summary>
        /// <param name="timer"></param>
        private void CheckFirstUpdateAction(SimpleTimer timer)
        {
            Logger.Log.Debug("CheckFirstUpdateAction. Enter");

            if (ConnectionStatus.Instance.IsConnected)
            {
                timer.Stop();
                _mainEntry.Requests.RequireSystemData();
                
                Utils.StartSimpleThread(CheckConnectionStatus);

#if (BARCODEEMU)
                if (_barCodeReaderEmuForm.InvokeRequired)
                    _barCodeReaderEmuForm.Invoke(new Action(() => { _barCodeReaderEmuForm.ShowDialog(); }));
                else _barCodeReaderEmuForm.ShowDialog();
#endif                
            }

            Logger.Log.Debug("CheckFirstUpdateAction. Exit");
        }

        #region Connection Status

        /// <summary>
        /// Use for check connection status
        /// </summary>
        private void CheckConnectionStatus()
        {
            Logger.Log.Debug("CheckConnectionStatus. Enter");

            try
            {
                _checkConnectionTimer.Start(1, () => 
                {
                    if ((ConnectionStatus.Instance.IsConnected) && !_oldConnectionStatus)
                    {
                        _oldConnectionStatus = ConnectionStatus.Instance.IsConnected;
                        ConnectionActions();
                    }
                    if ((!ConnectionStatus.Instance.IsConnected) && _oldConnectionStatus)
                    {
                        _oldConnectionStatus = ConnectionStatus.Instance.IsConnected;
                        DisconnectionActions();
                    }
                });
                
                Logger.Log.Debug("CheckConnectionStatus. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("CheckConnectionStatus.", ex);
            }
        }

        /// <summary>
        /// Do connection actions
        /// </summary>
        private void ConnectionActions()
        {
            Logger.Log.Debug("ConnectionActions. Enter");

            try
            {
                           
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ConnectionActions.", ex);
            }

            Logger.Log.Debug("ConnectionActions. Exit");
        }

        /// <summary>
        /// Do disconnection actions
        /// </summary>
        private void DisconnectionActions()
        {
            Logger.Log.Debug("DisconnectionActions. Enter");

            try
            {

            }
            catch (Exception ex)
            {
                Logger.Log.Error("DisconnectionActions.", ex);
            }

            Logger.Log.Debug("DisconnectionActions. Exit");
        }

        #endregion
        
#if (BARCODEEMU)
        /// <summary>
        /// Use for send product info require by readed barcode
        /// </summary>
        /// <param name="barCodeValue">BarCode string value</param>
        private void BarCodeEmuRead(string barCodeValue)
        {
            Logger.Log.Debug("BarCodeEmuRead. Enter");

            try
            {
                string barCodeData = barCodeValue;
                if (barCodeData != null)
                {
                    var currentLanguage = _mainEntry.Transfer.CurrentLanguage;
                    var currentCurrency = _mainEntry.Transfer.CurrentCurrency;
                    _mainEntry.Requests.RequireProductInfo(barCodeData, currentLanguage, currentCurrency);
                }

                Logger.Log.Debug("BarCodeEmuRead. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("BarcodeReader_OnRead.", ex);
            }
        }
#endif
        
        /// <summary>
        /// Timer action for check signal of shutdown client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Logger.Log.Debug("timer1_Tick. Enter");

            var filePath = string.Format("{0}\\{1}\\{2}", Directory.GetCurrentDirectory(),
                BaseConstants.SignalFolderName, BaseConstants.SignalFileName);
            if (File.Exists(filePath))
            {
                ShutdownClient();
                Process.GetCurrentProcess().Kill();
                Application.Exit();
            }

            Logger.Log.Debug("timer1_Tick. Exit");
        }

        #endregion
    }
}