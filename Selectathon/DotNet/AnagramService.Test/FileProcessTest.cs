using DotNetRecruit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace AnagramService.Test
{
    [TestClass]
    public class FileProcessTest
    {
        string dictionaryFile= string.Empty;

        public FileProcessTest()
        {
            Initialize();
        }
        public void Initialize()
        {
            dictionaryFile = @"Data\Dictionary.txt";
        }
        [TestMethod]
        public void FileExist_ReturnsTrue_IfFileExist()
        {
            FileProcess fileProcess = new FileProcess();

            bool fileExist = fileProcess.FileExist(dictionaryFile);

            Assert.IsTrue(fileExist);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileExist_ThrowsFileNotFoundException_IfFileIsNotPassed()
        {
            FileProcess fileProcess = new FileProcess();

           fileProcess.FileExist("No File");  
        }
        [TestMethod]
        public void LoadTextFile_ReturnsFile_IfFileIsPassed()
        {
            FileProcess fileProcess = new FileProcess();

            string filePath = fileProcess.LoadTextFile();

            Assert.IsNotNull(filePath);
        }

        

    }
}
