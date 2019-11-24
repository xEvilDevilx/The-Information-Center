using IC.EFDesignLib.Interfaces;

namespace IC.EFDesignLib.TestRecords
{
    /// <summary>
    /// Presents Terminal Test Records
    /// 
    /// 2017/04/18 - created VTyagunov
    /// </summary>
    class TerminalRecords : IRecords
    {
        /// <summary>
        /// Use for Add Records to database
        /// </summary>
        public void AddRecordsToDB()
        {
            using (var context = new ICDBContext())
            {
                var terminal = new Terminal()
                {
                    ActivityStatus = 0,
                    IPAddress = "127.0.0.1",
                    MacAddress = "0F0FAFAF",
                    StoreID = "S001",
                    TerminalID = "T001",
                    TerminalUID = "11f48831-02ac-485c-9010-b659fbdb36fa",
                    TerminalVersion = "1.0.0.0"
                };
                context.Terminal.Add(terminal);

                terminal = new Terminal()
                {
                    ActivityStatus = 0,
                    IPAddress = "127.0.0.2",
                    MacAddress = "1F1FBFBF",
                    StoreID = "S001",
                    TerminalID = "T002",
                    TerminalUID = "96b560da-db4e-4f20-b858-ed1bb67efeff",
                    TerminalVersion = "1.0.0.0"
                };
                context.Terminal.Add(terminal);

                terminal = new Terminal()
                {
                    ActivityStatus = 0,
                    IPAddress = "127.0.0.3",
                    MacAddress = "2F2FCFCF",
                    StoreID = "S002",
                    TerminalID = "T001",
                    TerminalUID = "f448707e-8e12-4ffe-966b-5ecd37c97d2d",
                    TerminalVersion = "1.0.0.0"
                };
                context.Terminal.Add(terminal);

                context.SaveChanges();
            }
        }
    }
}