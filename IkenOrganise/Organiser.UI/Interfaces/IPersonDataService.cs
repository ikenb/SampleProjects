using Organiser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser.UI.Interfaces
{
    public interface IPersonDataService
    {
        Task<Person> GetPersonByIdAsync(int personId);
        Task SaveAsync(Person person);
    }
}
