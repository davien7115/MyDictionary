using Microsoft.EntityFrameworkCore;

namespace MyDictionary.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<LibraryModels> Words { get; set; }
    }
}