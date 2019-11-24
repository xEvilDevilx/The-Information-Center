using System;
using System.Drawing;

namespace IC.Client.DataLayer
{
    /// <summary>
    /// Presents AdvancedItem data object
    /// 
    /// 2017/02/25 - Created, VTyagunov
    /// </summary>
    [Serializable]
    public class AdvancedItem
    {
        /// <summary>item Code string</summary>
        public string Code { get; set; }
        /// <summary>Item Name string</summary>
        public string ItemName { get; set; }
        /// <summary>Item Image</summary>
        public Image ItemImage { get; set; }
    }
}