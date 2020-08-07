using System.Windows.Controls;

namespace Calculator.UI
{
    public class CalculatorHelper
    {
        Logic.Math math;
        public CalculatorHelper()
        {
            math = new Logic.Math();
        }

        public string GenerateOutputValueForNumber(Label output, string pressedNumber)
        {
            string outputValue = output.Content.ToString();

            if (outputValue != "0")
                output.Content = outputValue + pressedNumber;
            else
                output.Content = pressedNumber;

            return output.Content.ToString();
        }

        public string GenerateOutputValueForZero(Label output, string pressedNumber)
        {
            string outputValue = output.Content.ToString();

            if (outputValue != "0")
                output.Content = outputValue + pressedNumber;
            else
                output.Content = 0;

            return output.Content.ToString();
        }

        

        public string GenerateOutputValueForComma(string outputValue)
        {
            if (!outputValue.Contains(","))
                outputValue = outputValue + ",";


            return outputValue;
        }

        public string GenerateOutputValueForOperations(string outputValue, string pressedOperation)
        {
            if (!outputValue.Contains(pressedOperation))
                outputValue = outputValue + pressedOperation;


            return outputValue;
        }

        public string ComputeResults(string operation, string lastEnteredNumber, string currentEnteredNumber)
        {
            string results = string.Empty;
            switch (operation)
            {
                case "+":
                    results = math.AddNumbers(lastEnteredNumber, currentEnteredNumber);
                    break;

                case "-":
                    results = math.SubtractNumbers(lastEnteredNumber, currentEnteredNumber);
                    break;

                case "/":
                    results = math.DivideNumbers(lastEnteredNumber, currentEnteredNumber);
                    break;

                case "*":
                    results = math.MultiplyNumbers(lastEnteredNumber, currentEnteredNumber);
                    break;

            }

            return results;
        }
    }
}
