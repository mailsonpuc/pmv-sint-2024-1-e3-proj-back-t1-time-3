using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using perfilprofessor.Models;

namespace perfilprofessor.Controllers
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
            if (ModelState.IsValid)
            {
                _context.Professores.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Professores.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Professor professor)
        {
            if (id != professor.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Professores.Update(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Professores.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

            [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Professores.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Professores.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
