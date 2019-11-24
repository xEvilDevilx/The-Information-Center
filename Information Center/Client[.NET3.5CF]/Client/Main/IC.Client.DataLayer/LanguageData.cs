namespace IC.Client.DataLayer
{
    /// <summary>
    /// Presents Language Data
    /// 
    /// 2016/12/11 - created VTyagunov
    /// </summary>
    public class LanguageData
    {
        /// <summary>Language text name</summary>
        public string LanguageText { get; set; }
        /// <summary>Language picture bytes array</summary>
        public byte[] LanguagePicture { get; set; }
        /// <summary>Language code</summary>
        public string LanguageCode { get; set; }
    }
}