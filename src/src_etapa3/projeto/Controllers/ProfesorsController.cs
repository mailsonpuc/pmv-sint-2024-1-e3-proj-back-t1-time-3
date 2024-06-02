using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto.Models;
using projeto.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace projeto.Controllers
{
    public class ProfesorsController : Controller
    {
        private readonly projetoContext _context;

        public ProfesorsController(projetoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Professor.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // GET: Profesors/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesors/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf,Name,Email,Senha,Materias")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                professor.Senha = BCrypt.Net.BCrypt.HashPassword(professor.Senha);
                _context.Add(professor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Profesors/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }
            return View(professor);
        }

        // POST: Profesors/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cpf,Name,Email,Senha,Materias")] Professor professor)
        {
            if (id != professor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    professor.Senha = BCrypt.Net.BCrypt.HashPassword(professor.Senha);
                    _context.Update(professor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorExists(professor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(professor);
        }

        // GET: Profesors/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }

        // POST: Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professor = await _context.Professor.FindAsync(id);
            if (professor != null)
            {
                _context.Professor.Remove(professor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professor.Any(e => e.Id == id);
        }

        // GET: Profesors/Perfil
        [Authorize]
        public async Task<IActionResult> Perfil()
        {
            var professorIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (professorIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!int.TryParse(professorIdClaim.Value, out int professorId))
            {
                return RedirectToAction("Login", "Account");
            }

            var professor = await _context.Professor
                .FirstOrDefaultAsync(m => m.Id == professorId);
            if (professor == null)
            {
                return NotFound();
            }

            return View(professor);
        }
    }
}
