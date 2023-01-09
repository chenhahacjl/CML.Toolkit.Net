namespace CML.Framework.Helpers
{
    /// <summary>
    /// 获取异常消息委托
    /// </summary>
    /// <param name="exception">异常对象</param>
    /// <returns>异常消息</returns>
    public delegate string? GetExceptionMessageDelegate(Exception exception);

    /// <summary>
    /// 异常帮助类
    /// </summary>
    public static class ExceptionHelper
    {
        /// <summary>
        /// 获取异常消息事件
        /// </summary>
        public static event GetExceptionMessageDelegate GetExceptionMessageEvent = exception => exception?.Message;

        /// <summary>
        /// 获取异常消息
        /// </summary>
        /// <param name="exception">异常对象</param>
        /// <returns>异常消息</returns>
        public static string? GetExceptionMessage(Exception exception)
        {
            if (exception == null)
            {
                return null;
            }

            string? message = GetExceptionMessageEvent?.Invoke(exception);

            if (string.IsNullOrEmpty(message))
            {
                message = exception.Message;
            }

            return message;
        }
    }
}
