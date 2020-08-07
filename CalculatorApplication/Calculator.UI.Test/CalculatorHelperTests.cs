using System;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.UI.Test
{
    [TestClass]
    [System.Runtime.InteropServices.Guid("9DB27718-6EA0-44B9-8FB0-78110A58ED54")]
    public class CalculatorHelperTests
    {

        CalculatorHelper _calculatorHelper;

        [TestInitialize]
        public void SetUp()
        {

            _calculatorHelper = new CalculatorHelper();
        }
        [TestMethod]
        public void GenerateOutputValueForNumber_IfOutputScreenIsZero_GenerateTheValueThatIsPressedOnce()
        {
            var label = new Label()
            {
                Content = 0
            };

            var output = _calculatorHelper.GenerateOutputValueForNumber(label,"7");

            Assert.AreEqual(output, "7");

        }

        [TestMethod]
        public void GenerateOutputValueForNumber_IfOutputScreenIsNotZero_ConcatinateTheValueOnTheScreenWithWhatWasPressed()
        {
            var label = new Label()
            {
                Content = 7
            };

            var output = _calculatorHelper.GenerateOutputValueForNumber(label, "7");

            Assert.AreEqual(output, "77");
        }


        [TestMethod]
        public void GenerateOutputValueForZero_IfOutputScreenIsNotZero_ConcatinateTheValueOnTheScreenWithZero()
        {
            var label = new Label()
            {
                Content = 9
            };

            var output = _calculatorHelper.GenerateOutputValueForZero(label, "0");

            Assert.AreEqual(output, "90");
        }

        [TestMethod]
        public void GenerateOutputValueForZero_IfOutputScreenIsZero_ReturnZero()
        {
            var label = new Label()
            {
                Content = 0
            };

            var output = _calculatorHelper.GenerateOutputValueForZero(label, "0");

            Assert.AreEqual(output, "0");
        }

        [TestMethod]
        public void GenerateOutputValueForComma_IfOutputScreenContainsComma_ReturnTheValueAsIs()
        {
           

            var output = _calculatorHelper.GenerateOutputValueForComma("2020,03");

            Assert.AreEqual(output, "2020,03");
        }


        [TestMethod]
        public void GenerateOutputValueForComma_IfOutputScreenDoesNotContainComma_AddCommaToTheValue()
        {
          
            var output = _calculatorHelper.GenerateOutputValueForComma("2020");

            Assert.AreEqual(output, "2020,");
        }

    }
}
