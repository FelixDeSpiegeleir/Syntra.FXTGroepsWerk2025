using Microsoft.EntityFrameworkCore;
using OWN.GroupProject2.Objects;
using System.Collections.Generic;

namespace OWN.GroupProject2.DataLayer
{
    public class MyContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Calls the base method to ensure any default configurations are applied.

            // Configuring the relationship between Book and Author
            modelBuilder.Entity<Book>()
                // Defining that a Book has one Author
                .HasOne(b => b.Author)
                // Defining that an Author can have many Books
                .WithMany(a => a.Books)
                // Setting the foreign key for the relationship on the Book entity
                .HasForeignKey(b => b.Author);

            // Configuring the relationship between Movie and Director
            modelBuilder.Entity<Movie>()
                // Defining that a Movie has one Director
                .HasOne(m => m.Director)
                // Defining that a Director can have many Movies
                .WithMany(d => d.Movies)
                // Setting the foreign key for the relationship on the Movie entitys
                .HasForeignKey(m => m.Director);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // extra paths in the works...
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=MoviesAndBooksDB;Integrated Security=True;Encrypt=False;");
        }
    }
}
