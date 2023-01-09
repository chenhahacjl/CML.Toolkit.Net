using CML.Toolkit.Helpers;
using System.Reflection;

namespace CML.Toolkit.ProjectVersion
{
    /// <summary>
    /// 项目版本信息基类
    /// </summary>
    public class ProjectVersionBase
    {
        #region 版本号

        /// <summary>
        /// 版本号
        /// </summary>
        public virtual string Version => "1.0";
        /// <summary>
        /// 构建版本号
        /// </summary>
        public virtual string BuildVersion => $"{UpdateTime.Year}Y{YearVersion:000}{VersionType.GetIdentifier()}{TypeVersion:000}";

        #endregion

        #region 版本信息

        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime UpdateTime => new(2001, 03, 04, 05, 06, 07);
        /// <summary>
        /// 年度版本
        /// </summary>
        public virtual int YearVersion => 1;
        /// <summary>
        /// 工程版本类型
        /// </summary>
        public virtual ProjectVersionType VersionType => ProjectVersionType.Alpha;
        /// <summary>
        /// 类型版本
        /// </summary>
        public virtual int TypeVersion => 1;

        #endregion

        #region 内部使用

        /// <summary>
        /// 程序集 
        /// </summary>
        protected virtual Assembly Assembly => Assembly.GetExecutingAssembly();
        /// <summary>
        /// 更新日志文件 
        /// </summary>
        protected virtual string UpdateRecordFile => string.Empty;

        #endregion

        #region 公共方法

        /// <summary>
        /// 获得版本信息
        /// </summary>
        /// <returns>版本信息</returns>
        public virtual string GetVersionInfo()
        {
            string versionInfo =
                $"[Version] {Version}{Environment.NewLine}" +
                $"[Build Version] {BuildVersion}{Environment.NewLine}" +
                $"[Version Type] {VersionType}{Environment.NewLine}" +
                $"[Update Time] {UpdateTime:yyyy/MM/dd HH:mm}{Environment.NewLine}" +
                $"{Environment.NewLine}";

            if (Assembly.ExistResource(UpdateRecordFile))
            {
                versionInfo +=
                    $"@ Update Record @ {Environment.NewLine}" +
                    $"{Environment.NewLine}" +
                    $"{GetUpdateRecord()}";
            }

            return versionInfo.Trim();
        }

        /// <summary>
        /// 获取更新日志
        /// </summary>
        /// <returns>更新日志</returns>
        public string GetUpdateRecord()
        {
            return Assembly.GetResourceString(UpdateRecordFile); ;
        }

        #endregion
    }
}
