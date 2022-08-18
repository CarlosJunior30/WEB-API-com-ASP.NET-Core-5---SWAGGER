using Microsoft.EntityFrameworkCore;
using System;

namespace BooksApi.Model
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
    }
}
