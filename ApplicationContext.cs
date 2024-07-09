using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=gamestore;Username=postgres;Password=postgres");
            }
        }
    }
}
