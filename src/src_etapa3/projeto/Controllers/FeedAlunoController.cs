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

            var professores = await _context.Professor.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var lowerSearchString = searchString.ToLower();
                professores = professores.Where(p => p.Name.ToLower().Contains(lowerSearchString) ||
                                                     p.Materias.ToString().ToLower().Contains(lowerSearchString))
                                         .ToList();
            }

            return View(professores);
        }

        // POST: Aulas/Marcar
        [HttpPost("Marcar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Marcar(int professorId, string conteudo)
        {
            if (string.IsNullOrEmpty(conteudo))
            {
                // Se o conteúdo estiver vazio, redirecione de volta para a página de índice.
                // Você pode adicionar uma mensagem de erro aqui, se desejar.
                return RedirectToAction(nameof(Index));
            }

            var alunoId = 1;

            var marcarAula = new MarcarAula
            {
                ProfessorId = professorId,
                AlunoId = alunoId,
                Conteudo = conteudo,
                Confirmacao = false
            };

            _context.Add(marcarAula);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
