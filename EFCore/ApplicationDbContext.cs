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

                //Identify one-to-one relationship between Blog entity (parent/principal entity) and BlogImage entity (child/dependant entity).
                eb.HasOne(b => b.BlogImage)
                    .WithOne(bi => bi.Blog)
                    .HasForeignKey<BlogImage>(bi => bi.BlogForeignKey);
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

            //To set generated identity column with fluent api.
            modelBuilder.Entity<Category>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            //To set computed column using fluent api.
            modelBuilder.Entity<Apartment>()
                .Property(a => a.Size)
                .HasComputedColumnSql("[Width] * [Height]");

            //To create one-to-many relationship with reference navigation property and collection navigation property (Recommended) (First way).
            //You have to use 1st way or 2nd way.
            modelBuilder.Entity<Apartment>()
                .HasMany(a => a.ApartmentOwner)
                .WithOne(ao => ao.Apartment)
                .HasForeignKey(ao => ao.ApartmentKey)
                .HasConstraintName("FK_ApartmentOwner_Test");

            //To create one-to-many relationship with reference navigation property and collection navigation property (Recommended) (Second way).
            //You have to use 2nd way or 1st way.
            //modelBuilder.Entity<ApartmentOwner>()
            //    .HasOne(ao => ao.Apartment)
            //    .WithMany(a => a.ApartmentOwner)
            //    .HasForeignKey(ao => ao.ApartmentKey)
            //    .HasConstraintName("FK_Test");


            //To create one-to-many relationshio without any navigation property with custom foreign key name (Not recommended at all) (First way).
            //modelBuilder.Entity<Apartment>()
            //    .HasMany<ApartmentOwner>()
            //    .WithOne()
            //    .HasForeignKey(ao => ao.ApartmentKey);

            //To create one-to-many relationshio without any navigation property with custom foreign key name (Not recommended at all) (Second way).
            //modelBuilder.Entity<ApartmentOwner>()
            //    .HasOne<Apartment>()
            //    .WithMany()
            //    .HasForeignKey(ao => ao.ApartmentKey);

        }

        //Add entity to database (First Method) which is default one.
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentOwner> ApartmentOwners { get; set; }
    }
}
