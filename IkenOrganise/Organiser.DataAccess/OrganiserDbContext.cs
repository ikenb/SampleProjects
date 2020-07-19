using Organiser.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Organiser.DataAccess
{
    public class OrganiserDbContext : DbContext
    {
        public OrganiserDbContext()
            : base("OrganiserDb")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Person> People { get; set; }
    }
}
   
