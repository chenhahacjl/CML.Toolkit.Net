namespace CML.Framework.Logger
{
    /// <summary>
    /// 记录异常信息委托
    /// </summary>
    /// <param name="logLevel">日志等级</param>
    /// <param name="model">模块名称</param>
    /// <param name="function">方法名称</param>
    /// <param name="exception">错误对象</param>
    public delegate void WriteExceptionDelegate(
        LogLevel logLevel,
        string model,
        string function,
        Exception exception
    );
}
