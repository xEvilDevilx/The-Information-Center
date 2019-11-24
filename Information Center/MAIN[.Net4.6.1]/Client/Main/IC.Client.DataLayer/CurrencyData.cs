namespace IC.Client.DataLayer
{
    /// <summary>
    /// Presents Currency Data
    /// 
    /// 2016/12/11 - Created, VTyagunov
    /// </summary>
    public class CurrencyData
    {
        /// <summary>Currency text name</summary>
        public string CurrencyText { get; set; }
        /// <summary>Currency picture bytes array</summary>
        public byte[] CurrencyPicture { get; set; }
        /// <summary>Currency code</summary>
        public string CurrencyCode { get; set; }
    }
}