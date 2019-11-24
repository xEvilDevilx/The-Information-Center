using IC.Client.FormModel.Interfaces;

namespace IC.Client.BusinessLogic.Interfaces
{
    /// <summary>
    /// Presents Hardware Manager interface
    /// 
    /// 2017/08/24 - Created, VTyagunov
    /// </summary>
    public interface IHardwareManager
    {
        /// <summary>Key Hook functionality</summary>
        IKeyHook KeyHook { get; }
    }
}