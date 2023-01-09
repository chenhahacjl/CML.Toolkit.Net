using System.Runtime.CompilerServices;

namespace CML.Toolkit.Logger
{
    /// <summary>
    /// 日志记录器接口
    /// </summary>
    public interface ILogger
    {
        #region 公共属性

        /// <summary>
        /// 输出到控制台
        /// </summary>
        bool WriteToConsole { get; set; }

        /// <summary>
        /// 记录日志等级
        /// </summary>
        LogLevel WriteLogLevel { get; set; }

        #endregion

        #region 公共事件

        /// <summary> 
        /// 记录跟踪信息事件
        /// </summary>
        event WriteTraceDelegate WriteTraceEvent;

        /// <summary>
        /// 记录日志信息事件
        /// </summary>
        event WriteLogDelegate WriteLogEvent;

        /// <summary>
        /// 记录异常信息事件
        /// </summary>
        event WriteExceptionDelegate WriteExceptionEvent;

        #endregion

        #region 记录日志信息方法

        /// <summary>
        /// 记录调试日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        void DebugLog(string model, string function, string message);

        /// <summary>
        /// 记录一般日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        void InfoLog(string model, string function, string message);

        /// <summary>
        /// 记录警告日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        void WarnLog(string model, string function, string message);

        /// <summary>
        /// 记录错误日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        void ErrorLog(string model, string function, string message);

        /// <summary>
        /// 记录致命日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        void FatalLog(string model, string function, string message);

        #endregion

        #region 记录异常信息方法

        /// <summary>
        /// 记录调试异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        void DebugException(string model, string function, Exception exception);

        /// <summary>
        /// 记录一般异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        void InfoException(string model, string function, Exception exception);

        /// <summary>
        /// 记录警告异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        void WarnException(string model, string function, Exception exception);

        /// <summary>
        /// 记录错误异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        void ErrorException(string model, string function, Exception exception);

        /// <summary>
        /// 记录致命异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        void FatalException(string model, string function, Exception exception);

        #endregion

        #region 记录跟踪信息方法

        /// <summary>
        /// 记录调试跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        void DebugTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");

        /// <summary>
        /// 记录一般跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        void InfoTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");

        /// <summary>
        /// 记录警告跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        void WarnTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");

        /// <summary>
        /// 记录错误跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        void ErrorTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");

        /// <summary>
        /// 记录致命跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        void FatalTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");

        #endregion
    }
}
