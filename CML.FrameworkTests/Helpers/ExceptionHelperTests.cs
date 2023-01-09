using CML.Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CML.Framework.Tests
{
    [TestClass()]
    public class ExceptionHelperTests
    {
        private string? GetExceptionMessageEvent(Exception exception)
        {
            return $"[0x{exception.HResult:X2}]{exception.Message}";
        }

        [TestMethod()]
        public void GetExceptionMessageTest()
        {
            Exception exception = new("操作异常") { HResult = 0x10 };

            Assert.AreEqual(ExceptionHelper.GetExceptionMessage(exception), exception.Message);

            ExceptionHelper.GetExceptionMessageEvent += GetExceptionMessageEvent;

            Assert.AreEqual(ExceptionHelper.GetExceptionMessage(exception), $"[0x{exception.HResult:X2}]{exception.Message}");

            ExceptionHelper.GetExceptionMessageEvent -= GetExceptionMessageEvent;
        }
    }
}