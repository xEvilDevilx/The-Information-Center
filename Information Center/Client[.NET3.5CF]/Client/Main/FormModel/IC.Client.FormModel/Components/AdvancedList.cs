using System;
using System.Collections.Generic;
using System.Linq;

using IC.Client.DataLayer;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces.Components;
using IC.Client.FormModel.Interfaces.ControlModel;
using IC.SDK;

namespace IC.Client.FormModel.Components
{
    /// <summary>
    /// The Advanced List
    /// 
    /// 2017/07/03 - Created, VTyagunov
    /// </summary>
    public class AdvancedList : IAdvancedList
    {
        #region Variables

        /// <summary>Settings control</summary>
        private ISettingsControl _settingsControl;
        /// <summary>Collection of Items</summary>
        private List<AdvancedItem> _itemList;

        #endregion

        #region Properties

        /// <summary>Advanced List Type</summary>
        public AdvancedListTypes AdvancedListType { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="settingsControl">Settings Control</param>
        /// <param name="advancedListType">Advanced List Type</param>
        public AdvancedList(ISettingsControl settingsControl, AdvancedListTypes advancedListType)
        {
            Logger.Log.Debug("AdvancedList. Ctr. Enter");

            if (settingsControl == null)
                throw new NullReferenceException("settingsControl");

            AdvancedListType = advancedListType;
            _settingsControl = settingsControl;
            _itemList = new List<AdvancedItem>();            

            Logger.Log.Debug("AdvancedList. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add Item to Items Collection
        /// </summary>
        /// <param name="item">Advanced Item</param>
        public void AddItem(AdvancedItem item)
        {
            Logger.Log.Debug("AddItem. Enter");

            try
            {
                if (ListContains(item.Code))
                {
                    var itemID = GetItemID(item.Code);
                    if (itemID != -1)
                        _itemList.RemoveRange(itemID, 1);
                }
                _itemList.Add(item);
                SetItemsToAdvancedItems();

                Logger.Log.Debug("AddItem. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("AddItem", ex);
            }
        }

        /// <summary>
        /// Use for clear list
        /// </summary>
        public void ClearList()
        {
            Logger.Log.Debug("ClearList. Enter");

            try
            {
                if (_itemList.Count > 0)
                {
                    _itemList.Clear();
                    _settingsControl.ClearListItems(AdvancedListType);
                }
                Logger.Log.Debug("ClearList. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("ClearList", ex);
            }
        }

        /// <summary>
        /// Use for get current selected item
        /// </summary>
        /// <returns></returns>
        public AdvancedItem GetSelectedItem()
        {
            Logger.Log.Debug("GetSelectedItem. Enter/Exit");

            if (_itemList.Count > 0)
                return _itemList.First();
            else return null;
        }

        /// <summary>
        /// Set items to the Advanced items of Advanced List
        /// </summary>
        public void SetItemsToAdvancedItems()
        {
            Logger.Log.Debug("SetItemsToAdvancedItems. Enter");

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    if (_itemList.Count > i)
                    {
                        _settingsControl.SetItemToAdvancedItem(_itemList[i], i,
                            AdvancedListType);
                    }
                    else _settingsControl.SetEmptyItem(i, AdvancedListType);
                }

                CheckItemsCount();

                Logger.Log.Debug("SetItemsToAdvancedItems. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SetItemsToAdvancedItems", ex);
            }
        }

        /// <summary>
        /// Use for swap items in list
        /// </summary>
        private void SwapItemList()
        {
            Logger.Log.Debug("SwapItemList. Enter");

            try
            {
                if (_itemList.Count > 0)
                {
                    _itemList.Add(_itemList.First());
                    _itemList.RemoveAt(0);
                }

                Logger.Log.Debug("SwapItemList. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("SwapItemList", ex);
            }
        }

        /// <summary>
        /// Move items up
        /// </summary>
        public void MoveItems()
        {
            Logger.Log.Debug("MoveItems. Enter");

            try
            {
                SwapItemList();
                SetItemsToAdvancedItems();

                Logger.Log.Debug("MoveItems. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("MoveItems", ex);
            }
        }

        /// <summary>
        /// Use for check list for contains of itemCode
        /// </summary>
        /// <param name="itemCode">Item Code</param>
        /// <returns></returns>
        public bool ListContains(string itemCode)
        {
            Logger.Log.Debug("ListContains. Enter/Exit");

            foreach (AdvancedItem item in _itemList)
                if (item.Code == itemCode)
                    return true;

            return false;
        }

        /// <summary>
        /// Use for update item data in List
        /// </summary>
        /// <param name="item">Advanced Item</param>
        public void UpdateItemInList(AdvancedItem item)
        {
            Logger.Log.Debug("UpdateItemInList. Enter");

            try
            {
                var itemID = GetItemID(item.Code);
                _itemList[itemID].ItemName = item.ItemName;
                SetItemsToAdvancedItems();

                Logger.Log.Debug("UpdateItemInList. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("UpdateItemInList", ex);
            }
        }

        /// <summary>
        /// Use for check Items count
        /// </summary>
        public int CheckItemsCount()
        {
            Logger.Log.Debug("CheckItemsCount. Enter/Exit");

            if (_itemList.Count > 3)
                _settingsControl.SetLblMoreItemsVisibility(true, AdvancedListType);
            else _settingsControl.SetLblMoreItemsVisibility(false, AdvancedListType);

            return _itemList.Count;
        }

        /// <summary>
        /// Get List Item ID
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        private int GetItemID(string itemCode)
        {
            Logger.Log.Debug("GetItemID. Enter/Exit");

            for (int i = 0; i < _itemList.Count; i++)
                if (_itemList[i].Code == itemCode)
                    return i;

            return -1;
        }

        #endregion
    }
}