namespace EcommerceProyecto.Models
{
    public class Carrito
    {
        public Guid CarritoId { get; set; }
        public Guid ProductoId { get; set; }
        public Guid VendedorId { get; set; }
        public Guid ConsumidorId { get; set; }
    }
}
