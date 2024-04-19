using FeedPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedPro.Controllers
{
    public class ProfessoresController : Controller
    {
        private readonly AppDbContext _context;
        public ProfessoresController(AppDbContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Professores.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professor professor)
        {
            if(ModelState.IsValid)
            {
                _context.Professores.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(professor);
        }

    }
}
