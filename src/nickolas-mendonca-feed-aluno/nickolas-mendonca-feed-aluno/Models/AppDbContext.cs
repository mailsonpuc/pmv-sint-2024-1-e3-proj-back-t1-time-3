using Microsoft.EntityFrameworkCore;

namespace nickolas_mendonca_feed_aluno.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
        public DbSet<AlunoProfessorDisciplina> AlunoProfessoresDisciplinas { get; set; }
    }
}
