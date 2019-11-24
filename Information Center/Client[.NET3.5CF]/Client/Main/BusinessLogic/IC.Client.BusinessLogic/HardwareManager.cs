using IC.Client.BusinessLogic.Interfaces;
using IC.Client.FormModel.Interfaces;
using IC.SDK;

namespace IC.Client.BusinessLogic
{
    /// <summary>
    /// Implements Hardware Manager functionality
    /// 
    /// 2017/02/24 - created VTyagunov
    /// </summary>
    public class HardwareManager : IHardwareManager
    {
        #region Properties

        /// <summary>Key Hook functionality</summary>
        public IKeyHook KeyHook { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pluginManager">Plugin Manager object</param>
        public HardwareManager(IPluginManager pluginManager)
        {
            Logger.Log.Debug("HardwareManager. Ctr. Enter");

            if(pluginManager.KeyHook != null)
                KeyHook = pluginManager.KeyHook;

            Logger.Log.Debug("HardwareManager. Ctr. Exit");
        }

        #endregion
    }
}