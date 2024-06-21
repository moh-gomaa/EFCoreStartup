using EFCore.Configrations;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=.;Database=EFCore;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BlogEntityTypeConfigration().Configure(modelBuilder.Entity<Blog>());

            //Same as above but with other syntax
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfigration).Assembly);
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
