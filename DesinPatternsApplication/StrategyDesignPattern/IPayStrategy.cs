using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyDesignPattern
{
    public interface IPayStrategy
    {
        void Pay(int amount);
    }
}
