using AliMertTosunAracSinavi.Models;
using Microsoft.EntityFrameworkCore;

namespace AliMertTosunAracSinavi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Kiralama> Kiralamalar { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Admin kullanıcı ekleme
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Admin",
                    Email = "admin@gmail.com",
                    Password = "123456", // Test şifresi
                    IsAdmin = true
                }
            );
        }
    }
}