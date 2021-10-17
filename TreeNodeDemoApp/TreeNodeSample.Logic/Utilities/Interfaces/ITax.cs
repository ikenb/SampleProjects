namespace TreeNodeSample.Logic.Utilities.Interfaces
{
    public interface ITax
    {
        decimal ComputeTax(decimal stake, string formula);//TODO:PassThe Key-Value pair of the formula
    }
}
