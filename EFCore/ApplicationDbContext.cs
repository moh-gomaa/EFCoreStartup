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

            //Add entity to database (Third Method).
            modelBuilder.Entity<AuditEntry>();

            //Exclude entity from database (Second Method).
            //modelBuilder.Ignore<BlogPoint>();

            //To exclude the table from migration (Don't listen to changes) but still in database.
            modelBuilder.Entity<BlogPoint>()
                .ToTable("BlogPoint", t => t.ExcludeFromMigrations());
        }

        //Add entity to database (First Method) which is default one.
        public DbSet<Blog> Blogs { get; set; }
    }
}
