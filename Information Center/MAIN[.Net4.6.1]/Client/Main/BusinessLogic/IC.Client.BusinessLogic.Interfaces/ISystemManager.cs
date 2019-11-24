using IC.Client.DataLayer;

namespace IC.Client.BusinessLogic.Interfaces
{
    /// <summary>
    /// Presents System Manager interface for manage system data(Logotypes, localizations, etc)
    /// 
    /// 2017/08/15 - Created, VTyagunov
    /// </summary>
    public interface ISystemManager
    {
        /// <summary>
        /// Use for localize all system controls
        /// </summary>
        /// <param name="systemTranslationData">System Translation Data object</param>
        bool LocalizeControls(SystemTranslationData systemTranslationData);

        /// <summary>
        /// Use for set logo to all system controls
        /// </summary>
        /// <param name="logoData">Logo Data object</param>
        bool SetLogoToControls(LogoData logoData);
    }
}