using CML.Framework.Helpers;

namespace CML.Framework
{
    /// <summary>
    /// 操作结果
    /// </summary>
    public class OperateResult
    {
        #region 公共属性

        /// <summary>
        /// 操作成功状态
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// 操作结果代码
        /// </summary>
        public int Code { get; set; } = 0;

        /// <summary>
        /// 操作结果消息
        /// </summary>
        public string? Message { get; set; } = string.Empty;

        #endregion

        #region 构造函数

        /// <summary>
        /// 使用消息构造操作结果对象 [true, 0, <see langword="message"/>]
        /// </summary>
        /// <param name="message">操作结果消息</param>
        protected OperateResult(string? message)
        {
            Message = message;
        }

        /// <summary>
        /// 使用代码、消息构造操作结果对象 [true, <see langword="code"/>, <see langword="message"/>]
        /// </summary>
        /// <param name="code">操作结果代码</param>
        /// <param name="message">操作结果消息</param>
        protected OperateResult(int code, string? message)
        {
            Code = code;
            Message = message;
        }

        #endregion

        #region 构造成功操作结果对象

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, 0, "操作成功"]
        /// </summary>
        /// <returns></returns>
        public static OperateResult Succeed() => new("操作成功") { Success = true };

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, 0, <see langword="message"/>]
        /// </summary>
        /// <param name="message">结果消息</param>
        /// <returns>成功操作结果对象</returns>
        public static OperateResult Succeed(string? message) => new(message) { Success = true };

        #endregion

        #region 构造失败操作结果对象

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, -1, "操作失败"]
        /// </summary>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult Failed() => new(-1, "操作失败") { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, -1, <see langword="errorMessage"/>]
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult Failed(string errorMessage) => new(-1, errorMessage) { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, <see langword="errorCode"/>, <see langword="errorMessage"/>]
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult Failed(int errorCode, string errorMessage) => new(errorCode, errorMessage) { Success = false };

        #endregion

        #region 构造异常操作结果对象

        /// <summary>
        /// 创建并返回一个异常操作结果对象 [false, <see langword="exception"/>.<see cref="Exception.HResult"/>, <see langword="exception"/>.<see cref="Exception.Message"/>]
        /// </summary>
        /// <param name="exception">异常对象</param>
        /// <returns>异常操作结果对象</returns>
        public static OperateResult Exception(Exception exception) => new(exception.HResult, ExceptionHelper.GetExceptionMessage(exception) ?? "操作异常") { Success = false };

        #endregion

        #region 结果对象操作

        /// <summary>
        /// 从操作结果中复制操作结果代码 <see langword="operateResult"/>.<see cref="Code"/> 和操作结果消息 <see langword="operateResult"/>.<see cref="Message"/>
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>当前操作结果对象</returns>
        public OperateResult CopyFrom(OperateResult operateResult)
        {
            if (operateResult != null)
            {
                Code = operateResult.Code;
                Message = operateResult.Message;
            }

            return this;
        }

        /// <summary>
        /// 操作结果与操作
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>操作结果对象</returns>
        public OperateResult And(OperateResult operateResult) => Success ? operateResult : this;

        /// <summary>
        /// 操作结果与操作
        /// </summary>
        /// <param name="func">构造操作结果对象方法</param>
        /// <returns>操作结果对象</returns>
        public OperateResult ThenAnd(Func<OperateResult> func) => Success ? func() : this;

        /// <summary>
        /// 操作结果或操作
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>操作结果对象</returns>
        public OperateResult Or(OperateResult operateResult) => Success ? this : operateResult;

        /// <summary>
        /// 操作结果或操作
        /// </summary>
        /// <param name="func">构造操作结果对象方法</param>
        /// <returns>操作结果对象</returns>
        public OperateResult ThenOr(Func<OperateResult> func) => Success ? this : func();

        #endregion

        #region 方法重写

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString()
        {
            return $"<{Success}>[{Code}]{Message}";
        }

        #endregion

        #region 操作符重载

        /// <summary>
        /// 重载'<see langword="!"/>'操作符
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns></returns>
        public static bool operator !(OperateResult operateResult) => !operateResult.Success;

        /// <summary>
        /// 重载'<see langword="true"/>'操作符
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns></returns>
        public static bool operator true(OperateResult operateResult) => operateResult.Success;

        /// <summary>
        /// 重载'<see langword="false"/>'操作符
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns></returns>
        public static bool operator false(OperateResult operateResult) => !operateResult.Success;

        #endregion
    }
}
