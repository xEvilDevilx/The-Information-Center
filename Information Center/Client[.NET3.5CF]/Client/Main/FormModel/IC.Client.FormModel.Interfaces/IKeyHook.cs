using IC.Client.FormModel.Base;
namespace IC.Client.FormModel.Interfaces
{
    /// <summary>
    /// Presents Jey Hook interface
    /// 
    /// 2017/08/24 - Created, VTyagunov
    /// </summary>
    public interface IKeyHook
    {
        /// <summary>Hook Event</summary>
        HardwareDelegates.HookEventHandler HookEvent { get; set; }
        /// <summary>Flag shows is handled or non-handled the Key</summary>
        bool KeyHandled { get; set; }

        /// <summary>
        /// Use for Start the hook
        /// </summary>
        void Start();

        /// <summary>
        /// Use for Stop the Hook
        /// </summary>
        void Stop();
    }
}