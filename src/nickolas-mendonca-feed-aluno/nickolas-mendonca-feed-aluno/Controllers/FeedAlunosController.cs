using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nickolas_mendonca_feed_aluno.Models;
using System.Linq;
using System.Threading.Tasks;

namespace nickolas_mendonca_feed_aluno.Controllers
{
    public class FeedAlunosController : Controller
    {
        private readonly AppDbContext _context;

        public FeedAlunosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tipoProfessor = TipoUsuario.Professor;

            var professoresComDisciplinas = await _context.ProfessorDisciplinas
                .Include(pd => pd.Professor)
                .Include(pd => pd.Disciplina)
                .Where(pd => pd.Professor.TipoUsuario == tipoProfessor)
                .ToListAsync();

            return View(professoresComDisciplinas);
        }
    }
}
