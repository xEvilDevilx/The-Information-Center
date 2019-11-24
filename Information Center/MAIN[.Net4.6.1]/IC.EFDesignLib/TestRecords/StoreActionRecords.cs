using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Store Action Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class StoreActionRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var storeAction = new StoreAction()
                {                    
                    RetailActionID = 4,
                    StoreID = "S001"
                };
                context.StoreAction.Add(storeAction);

                storeAction = new StoreAction()
                {
                    RetailActionID = 5,
                    StoreID = "S001"
                };
                context.StoreAction.Add(storeAction);

                storeAction = new StoreAction()
                {
                    RetailActionID = 6,
                    StoreID = "S002"
                };
                context.StoreAction.Add(storeAction);

                context.SaveChanges();
            }
        }
    }
}