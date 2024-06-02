using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto.Data;

namespace projeto.Controllers
{
    public class FeedProfessorController : Controller
    {
        private readonly projetoContext _context;

        public FeedProfessorController(projetoContext context)
        {
            _context = context;
        }
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var alunos = from a in _context.Aluno
                         select a;

            if (!string.IsNullOrEmpty(searchString))
            { 
                searchString = searchString.ToLower();
                alunos = alunos.Where(a => a.Name.ToLower().Contains(searchString) || a.Email.ToLower().Contains(searchString));
            }

            return View(await alunos.ToListAsync());
        }
    }
}
