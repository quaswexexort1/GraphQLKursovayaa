using Microsoft.EntityFrameworkCore;

namespace GraphQLKursovayaa.DataAccess.Entity
{
    public class SampleAppDbContext : DbContext
    {
        public SampleAppDbContext(DbContextOptions options) :base(options) 
        {
            Database.EnsureCreated();   
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Advokat> Advokats { get; set; }

        public DbSet<Case> Cases { get; set; }

        public DbSet<Action> Actions { get; set; }
    }
}
