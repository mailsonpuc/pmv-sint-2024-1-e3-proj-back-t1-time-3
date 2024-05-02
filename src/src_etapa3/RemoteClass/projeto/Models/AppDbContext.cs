using Microsoft.EntityFrameworkCore;

namespace projeto.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Professor> Professores { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<MarcarAula> MarcarAula { get; set; }
    }
}
