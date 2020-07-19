using Organiser.Model;
using System.Data.Entity.Migrations;

namespace Organiser.DataAccess.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Organiser.DataAccess.OrganiserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Organiser.DataAccess.OrganiserDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.People.AddOrUpdate(p => p.FirstName,
                new Person { FirstName = "Tshepiso", LastName = "Marape", Email = "ti@marape.co.za" },
                new Person { FirstName = "Ike", LastName = "Magicain", Email = "ike@magician.com" },
                new Person { FirstName = "Lesedi", LastName = "Smith", Email = "les@les.com" },
                new Person { FirstName = "Bridget", LastName = "Mc Donald", Email = "bree@taxi.co.za" },
                new Person { FirstName = "Noti", LastName = "Van Wyk", Email = "noti@voetsek.co.za" });
        }
    }
}

