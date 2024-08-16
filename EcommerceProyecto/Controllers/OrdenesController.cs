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
    public class OrdenesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ordenes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ordenes.ToListAsync());
        }

        // GET: Ordenes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.ordenes
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordenes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdenId,ConsumidorId,VendedorId,ProductoId,FechaPedido,CantidadPedido")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                orden.OrdenId = Guid.NewGuid();
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            return View(orden);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrdenId,ConsumidorId,VendedorId,ProductoId,FechaPedido,CantidadPedido")] Orden orden)
        {
            if (id != orden.OrdenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.OrdenId))
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
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.ordenes
                .FirstOrDefaultAsync(m => m.OrdenId == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var orden = await _context.ordenes.FindAsync(id);
            if (orden != null)
            {
                _context.ordenes.Remove(orden);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(Guid id)
        {
            return _context.ordenes.Any(e => e.OrdenId == id);
        }
    }
}
