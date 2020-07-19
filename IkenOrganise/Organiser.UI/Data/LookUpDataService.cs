using Organiser.DataAccess;
using Organiser.Model;
using Organiser.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Organiser.UI.Data
{
    public class LookUpDataService : ILookUpDataService
    {
        private Func<OrganiserDbContext> _contextCreator;

        public LookUpDataService(Func<OrganiserDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<LookUpItem>> GetPersonLookUpAsync()
        {
            using (var context = _contextCreator())
            {
                return await context.People.AsNoTracking().Select(p =>
                new LookUpItem
                {
                    Id = p.Id,
                    DisplayMember = p.FirstName + " " + p.LastName
                }).ToListAsync();
            }

        }
    }
}
