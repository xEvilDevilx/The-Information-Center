using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Store Advertising Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class StoreAdvertisingRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var storeAdvertising = new StoreAdvertising()
                {
                    AdvertisingID = 1,
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.StoreAdvertising.Add(storeAdvertising);

                storeAdvertising = new StoreAdvertising()
                {
                    AdvertisingID = 2,
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.StoreAdvertising.Add(storeAdvertising);

                storeAdvertising = new StoreAdvertising()
                {
                    AdvertisingID = 1,
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.StoreAdvertising.Add(storeAdvertising);

                storeAdvertising = new StoreAdvertising()
                {
                    AdvertisingID = 2,
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.StoreAdvertising.Add(storeAdvertising);

                storeAdvertising = new StoreAdvertising()
                {
                    AdvertisingID = 1,
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.StoreAdvertising.Add(storeAdvertising);

                storeAdvertising = new StoreAdvertising()
                {
                    AdvertisingID = 2,
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.StoreAdvertising.Add(storeAdvertising);

                context.SaveChanges();
            }
        }
    }
}