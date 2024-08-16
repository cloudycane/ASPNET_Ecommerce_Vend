using EcommerceProyecto.Data;
using EcommerceProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProyecto.Repositories
{
    public interface ICarritosRepositorio
    {

    }
    public class CarritosRepositorio : ICarritosRepositorio
    {
        
        private readonly ApplicationDbContext dbContext;

        public CarritosRepositorio(ApplicationDbContext _dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ObtenerPorID(Carrito carritos)
        {
            await dbContext.carritos.ToListAsync();
        }

    }
}
