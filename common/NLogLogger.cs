using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
