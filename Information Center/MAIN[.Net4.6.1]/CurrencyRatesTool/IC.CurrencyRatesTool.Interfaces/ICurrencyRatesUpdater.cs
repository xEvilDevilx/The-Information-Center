namespace IC.CurrencyRatesTool.Interfaces
{
    /// <summary>
    /// Implements Currency Rates Updater work
    /// 
    /// 2017/04/17 - Created, VTyagunov
    /// </summary>
    public interface ICurrencyRatesUpdater
    {
        /// <summary>
        /// Use for Start Updater
        /// </summary>
        void StartUpdater();

        /// <summary>
        /// Use for Stop Updater
        /// </summary>
        void StopUpdater();

        /// <summary>
        /// Use for Update Currency Rates
        /// </summary>
        void Update();
    }
}