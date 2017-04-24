namespace common
{
    /// <summary>
    /// Returns an instance of a named logger
    /// </summary>
    public interface ILogProvider
    {
        /// <summary>
        /// Given a name, returns an instance of a logger
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns></returns>
        ILogger GetLogger(string loggerName);
    }
}
