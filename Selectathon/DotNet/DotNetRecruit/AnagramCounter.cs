namespace DotNetRecruit
{
    /// <summary>
    /// AnagramCounter: Holds the word lenght and counter 
    /// </summary>
    public struct AnagramCounter
    {
        #region Fields
        private int wordLength;
        private int count;
        #endregion

        #region Properties
        public int WordLength { get => wordLength; set => wordLength = value; }

        public int Count { get => count; set => count = value; }
        #endregion

        #region Constructor
        public AnagramCounter(int wordLength, int count)
        {
            this.wordLength = wordLength;
            this.count = count;
        }
        #endregion

    }
}