using System;

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
        static void Main(string[] args)
        {

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
