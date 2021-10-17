using System;

namespace StrategyDesignPattern
{
    public class Debit : IPayStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine("You payed by debit card");
        }
    }
}
