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
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,ProductoNombre,VendedorId,Descripcion,URLImagen,ValoracionProducto,FechaCreacion,EsVerificado,ConIVA,ConDiscuento,ConPuntos,PaisProducto,LugarFabricacion,Materiales,PrecioProducto")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.ProductoId = Guid.NewGuid();
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ProductoId,ProductoNombre,VendedorId,Descripcion,URLImagen,ValoracionProducto,FechaCreacion,EsVerificado,ConIVA,ConDiscuento,ConPuntos,PaisProducto,LugarFabricacion,Materiales,PrecioProducto")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
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
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.productos
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto != null)
            {
                _context.productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(Guid id)
        {
            return _context.productos.Any(e => e.ProductoId == id);
        }
    }
}
