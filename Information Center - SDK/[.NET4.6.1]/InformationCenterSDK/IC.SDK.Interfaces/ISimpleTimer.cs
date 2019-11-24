using System;

namespace IC.SDK.Interfaces
{
    /// <summary>
    /// Custom simple timer interface
    /// 
    /// 2017/01/22 - Created, VTyagunov
    /// </summary>
    public interface ISimpleTimer
    {
        /// <summary>
        /// Use for start timer
        /// </summary>
        /// <param name="timeInterval">Time interval for timer</param>
        /// <param name="action">Action for timer</param>
        void Start(int timeInterval, Action action);

        /// <summary>
        /// Use for stop timer
        /// </summary>
        void Stop();
    }
}