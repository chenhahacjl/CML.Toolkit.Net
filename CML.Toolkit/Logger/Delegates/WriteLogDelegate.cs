namespace CML.Toolkit.Logger
{
    /// <summary>
    /// 记录日志信息委托
    /// </summary>
    /// <param name="logLevel">日志等级</param>
    /// <param name="model">模块名称</param>
    /// <param name="function">方法名称</param>
    /// <param name="message">日志内容</param>
    public delegate void WriteLogDelegate(
        LogLevel logLevel,
        string model,
        string function,
        string message
    );
}
