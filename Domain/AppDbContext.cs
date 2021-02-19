using IntershipProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IntershipProject.Domain
{
    public class AppDbContext : IdentityDbContext<AppUser> // IdentityUser --> AppUser
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        
        public DbSet<LogModel> Logging { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole {
                Id = "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                Name = "user",
                NormalizedName = "USER"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser {
                Id = "aa589457-cfcf-425f-a74d-fa098b0cd513",
                UserName = "test",
                NormalizedUserName = "TEST",
                Email = "test@ss.ru",
                NormalizedEmail = "TEST@SS.RU",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "test"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> {
                RoleId = "f33d8288-6bda-4e5b-a01f-f5df8bd5cfb6",
                UserId = "aa589457-cfcf-425f-a74d-fa098b0cd513"
            });
        }
    }
}
