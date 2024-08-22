using Archon.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Archon.API.Data
{
    //database connection related class
    public class ArchonDbContext : DbContext
    {
        public ArchonDbContext(DbContextOptions<ArchonDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
