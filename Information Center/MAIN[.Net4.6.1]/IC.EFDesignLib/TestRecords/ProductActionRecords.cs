using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Product Action Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class ProductActionRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var productAction = new ProductAction()
                {
                    ProductID = 1,
                    RetailActionID = 1,
                    StoreID = "S001"
                };
                context.ProductAction.Add(productAction);

                productAction = new ProductAction()
                {
                    ProductID = 2,
                    RetailActionID = 2,
                    StoreID = "S001"
                };
                context.ProductAction.Add(productAction);

                productAction = new ProductAction()
                {
                    ProductID = 4,
                    RetailActionID = 3,
                    StoreID = "S002"
                };
                context.ProductAction.Add(productAction);

                context.SaveChanges();
            }
        }
    }
}