namespace IC.Client.DataLayer
{
    /// <summary>
    /// Presents Product Info data
    /// 
    /// 2016/12/11 - created VTyagunov
    /// </summary>
    public class ProductInfoData
    {
        /// <summary>Vendor Code text</summary>
        public string TextBoxVendorCode { get; set; }
        /// <summary>BarCode text</summary>
        public string TextBoxBarCode { get; set; }
        /// <summary>Product Name</summary>
        public string TextBoxProductName { get; set; }
        /// <summary>Product Price value</summary>
        public string TextBoxPrice { get; set; }
        /// <summary>Product Info text</summary>
        public string TextBoxProductInfo { get; set; }
        /// <summary>Product Image bytes array</summary>
        public byte[] PictureBoxProductImage { get; set; }
        /// <summary>Product Shares Names</summary>
        public string ProductSharesNames { get; set; }
        /// <summary>Product Shares Desriptions</summary>
        public string ProductSharesDesriptions { get; set; }
    }
}