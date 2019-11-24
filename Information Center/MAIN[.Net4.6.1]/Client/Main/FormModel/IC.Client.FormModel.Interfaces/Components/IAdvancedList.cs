using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;

namespace IC.Client.FormModel.Interfaces.Components
{
    /// <summary>
    /// The Advanced List
    /// 
    /// 2017/08/15 - Created, VTyagunov
    /// </summary>
    public interface IAdvancedList
    {
        /// <summary>Advanced List Type</summary>
        AdvancedListTypes AdvancedListType { get; set; }

        /// <summary>
        /// Add Item to Items Collection
        /// </summary>
        /// <param name="item">Advanced Item</param>
        void AddItem(AdvancedItem item);

        /// <summary>
        /// Use for clear list
        /// </summary>
        void ClearList();

        /// <summary>
        /// Use for get current selected item
        /// </summary>
        /// <returns></returns>
        AdvancedItem GetSelectedItem();

        /// <summary>
        /// Set items to the Advanced items of Advanced List
        /// </summary>
        void SetItemsToAdvancedItems();

        /// <summary>
        /// Move items up
        /// </summary>
        void MoveItems();

        /// <summary>
        /// Use for check list for contains of itemCode
        /// </summary>
        /// <param name="itemCode">Item Code</param>
        /// <returns></returns>
        bool ListContains(string itemCode);

        /// <summary>
        /// Use for update item data in List
        /// </summary>
        /// <param name="item">Advanced Item</param>
        void UpdateItemInList(AdvancedItem item);

        /// <summary>
        /// Use for check Items count
        /// </summary>
        int CheckItemsCount();
    }
}