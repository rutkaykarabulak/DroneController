using Microsoft.EntityFrameworkCore;

namespace Musala.EFModels
{
    public class PostgreSQLDbContext : DbContext
    {
        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> options) : base(options)
        {

        }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<DroneLoad> DroneLoads { get; set; }
    }
}
