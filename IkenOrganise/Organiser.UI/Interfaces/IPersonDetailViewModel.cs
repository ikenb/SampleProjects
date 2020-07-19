using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.UI.Interfaces
{
    public interface IPersonDetailViewModel
    {
        Task LoadAsync(int personId);
    }
}
