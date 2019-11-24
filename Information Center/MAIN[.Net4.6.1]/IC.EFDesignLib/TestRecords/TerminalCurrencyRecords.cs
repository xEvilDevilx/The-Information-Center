using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Terminal Currency Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class TerminalCurrencyRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                #region S001 T001

                var terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "EUR",
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "USD",
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "RUB",
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);
                
                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "CNY",
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                #endregion

                #region S001 T002

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "EUR",
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "USD",
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "RUB",
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "CNY",
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                #endregion

                #region S002 T001

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "EUR",
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "USD",
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "RUB",
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                terminalCurrency = new TerminalCurrency()
                {
                    CurrencyCode = "CNY",
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.TerminalCurrency.Add(terminalCurrency);

                #endregion

                context.SaveChanges();
            }
        }
    }
}