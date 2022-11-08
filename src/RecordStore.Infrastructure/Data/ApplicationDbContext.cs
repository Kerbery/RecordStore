using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RecordStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole() { Id = "F7423EB5-E11B-4A66-9D04-D64A464148BB", Name = "Admin", NormalizedName = "Admin" },
                    new IdentityRole() { Id = "22747656-AA1D-4260-93B3-F6767F35EC6D", Name = "User", NormalizedName = "User" }
                );

            var hasher = new PasswordHasher<IdentityUser>();
            IdentityUser adminUser = new IdentityUser
            {
                Id = "E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B",
                UserName = "admin",
                NormalizedUserName = "Admin",
                Email = "admin@mail.com"
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Pa$$w0rd");
            builder.Entity<IdentityUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "F7423EB5-E11B-4A66-9D04-D64A464148BB",
                UserId = "E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B"
            }
        );
        }
    }
}