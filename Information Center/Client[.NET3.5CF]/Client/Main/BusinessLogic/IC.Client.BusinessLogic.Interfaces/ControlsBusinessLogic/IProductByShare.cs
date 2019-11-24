using IC.Client.DataLayer;

namespace IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic
{
    /// <summary>
    /// Presents Product By Share business logic interface
    /// 
    /// 2018/08/14 - Created, VTyagunov
    /// </summary>
    public interface IProductByShare : IControlBusinessLogic
    {
        /// <summary>
        /// Use for set data to ProductByShare control
        /// </summary>
        /// <param name="productInfoData">Product Info Data object</param>
        void SetProductByShareData(ProductInfoData productInfoData);
    }
}