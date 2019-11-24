using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Terminal Language Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class TerminalLanguageRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                #region S001 T001

                var terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "ENG",
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "RUS",
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "CN",
                    StoreID = "S001",
                    TerminalID = "T001"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                #endregion

                #region S001 T002

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "ENG",
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "RUS",
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "CN",
                    StoreID = "S001",
                    TerminalID = "T002"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                #endregion

                #region S002 T001

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "ENG",
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "RUS",
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.TerminalLanguage.Add(terminalLanguage);

                terminalLanguage = new TerminalLanguage()
                {
                    LanguageCode = "CN",
                    StoreID = "S002",
                    TerminalID = "T001"
                };
                context.TerminalLanguage.Add(terminalLanguage);
                
                #endregion

                context.SaveChanges();
            }
        }
    }
}