using IC.Client.DataLayer;

namespace IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic
{
    /// <summary>
    /// Presents Product Info Business Logic interface
    /// 
    /// 2017/08/14 - Created, VTyagunov
    /// </summary>
    public interface IProductInfo : IControlBusinessLogic
    {
        /// <summary>
        /// Use for set ProductInfo data to control
        /// </summary>
        /// <param name="advertisingData">ProductInfo Data object</param>
        void Set(ProductInfoData productInfoData);

        /// <summary>
        /// Use for get last bar code
        /// </summary>
        /// <returns></returns>
        string GetLastBarCode();
    }
}