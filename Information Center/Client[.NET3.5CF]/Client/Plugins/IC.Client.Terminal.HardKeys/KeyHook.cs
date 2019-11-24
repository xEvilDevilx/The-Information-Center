using System;
using System.Runtime.InteropServices;

using IC.Client.BusinessLogic.Interfaces;
using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.SDK;

namespace IC.Client.Plugins.Terminal.HardKeys
{
    /// <summary>
    /// Implements Key Hook Manage
    /// 
    /// 2017/08/10 - Created, VTyagunov
    /// </summary>
    [HardwareType(HardwareTypes.Keys)]
    public class KeyHook : IKeyHook
    {
        #region Invoke Declarations

        [DllImport("coredll.dll")]
        private static extern int AllKeys(bool bEnable);
        [DllImport("coredll.dll")]
        private static extern int SetWindowsHookEx(int type, HardwareDelegates.HookProc hookProc, IntPtr hInstance, int m);
        [DllImport("coredll.dll")]
        private static extern IntPtr GetModuleHandle(string mod);
        [DllImport("coredll.dll")]
        private static extern int CallNextHookEx(HardwareDelegates.HookProc hhk, int nCode, IntPtr wParam,
            IntPtr lParam);
        [DllImport("coredll.dll", SetLastError = true)]
        private static extern int UnhookWindowsHookEx(int idHook);

        #endregion

        #region Variables

        /// <summary>Hook Event Action</summary>
        private HardwareDelegates.HookProc _hookEventAction;
        /// <summary>HHOOK result of SetWindowsHookEx function</summary>
        private int _hHook;
        /// <summary>Key Up Block</summary>
        private int _keyUpBlock;
        /// <summary>Key Press Second Time</summary>
        private bool _keyPressSecondTime;
        /// <summary>WH_KEYBOARD_LL constant</summary>
        private const int WH_KEYBOARD_LL = 20;

        #endregion

        #region Properties

        /// <summary>Hook Event</summary>
        public HardwareDelegates.HookEventHandler HookEvent { get; set; }
        /// <summary>Flag shows is handled or non-handled the Key</summary>
        public bool KeyHandled { get; set; }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Constructor
        /// </summary>
        public KeyHook()
        {
            Logger.Log.Debug("KeyHook. Ctr. Enter");

            _hHook = 0;
            _keyUpBlock = 0;
            _keyPressSecondTime = true;

            Logger.Log.Debug("KeyHook. Ctr. Exit");
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~KeyHook()
        {
            Logger.Log.Debug("KeyHook. Dtr. Enter");

            if (_hHook != 0)
                this.Stop();

            Logger.Log.Debug("KeyHook. Dtr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for Start the hook
        /// </summary>
        public void Start()
        {
            Logger.Log.Debug("Start. Enter");

            if (_hHook != 0)
                this.Stop();

            _hookEventAction = new HardwareDelegates.HookProc(HookProcedure);
            _hHook = SetWindowsHookEx(WH_KEYBOARD_LL, _hookEventAction, GetModuleHandle(null), 0);

            if (_hHook == 0)
                throw new SystemException("Failed acquiring of the hook.");

            AllKeys(true);

            Logger.Log.Debug("Start. Exit");
        }

        /// <summary>
        /// Use for Stop the Hook
        /// </summary>
        public void Stop()
        {
            Logger.Log.Debug("Stop. Enter");

            if (_hHook != 0)
            {
                _keyUpBlock = 0;
                UnhookWindowsHookEx(_hHook);
                AllKeys(false);
            }

            Logger.Log.Debug("Stop. Exit");
        }

        /// <summary>
        /// OnHookEvent action
        /// </summary>
        /// <param name="hookArgs">Hook Event Args</param>
        /// <param name="keyBoardInfo">Key Board Info</param>
        protected virtual void OnHookEvent(HookEventArgs hookArgs, KeyBoardInfo keyBoardInfo)
        {
            Logger.Log.Debug("OnHookEvent. Enter");

            int keyUpBlockOld = _keyUpBlock;
            _keyUpBlock = keyBoardInfo.scanCode;

            if ((_keyUpBlock != keyUpBlockOld) || ((_keyUpBlock == keyUpBlockOld) && 
                (_keyPressSecondTime)))
            {
                _keyPressSecondTime = false;
                if (HookEvent != null)
                {
                    KeyHandled = false;
                    Logger.Log.DebugFormat("+++++++++++++++OnHookEvent. {0}++++++++++++++++", 
                        KeyHandled.ToString());
                    HookEvent(keyBoardInfo.scanCode);
                }
            }
            else _keyPressSecondTime = true;

            Logger.Log.Debug("OnHookEvent. Exit");
        }

        /// <summary>
        /// Use for Hook Procedure action
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="wParam">W Param</param>
        /// <param name="lParam">L Param</param>
        /// <returns></returns>
        private int HookProcedure(int code, IntPtr wParam, IntPtr lParam)
        {
            Logger.Log.Debug("HookProcedure. Enter");

            var hookStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
            
            if ((code >= 0) && (hookStruct.flags < 0x80))
            {
                HookEventArgs e = new HookEventArgs();
                e.Code = code;
                e.wParam = wParam;
                e.lParam = lParam;
                KeyBoardInfo keyInfo = new KeyBoardInfo();
                keyInfo.vkCode = hookStruct.vkCode;
                keyInfo.scanCode = hookStruct.scanCode;
                OnHookEvent(e, keyInfo);
            }

            int callNextHookExResult = CallNextHookEx(_hookEventAction, code, wParam, lParam);

            Logger.Log.Debug("HookProcedure. Exit");
            return callNextHookExResult;
        }

        #endregion
    }
}