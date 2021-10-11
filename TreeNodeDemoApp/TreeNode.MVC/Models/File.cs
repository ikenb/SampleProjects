using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppConvertFolderDataToJasonFormat.Models
{
    public class File
    {
        public File()
        { }

        public File(string name, long size, string path)
        {
            Name = name;
            Size = size;
            Path = path;
        }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }

    }
}
