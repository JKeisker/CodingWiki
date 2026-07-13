using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext() : base() { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookAuthorMap> bookAuthorMaps { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        //rename to Fluent_BookDetails
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_bookAuthorMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source = HALUCIN8; Database = CodingWiki; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate = True; Application Intent = ReadWrite; Multi Subnet Failover = False")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<Book>().HasData(
           new Book { BookId = 1, Title = "Spider Without Duty", ISBN = "123B12", Price = 10.99m, Publisher_Id=1 },
                new Book { BookId = 2, Title = "Fortune of Time", ISBN = "12123B12", Price = 11.99m, Publisher_Id=1 }
            );

            var bookList = new Book[]
            {
                new Book { BookId = 3, Title = "Fake Sunda", ISBN = "77652", Price = 20.99m, Publisher_Id=2 },
                new Book { BookId = 4, Title = "Cookie Jar", ISBN = "CC12B12", Price = 25.99m, Publisher_Id=3 },
                new Book { BookId = 5, Title = "Cloudy Forest", ISBN = "90392B33", Price = 40.99m, Publisher_Id=3 }
            };
            modelBuilder.Entity<Book>().HasData(bookList);

            modelBuilder.Entity<Publisher>().HasData(
           new Publisher { Publisher_Id = 1, Name = "Pub 1 Jimmy", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "Pub 2 John", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Pub 3 Ben", Location = "Hawaii" }
            );

            modelBuilder.Entity<Author>().HasData(
           new Author { Author_Id = 1, BirthDate = new DateTime(1965, 12, 5), FirstName = "Bill", LastName = "Shakespeare", Location = "Chicago" },
                new Author { Author_Id = 2, BirthDate = new DateTime(1975, 9, 9), FirstName = "Larry", LastName = "Bird", Location = "Chicago" },
                new Author { Author_Id = 3, BirthDate = new DateTime(1987, 5, 15), FirstName = "Tom", LastName = "Barrett", Location = "Chicago" },
                new Author { Author_Id = 4, BirthDate = new DateTime(1945, 4, 6), FirstName = "Betty", LastName = "Thomas", Location = "Chicago" },
                new Author { Author_Id = 5, BirthDate = new DateTime(1955, 1, 7), FirstName = "Shanna", LastName = "Leon", Location = "Chicago" }
            );
        }
    }
}
