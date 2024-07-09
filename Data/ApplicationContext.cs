using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }
        
    public DbSet<GameReview> Reviews { get; set; }
        
    public DbSet<StudioDev> StudioDevs { get; set; }

    public DbSet<Coupon> Coupons { get; set; }
        
    public DbSet<BuyingGames> BuyingGames { get; set; }
        
}