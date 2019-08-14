namespace DotNetRecruit
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    /// <summary>
    /// INSTRUCTIONS:
    /// Write the logic within the Anagram Service class to determine how many anagrams exist in a given list of words.
    /// The definition of an anagram can be found here: https://www.google.co.za/?#q=definition+of+anagram
    /// 
    /// The output should list how many anagrams exist for a given character count.
    /// E.g. Words with the character length of 4 had 5000 anagrams  
    /// 
    /// Feel free to change the structure of the solution if you feel it helps optimise execution speed, memory usage etc.
    /// Feel free to ask other colleagues and / or use google when crafting your solution.
    /// Document assumptions (if any) as comments in code.
    /// 
    /// Your code should:
    ///     a) make use of the included file Dictionary.txt, 
    ///     b) write your results to the console in the form "Words with the character length of x had y anagrams"
    ///     c) include the total time in milliseconds somewhere in your console output
    ///     d) not write to the console on processing each word
    /// 
    /// Should BSG proceed with a follow-up interview, you will be required to walk through your code as part of the face to face interview process. 
    /// 
    /// Press return the completed solution with 48 hours to BSG, using the same email address that you received the zipped package.
    /// Please re-zip your solution excluding all unnecessary files (e.g. *.user, *.suo, bin folder, obj folder)
    /// </summary>
    public class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                FileProcess fileProcess = new FileProcess();
                Stopwatch timer = new Stopwatch();
                AnagramService anagramService = new AnagramService();
                
                timer.Start();
                string processedFiles = fileProcess.LoadTextFile();
                Console.WriteLine($"Loaded file in .....{timer.ElapsedMilliseconds}ms");

                anagramService.ExtractWordsAsync(processedFiles);
                Console.WriteLine($"Extracted the words on the file in .....{timer.ElapsedMilliseconds}ms");

                Task<IEnumerable<AnagramCounter>>  t = anagramService.ComputeAsync();
                Console.WriteLine();
                Console.WriteLine($"Computing anagrams ......Good things come to those who wait :-)");

                var anagramCounters = t.Result;
                Console.WriteLine($"Anagram Results (completed in {timer.ElapsedMilliseconds}ms");
                timer.Stop();

                Console.WriteLine();

                foreach (var anagramCounter in anagramCounters)
                {
                    Console.WriteLine(
                        "Words with the character length of {0} had {1} anagrams",
                        anagramCounter.WordLength,
                        anagramCounter.Count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The following exception occurred:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
