namespace common
{
    public interface ILogProvider
    {
        ILogger GetLogger(string loggerName);
    }
}
