using CML.Toolkit.Helpers;
using System.Runtime.CompilerServices;

namespace CML.Toolkit.Logger
{
    /// <summary>
    /// 基础控制台日志记录器
    /// </summary>
    public class BasicConsoleLogger : ILogger
    {
        #region 公共属性

        /// <summary>
        /// 输出到控制台
        /// </summary>
        public bool WriteToConsole { get; set; } = true;

        /// <summary>
        /// 记录日志等级
        /// </summary>
        public LogLevel WriteLogLevel { get; set; } = LogLevel.INFO;

        #endregion

        #region 私有方法
        /// <summary>
        /// 打印等级标识到控制台
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="logLevel">日志等级</param>
        /// <returns>空字符串</returns>
        private static void PrintLevelToConsole(string type, LogLevel logLevel)
        {
            Console.ForegroundColor = logLevel switch
            {
                LogLevel.FATAL => ConsoleColor.Magenta,
                LogLevel.ERROR => ConsoleColor.Red,
                LogLevel.WARN => ConsoleColor.Yellow,
                LogLevel.INFO => ConsoleColor.White,
                LogLevel.DEBUG => ConsoleColor.Gray,
                _ => ConsoleColor.Black,
            };

            Console.Write($"{type}.{logLevel,-5}");

            Console.ResetColor();
        }

        /// <summary>
        /// 打印消息到控制台
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="logLevel">日志等级</param>
        /// <param name="message">日志内容</param>
        private static void PrintMessageToConsole(string type, LogLevel logLevel, string message)
        {
            PrintLevelToConsole(type, logLevel);
            Console.WriteLine($" {message}");
        }

        #endregion

        #region 公共事件

        /// <summary> 
        /// 记录跟踪信息事件
        /// </summary>
        public event WriteTraceDelegate? WriteTraceEvent = null;

        /// <summary>
        /// 记录日志信息事件
        /// </summary>
        public event WriteLogDelegate? WriteLogEvent = null;

        /// <summary>
        /// 记录异常信息事件
        /// </summary>
        public event WriteExceptionDelegate? WriteExceptionEvent = null;

        #endregion

        #region 记录日志信息方法
        /// <summary>
        /// 打印日志信息到控制台
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        private void PrintLogToConsole(LogLevel logLevel, string model, string function, string message)
        {
            if (WriteToConsole)
            {
                PrintMessageToConsole("L", logLevel, $"[{model}.{function}]{message}");
            }
        }

        /// <summary>
        /// 记录调试日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        public void DebugLog(string model, string function, string message)
        {
            WriteLogEvent?.BeginInvoke(LogLevel.DEBUG, model, function, message, null, null);

            PrintLogToConsole(LogLevel.DEBUG, model, function, message);
        }

        /// <summary>
        /// 记录一般日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        public void InfoLog(string model, string function, string message)
        {
            WriteLogEvent?.BeginInvoke(LogLevel.INFO, model, function, message, null, null);

            PrintLogToConsole(LogLevel.INFO, model, function, message);
        }

        /// <summary>
        /// 记录警告日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        public void WarnLog(string model, string function, string message)
        {
            WriteLogEvent?.BeginInvoke(LogLevel.WARN, model, function, message, null, null);

            PrintLogToConsole(LogLevel.WARN, model, function, message);
        }

        /// <summary>
        /// 记录错误日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        public void ErrorLog(string model, string function, string message)
        {
            WriteLogEvent?.BeginInvoke(LogLevel.ERROR, model, function, message, null, null);

            PrintLogToConsole(LogLevel.ERROR, model, function, message);
        }

        /// <summary>
        /// 记录致命日志信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="message">日志内容</param>
        public void FatalLog(string model, string function, string message)
        {
            WriteLogEvent?.BeginInvoke(LogLevel.FATAL, model, function, message, null, null);

            PrintLogToConsole(LogLevel.FATAL, model, function, message);
        }

        #endregion

        #region 记录异常信息方法
        /// <summary>
        /// 打印异常信息到控制台
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        private void PrintExceptionToConsole(LogLevel logLevel, string model, string function, Exception exception)
        {
            if (WriteToConsole)
            {
                PrintMessageToConsole("E", logLevel, $"[{model}.{function}]{ExceptionHelper.GetExceptionMessage(exception)}");
            }
        }

        /// <summary>
        /// 记录调试异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        public void DebugException(string model, string function, Exception exception)
        {
            WriteExceptionEvent?.BeginInvoke(LogLevel.DEBUG, model, function, exception, null, null);

            PrintExceptionToConsole(LogLevel.DEBUG, model, function, exception);
        }

        /// <summary>
        /// 记录一般异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        public void InfoException(string model, string function, Exception exception)
        {
            WriteExceptionEvent?.BeginInvoke(LogLevel.INFO, model, function, exception, null, null);

            PrintExceptionToConsole(LogLevel.INFO, model, function, exception);
        }

        /// <summary>
        /// 记录警告异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        public void WarnException(string model, string function, Exception exception)
        {
            WriteExceptionEvent?.BeginInvoke(LogLevel.WARN, model, function, exception, null, null);

            PrintExceptionToConsole(LogLevel.WARN, model, function, exception);
        }

        /// <summary>
        /// 记录错误异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        public void ErrorException(string model, string function, Exception exception)
        {
            WriteExceptionEvent?.BeginInvoke(LogLevel.ERROR, model, function, exception, null, null);

            PrintExceptionToConsole(LogLevel.ERROR, model, function, exception);
        }

        /// <summary>
        /// 记录致命异常信息
        /// </summary>
        /// <param name="model">模块名称</param>
        /// <param name="function">方法名称</param>
        /// <param name="exception">错误对象</param>
        public void FatalException(string model, string function, Exception exception)
        {
            WriteExceptionEvent?.BeginInvoke(LogLevel.FATAL, model, function, exception, null, null);

            PrintExceptionToConsole(LogLevel.FATAL, model, function, exception);
        }

        #endregion

        #region 记录跟踪信息方法
        /// <summary>
        /// 打印跟踪信息到控制台
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        private void PrintTraceToConsole(LogLevel logLevel, string message, string callerFilePath, int callerLineNumber, string callerMemberName)
        {
            if (WriteToConsole)
            {
                PrintMessageToConsole("T", logLevel, $"[{callerMemberName}]{message}\n  in {callerFilePath} at line {callerLineNumber}");
            }
        }

        /// <summary>
        /// 记录调试跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        public void DebugTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
        {
            WriteTraceEvent?.BeginInvoke(LogLevel.DEBUG, message, callerFilePath, callerLineNumber, callerMemberName, null, null);

            PrintTraceToConsole(LogLevel.DEBUG, message, callerFilePath, callerLineNumber, callerMemberName);
        }

        /// <summary>
        /// 记录一般跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        public void InfoTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
        {
            WriteTraceEvent?.BeginInvoke(LogLevel.INFO, message, callerFilePath, callerLineNumber, callerMemberName, null, null);

            PrintTraceToConsole(LogLevel.INFO, message, callerFilePath, callerLineNumber, callerMemberName);
        }

        /// <summary>
        /// 记录警告跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        public void WarnTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
        {
            WriteTraceEvent?.BeginInvoke(LogLevel.WARN, message, callerFilePath, callerLineNumber, callerMemberName, null, null);

            PrintTraceToConsole(LogLevel.WARN, message, callerFilePath, callerLineNumber, callerMemberName);
        }

        /// <summary>
        /// 记录错误跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        public void ErrorTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
        {
            WriteTraceEvent?.BeginInvoke(LogLevel.ERROR, message, callerFilePath, callerLineNumber, callerMemberName, null, null);

            PrintTraceToConsole(LogLevel.ERROR, message, callerFilePath, callerLineNumber, callerMemberName);
        }

        /// <summary>
        /// 记录致命跟踪信息
        /// </summary>
        /// <param name="message">信息内容</param>
        /// <param name="callerFilePath">调用文件路径</param>
        /// <param name="callerLineNumber">调用文件行数</param>
        /// <param name="callerMemberName">调用方法名称</param>
        public void FatalTrace(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
        {
            WriteTraceEvent?.BeginInvoke(LogLevel.FATAL, message, callerFilePath, callerLineNumber, callerMemberName, null, null);

            PrintTraceToConsole(LogLevel.FATAL, message, callerFilePath, callerLineNumber, callerMemberName);
        }

        #endregion
    }
}
