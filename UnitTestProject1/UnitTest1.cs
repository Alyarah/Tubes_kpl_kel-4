using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expectedResult = 2;
            int actualResult = 1 + 1;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
