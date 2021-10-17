using System;

namespace StrategyDesignPattern
{
    public class Credit : IPayStrategy
    {
        public void Pay(int amount)
        {
            Console.WriteLine("You payed by Credit card");
        }
    }
}
