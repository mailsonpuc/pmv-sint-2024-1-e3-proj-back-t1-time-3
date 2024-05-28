using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto.Models;
using projeto.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace projeto.Controllers
{
    [Authorize]
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
                return RedirectToAction(nameof(Index));
            }

            var alunoIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (alunoIdClaim == null)
            {
                return RedirectToAction("Login", "Alunos");
            }

            if (!int.TryParse(alunoIdClaim.Value, out int alunoId))
            {
                return RedirectToAction("Login", "Alunos");
            }

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
