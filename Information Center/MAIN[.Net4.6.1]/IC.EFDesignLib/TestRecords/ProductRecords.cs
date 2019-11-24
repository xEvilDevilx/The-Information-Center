using IC.EFDesignLib.Interfaces;
using System.IO;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Product Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class ProductRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Products\StoreID S001\Amouage Honour for woman\1.png");
                var product = new Product()
                {
                    ActivityStatus = 1,
                    Article = "45IC65",
                    BarcodeValue = "IC215716 812319",
                    CaptionID = 1001,
                    DescriptionID = 2001,
                    Image = imageBytes,
                    ProductID = 1
                };
                context.Product.Add(product);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Products\StoreID S001\Woman 50 ml Hugo Boss\1.png");
                product = new Product()
                {
                    ActivityStatus = 1,
                    Article = "66IC55",
                    BarcodeValue = "IC754873 186442",
                    CaptionID = 1002,
                    DescriptionID = 2002,
                    Image = imageBytes,
                    ProductID = 2
                };
                context.Product.Add(product);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Products\StoreID S001\MAN in RED 50 ml Ferrari Cavallino\1.png");
                product = new Product()
                {
                    ActivityStatus = 1,
                    Article = "12IC32",
                    BarcodeValue = "IC448522 234987",
                    CaptionID = 1003,
                    DescriptionID = 2003,
                    Image = imageBytes,
                    ProductID = 3
                };
                context.Product.Add(product);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Products\StoreID S002\MSI Aegis-075RU, Black\1.png");
                product = new Product()
                {
                    ActivityStatus = 1,
                    Article = "42IC78",
                    BarcodeValue = "IC645746 732889",
                    CaptionID = 1004,
                    DescriptionID = 2004,
                    Image = imageBytes,
                    ProductID = 4
                };
                context.Product.Add(product);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Products\StoreID S002\Redmond RK-G127\1.png");
                product = new Product()
                {
                    ActivityStatus = 1,
                    Article = "77IC19",
                    BarcodeValue = "IC464246 499812",
                    CaptionID = 1005,
                    DescriptionID = 2005,
                    Image = imageBytes,
                    ProductID = 5
                };
                context.Product.Add(product);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Products\StoreID S002\SAMSUNG UE50KU6000UXRU\1.png");
                product = new Product()
                {
                    ActivityStatus = 1,
                    Article = "62IC53",
                    BarcodeValue = "IC001035 900075",
                    CaptionID = 1006,
                    DescriptionID = 2006,
                    Image = imageBytes,
                    ProductID = 6
                };
                context.Product.Add(product);

                context.SaveChanges();
            }
        }
    }
}