using System;

namespace Calculator.Logic
{
    public class Math
    {
        double firstNumber, secondNumber;
        public string AddNumbers(string numberOnTheScreen, string numberEntered )
        {
            ConverNumbers(numberOnTheScreen,numberEntered);

            return (firstNumber + secondNumber).ToString();
        }

        public string SubtractNumbers(string numberOnTheScreen, string numberEntered)
        {
            ConverNumbers(numberOnTheScreen, numberEntered);

            return (firstNumber - secondNumber).ToString();
        }

        public string DivideNumbers(string numberOnTheScreen, string numberEntered)
        {       
            ConverNumbers(numberOnTheScreen, numberEntered);

            return (firstNumber / secondNumber).ToString();
        }
        public string MultiplyNumbers(string numberOnTheScreen, string numberEntered)
        {          
            ConverNumbers(numberOnTheScreen, numberEntered);

            return (firstNumber * secondNumber).ToString();
        }


        private void ConverNumbers(string numberOnTheScreen, string numberEntered)
        {
            double.TryParse(numberOnTheScreen, out firstNumber);
            double.TryParse(numberEntered, out secondNumber);
        }
    }
}
