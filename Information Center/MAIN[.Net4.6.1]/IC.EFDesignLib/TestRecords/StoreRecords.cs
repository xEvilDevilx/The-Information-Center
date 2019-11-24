using IC.EFDesignLib.Interfaces;
using System.IO;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Store Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class StoreRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                //var imageBytes = File.ReadAllBytes(
                //    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Store\StoreID S001\1.png");
                //var store = new Store()
                //{
                //    CaptionID = 10001,
                //    Image = imageBytes,
                //    StoreID = "S001"
                //};
                //context.Store.Add(store);

                var imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Advertising\3.png");
                var store = new Store()
                {
                    CaptionID = 10003,
                    Image = imageBytes,
                    StoreID = "S003"
                };
                context.Store.Add(store);

                //imageBytes = File.ReadAllBytes(
                //    //@"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Store\StoreID S002\1.png");
                //    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\TestStoreImage.png");
                //store = new Store()
                //{
                //    CaptionID = 10002,
                //    Image = imageBytes,
                //    StoreID = "S002"
                //};
                //context.Store.Add(store);

                context.SaveChanges();
            }
        }
    }
}