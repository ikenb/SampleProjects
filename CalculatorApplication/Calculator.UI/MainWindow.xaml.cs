using System;
using System.Windows;
using Calculator;
using System.Windows.Controls;

namespace Calculator.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorHelper calculatorHelper;
        string _currentEnteredNumber;
        string _lastEnteredNumber;
        Button _control;
        string _operation = string.Empty;
        Logic.Math math;

        public MainWindow()
        {
            InitializeComponent();
            calculatorHelper = new CalculatorHelper();
            math = new Logic.Math();
        }

        private void SevenButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());

        }

        private void EightButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());
        }

        private void NineButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());

        }


        private void FourButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());
        }

        private void FiveButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());

        }

        private void SixButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());
        }

        private void OneButton_Click(object sender, RoutedEventArgs e)
        {

            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());

        }

        private void TwoButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());

        }

        private void ThreeButton_Click(object sender, RoutedEventArgs e)
        {
            _control = sender as Button;

            ControlOutputScreen(_control.Content.ToString());

        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void ButtonComma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _lastEnteredNumber = _currentEnteredNumber;

            outputLabel.Content = "0";
            _operation = "+";

        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {

            outputLabel.Content = calculatorHelper.ComputeResults(_operation, _lastEnteredNumber, _currentEnteredNumber);

            _currentEnteredNumber = outputLabel.Content.ToString();
            _operation = string.Empty;
        }

        private void ControlOutputScreen(string lastNumberPressed)
        {
            
           
                outputLabel.Content = calculatorHelper.GenerateOutputValueForNumber(outputLabel, lastNumberPressed);
           
           
            _currentEnteredNumber = outputLabel.Content.ToString();


        }

        
    }
}
