using System.Drawing;

using IC.Client.DataLayer;
using IC.Client.FormModel.Interfaces.ControlModel.Base;

namespace IC.Client.FormModel.Interfaces.ControlModel
{
    /// <summary>
    /// Presents ProductNotFoundControl interface
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    public interface IProductNotFoundControl : IControl
    {
        /// <summary>
        /// Use for set system data of control
        /// </summary>
        /// <param name="systemTranslationData">System Translation Data object</param>
        void Localize(SystemTranslationData systemTranslationData);

        /// <summary>
        /// Use for set image to Logo
        /// </summary>
        /// <param name="image">Image object</param>
        void SetLogoImage(Image image);
    }
}