using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAppConvertFolderDataToJasonFormat.Models;
using WebAppConvertFolderDataToJasonFormat.Services.Interfaces;
using File = WebAppConvertFolderDataToJasonFormat.Models.File;

namespace WebAppConvertFolderDataToJasonFormat.Services.Implementation
{
    public class FileService : IFileService
    {
        public Folder OutPutInfo(string folder)
        {
            DirectoryInfo dir = new DirectoryInfo(folder);

            Folder instance = new Folder();
            instance.Name = dir.Name;
            instance.DateCreated = dir.CreationTime.ToString();
            var files = dir.GetFiles();

            foreach(var item in files)
            {
                instance.Files.Add(new File(item.Name, item.Length, item.FullName));
            }
            var folders = dir.GetDirectories();
            foreach(var item in folders)
            {
                instance.Folders.Add(OutPutInfo($"{folder}\\{item.Name}"));
            }
            return instance;
        }
    }
}
