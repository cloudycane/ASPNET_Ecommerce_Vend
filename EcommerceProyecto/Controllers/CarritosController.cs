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
    public class CarritosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carritos
        public async Task<IActionResult> Index()
        {
            return View(await _context.carritos.ToListAsync());
        }

        // GET: Carritos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.carritos
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carritos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carritos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarritoId,ProductoId,VendedorId,ConsumidorId")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                carrito.CarritoId = Guid.NewGuid();
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrito);
        }

        // GET: Carritos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            return View(carrito);
        }

        // POST: Carritos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CarritoId,ProductoId,VendedorId,ConsumidorId")] Carrito carrito)
        {
            if (id != carrito.CarritoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.CarritoId))
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
            return View(carrito);
        }

        // GET: Carritos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrito = await _context.carritos
                .FirstOrDefaultAsync(m => m.CarritoId == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var carrito = await _context.carritos.FindAsync(id);
            if (carrito != null)
            {
                _context.carritos.Remove(carrito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(Guid id)
        {
            return _context.carritos.Any(e => e.CarritoId == id);
        }
    }
}
