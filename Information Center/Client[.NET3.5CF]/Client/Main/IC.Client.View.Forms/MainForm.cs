using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.Win32;

using IC.Client.FormModel.Base.Enums;
using IC.Client.Network;
using IC.Client.Network.Interfaces;
using IC.SDK;
using IC.SDK.Helpers;
using IC.SDK.Base;

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
        private SimpleTimer _checkConnectionTimer;
        /// <summary>Flag shows an old connection status</summary>
        private bool _oldConnectionStatus;
#if (BARCODEEMU)
        /// <summary>BarCode Reader Emulator Form</summary>
        private BarCodeReaderEmuForm _barCodeReaderEmuForm;
#endif

        #region EXAMPLE Show-Hide Window/FontSmooth(ClearType)

        [DllImport("coredll.dll")]
        static extern bool ShowWindow(int hWnd, int nCmdShow);

        [DllImport("coredll.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("coredll.dll")]
        private static extern int SystemParametersInfo(int uiAction, int uiParam, out int pvParam, int fWinIni);

        [DllImport("coredll.dll")]
        private static extern int SystemParametersInfo(int uiAction, int uiParam, IntPtr pvParam, int fWinIni);

        const int SPI_GETFONTSMOOTHING = 0x0000004A;    // use pvParam to query
        const int SPI_SETFONTSMOOTHING = 0x0000004B;    // use uiParam to set

        public bool SystemWideClearType
        {
            get
            {
                int enabled;
                SystemParametersInfo(SPI_GETFONTSMOOTHING, 0, out enabled, 0);
                return (enabled != 0);
            }
            set
            {
                SystemParametersInfo(SPI_SETFONTSMOOTHING, value ? -1 : 0, IntPtr.Zero, 0);
            }
        }

        int hWnd = 0;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            Logger.Log.Debug("MainForm. Ctr. Enter");

            #region EXAMPLE FontSmooth(ClearType)
            SystemWideClearType = true;
            #endregion

            InitializeComponent();

            var version = typeof(MainForm).Assembly.GetName().Version;
            AssemblyWorker.Instance.Version = version;
            ConnectionStatus.Instance.IsConnected = false;
            _mainEntry = new MainEntry(Controls);
            _mainEntry.Run();
            if(_mainEntry.ControlsPlugin.CleanBackgroundImage != null)
                imgBackground.Image = _mainEntry.ControlsPlugin.CleanBackgroundImage;
            _mainEntry.ControlsPlugin.ShowControl(UserControlTypes.UnAvailable);
            _oldConnectionStatus = false;
            _checkConnectionTimer = new SimpleTimer();

            WriteRegisterKeys();
            
            var signalFolder = string.Format("{0}\\{1}", Utils.GetCurrentDirectory(),
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

            CheckFirstUpdate();

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
                #region EXAMPLE Show/Hide TaskBar
                ShowWindow(hWnd, 1);
                #endregion

#if (BARCODEEMU)
                if (_barCodeReaderEmuForm.InvokeRequired)
                    _barCodeReaderEmuForm.Invoke(new Action(() => { _barCodeReaderEmuForm.Close(); }));
                else _barCodeReaderEmuForm.Close();
#else
                barcodeReader.EnableScanner = false;
#endif
                _checkConnectionTimer.Stop();
                _mainEntry.FullStop();
            }
            catch (Exception ex)
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

                #region EXAMPLE Show/Hide TaskBar
                hWnd = FindWindow("HHTaskBar", "");
                ShowWindow(hWnd, 0);
                #endregion

#if (BARCODEEMU)
                if (_barCodeReaderEmuForm.InvokeRequired)
                    _barCodeReaderEmuForm.Invoke(new Action(() => { _barCodeReaderEmuForm.ShowDialog(); }));
                else _barCodeReaderEmuForm.ShowDialog();
#else
                barcodeReader.EnableScanner = true;
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
                #region EXAMPLE Keys/Barcode

                //if (this.InvokeRequired)
                //    this.Invoke(new Action(() =>
                //    {
                //        BarcodeReader.EnableScanner = true;
                //    }));

                #endregion
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
                #region EXAMPLE Keys/Barcode

                //if (this.InvokeRequired)
                //    this.Invoke(new Action(() =>
                //    {
                //        BarcodeReader.EnableScanner = false;
                //    }));

                #endregion
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
                    _mainEntry.Requests.RequireProductInfo(barCodeValue, currentLanguage, currentCurrency);
                    _mainEntry.ControlsPlugin.WaitControl.ShowControl();
                }

                Logger.Log.Debug("BarCodeEmuRead. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("BarcodeReader_OnRead.", ex);
            }
        }
#else
        /// <summary>
        /// Use for send product info require by readed barcode
        /// </summary>
        private void BarcodeReader_OnRead(object sender, Symbol.Barcode.ReaderData readerData)
        {
            Logger.Log.Debug("BarcodeReader_OnRead. Enter");

            try
            {
                string barCodeData = barcodeReader.ReaderData.Text;
                if (barCodeData != null)
                {
                    var currentLanguage = _mainEntry.Transfer.CurrentLanguage;
                    var currentCurrency = _mainEntry.Transfer.CurrentCurrency;
                    _mainEntry.Requests.RequireProductInfo(barCodeData, currentLanguage, currentCurrency);
                }

                Logger.Log.Debug("BarcodeReader_OnRead. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("BarcodeReader_OnRead.", ex);
            }
        }
#endif

        /// <summary>
        /// Use for write register keys
        /// </summary>
        private void WriteRegisterKeys()
        {
            Logger.Log.Debug("WriteRegisterKeys. Enter");

            #region EXAMPLE RegKeys for Keys

            var vmsBaseKeyString = @"SOFTWARE\Symbol\ProgrammableKeys\P1";
            RegistryKey vmsBaseKey = Registry.LocalMachine.OpenSubKey(vmsBaseKeyString, true);
            vmsBaseKey.SetValue("KeyCode", 0x0010, RegistryValueKind.DWord);

            vmsBaseKeyString = @"SOFTWARE\Symbol\ProgrammableKeys\P2";
            vmsBaseKey = Registry.LocalMachine.OpenSubKey(vmsBaseKeyString, true);
            vmsBaseKey.SetValue("KeyCode", 0x0035, RegistryValueKind.DWord);

            vmsBaseKeyString = @"SOFTWARE\Symbol\ProgrammableKeys\P3";
            vmsBaseKey = Registry.LocalMachine.OpenSubKey(vmsBaseKeyString, true);
            vmsBaseKey.SetValue("KeyCode", 0x0030, RegistryValueKind.DWord);

            vmsBaseKeyString = @"SOFTWARE\Symbol\ProgrammableKeys\P4";
            vmsBaseKey = Registry.LocalMachine.OpenSubKey(vmsBaseKeyString, true);
            vmsBaseKey.SetValue("KeyCode", 0x0040, RegistryValueKind.DWord);

            #endregion

            Logger.Log.Debug("WriteRegisterKeys. Exit");
        }

        /// <summary>
        /// Timer action for check signal of shutdown client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Logger.Log.Debug("timer1_Tick. Enter");

            var filePath = string.Format("{0}\\{1}\\{2}", Utils.GetCurrentDirectory(),
                BaseConstants.SignalFolderName, BaseConstants.SignalFileName);
            if (File.Exists(filePath))
            {
                ShutdownClient();
                Application.Exit();
            }

            Logger.Log.Debug("timer1_Tick. Exit");
        }

        #endregion
    }
}