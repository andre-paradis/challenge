using NLog;

namespace common
{
    class NLogLogger : ILogger
    {
        private Logger _logger;

        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }

        public void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public void Info(string msg)
        {
            _logger.Info(msg);
        }
    }
}
