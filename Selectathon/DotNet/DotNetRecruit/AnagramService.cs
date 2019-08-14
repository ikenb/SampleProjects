namespace DotNetRecruit
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    /// <summary>
    /// AnagramService: Compute the anagram of a given text
    /// </summary>
    public class AnagramService
    {
        int anagramSizeTracker = 0;

        Dictionary<int, string> words = new Dictionary<int, string>();
        List<AnagramCounter> anagramCounters = new List<AnagramCounter>();

        public async void ExtractWordsAsync(string dictionaryLocation)
        {
            int characterLenth = 0;

            using (StreamReader reader = File.OpenText(dictionaryLocation))
            {
                while (!reader.EndOfStream)
                {
                    var word = await reader.ReadLineAsync();
                    characterLenth = word.Length;

                    if (!words.ContainsKey(characterLenth))
                        words.Add(characterLenth, word);
                }
            }
        }

        public async Task<IEnumerable<AnagramCounter>> ComputeAsync()
        {
            Task<IEnumerable<AnagramCounter>> t = Task<IEnumerable<AnagramCounter>>.Factory.StartNew(() =>
                {
                    foreach (string word in words.Values)
                    {
                        GetAnagramAsync(word, 0, word.Length - 1);
                        anagramCounters.Add(new AnagramCounter
                        {
                            WordLength = word.Length,
                            Count = anagramSizeTracker
                        });

                        //Console.ReadLine();
                        anagramSizeTracker = 0;
                    }

                    return anagramCounters;
                });
            
            return await t;
        }

        public int GetAnagramAsync(string word, int stringStartingIndex, int stringEndingIndex)
        {
            if (stringStartingIndex == stringEndingIndex)
            {
                anagramSizeTracker++;
                return anagramSizeTracker;
            }
            else
            {
                for (int count = stringStartingIndex; count <= stringEndingIndex; count++)
                {
                    word = SwapCharacters(word, stringStartingIndex, count);
                    GetAnagramAsync(word, stringStartingIndex + 1, stringEndingIndex);
                    word = SwapCharacters(word, stringStartingIndex, count);
                }
                return anagramSizeTracker;
            }
        }

        public string SwapCharacters(string word, int index, int counter)
        {
            char temp;
            char[] charArray = word.ToCharArray();

            temp = charArray[index];
            charArray[index] = charArray[counter];
            charArray[counter] = temp;

            string newWord = new string(charArray);

            return newWord;

        }


    }
}
