using BlazorApp3.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
