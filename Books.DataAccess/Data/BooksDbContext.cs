using Books.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataAccess.Data
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public BooksDbContext()
        {

        }
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                       .HasOne(b => b.Author)
                       .WithMany(a => a.Books)
                       .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                       .HasOne(b => b.Publisher)
                       .WithMany(p => p.Books)
                       .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<BookGenre>()
                        .HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<BookGenre>()
                        .HasOne(bg => bg.Book)
                        .WithMany(b => b.Genres)
                        .HasForeignKey(bg => bg.GenreId);

            modelBuilder.Entity<BookGenre>()
                        .HasOne(bg => bg.Genre)
                        .WithMany(g => g.Books)
                        .HasForeignKey(bg => bg.BookId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
