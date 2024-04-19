using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nickolas_mendonca_feed_aluno.Models;

namespace nickolas_mendonca_feed_aluno.Controllers
{
    public class AlunoProfessoresDisciplinasController : Controller
    {
        private readonly AppDbContext _context;

        public AlunoProfessoresDisciplinasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AlunoProfessoresDisciplinas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AlunoProfessoresDisciplinas
                .Include(a => a.Aluno)
                .Include(a => a.ProfessorDisciplina)
                    .ThenInclude(pd => pd.Disciplina)
                .Include(apd => apd.ProfessorDisciplina)
                    .ThenInclude(pd => pd.Professor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AlunoProfessoresDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoProfessorDisciplina = await _context.AlunoProfessoresDisciplinas
                .Include(a => a.Aluno)
                .Include(a => a.ProfessorDisciplina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoProfessorDisciplina == null)
            {
                return NotFound();
            }

            return View(alunoProfessorDisciplina);
        }

        // GET: AlunoProfessoresDisciplinas/Create
        public IActionResult Create()
        {
            try
            {
                ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "Nome");
                ViewData["PorfDiscId"] = new SelectList(_context.ProfessorDisciplinas.Include(pd => pd.Disciplina)
                    .Select(pd => new { Id = pd.Id, Descricao = pd.Disciplina.Descricao }), "Id", "Descricao");
                ViewData["ProfessorId"] = new SelectList(_context.ProfessorDisciplinas.Include(pd => pd.Professor)
                    .Select(pd => new { Id = pd.Id, Nome = pd.Professor.Nome }), "Id", "Nome");

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { message = ex.Message });
            }
        }

        // POST: AlunoProfessoresDisciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlunoId,PorfDiscId")] AlunoProfessorDisciplina alunoProfessorDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunoProfessorDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "Email", alunoProfessorDisciplina.AlunoId);
            ViewData["PorfDiscId"] = new SelectList(_context.ProfessorDisciplinas, "Id", "Id", alunoProfessorDisciplina.PorfDiscId);
            return View(alunoProfessorDisciplina);
        }

        // GET: AlunoProfessoresDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoProfessorDisciplina = await _context.AlunoProfessoresDisciplinas.FindAsync(id);
            if (alunoProfessorDisciplina == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "Email", alunoProfessorDisciplina.AlunoId);
            ViewData["PorfDiscId"] = new SelectList(_context.ProfessorDisciplinas, "Id", "Id", alunoProfessorDisciplina.PorfDiscId);
            return View(alunoProfessorDisciplina);
        }

        // POST: AlunoProfessoresDisciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlunoId,PorfDiscId")] AlunoProfessorDisciplina alunoProfessorDisciplina)
        {
            if (id != alunoProfessorDisciplina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunoProfessorDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoProfessorDisciplinaExists(alunoProfessorDisciplina.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Usuarios, "Id", "Email", alunoProfessorDisciplina.AlunoId);
            ViewData["PorfDiscId"] = new SelectList(_context.ProfessorDisciplinas, "Id", "Id", alunoProfessorDisciplina.PorfDiscId);
            return View(alunoProfessorDisciplina);
        }

        // GET: AlunoProfessoresDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoProfessorDisciplina = await _context.AlunoProfessoresDisciplinas
                .Include(a => a.Aluno)
                .Include(a => a.ProfessorDisciplina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alunoProfessorDisciplina == null)
            {
                return NotFound();
            }

            return View(alunoProfessorDisciplina);
        }

        // POST: AlunoProfessoresDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunoProfessorDisciplina = await _context.AlunoProfessoresDisciplinas.FindAsync(id);
            if (alunoProfessorDisciplina != null)
            {
                _context.AlunoProfessoresDisciplinas.Remove(alunoProfessorDisciplina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoProfessorDisciplinaExists(int id)
        {
            return _context.AlunoProfessoresDisciplinas.Any(e => e.Id == id);
        }
    }
}
