using DataAccessLibrary.Configurations;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ApplyCongigurations(builder);
        }
        private static void ApplyCongigurations(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StateConfiguration());
            builder.ApplyConfiguration(new HobbyConfiguration());
        }

    }
}
