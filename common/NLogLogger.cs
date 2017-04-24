using NLog;

namespace common
{
    /// <summary>
    /// NLog implementation of the common logger
    /// </summary>
    /// <seealso cref="common.ILogger" />
    class NLogLogger : ILogger
    {
        private Logger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Debugs level
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void Debug(string msg)
        {
            _logger.Debug(msg);
        }


        /// <summary>
        /// Info level
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void Info(string msg)
        {
            _logger.Info(msg);
        }
    }
}
