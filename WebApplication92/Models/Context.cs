using Microsoft.EntityFrameworkCore;

namespace WebApplication92.Models
{
    public class DeviceContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Event> Events { get; set; }

        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

    }
}
