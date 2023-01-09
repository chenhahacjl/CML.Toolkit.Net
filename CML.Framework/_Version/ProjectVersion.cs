using CML.Toolkit.ProjectVersion;
using System.Reflection;

namespace CML.Toolkit._Version
{
    /// <summary>
    /// 项目版本信息
    /// </summary>
    public sealed class ProjectVersion : ProjectVersionBase
    {
        #region 版本号

        /// <summary>
        /// 版本号
        /// </summary>
        public override string Version => "1.0";

        #endregion

        #region 版本信息

        /// <summary>
        /// 更新时间
        /// </summary>
        public override DateTime UpdateTime => new(2023, 01, 09, 10, 15, 00);
        /// <summary>
        /// 年度版本
        /// </summary>
        public override int YearVersion => 1;
        /// <summary>
        /// 工程版本类型
        /// </summary>
        public override ProjectVersionType VersionType => ProjectVersionType.Alpha;
        /// <summary>
        /// 类型版本
        /// </summary>
        public override int TypeVersion => 4;

        #endregion

        #region 内部使用

        /// <summary>
        /// 程序集 
        /// </summary>
        protected override Assembly Assembly => Assembly.GetExecutingAssembly();
        /// <summary>
        /// 更新日志文件 
        /// </summary>
        protected override string UpdateRecordFile => "CML.Framework._Version.UpdateRecord";

        #endregion
    }
}
