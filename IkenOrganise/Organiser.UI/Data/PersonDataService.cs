using Organiser.DataAccess;
using Organiser.Model;
using Organiser.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Organiser.UI.Data
{
    public class PersonDataService : IPersonDataService
    {
        private Func<OrganiserDbContext> _contextCreator;

        public PersonDataService(Func<OrganiserDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }
        public async Task<Person> GetPersonByIdAsync(int personId)
        {
            using (var context =_contextCreator())
            {
                return await context.People.AsNoTracking().SingleAsync(p => p.Id == personId);
            }
        }

        public async Task SaveAsync(Person person)
        {
            using (var context = _contextCreator())
            {
                context.People.Attach(person);
                context.Entry(person).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}
