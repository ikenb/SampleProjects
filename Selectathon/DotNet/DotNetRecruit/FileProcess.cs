using System;
using System.IO;
using System.Reflection;

namespace DotNetRecruit
{
    /// <summary>
    /// FileProcess: To Load The File
    /// </summary>
    public class FileProcess
    {
        public string LoadTextFile()
        {
            string dictionaryLocation = string.Empty;
            string localPath = string.Empty;

            localPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath;
            dictionaryLocation = Path.Combine(localPath, @"Data\Dictionary.txt");

            if (FileExist(dictionaryLocation))
                return dictionaryLocation;

            return dictionaryLocation;
        }

        public bool FileExist(string fileName)
        {
            return File.Exists(fileName) ? true : throw new FileNotFoundException();
        }
    }
}
