using IC.EFDesignLib.Interfaces;
using System.IO;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Currency Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class CurrencyRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Currency\3.png");
                var currency = new Currency()
                {
                    CurrencyCode = "RUB",
                    CaptionID = 4,
                    Image = imageBytes
                };
                context.Currency.Add(currency);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Currency\1.png");
                currency = new Currency()
                {
                    CurrencyCode = "USD",
                    CaptionID = 5,
                    Image = imageBytes
                };
                context.Currency.Add(currency);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Currency\2.png");
                currency = new Currency()
                {
                    CurrencyCode = "EUR",
                    CaptionID = 6,
                    Image = imageBytes
                };
                context.Currency.Add(currency);

                imageBytes = File.ReadAllBytes(
                    @"G:\DEVELOPMENT\Information Center\Docs\Test Data for ICDB\Currency\4.png");
                currency = new Currency()
                {
                    CurrencyCode = "CNY",
                    CaptionID = 7,
                    Image = imageBytes
                };
                context.Currency.Add(currency);

                context.SaveChanges();
            }
        }
    }
}