using System;

namespace StrategyDesignPattern
{
    public class Cash : IPayStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine("You payed by cash");
        }
    }
}
