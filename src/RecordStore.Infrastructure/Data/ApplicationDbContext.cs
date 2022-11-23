using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecordStore.Core.Entities.Identity;
using RecordStore.Core.Entities.Models;

namespace RecordStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Format> Formats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var createDate = DateTime.Parse("2022-01-01");

            builder.Entity<Role>()
                .HasData(
                    new Role() { Id = Guid.Parse("F7423EB5-E11B-4A66-9D04-D64A464148BB"), Name = "Admin", NormalizedName = "Admin".ToUpper(), CreateDate = createDate },
                    new Role() { Id = Guid.Parse("22747656-AA1D-4260-93B3-F6767F35EC6D"), Name = "User", NormalizedName = "User".ToUpper(), CreateDate = createDate }
                );

            var hasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.Parse("E35ECCB0-55EF-4DF8-99AD-7B3DE0BA8B6B"),
                UserName = "admin",
                NormalizedUserName = "Admin",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                CreateDate = createDate
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

            builder.Entity<Record>()
                .HasMany(r => r.Artists)
                .WithMany(a => a.Records);

            builder.Entity<Record>()
                .HasMany(r => r.Styles)
                .WithMany(s => s.Records);

            builder.Entity<Record>()
                .HasMany(r => r.Genres)
                .WithMany(g => g.Records);

            builder.Entity<Record>()
                .HasMany(r => r.Categories)
                .WithMany(c => c.Records);

            builder.Entity<Record>()
                .HasMany(r => r.Genres)
                .WithMany(g => g.Records);

            builder.Entity<Record>()
                .HasMany(r => r.Categories)
                .WithMany(c => c.Records);
        }
    }
}