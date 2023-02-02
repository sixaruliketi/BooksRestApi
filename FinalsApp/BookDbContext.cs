using FinalsApp.models;
using Microsoft.EntityFrameworkCore;

namespace FinalsApp
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
