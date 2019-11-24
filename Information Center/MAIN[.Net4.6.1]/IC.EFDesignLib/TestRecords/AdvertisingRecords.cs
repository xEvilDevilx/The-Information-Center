using IC.EFDesignLib.Interfaces;
using System.IO;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Advertising Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class AdvertisingRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                //var imageBytes = File.ReadAllBytes(
                //    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Advertising\1.png");
                //var ad = new Advertising()
                //{
                //    AdvertisingID = 1,
                //    Image = imageBytes,
                //    ActivityStatus = 1
                //};
                //context.Advertising.Add(ad);

                var imageBytes = File.ReadAllBytes(
                    //@"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Advertising\2.png");
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Advertising\3.png");
                var ad = new Advertising()
                {
                    AdvertisingID = 2,
                    Image = imageBytes,
                    AccessStatus = 1
                };
                context.Advertising.Add(ad);
                
                context.SaveChanges();
            }
        }
    }
}