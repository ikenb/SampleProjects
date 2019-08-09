using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace DotNetRecruit
{
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
