using Microsoft.EntityFrameworkCore;

namespace perfilprofessor.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
