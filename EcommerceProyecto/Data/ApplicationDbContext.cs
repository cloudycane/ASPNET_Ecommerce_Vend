using EcommerceProyecto.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EcommerceProyecto.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Carrito> carritos { get; set; }
        public DbSet<Consumidor> consumidores { get; set; }
        public DbSet<Orden> ordenes { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Reseña> reseñas { get; set; }
        public DbSet<Transaccion> transacciones { get; set; }
        public DbSet<Vendedor> vendedores { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

         
        }

    }
}
