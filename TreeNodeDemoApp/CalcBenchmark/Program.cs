using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Jace;
using NCalc;

namespace CalcBenchmark
{
    class Program
    {
        private const int NumberOfTests = 1000000;

        private static Random random = new Random();

        static void Main(string[] args)
        {
            IEnumerable<string> formulas = GenerateFormulas(10);

            BenchmarkNcalc(formulas);

            BenchmarkJace(formulas);

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static void BenchmarkNcalc(IEnumerable<string> formulas)
        {
            DateTime startTime = DateTime.Now;

            foreach (string formula in formulas)
            {
                Expression expression = new Expression(formula);

                for (int i = 0; i < NumberOfTests; i++)
                {
                    expression.Parameters["var1"] = NextDouble();
                    expression.Parameters["var2"] = NextDouble();
                    expression.Parameters["var3"] = NextDouble();
                    double resultNcalc = (double)expression.Evaluate();
                }
            }

            DateTime endTime = DateTime.Now;
            Console.WriteLine("Execution time Ncalc: {0}", endTime - startTime);
        }

        private static void BenchmarkJace(IEnumerable<string> formulas)
        {
            DateTime startTime = DateTime.Now;

            CalculationEngine engine = new CalculationEngine(CultureInfo.InvariantCulture);
            Dictionary<string, double> variables = new Dictionary<string, double>();

            foreach (string formula in formulas)
            {
                for (int i = 0; i < NumberOfTests; i++)
                {
                    variables.Clear();
                    variables.Add("var1", NextDouble());
                    variables.Add("var2", NextDouble());
                    variables.Add("var3", NextDouble());
                    double resultJace = engine.Calculate(formula, variables);
                }
            }

            DateTime endTime = DateTime.Now;
            Console.WriteLine("Execution time Jace: {0}", endTime - startTime);
        }

        private static IEnumerable<string> GenerateFormulas(int numberOfFormulas)
        {
            List<string> formulas = new List<string>();
            FunctionGenerator generator = new FunctionGenerator(CultureInfo.InvariantCulture);

            for (int i = 0; i < numberOfFormulas; i++)
            {
                formulas.Add(generator.Next());
            }
            
            return formulas;
        }

        private static double NextDouble()
        {
            return random.NextDouble() * random.Next();
        }
    }
}
