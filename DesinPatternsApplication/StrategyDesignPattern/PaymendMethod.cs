namespace StrategyDesignPattern
{
    public class PaymendMethod
    {
        public int Amount;
        private IPayStrategy _payStrategy;

        public void SetStrategy(IPayStrategy payStrategy)
        {
            _payStrategy = payStrategy;
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }

        public void Pay()
        {
            _payStrategy.Pay(Amount);
        }
    }
}
