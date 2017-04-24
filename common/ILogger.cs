namespace common
{
    /// <summary>
    /// Main logger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Debugs level
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Debug(string msg);

        /// <summary>
        /// Info level
        /// </summary>
        /// <param name="msg">The MSG.</param>
        void Info(string msg);
    }
}
