using IC.EFDesignLib.Interfaces;
using System;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Product Price Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class ProductPriceRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var productPrice = new ProductPrice()
                {
                    DateBegin = DateTime.Now,
                    DateEnd = new DateTime(2117, 04, 18),
                    PriceValue = 199.99m,
                    ProductID = 1,
                    StoreID = "S001"
                };
                context.ProductPrice.Add(productPrice);

                productPrice = new ProductPrice()
                {
                    DateBegin = DateTime.Now,
                    DateEnd = new DateTime(2117, 04, 18),
                    PriceValue = 71.71m,
                    ProductID = 2,
                    StoreID = "S001"
                };
                context.ProductPrice.Add(productPrice);

                productPrice = new ProductPrice()
                {
                    DateBegin = DateTime.Now,
                    DateEnd = new DateTime(2117, 04, 18),
                    PriceValue = 56.87m,
                    ProductID = 3,
                    StoreID = "S001"
                };
                context.ProductPrice.Add(productPrice);

                productPrice = new ProductPrice()
                {
                    DateBegin = DateTime.Now,
                    DateEnd = new DateTime(2117, 04, 18),
                    PriceValue = 102500.00m,
                    ProductID = 4,
                    StoreID = "S002"
                };
                context.ProductPrice.Add(productPrice);

                productPrice = new ProductPrice()
                {
                    DateBegin = DateTime.Now,
                    DateEnd = new DateTime(2117, 04, 18),
                    PriceValue = 2995.00m,
                    ProductID = 5,
                    StoreID = "S002"
                };
                context.ProductPrice.Add(productPrice);

                productPrice = new ProductPrice()
                {
                    DateBegin = DateTime.Now,
                    DateEnd = new DateTime(2117, 04, 18),
                    PriceValue = 46490.00m,
                    ProductID = 6,
                    StoreID = "S002"
                };
                context.ProductPrice.Add(productPrice);

                context.SaveChanges();
            }
        }
    }
}