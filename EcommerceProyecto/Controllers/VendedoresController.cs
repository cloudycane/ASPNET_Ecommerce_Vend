using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceProyecto.Data;
using EcommerceProyecto.Models;
using EcommerceProyecto.Repositories;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.AspNetCore.Authorization;
using EcommerceProyecto.Utilities;

namespace EcommerceProyecto.Controllers
{
    [Authorize(Roles = SD.Role_Seller)]
    public class VendedoresController : Controller
    {
        private readonly IUnidad _unidad;
        private readonly IVendedoresRepositorio _vendedoresRepositorio; 
        public VendedoresController(IVendedoresRepositorio vendedoresRepositorio, IUnidad unidad)
        {
            _vendedoresRepositorio = vendedoresRepositorio;
            _unidad = unidad;
        }

        public async Task<IActionResult> Index()
        {

            var vendedores = await _vendedoresRepositorio.ObtenerListado();
            return View(vendedores);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _vendedoresRepositorio.ObtenerPorId(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {

                _vendedoresRepositorio.Crear(vendedor);
                _unidad.Save(vendedor);
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _vendedoresRepositorio.BuscarPorId(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Vendedor vendedor)
        {
            if (id != vendedor.VendedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _vendedoresRepositorio.Update(vendedor);
                    _unidad.Save(vendedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _vendedoresRepositorio.ObtenerPorId(id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vendedor = await _vendedoresRepositorio.BuscarPorId(id);
            if (vendedor != null)
            {

                _vendedoresRepositorio.Eliminar(vendedor);
            }   
            _unidad.Save(vendedor);
            return RedirectToAction(nameof(Index));
        }
        }
    }