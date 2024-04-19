using Microsoft.EntityFrameworkCore;

namespace FeedPro.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Professor> Professores { get; set; }

    }
}
