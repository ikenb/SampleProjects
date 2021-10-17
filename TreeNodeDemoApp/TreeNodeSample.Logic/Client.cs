namespace TreeNodeSample.Logic
{
    public enum BetType
    {
        SingleBet,
        MultiBet,
        ExoticBet
    }
    public class Client
    {
        public string Name { get; set; }
        public decimal Stake { get; set; }
        public BetType BetType { get; set; }
    }
}
