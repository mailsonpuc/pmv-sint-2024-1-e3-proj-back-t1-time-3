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
    public class ProfessorDisciplinasController : Controller
    {
        private readonly AppDbContext _context;

        public ProfessorDisciplinasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ProfessorDisciplinas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ProfessorDisciplinas.Include(p => p.Disciplina).Include(p => p.Professor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ProfessorDisciplinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorDisciplina = await _context.ProfessorDisciplinas
                .Include(p => p.Disciplina)
                .Include(p => p.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professorDisciplina == null)
            {
                return NotFound();
            }

            return View(professorDisciplina);
        }

        // GET: ProfessorDisciplinas/Create
        public IActionResult Create()
        {
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Descricao");
            ViewData["ProfessorId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: ProfessorDisciplinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfessorId,DisciplinaId,ValorAula,Resumo")] ProfessorDisciplina professorDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professorDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Descricao", professorDisciplina.DisciplinaId);
            ViewData["ProfessorId"] = new SelectList(_context.Usuarios, "Id", "Nome", professorDisciplina.ProfessorId);
            return View(professorDisciplina);
        }

        // GET: ProfessorDisciplinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorDisciplina = await _context.ProfessorDisciplinas.FindAsync(id);
            if (professorDisciplina == null)
            {
                return NotFound();
            }
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Descricao", professorDisciplina.DisciplinaId);
            ViewData["ProfessorId"] = new SelectList(_context.Usuarios, "Id", "Email", professorDisciplina.ProfessorId);
            return View(professorDisciplina);
        }

        // POST: ProfessorDisciplinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfessorId,DisciplinaId,ValorAula,Resumo")] ProfessorDisciplina professorDisciplina)
        {
            if (id != professorDisciplina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professorDisciplina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessorDisciplinaExists(professorDisciplina.Id))
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
            ViewData["DisciplinaId"] = new SelectList(_context.Disciplinas, "Id", "Descricao", professorDisciplina.DisciplinaId);
            ViewData["ProfessorId"] = new SelectList(_context.Usuarios, "Id", "Email", professorDisciplina.ProfessorId);
            return View(professorDisciplina);
        }

        // GET: ProfessorDisciplinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professorDisciplina = await _context.ProfessorDisciplinas
                .Include(p => p.Disciplina)
                .Include(p => p.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (professorDisciplina == null)
            {
                return NotFound();
            }

            return View(professorDisciplina);
        }

        // POST: ProfessorDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professorDisciplina = await _context.ProfessorDisciplinas.FindAsync(id);
            if (professorDisciplina != null)
            {
                _context.ProfessorDisciplinas.Remove(professorDisciplina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessorDisciplinaExists(int id)
        {
            return _context.ProfessorDisciplinas.Any(e => e.Id == id);
        }
    }
}
