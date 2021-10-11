using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppConvertFolderDataToJasonFormat.Models
{
    public class Folder
    {

        public string Name { get; set; }
        public string DateCreated { get; set; }
        public List<File> Files { get; set; } = new List<File>();
        public List<Folder> Folders { get; set; } = new List<Folder>();

    }
}
