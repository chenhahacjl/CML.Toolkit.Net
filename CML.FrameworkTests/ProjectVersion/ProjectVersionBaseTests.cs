using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace CML.Framework.ProjectVersion.Tests
{
    [TestClass()]
    public class ProjectVersionBaseTests
    {
        [TestMethod()]
        public void GetVersionInfoTest()
        {
            string info =
                $"Version:1.0{Environment.NewLine}" +
                $"BuildVersion:2023Y001A001{Environment.NewLine}" +
                $"UpdateTime:2023/01/02 03:04:05{Environment.NewLine}" +
                $"YearVersion:1{Environment.NewLine}" +
                $"VersionType:Alpha{Environment.NewLine}" +
                $"TypeVersion:1{Environment.NewLine}" +
                $"Assembly:{Assembly.GetExecutingAssembly().GetName()}{Environment.NewLine}" +
                $"UpdateRecordFile:CML.FrameworkTests.ProjectVersion.UpdateRecord{Environment.NewLine}" +
                $"UpdateRecord:UpdateRecordTest";

            ProjectVersion projectVersion = new();
            string versionInfo = projectVersion.GetVersionInfo();

            Assert.AreEqual(info, versionInfo);
        }
    }
}