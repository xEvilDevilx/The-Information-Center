using IC.EFDesignLib.Interfaces;
using IC.EFDesignLib.TestRecords;
using System;

namespace IC.EFDesignLib
{
    static class Program
    {
        static void Main()
        {
            IRecords record = new AdvertisingRecords();
            //record.AddRecordsToDB();
            //record = new ConfigRecords();
            //record.AddRecordsToDB();
            //record = new ContentTranslationRecords();
            //record.AddRecordsToDB();
            //record = new CurrencyRecords();
            //record.AddRecordsToDB();
            //record = new LanguageRecords();
            //record.AddRecordsToDB();
            //record = new ProductActionRecords();
            //record.AddRecordsToDB();
            //record = new ProductPriceRecords();
            //record.AddRecordsToDB();
            //record = new ProductRecords();
            //record.AddRecordsToDB();
            //record = new RetailActionRecords();
            //record.AddRecordsToDB();
            //record = new StoreActionRecords();
            //record.AddRecordsToDB();
            //record = new StoreAdvertisingRecords();
            //record.AddRecordsToDB();
            record = new StoreRecords();
            record.AddRecordsToDB();
            //record = new SystemTranslationRecords();
            //record.AddRecordsToDB();
            //record = new TerminalCurrencyRecords();
            //record.AddRecordsToDB();
            //record = new TerminalLanguageRecords();
            //record.AddRecordsToDB();
            //record = new TerminalRecords();
            //record.AddRecordsToDB();

            Console.WriteLine("All done!");

            Console.ReadLine();
        }
    }
}