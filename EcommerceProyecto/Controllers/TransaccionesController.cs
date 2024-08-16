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
    public class TransaccionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransaccionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transacciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.transacciones.ToListAsync());
        }

        // GET: Transacciones/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.transacciones
                .FirstOrDefaultAsync(m => m.TransaccionId == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // GET: Transacciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransaccionId,VendedorId,ConsumidorId,OrdenId,Fecha_Transaccion")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                transaccion.TransaccionId = Guid.NewGuid();
                _context.Add(transaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaccion);
        }

        // GET: Transacciones/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.transacciones.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }
            return View(transaccion);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TransaccionId,VendedorId,ConsumidorId,OrdenId,Fecha_Transaccion")] Transaccion transaccion)
        {
            if (id != transaccion.TransaccionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccionExists(transaccion.TransaccionId))
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
            return View(transaccion);
        }

        // GET: Transacciones/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaccion = await _context.transacciones
                .FirstOrDefaultAsync(m => m.TransaccionId == id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return View(transaccion);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var transaccion = await _context.transacciones.FindAsync(id);
            if (transaccion != null)
            {
                _context.transacciones.Remove(transaccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccionExists(Guid id)
        {
            return _context.transacciones.Any(e => e.TransaccionId == id);
        }
    }
}
