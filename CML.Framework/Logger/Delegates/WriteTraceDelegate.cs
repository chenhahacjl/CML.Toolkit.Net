using System.Runtime.CompilerServices;

namespace CML.Toolkit.Logger
{
    /// <summary>
    /// 记录跟踪信息委托
    /// </summary>
    /// <param name="logLevel">日志等级</param>
    /// <param name="message">信息内容</param>
    /// <param name="callerFilePath">调用文件路径</param>
    /// <param name="callerLineNumber">调用文件行数</param>
    /// <param name="callerMemberName">调用方法名称</param>
    public delegate void WriteTraceDelegate(
        LogLevel logLevel,
        string message,
        [CallerFilePath] string callerFilePath = "",
        [CallerLineNumber] int callerLineNumber = 0,
        [CallerMemberName] string callerMemberName = ""
    );
}
