using EcommerceProyecto.Data;
using EcommerceProyecto.Models;

namespace EcommerceProyecto.Repositories
{

    public interface IUnidad
    {
        void Save(Vendedor vendedor);
    }
    public class Unidad : IUnidad
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IVendedoresRepositorio Vendedores {  get; set; }
        public Unidad(ApplicationDbContext applicationDbContext) 
        { 
            _applicationDbContext = applicationDbContext;
            Vendedores = new VendedoresRepositorio(_applicationDbContext);
        }

        public void Save(Vendedor vendedor)
        {
            _applicationDbContext.SaveChanges();
        }
    }
}

