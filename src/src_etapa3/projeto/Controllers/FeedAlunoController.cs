using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto.Models;
using projeto.Data;

namespace projeto.Controllers
{

    public class FeedAlunoController : Controller
    {
        private readonly projetoContext _context;

        public FeedAlunoController(projetoContext context)
        {
            _context = context;
        }

        // GET: Aulas/Feed
        public async Task<IActionResult> Index(string searchString) 
        {
            ViewData["CurrentFilter"] = searchString;

            var professores = from p in _context.Professor
                              select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                professores = professores.Where(s => s.Name.Contains(searchString) || s.Materias.ToString().Contains(searchString));
            }

            return View(await professores.ToListAsync());
        }

        // POST: Aulas/Marcar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Marcar(int professorId)
        {
            // Pegue o ID do aluno autenticado. Este é um exemplo e deve ser ajustado conforme sua autenticação
            var alunoId = 1; // Substitua pelo ID do aluno autenticado

            var marcarAula = new MarcarAula
            {
                ProfessorId = professorId,
                AlunoId = alunoId,
                Confirmacao = false
            };

            _context.Add(marcarAula);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
