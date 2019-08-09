using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        MathOperation selectedOperation;
        double firstNumber = 0.0;

        public MainWindow()
        {
            InitializeComponent();

            percentageButton.Click += PercentegeButton_Click;
        }

        private void PercentegeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = (lastNumber/100).ToString();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";

        }
        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content= (lastNumber * -1).ToString();
            }
        }
        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
           resultLabel.Content = ManageNumberDisplay("7");
        }

        private string ManageNumberDisplay(string labelValue)
        {
            string resultScreeValue = labelValue;

            if (resultScreeValue != "0" && labelValue != resultScreeValue)
                labelValue = $"{resultScreeValue}{labelValue}";

            return labelValue;
        }
        private void AdditionButton_Click(object sender, RoutedEventArgs e)
        {
            selectedOperation = MathOperation.Addition;
            firstNumber = int.Parse(resultLabel.Content.ToString());

        }
        private void DivisionButton_Click(object sender, RoutedEventArgs e)
        {
            selectedOperation = MathOperation.Division;
            firstNumber = int.Parse(resultLabel.Content.ToString());
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            selectedOperation = MathOperation.Multiple;
            firstNumber = int.Parse(resultLabel.Content.ToString());
        }

        private void SubstractionButton_Click(object sender, RoutedEventArgs e)
        {
            selectedOperation = MathOperation.Substraction;
            firstNumber = int.Parse(resultLabel.Content.ToString());
        }
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber = double.Parse(resultLabel.Content.ToString());
            switch (selectedOperation)
            {
                case MathOperation.Addition:
                    resultLabel.Content = Addition(secondNumber,firstNumber);
                    break;
                case MathOperation.Substraction:
                    resultLabel.Content = Substraction(firstNumber, secondNumber);
                    break;
                case MathOperation.Multiple:
                    resultLabel.Content = Multiplication(secondNumber, firstNumber);
                    break;
                case MathOperation.Division:
                    resultLabel.Content = Division(firstNumber, secondNumber);
                    break;
                default:
                    break;
            }
        }

        private double Addition(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }
        private double Substraction(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }
        private double Multiplication(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }
        private double Division(double firstNumber, double secondNumber)
        {
            double results = 0;
            if (secondNumber != 0)
                results = firstNumber / secondNumber;
            else
            {
                MessageBox.Show("You can't really divide by 0", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return results;
        }

        enum MathOperation
        {
            Addition,
            Substraction,
            Multiple,
            Division
        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("8");
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("9");
        }

        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("4");
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("5");
        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("6");
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("1");
        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("2");
        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("3");
        }
 
        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = ManageNumberDisplay("0");
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains("."))
            {
                //Do Nothing
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

    }
}
