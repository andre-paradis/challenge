using NLog;

namespace common
{
    class NLogLogProvider : ILogProvider
    {
        public ILogger GetLogger(string name)
        {
            return new NLogLogger(LogManager.GetLogger(name));
        }
    }
}
