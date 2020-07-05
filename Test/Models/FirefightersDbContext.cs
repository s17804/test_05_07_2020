using Microsoft.EntityFrameworkCore;
using Test.Configurations;

namespace Test.Models
{
    public class FirefightersDbContext : DbContext
    {
        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruckAction> FireTruckActions { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        
        protected FirefightersDbContext()
        {
        }

        public FirefightersDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FirefighterConfiguration());
            modelBuilder.ApplyConfiguration(new FirefighterActionConfiguration());
            modelBuilder.ApplyConfiguration(new ActionConfiguration());
            modelBuilder.ApplyConfiguration(new FireTruckActionConfiguration());
            modelBuilder.ApplyConfiguration(new FireTruckConfiguration());

        }
    }
}