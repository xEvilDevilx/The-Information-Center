using IC.EFDesignLib.Interfaces;
using System.IO;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Language Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class LanguageRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Language\3.png");
                var language = new Language()
                {
                    LanguageCode = "RUS",
                    CaptionID = 1,
                    Image = imageBytes
                };
                context.Language.Add(language);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Language\4.png");
                language = new Language()
                {
                    LanguageCode = "ENG",
                    CaptionID = 2,
                    Image = imageBytes
                };
                context.Language.Add(language);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Language\2.png");
                language = new Language()
                {
                    LanguageCode = "CN",
                    CaptionID = 3,
                    Image = imageBytes
                };
                context.Language.Add(language);

                context.SaveChanges();
            }
        }
    }
}