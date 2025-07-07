using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Melodix.Data;
using Melodix.Models;

namespace Melodix.MVC.Controllers
{
    public class PistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pistas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pistas.Include(p => p.ArtistaNav);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = await _context.Pistas
                .Include(p => p.ArtistaNav)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pista == null)
            {
                return NotFound();
            }

            return View(pista);
        }

        // GET: Pistas/Create
        public IActionResult Create()
        {
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nombre");
            return View();
        }

        // POST: Pistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Duracion,CreadoEn,ActualizadoEn,Artista,Album,UrlPortada,FechaLanzamiento,SpotifyPistaId,ArtistaId")] Pista pista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nombre", pista.ArtistaId);
            return View(pista);
        }

        // GET: Pistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = await _context.Pistas.FindAsync(id);
            if (pista == null)
            {
                return NotFound();
            }
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nombre", pista.ArtistaId);
            return View(pista);
        }

        // POST: Pistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Duracion,CreadoEn,ActualizadoEn,Artista,Album,UrlPortada,FechaLanzamiento,SpotifyPistaId,ArtistaId")] Pista pista)
        {
            if (id != pista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PistaExists(pista.Id))
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
            ViewData["ArtistaId"] = new SelectList(_context.Artistas, "Id", "Nombre", pista.ArtistaId);
            return View(pista);
        }

        // GET: Pistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pista = await _context.Pistas
                .Include(p => p.ArtistaNav)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pista == null)
            {
                return NotFound();
            }

            return View(pista);
        }

        // POST: Pistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pista = await _context.Pistas.FindAsync(id);
            if (pista != null)
            {
                _context.Pistas.Remove(pista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PistaExists(int id)
        {
            return _context.Pistas.Any(e => e.Id == id);
        }
    }
}
