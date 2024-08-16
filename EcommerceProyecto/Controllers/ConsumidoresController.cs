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
    public class ConsumidoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumidoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consumidores
        public async Task<IActionResult> Index()
        {
            return View(await _context.consumidores.ToListAsync());
        }

        // GET: Consumidores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumidor = await _context.consumidores
                .FirstOrDefaultAsync(m => m.ConsumidorId == id);
            if (consumidor == null)
            {
                return NotFound();
            }

            return View(consumidor);
        }

        // GET: Consumidores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consumidores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumidorId,NombreConsumidor,ApellidosConsumidor,Direccion,NumTelefono,TarjetCredito,Correo_Electronico,FechaNacimiento,Valoracion,EsVerificado")] Consumidor consumidor)
        {
            if (ModelState.IsValid)
            {
                consumidor.ConsumidorId = Guid.NewGuid();
                _context.Add(consumidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consumidor);
        }

        // GET: Consumidores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumidor = await _context.consumidores.FindAsync(id);
            if (consumidor == null)
            {
                return NotFound();
            }
            return View(consumidor);
        }

        // POST: Consumidores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ConsumidorId,NombreConsumidor,ApellidosConsumidor,Direccion,NumTelefono,TarjetCredito,Correo_Electronico,FechaNacimiento,Valoracion,EsVerificado")] Consumidor consumidor)
        {
            if (id != consumidor.ConsumidorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumidorExists(consumidor.ConsumidorId))
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
            return View(consumidor);
        }

        // GET: Consumidores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumidor = await _context.consumidores
                .FirstOrDefaultAsync(m => m.ConsumidorId == id);
            if (consumidor == null)
            {
                return NotFound();
            }

            return View(consumidor);
        }

        // POST: Consumidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var consumidor = await _context.consumidores.FindAsync(id);
            if (consumidor != null)
            {
                _context.consumidores.Remove(consumidor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumidorExists(Guid id)
        {
            return _context.consumidores.Any(e => e.ConsumidorId == id);
        }
    }
}
