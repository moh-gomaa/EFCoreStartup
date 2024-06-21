using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=.;Database=EFCore;Trusted_Connection=True;TrustServerCertificate=True");

        public DbSet<Employee> Employees { get; set; }
    }
}
