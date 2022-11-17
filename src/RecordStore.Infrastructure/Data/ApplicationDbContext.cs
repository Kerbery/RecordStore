using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecordStore.Core.Entities.Identity;

namespace RecordStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>()
                .HasData(
                    new Role() { Id = Guid.Parse("F7423EB5-E11B-4A66-9D04-D64A464148BB"), Name = "Admin", NormalizedName = "Admin".ToUpper() },
                    new Role() { Id = Guid.Parse("22747656-AA1D-4260-93B3-F6767F35EC6D"), Name = "User", NormalizedName = "User".ToUpper() }
                );

            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.Parse("E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B"),
                UserName = "admin",
                NormalizedUserName = "Admin",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Pa$$w0rd");
            builder.Entity<ApplicationUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("F7423EB5-E11B-4A66-9D04-D64A464148BB"),
                    UserId = Guid.Parse("E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B")
                }
            );
        }
    }
}