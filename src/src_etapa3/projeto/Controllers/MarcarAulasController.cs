using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto.Data;
using projeto.Models;

namespace projeto.Controllers
{
    public class MarcarAulasController : Controller
    {
        private readonly projetoContext _context;

        public MarcarAulasController(projetoContext context)
        {
            _context = context;
        }

        // GET: MarcarAulas
        public async Task<IActionResult> Index()
        {
            var projetoContext = _context.MarcarAula.Include(m => m.Aluno).Include(m => m.Professor);
            return View(await projetoContext.ToListAsync());
        }

        // GET: MarcarAulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcarAula = await _context.MarcarAula
                .Include(m => m.Aluno)
                .Include(m => m.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcarAula == null)
            {
                return NotFound();
            }

            return View(marcarAula);
        }

        // GET: MarcarAulas/Create
        public IActionResult Create()
        {
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Email");
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Cpf");
            return View();
        }

        // POST: MarcarAulas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProfessorId,AlunoId,Conteudo,Confirmacao")] MarcarAula marcarAula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marcarAula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Email", marcarAula.AlunoId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Cpf", marcarAula.ProfessorId);
            return View(marcarAula);
        }

        // GET: MarcarAulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcarAula = await _context.MarcarAula.FindAsync(id);
            if (marcarAula == null)
            {
                return NotFound();
            }
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Email", marcarAula.AlunoId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Cpf", marcarAula.ProfessorId);
            return View(marcarAula);
        }

        // POST: MarcarAulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfessorId,AlunoId,Conteudo,Confirmacao")] MarcarAula marcarAula)
        {
            if (id != marcarAula.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marcarAula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcarAulaExists(marcarAula.Id))
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
            ViewData["AlunoId"] = new SelectList(_context.Aluno, "Id", "Email", marcarAula.AlunoId);
            ViewData["ProfessorId"] = new SelectList(_context.Professor, "Id", "Cpf", marcarAula.ProfessorId);
            return View(marcarAula);
        }

        // GET: MarcarAulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marcarAula = await _context.MarcarAula
                .Include(m => m.Aluno)
                .Include(m => m.Professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marcarAula == null)
            {
                return NotFound();
            }

            return View(marcarAula);
        }

        // POST: MarcarAulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marcarAula = await _context.MarcarAula.FindAsync(id);
            if (marcarAula != null)
            {
                _context.MarcarAula.Remove(marcarAula);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarcarAulaExists(int id)
        {
            return _context.MarcarAula.Any(e => e.Id == id);
        }
    }
}
