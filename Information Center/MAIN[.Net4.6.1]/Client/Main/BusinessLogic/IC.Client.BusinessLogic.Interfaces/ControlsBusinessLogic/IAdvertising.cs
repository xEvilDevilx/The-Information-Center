using System.Collections.Generic;

using IC.Client.DataLayer;

namespace IC.Client.BusinessLogic.Interfaces.ControlsBusinessLogic
{
    /// <summary>
    /// Presents Advertising business logic interface
    /// 
    /// 2018/08/14 - Created, VTyagunov
    /// </summary>
    public interface IAdvertising : IControlBusinessLogic
    {
        /// <summary>Image bytes array list</summary>
        List<byte[]> AdvertisingImageList { get; set; }

        /// <summary>
        /// Use for set advertising to ad image list
        /// </summary>
        /// <param name="advertisingData">Advertising Data object</param>
        void Set(AdvertisingData advertisingData);
    }
}