using System;
using Calculator.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Logic.Test
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void AddNumbers_WhenCalled_ReturnsTheSumOfTwoNumbers()
        {
            Math math = new Math();

            var sum = math.AddNumbers("2", "4");

            Assert.AreEqual(sum,"6");
        }
    }
}
