using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppConvertFolderDataToJasonFormat.Models;

namespace WebAppConvertFolderDataToJasonFormat.Services.Interfaces
{
   public interface IFileService
    {
        Folder OutPutInfo(string folder);
    }
}
