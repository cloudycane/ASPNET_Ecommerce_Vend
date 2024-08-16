using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceProyecto.Data;
using EcommerceProyecto.Models;

namespace EcommerceProyecto.Controllers
{
    public class ReseñaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReseñaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reseña
        public async Task<IActionResult> Index()
        {
            return View(await _context.reseñas.ToListAsync());
        }

        // GET: Reseña/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.reseñas
                .FirstOrDefaultAsync(m => m.ReseñaId == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // GET: Reseña/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reseña/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReseñaId,ConsumidorId,VendedorId,ProductoId,FechaReseña")] Reseña reseña)
        {
            if (ModelState.IsValid)
            {
                reseña.ReseñaId = Guid.NewGuid();
                _context.Add(reseña);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reseña);
        }

        // GET: Reseña/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.reseñas.FindAsync(id);
            if (reseña == null)
            {
                return NotFound();
            }
            return View(reseña);
        }

        // POST: Reseña/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ReseñaId,ConsumidorId,VendedorId,ProductoId,FechaReseña")] Reseña reseña)
        {
            if (id != reseña.ReseñaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reseña);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReseñaExists(reseña.ReseñaId))
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
            return View(reseña);
        }

        // GET: Reseña/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reseña = await _context.reseñas
                .FirstOrDefaultAsync(m => m.ReseñaId == id);
            if (reseña == null)
            {
                return NotFound();
            }

            return View(reseña);
        }

        // POST: Reseña/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var reseña = await _context.reseñas.FindAsync(id);
            if (reseña != null)
            {
                _context.reseñas.Remove(reseña);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReseñaExists(Guid id)
        {
            return _context.reseñas.Any(e => e.ReseñaId == id);
        }
    }
}
