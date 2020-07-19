using Organiser.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Organiser.UI.Interfaces
{
    public interface ILookUpDataService
    {
        Task<IEnumerable<LookUpItem>> GetPersonLookUpAsync();
    }
}
