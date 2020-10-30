using Flo.FinishingMaster.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Flo.FinishingMaster.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Wall> Walls { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
    }
}
