using Microsoft.EntityFrameworkCore;

namespace MyDictionaryModels
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<LibraryModels> Words { get; set; }
    }
}