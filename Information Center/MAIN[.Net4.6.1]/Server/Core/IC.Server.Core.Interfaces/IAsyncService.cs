namespace IC.Server.Core.Interfaces
{
    /// <summary>
    /// Presents Async work
    /// 
    /// 2016/12/11 - Created, VTyagunov
    /// </summary>
    public interface IAsyncService
    {
        /// <summary>
        /// Use for async start work
        /// </summary>
        void RunAsync();

        /// <summary>
        /// Use for stop work
        /// </summary>
        void Stop();
    }
}