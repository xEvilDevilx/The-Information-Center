using IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic;
using IC.Client.FormModel.Base.Enums;

namespace IC.Client.BusinessLogic.Interfaces
{
    /// <summary>
    /// Presents Business logic Entry interface
    /// 
    /// 2017/08/15 - Created, VTyagunov
    /// </summary>
    public interface IBusinessLogicEntry
    {
        /// <summary>Presents Advertising business logic</summary>
        IAdvertising Advertising { get; }
        /// <summary>Presents Product By Share business logic</summary>
        IProductByShare ProductByShare { get; }
        /// <summary>Presents Product Info business logic</summary>
        IProductInfo ProductInfo { get; }
        /// <summary>Presents Product Not Found business logic</summary>
        IProductNotFound ProductNotFound { get; }
        /// <summary>Presents Scan business logic</summary>
        IScan Scan { get; }
        /// <summary>Presents Settings business logic</summary>
        ISettings Settings { get; }
        /// <summary>Presents Shares and Sales business logic</summary>
        ISharesSales SharesSales { get; }
        /// <summary>Presents System Manager business logic</summary>
        ISystemManager SystemManager { get; }

        /// <summary>
        /// Use for show asigned control
        /// </summary>
        /// <param name="control">IControl object</param>
        void ShowControl(UserControlTypes controlType);

        /// <summary>
        /// Use for hide all controls
        /// </summary>
        void HideAllControls();

        /// <summary>
        /// Use for Show Last Control
        /// </summary>
        void ShowLastControl();
    }
}