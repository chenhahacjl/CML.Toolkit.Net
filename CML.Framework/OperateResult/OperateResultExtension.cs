namespace CML.Toolkit
{
    /// <summary>
    /// 操作结果扩展方法
    /// </summary>
    public static class OperateResultExtension
    {
        /// <summary>
        /// 从操作结果中复制操作结果代码 <see cref="OperateResult.Code"/> 和操作结果消息 <see cref="OperateResult.Message"/>
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="operateResult">操作结果对象</param>
        /// <param name="operateResultT1">带数据的操作结果</param>
        public static OperateResult CopyFrom<T>(this OperateResult operateResult, OperateResult<T?> operateResultT1)
        {
            if (operateResultT1 != null)
            {
                operateResult.Code = operateResultT1.Code;
                operateResult.Message = operateResultT1.Message;
            }

            return operateResult;
        }

        /// <summary>
        /// 将当前的操作结果对象转换为带数据的操作结果对象，，当操作结果代码 <see cref="OperateResult.Success"/> 等于 <see langword="false"/> 时，返回带数据的失败操作结果对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="operateResult">操作结果对象</param>
        /// <param name="data">数据</param>
        /// <returns>带数据的操作结果对象</returns>
        public static OperateResult<T?> ConvertTo<T>(this OperateResult operateResult, T? data)
        {
            return operateResult.Success ? OperateResult<T?>.Succeed(data, operateResult) : OperateResult<T?>.Failed(data, operateResult);
        }
    }
}
