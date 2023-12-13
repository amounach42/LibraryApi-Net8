using Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class AppDbContext : DbContext {

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}