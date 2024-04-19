using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using professor.Models;

namespace professor.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public ProfessorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var dados = await _appDbContext.Professores.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Add(professor);
                await _appDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(professor);
        }


    }
}
    
