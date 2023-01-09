using CML.Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CML.Framework.Tests
{
    [TestClass()]
    public class OperateResultTests
    {
        private string? GetExceptionMessageEvent(Exception exception)
        {
            return $"[0x{exception.HResult:X2}]{exception.Message}";
        }

        private static void CompareOperateResult(OperateResult operateResult, bool success, int code, string message)
        {
            Assert.AreEqual(success, operateResult.Success);
            Assert.AreEqual(code, operateResult.Code);
            Assert.AreEqual(message, operateResult.Message);
        }

        private static void CompareOperateResult<T>(OperateResult<T> operateResult, bool success, int code, string message, T data)
        {
            Assert.AreEqual(success, operateResult.Success);
            Assert.AreEqual(code, operateResult.Code);
            Assert.AreEqual(message, operateResult.Message);
            Assert.AreEqual(data, operateResult.Data);
        }

        [TestMethod()]
        public void SucceedTest()
        {
            CompareOperateResult(OperateResult.Succeed(),
                true, 0, "操作成功");
            CompareOperateResult(OperateResult.Succeed("操作成功了！！！"),
                true, 0, "操作成功了！！！");

            CompareOperateResult(OperateResult<int>.Succeed(0x10),
                true, 0, "操作成功", 0x10);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, "操作成功了！！！"),
                true, 0, "操作成功了！！！", 0x10);
            CompareOperateResult(OperateResult<int>.Succeed(OperateResult.Succeed()),
                true, 0, "操作成功", default);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, OperateResult.Succeed()),
                true, 0, "操作成功", 0x10);
            CompareOperateResult(OperateResult<int>.Succeed(OperateResult<int>.Succeed(0x11)),
                true, 0, "操作成功", 0x11);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, OperateResult<int>.Succeed(0x11)),
                true, 0, "操作成功", 0x10);
        }

        [TestMethod()]
        public void FailedTest()
        {
            CompareOperateResult(OperateResult.Failed(),
                false, -1, "操作失败");
            CompareOperateResult(OperateResult.Failed("操作失败了！！！"),
                false, -1, "操作失败了！！！");
            CompareOperateResult(OperateResult.Failed(0x10, "操作失败了！！！"),
                false, 0x10, "操作失败了！！！");

            CompareOperateResult(OperateResult<int>.Failed(0x10),
                false, -1, "操作失败", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "操作失败了！！！"),
                false, -1, "操作失败了！！！", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, 0x11, "操作失败了！！！"),
                false, 0x11, "操作失败了！！！", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(OperateResult.Failed()),
                false, -1, "操作失败", default);
            CompareOperateResult(OperateResult<int>.Failed(0x10, OperateResult.Failed()),
                false, -1, "操作失败", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(OperateResult<int>.Failed(0x11)),
                false, -1, "操作失败", 0x11);
            CompareOperateResult(OperateResult<int>.Failed(0x10, OperateResult<int>.Failed(0x11)),
                false, -1, "操作失败", 0x10);
        }

        [TestMethod()]
        public void ExceptionTest()
        {
            Exception exception = new("操作异常") { HResult = 0x10 };

            ExceptionHelper.GetExceptionMessageEvent += GetExceptionMessageEvent;

            CompareOperateResult(OperateResult.Exception(exception),
                false, 0x10, "[0x10]操作异常");
            CompareOperateResult(OperateResult<int>.Exception(0x11, exception),
                false, 0x10, "[0x10]操作异常", 0x11);

            ExceptionHelper.GetExceptionMessageEvent -= GetExceptionMessageEvent;
        }

        [TestMethod()]
        public void CopyFromTest()
        {
            CompareOperateResult(OperateResult.Failed(0x10, "Object1").CopyFrom(OperateResult.Succeed("Object2")),
                false, 0, "Object2");
            CompareOperateResult(OperateResult.Failed(0x10, "Object1").CopyFrom<int>(OperateResult<int>.Succeed(0x11, "Object2")),
                false, 0, "Object2");
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").CopyFrom(OperateResult.Succeed("Object2")),
                false, 0, "Object2");
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").CopyFrom(OperateResult<int>.Succeed(0x11, "Object2")),
                false, 0, "Object2", 0x10);
        }

        [TestMethod()]
        public void AndTest()
        {
            CompareOperateResult(OperateResult.Succeed("Object1").And(OperateResult.Succeed("Object2")),
                true, 0, "Object2");
            CompareOperateResult(OperateResult.Failed("Object1").And(OperateResult.Failed("Object2")),
                false, -1, "Object1");
            CompareOperateResult(OperateResult.Succeed("Object1").And(OperateResult.Failed("Object2")),
                false, -1, "Object2");
            CompareOperateResult(OperateResult.Failed("Object1").And(OperateResult.Succeed("Object2")),
                false, -1, "Object1");

            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").And(OperateResult<int>.Succeed(0x11, "Object2")),
                true, 0, "Object2", 0x11);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").And(OperateResult<int>.Failed(0x11, "Object2")),
                false, -1, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").And(OperateResult<int>.Failed(0x11, "Object2")),
                false, -1, "Object2", 0x11);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").And(OperateResult<int>.Succeed(0x11, "Object2")),
                false, -1, "Object1", 0x10);
        }

        [TestMethod()]
        public void ThenAndTest()
        {
            CompareOperateResult(OperateResult.Succeed("Object1").ThenAnd(() => OperateResult.Succeed("Object2")),
                true, 0, "Object2");
            CompareOperateResult(OperateResult.Failed("Object1").ThenAnd(() => OperateResult.Failed("Object2")),
                false, -1, "Object1");
            CompareOperateResult(OperateResult.Succeed("Object1").ThenAnd(() => OperateResult.Failed("Object2")),
                false, -1, "Object2");
            CompareOperateResult(OperateResult.Failed("Object1").ThenAnd(() => OperateResult.Succeed("Object2")),
                false, -1, "Object1");

            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").ThenAnd((num) => OperateResult<int>.Succeed(0x11, "Object2")),
                true, 0, "Object2", 0x11);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").ThenAnd((num) => OperateResult<int>.Failed(0x11, "Object2")),
                false, -1, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").ThenAnd((num) => OperateResult<int>.Failed(0x11, "Object2")),
                false, -1, "Object2", 0x11);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").ThenAnd((num) => OperateResult<int>.Succeed(0x11, "Object2")),
                false, -1, "Object1", 0x10);
        }

        [TestMethod()]
        public void OrTest()
        {
            CompareOperateResult(OperateResult.Succeed("Object1").Or(OperateResult.Succeed("Object2")),
                true, 0, "Object1");
            CompareOperateResult(OperateResult.Failed("Object1").Or(OperateResult.Failed("Object2")),
                false, -1, "Object2");
            CompareOperateResult(OperateResult.Succeed("Object1").Or(OperateResult.Failed("Object2")),
                true, 0, "Object1");
            CompareOperateResult(OperateResult.Failed("Object1").Or(OperateResult.Succeed("Object2")),
                true, 0, "Object2");

            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").Or(OperateResult<int>.Succeed(0x11, "Object2")),
                true, 0, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").Or(OperateResult<int>.Failed(0x11, "Object2")),
                false, -1, "Object2", 0x11);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").Or(OperateResult<int>.Failed(0x11, "Object2")),
                true, 0, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").Or(OperateResult<int>.Succeed(0x11, "Object2")),
                true, 0, "Object2", 0x11);
        }

        [TestMethod()]
        public void ThenOrTest()
        {
            CompareOperateResult(OperateResult.Succeed("Object1").ThenOr(() => OperateResult.Succeed("Object2")),
                true, 0, "Object1");
            CompareOperateResult(OperateResult.Failed("Object1").ThenOr(() => OperateResult.Failed("Object2")),
                false, -1, "Object2");
            CompareOperateResult(OperateResult.Succeed("Object1").ThenOr(() => OperateResult.Failed("Object2")),
                true, 0, "Object1");
            CompareOperateResult(OperateResult.Failed("Object1").ThenOr(() => OperateResult.Succeed("Object2")),
                true, 0, "Object2");

            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Succeed(0x11, "Object2")),
                true, 0, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Failed(0x11, "Object2")),
                false, -1, "Object2", 0x11);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Failed(0x11, "Object2")),
                true, 0, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Succeed(0x11, "Object2")),
                true, 0, "Object2", 0x11);

            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Succeed(num, "Object2")),
                true, 0, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Failed(num, "Object2")),
                false, -1, "Object2", 0x10);
            CompareOperateResult(OperateResult<int>.Succeed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Failed(num, "Object2")),
                true, 0, "Object1", 0x10);
            CompareOperateResult(OperateResult<int>.Failed(0x10, "Object1").ThenOr((num) => OperateResult<int>.Succeed(num, "Object2")),
                true, 0, "Object2", 0x10);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual($"{OperateResult.Succeed("Object1")}", "<True>[0]Object1");
            Assert.AreEqual($"{OperateResult<int>.Succeed(0x10, "Object1")}", "<True>[0]Object1:16");
        }

        [TestMethod()]
        public void ConvertToTest()
        {
            CompareOperateResult(OperateResult.Succeed("Object1").ConvertTo(0x10),
                true, 0, "Object1", 0x10);
            CompareOperateResult(OperateResult.Failed("Object1").ConvertTo(0x10),
                false, -1, "Object1", 0x10);
        }
    }
}