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
            //Also change table name with fluent api
            modelBuilder.Entity<BlogPoint>()
                .ToTable("BlogPoints", t => t.ExcludeFromMigrations());

            //To set default schema for database
            //modelBuilder.HasDefaultSchema("blogging");

            //Change table name and table schema using fluent api
            //Also, map domain model to View also
            modelBuilder.Entity<Tag>()
                .ToTable("Tags", schema: "blogging")
                .ToView("SelectTags");
        }

        //Add entity to database (First Method) which is default one.
        public DbSet<Blog> Blogs { get; set; }
    }
}
