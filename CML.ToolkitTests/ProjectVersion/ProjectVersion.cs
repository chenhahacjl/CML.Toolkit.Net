using System.Reflection;

namespace CML.Toolkit.ProjectVersion.Tests
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
        public override DateTime UpdateTime => new(2023, 01, 02, 03, 04, 05);
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
        public override int TypeVersion => 1;

        #endregion

        #region 内部使用

        /// <summary>
        /// 程序集 
        /// </summary>
        protected override Assembly Assembly => Assembly.GetExecutingAssembly();
        /// <summary>
        /// 更新日志文件 
        /// </summary>
        protected override string UpdateRecordFile => "CML.ToolkitTests.ProjectVersion.UpdateRecord";

        #endregion

        #region 公共方法

        /// <summary>
        /// 获得版本信息
        /// </summary>
        /// <returns>版本信息</returns>
        public override string GetVersionInfo()
        {
            return
                $"Version:{Version}{Environment.NewLine}" +
                $"BuildVersion:{BuildVersion}{Environment.NewLine}" +
                $"UpdateTime:{UpdateTime:yyyy/MM/dd HH:mm:ss}{Environment.NewLine}" +
                $"YearVersion:{YearVersion}{Environment.NewLine}" +
                $"VersionType:{VersionType}{Environment.NewLine}" +
                $"TypeVersion:{TypeVersion}{Environment.NewLine}" +
                $"Assembly:{Assembly.GetName()}{Environment.NewLine}" +
                $"UpdateRecordFile:{UpdateRecordFile}{Environment.NewLine}" +
                $"UpdateRecord:{GetUpdateRecord()}";
        }

        #endregion
    }
}
