namespace CML.Framework.ProjectVersion
{
    /// <summary>
    /// 工程版本类型
    /// </summary>
    public enum ProjectVersionType
    {
        /// <summary>
        /// Alpha 版本
        /// </summary>
        Alpha = 1,
        /// <summary>
        /// Bata 版本
        /// </summary>
        Bata = 2,
        /// <summary>
        /// 试用版本
        /// </summary>
        Trial = 3,
        /// <summary>
        /// 发布版本
        /// </summary>
        Release = 4,
    }

    /// <summary>
    /// 工程版本类型扩展方法
    /// </summary>
    public static class VersionTypeExtension
    {
        /// <summary>
        /// 获取工程版本类型标识
        /// </summary>
        /// <param name="versionType">工程版本类型</param>
        /// <returns>工程版本类型标识</returns>
        /// <exception cref="ArgumentOutOfRangeException">工程版本类型异常</exception>
        public static char GetIdentifier(this ProjectVersionType versionType)
        {
            return versionType switch
            {
                ProjectVersionType.Alpha => 'A',
                ProjectVersionType.Bata => 'B',
                ProjectVersionType.Release => 'R',
                ProjectVersionType.Trial => 'T',
                _ => throw new ArgumentOutOfRangeException(nameof(versionType)),
            };
        }
    }
}
