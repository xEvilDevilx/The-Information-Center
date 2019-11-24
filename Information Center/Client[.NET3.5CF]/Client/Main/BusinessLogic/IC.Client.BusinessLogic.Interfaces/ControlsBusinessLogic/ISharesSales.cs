using IC.Client.DataLayer;

namespace IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic
{
    /// <summary>
    /// Presents Shares and Sales Business Logic interface
    /// 
    /// 2017/08/14 - Created, VTyagunov
    /// </summary>
    public interface ISharesSales : IControlBusinessLogic
    {
        /// <summary>
        /// Use for add AddSharesSalesData to collection
        /// </summary>
        /// <param name="sharesSalesData">Shares Sales Data object</param>
        void AddSharesSalesData(SharesSalesData sharesSalesData);

        /// <summary>
        /// Use for clear SharesSalesData collection
        /// </summary>
        void ClearSharesSalesData();
    }
}