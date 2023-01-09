using CML.Framework.Helpers;

namespace CML.Framework
{
    /// <summary>
    /// 带数据的操作结果
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public sealed class OperateResult<T> : OperateResult
    {
        #region 公共属性

        /// <summary>
        /// 数据
        /// </summary>
        public T? Data { get; set; } = default;

        #endregion

        #region 构造函数

        /// <summary>
        /// 使用消息构造操作结果对象 [true, 0, <see langword="message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">操作结果消息</param>
        private OperateResult(T? data, string? message) : base(message)
        {
            Data = data;
        }

        /// <summary>
        /// 使用代码、消息构造操作结果对象 [true, <see langword="code"/>, <see langword="message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="code">操作结果代码</param>
        /// <param name="message">操作结果消息</param>
        private OperateResult(T? data, int code, string? message) : base(code, message)
        {
            Data = data;
        }

        #endregion

        #region 构造成功操作结果对象

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, 0, "操作成功", <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static OperateResult<T?> Succeed(T? data) => new(data, "操作成功") { Success = true };

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, 0, <see langword="message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="message">结果消息</param>
        /// <returns>成功操作结果对象</returns>
        public static OperateResult<T?> Succeed(T? data, string? message) => new(data, message) { Success = true };

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, default]
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>成功操作结果对象</returns>
        public static OperateResult<T?> Succeed(OperateResult operateResult) => new(default, operateResult.Code, operateResult.Message) { Success = true };

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>成功操作结果对象</returns>
        public static OperateResult<T?> Succeed(T? data, OperateResult operateResult) => new(data, operateResult.Code, operateResult.Message) { Success = true };

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, <see langword="operateResult"/>.<see cref="OperateResult{T}.Data"/>]
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>成功操作结果对象</returns>
        public static OperateResult<T?> Succeed(OperateResult<T?> operateResult) => new(operateResult.Data, operateResult.Code, operateResult.Message) { Success = true };

        /// <summary>
        /// 创建并返回一个成功操作结果对象 [true, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>成功操作结果对象</returns>
        public static OperateResult<T?> Succeed(T? data, OperateResult<T?> operateResult) => new(data, operateResult.Code, operateResult.Message) { Success = true };

        #endregion

        #region 构造失败操作结果对象

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, -1, "操作失败", <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult<T?> Failed(T? data) => new(data, -1, "操作失败") { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, -1, <see langword="errorMessage"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult<T?> Failed(T? data, string errorMessage) => new(data, -1, errorMessage) { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, <see langword="errorCode"/>, <see langword="errorMessage"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="errorCode">错误代码</param>
        /// <param name="errorMessage">错误消息</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult<T?> Failed(T? data, int errorCode, string errorMessage) => new(data, errorCode, errorMessage) { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, default]
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult<T?> Failed(OperateResult operateResult) => new(default, operateResult.Code, operateResult.Message) { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult<T?> Failed(T? data, OperateResult operateResult) => new(data, operateResult.Code, operateResult.Message) { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, <see langword="operateResult"/>.<see cref="OperateResult{T}.Data"/>]
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult<T?> Failed(OperateResult<T?> operateResult) => new(operateResult.Data, operateResult.Code, operateResult.Message) { Success = false };

        /// <summary>
        /// 创建并返回一个失败操作结果对象 [false, <see langword="operateResult"/>.<see cref="OperateResult.Code"/>, <see langword="operateResult"/>.<see cref="OperateResult.Message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>失败操作结果对象</returns>
        public static OperateResult<T?> Failed(T? data, OperateResult<T?> operateResult) => new(data, operateResult.Code, operateResult.Message) { Success = false };

        #endregion

        #region 构造异常操作结果对象

        /// <summary>
        /// 创建并返回一个异常操作结果对象 [false, <see langword="exception"/>.<see cref="Exception.HResult"/>, <see langword="exception"/>.<see cref="Exception.Message"/>, <see langword="data"/>]
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="exception">异常对象</param>
        /// <returns>异常操作结果对象</returns>
        public static OperateResult<T?> Exception(T? data, Exception exception) => new(data, exception.HResult, ExceptionHelper.GetExceptionMessage(exception) ?? "操作异常") { Success = false };

        #endregion

        #region 结果对象操作

        /// <summary>
        /// 从操作结果中复制操作结果代码 <see langword="operateResult"/>.<see cref="OperateResult.Code"/> 和操作结果消息 <see cref="OperateResult.Message"/>
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>当前操作结果对象</returns>
        public OperateResult<T> CopyFrom<TResult>(OperateResult<TResult?> operateResult)
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
        public OperateResult<T?> And(OperateResult<T?> operateResult) => Success ? operateResult : OperateResult<T?>.Failed(this);

        /// <summary>
        /// 操作结果与操作
        /// </summary>
        /// <param name="func">构造操作结果对象方法</param>
        /// <returns>操作结果对象</returns>
        public OperateResult<T?> ThenAnd(Func<T?, OperateResult<T?>> func) => Success ? func(Data) : OperateResult<T?>.Failed(this);

        /// <summary>
        /// 操作结果或操作
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns>操作结果对象</returns>
        public OperateResult<T?> Or(OperateResult<T?> operateResult) => Success ? this : operateResult;

        /// <summary>
        /// 操作结果或操作
        /// </summary>
        /// <param name="func">构造操作结果对象方法</param>
        /// <returns>操作结果对象</returns>
        public OperateResult<T?> ThenOr(Func<T?, OperateResult<T?>> func) => Success ? this : func(Data);

        #endregion

        #region 方法重写

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString()
        {
            return $"<{Success}>[{Code}]{Message}:{Data}";
        }

        #endregion

        #region 操作符重载

        /// <summary>
        /// 重载'<see langword="!"/>'操作符
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns></returns>
        public static bool operator !(OperateResult<T?> operateResult) => !operateResult.Success;

        /// <summary>
        /// 重载'<see langword="true"/>'操作符
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns></returns>
        public static bool operator true(OperateResult<T?> operateResult) => operateResult.Success;

        /// <summary>
        /// 重载'<see langword="false"/>'操作符
        /// </summary>
        /// <param name="operateResult">操作结果对象</param>
        /// <returns></returns>
        public static bool operator false(OperateResult<T?> operateResult) => !operateResult.Success;

        #endregion
    }
}
