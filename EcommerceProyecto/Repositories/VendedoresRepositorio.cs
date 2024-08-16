using EcommerceProyecto.Data;
using EcommerceProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProyecto.Repositories
{
    public interface IVendedoresRepositorio
    {
        Task<Vendedor> BuscarPorId(Guid? id);
        void Crear([Bind(new[] { "VendedorId,NombreVendedor,ApellidosVendedor,Direccion,NumTelefono,TarjetaDeCredito,Correo_Electronico,FechaNacimiento,Valoracion,EsVerificado" })] Vendedor vendedor);
        void Eliminar(Vendedor vendedor);
        Task<List<Vendedor>> ObtenerListado();
        Task<Vendedor> ObtenerPorId(Guid? id);
        void Update([Bind(new[] { "VendedorId,NombreVendedor,ApellidosVendedor,Direccion,NumTelefono,TarjetaDeCredito,Correo_Electronico,FechaNacimiento,Valoracion,EsVerificado" })] Vendedor vendedor);
        

    }
    public class VendedoresRepositorio : IVendedoresRepositorio
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public VendedoresRepositorio(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        // Si retorna un valor usamos return 
        public async Task<List<Vendedor>> ObtenerListado()
        {
            return await _applicationDbContext.vendedores.ToListAsync(); 
        }

        //

        public async Task<Vendedor> ObtenerPorId(Guid? id)
        {
            return await _applicationDbContext.vendedores.FirstOrDefaultAsync(m => m.VendedorId == id);
        }

        // BuscarId o ObtenerId  
        public async Task<Vendedor> BuscarPorId(Guid? id)
        {
            return await _applicationDbContext.vendedores.FindAsync(id);
        }

        public void Crear([Bind("VendedorId,NombreVendedor,ApellidosVendedor,Direccion,NumTelefono,TarjetaDeCredito,Correo_Electronico,FechaNacimiento,Valoracion,EsVerificado")] Vendedor vendedor)
        {
            vendedor.VendedorId = Guid.NewGuid();
            _applicationDbContext.Add(vendedor);
        }

        public void Update([Bind("VendedorId,NombreVendedor,ApellidosVendedor,Direccion,NumTelefono,TarjetaDeCredito,Correo_Electronico,FechaNacimiento,Valoracion,EsVerificado")] Vendedor vendedor)
        {
            _applicationDbContext.Update(vendedor);
        }

        public void Eliminar(Vendedor vendedor)
        {
            _applicationDbContext.Remove(vendedor);
        }

        
    }
}
