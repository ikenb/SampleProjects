using Jace;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyDesignPattern
{
    enum PaymentType
    {
        Debit,
        Cash,
        Credit
    }
    class Program
    {
        public static Tuple<decimal, string>  ComputeTax(params object[] values)//Pass me x number of values
        {

            var formula = values[values.Length - 1].ToString();
            var cleanedFormula = formula.Replace("#", string.Empty);

            var engine = new CalculationEngine();
            var calculateEngine = engine.Build(cleanedFormula);


            char[] spearator = { '#','+', '-', '/', '*','(', ')', ' ' };
            var variables = formula.Split(spearator, StringSplitOptions.RemoveEmptyEntries);

            var requiredValues = values.Take(values.Length - 1);
            var requiredDoubles = new List<double>();

            foreach (var doubleValue in requiredValues)
            {
                requiredDoubles.Add(Convert.ToDouble(doubleValue));
            }


            var variablesLoader = ConvertToDecimal(variables,requiredDoubles);


            double result = calculateEngine(variablesLoader);

            return new Tuple<decimal, string>((decimal)result, formula);
        }

        private static Dictionary<string,double> ConvertToDecimal(string[] keys,List<double> values )
        {


            decimal doubleValue = 0;
            var listOfValues = new List<double>();
            var listOfKeys = new List<string>();

            foreach (var key in keys)
            {
                if (!(decimal.TryParse(key, out doubleValue)))
                {
                    listOfKeys.Add(key);
                }
            }

            foreach (var value in values)
            {
                    listOfValues.Add(value);
            }

            return VariableBuilder(listOfKeys, listOfValues);
        }

        private static Dictionary<string, double> VariableBuilder(List<string> listOfKeys, List<double> listOfValues)
        {
            var variablesLoader = new Dictionary<string, double>();

            for (int i = 0; i < listOfKeys.Count; i++)
            {
                variablesLoader.Add(listOfKeys[i], listOfValues[i]);
            }

            return variablesLoader;
        }

        //public static Tuple<decimal, string> ComputeWithHoldingTax(decimal netStake, decimal payOut, string formula)
        //{
        //    //var cleanedFormula = formula.Replace("#", string.Empty);
        //    char[] spearator = { '#', ' ' };
        //    var list = formula.Split(spearator, StringSplitOptions.RemoveEmptyEntries);

        //    var engine = new CalculationEngine();
        //    var exciseTaxFormula = string.Join(string.Empty, list);

        //    Func<Dictionary<string, double>, double> calculateEngine = engine.Build(exciseTaxFormula);

        //    Dictionary<string, double> variables = new Dictionary<string, double>();
        //    variables.Add(list[1], (double)netStake);
        //    variables.Add(list[3], (double)payOut);


        //    double result = calculateEngine(variables);

        //    return new Tuple<decimal, string>((decimal)result, formula);
        //}


        static void Main(string[] args)
        {
            Tuple<decimal, string> one;
            Tuple<decimal, string> two;
            Tuple<decimal, string> three;
            Tuple<decimal, string> four;

            //1st formula

            decimal stake1 = 2;
            string formula1 = @"(#stake#*(7,5/100))";
           var bla = ComputeTax(stake1, formula1);


            //2st formula

            decimal stake2 = 2;
            decimal exciseTax = 4;
            string formula2 = @"#stake#-#excisetax#";
           var ble = ComputeTax(stake2, exciseTax,stake1, formula2);

            //3rd formula

            decimal payOut1 = 20;
            string formula3 = @"#payout#*(20/100)";
           var blue = ComputeTax(payOut1, formula3);


            //4th formula

            decimal payOut2 = 20;
            decimal withHoldingTax = 21;
            string formula4 = @"#payout#-#withholdingtax#";

            var bli = ComputeTax(payOut2, withHoldingTax, formula4);






            PaymendMethod paymendMethod = new PaymendMethod();

            paymendMethod.SetAmount(12);

            var paymentOption = PaymentType.Debit;

            switch (paymentOption)
            {
                case PaymentType.Debit:
                    paymendMethod.SetStrategy(new Debit());
                    paymendMethod.Pay();
                    break;

                case PaymentType.Cash:
                    paymendMethod.SetStrategy(new Cash());
                    paymendMethod.Pay();
                    break;

                case PaymentType.Credit:
                    paymendMethod.SetStrategy(new Credit());
                    paymendMethod.Pay();
                    break;

                default:
                    Console.WriteLine("No valid payment method was chosen");
                    break;
            }
            Console.WriteLine("Hello World!");
        }
    }
}
