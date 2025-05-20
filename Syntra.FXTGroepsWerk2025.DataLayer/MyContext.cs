using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OWN.GroupProject2.Objects;
using Syntra.FXTGroepsWerk2025.Objects;

namespace OWN.GroupProject2.DataLayer
{

    /// <summary>
    /// Represents the database context for the application, managing the entity sets and their configurations.
    /// </summary>
    public class MyContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Constructor for testing scenarios
        /// </summary>
        /// <param name="options"></param>
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        /// <summary>
        /// Gets or sets the DbSet for WatchLists.
        /// </summary>
        public DbSet<WatchList> WatchLists { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for WatchListItems.
        /// </summary>
        public DbSet<WatchListItem> WatchListItems { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Books.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Movies.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Directors.
        /// </summary>
        public DbSet<Director> Directors { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for Authors.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Configures the model by overriding this method to set up relationships, inheritance, etc.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
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
        }

        /// <summary>
        /// Configures the database connection and other options for the context.
        /// </summary>
        /// <param name="optionsBuilder">The builder used to configure the context options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();

            string machineName = Environment.MachineName;
            string connectionString;

            switch (machineName)
            {
                case "TIMOTHY": // Timothy's PC
                    connectionString = @"Data Source=.\LESCSHARP; Initial Catalog=FXTWishlist; Integrated Security=True; Encrypt=False";
                    break;
                case "MOBILEBLOCKN": // Xander's PC 
                    connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=GroepsWerk2025;Integrated Security=True;Encrypt=False";
                    break;
                case "ACER-LAPTOP": // Felix's PC 
                    connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=FXTWishlist; Integrated Security=True; Encrypt=False";
                    break;
                default:
                    throw new Exception("Unknown machine name. Please configure the connection string for this machine.");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
