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

            //Ignore or drop propery from the table using fluent api.
            modelBuilder.Entity<Post>()
                .Ignore(t => t.CreatedAt);

            //To change multi columns name and other properties using fluent api.
            modelBuilder.Entity<Blog>(eb =>
            {
                eb.Property(b => b.Name)
                    .HasColumnName("BlogName")
                    .HasMaxLength(150)
                    .HasComment("The name of the blog");

                eb.Property(b => b.Url)
                    .HasColumnName("BlogUrl")
                    .HasColumnType("varchar(250)");

                //To set default value to column using fluent api.
                eb.Property(b => b.Rating)
                    .HasDefaultValue(2);

                //To set default sql value to column using fluent api.
                eb.Property(b => b.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");
            });

            //To set primary key and change its name using fluent api.
            //modelBuilder.Entity<Book>()
            //    .HasKey(b => b.BookKey)
            //    .HasName("PK_BookKey");

            //To set composite key and change name of it using fluent api.
            modelBuilder.Entity<Book>()
                .HasKey(b => new { b.Name, b.Author })
                .HasName("Pk_BookKey");

            //To set computed column using fluent api.
            modelBuilder.Entity<Author>()
                .Property(a => a.DisplayName)
                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
        }

        //Add entity to database (First Method) which is default one.
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
