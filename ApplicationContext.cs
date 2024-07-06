using Microsoft.EntityFrameworkCore;

namespace GameStore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
    }
}
