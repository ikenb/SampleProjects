namespace DotNetRecruit
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class AnagramService
    {
        public IEnumerable<AnagramCounter> Compute(string dictionaryLocation)
        {
            var words = File.ReadAllLines(dictionaryLocation);

            foreach (var word in words)
            {
                Console.WriteLine("TODO process word: {0}", word);
            }

            return new List<AnagramCounter>
                       {
                           new AnagramCounter { WordLength = 1, Count = 0 },
                           new AnagramCounter { WordLength = 2, Count = 0 },
                           new AnagramCounter { WordLength = 3, Count = 0 },
                           new AnagramCounter { WordLength = 4, Count = 0 },
                           new AnagramCounter { WordLength = 5, Count = 0 },
                           new AnagramCounter { WordLength = 6, Count = 0 },
                           new AnagramCounter { WordLength = 7, Count = 0 },
                           new AnagramCounter { WordLength = 8, Count = 0 },
                           new AnagramCounter { WordLength = 9, Count = 0 },
                           new AnagramCounter { WordLength = 10, Count = 0 }
                       };
        }
    }
}
