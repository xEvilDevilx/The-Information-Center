using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Config Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class ConfigRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var config = new Config()
                {
                    ConfigID = 1,
                    ConfigValue = "ENG",
                    TerminalID = "T001",
                    StoreID = "S001"
                };
                context.Config.Add(config);

                config = new Config()
                {
                    ConfigID = 1,
                    ConfigValue = "ENG",
                    TerminalID = "T002",
                    StoreID = "S001"
                };
                context.Config.Add(config);

                config = new Config()
                {
                    ConfigID = 1,
                    ConfigValue = "RUS",
                    TerminalID = "T001",
                    StoreID = "S002"
                };
                context.Config.Add(config);

                config = new Config()
                {
                    ConfigID = 2,
                    ConfigValue = "EUR",
                    TerminalID = "T001",
                    StoreID = "S001"
                };
                context.Config.Add(config);

                config = new Config()
                {
                    ConfigID = 2,
                    ConfigValue = "EUR",
                    TerminalID = "T002",
                    StoreID = "S001"
                };
                context.Config.Add(config);

                config = new Config()
                {
                    ConfigID = 2,
                    ConfigValue = "RUB",
                    TerminalID = "T001",
                    StoreID = "S002"
                };
                context.Config.Add(config);

                context.SaveChanges();
            }
        }
    }
}