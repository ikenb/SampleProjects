using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetRecruit.Test
{
    [TestClass]
    public class AnagramServiceTest
    {
        string dictionaryFile = string.Empty;
        public AnagramServiceTest()
        {
            Initialize();
        }
        public void Initialize()
        {
            dictionaryFile = @"TestData\SampleDictionary.txt";
        }
        [TestMethod]
        public void SwapCharacters_GivenWords_ReturnsNewStringWithSwappedCharacters()
        {
            AnagramService anagramService = new AnagramService();

           string newWord = anagramService.SwapCharacters("IKE", 0, 1);

            Assert.AreEqual(newWord, "KIE");
        }

        [TestMethod]
        public void GetAnagramAsync_GivenWords_ReturnsAnagramSize()
        {
            AnagramService anagramService = new AnagramService();

            int anagramLength = anagramService.GetAnagramAsync("IKE", 0, 2);

            Assert.AreEqual(anagramLength, 6);
        }
        [TestMethod]
        public void ComputeAsync_GivenWords_ReturnsAListOfAnagrams()
        {
            AnagramService anagramService = new AnagramService();

            //int anagramLength = anagramService.ComputeAsync();

            //Assert.AreEqual(anagramLength, 6);
        }
        
    }
}
