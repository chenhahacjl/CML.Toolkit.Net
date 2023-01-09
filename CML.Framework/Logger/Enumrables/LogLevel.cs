namespace CML.Framework.Logger
{
    /// <summary>
    /// 日志等级
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 不记录日志
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 致命等级
        /// </summary>
        FATAL,
        /// <summary>
        /// 错误等级
        /// </summary>
        ERROR,
        /// <summary>
        /// 警告等级
        /// </summary>
        WARN,
        /// <summary>
        /// 信息等级
        /// </summary>
        INFO,
        /// <summary>
        /// 调试等级
        /// </summary>
        DEBUG
    }
}
