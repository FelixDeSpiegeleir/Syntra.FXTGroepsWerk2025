using Microsoft.EntityFrameworkCore;
using OWN.GroupProject2.Objects;

namespace OWN.GroupProject2.DataLayer
{
    public class MyContext : DbContext
    {
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<WatchListItem> WatchListItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // 🏛 Table-Per-Hierarchy (TPH) Inheritance Strategy for WatchListItem
            // This means that `Book` and `Movie` will share a single database table
            // but will be distinguished by a discriminator column "ItemType".
            modelBuilder.Entity<WatchListItem>()
                .HasDiscriminator<string>("ItemType") // Creates a column named "ItemType" to distinguish entities
                .HasValue<Book>("Book")  // Records with "ItemType" = "Book" are mapped to the Book class
                .HasValue<Movie>("Movie"); // Records with "ItemType" = "Movie" are mapped to the Movie class

            //// 📚 Configuring the One-to-Many Relationship Between Book and Author
            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.Author)  // A book has one author
            //    .WithMany(a => a.Books)  // An author can have many books
            //    .HasForeignKey("AuthorId"); // Foreign key in Book table referencing Author's primary key

            //// 🎬 Configuring the One-to-Many Relationship Between Movie and Director
            //modelBuilder.Entity<Movie>()
            //    .HasOne(m => m.Director)  // A movie has one director
            //    .WithMany(d => d.Movies)  // A director can have many movies
            //    .HasForeignKey("DirectorId"); // Foreign key in Movie table referencing Director's primary key
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
            ////Xander's connection string
            //.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=GroepsWerk2025;Integrated Security=True;Encrypt=False;");

            ////Felix's connection string
            //.UseSqlServer(@";");

            //Timothy's connection string
            .UseSqlServer(@"Data Source =.\LESCSHARP; Initial Catalog = FXTWishlist; Integrated Security = True; Encrypt = False");


        }
    }
}
