using NLog;

namespace common
{
    /// <summary>
    /// Logger factory that returns instance of nlog loggers
    /// </summary>
    /// <seealso cref="common.ILogProvider" />
    class NLogLogProvider : ILogProvider
    {
        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ILogger GetLogger(string name)
        {
            return new NLogLogger(LogManager.GetLogger(name));
        }
    }
}
