using System;
using System.Threading;

using IC.SDK.Interfaces;

namespace IC.SDK
{
    /// <summary>
    /// Custom simple timer
    /// 
    /// 2017/01/22 - Created, VTyagunov
    /// </summary>
    public class SimpleTimer : ISimpleTimer
    {
        #region Variables

        /// <summary>Stop signal for timer</summary>
        private bool _isStop = false;

        #endregion

        #region Methods

        /// <summary>
        /// Use for start timer
        /// </summary>
        /// <param name="timeInterval">Time interval for timer</param>
        /// <param name="action">Action for timer</param>
        public void Start(int timeInterval, Action action)
        {
            Logger.Log.Debug("Start. Enter");

            _isStop = false;
            var checkTime = DateTime.Now;
            var updateRequestTime = DateTime.Now;
            var currentTime = DateTime.Now;

            while (!_isStop)
            {
                currentTime = DateTime.Now;
                var elapsedTicks = currentTime.Ticks - checkTime.Ticks;
                var elapsedSpan = new TimeSpan(elapsedTicks);
                var secondsNow = elapsedSpan.TotalSeconds;
                if (secondsNow >= timeInterval)
                {
                    action.Invoke();
                    checkTime = currentTime;
                }
                Thread.Sleep(100);
            }

            Logger.Log.Debug("Start. Exit");
        }
        
        /// <summary>
        /// Use for stop timer
        /// </summary>
        public void Stop()
        {
            Logger.Log.Debug("Stop. Enter");

            _isStop = true;

            Logger.Log.Debug("Stop. Exit");
        }

        #endregion
    }
}