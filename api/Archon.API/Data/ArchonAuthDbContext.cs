using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Archon.API.Data
{
    public class ArchonAuthDbContext : IdentityDbContext
    {
        public ArchonAuthDbContext(DbContextOptions<ArchonAuthDbContext> options) : base(options)
        {

        }

        //seeding roles in auth database
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "46c27999-3690-482f-8456-a5bcd0ba7386";
            var writerId = "945d2840-576f-4675-b3f0-fdc8f5bee4ce";


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
