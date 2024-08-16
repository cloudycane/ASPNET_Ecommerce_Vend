namespace EcommerceProyecto.Models
{
    public class Orden
    {
        public Guid OrdenId { get; set; }
        public Guid ConsumidorId { get; set; }
        public Guid VendedorId { get; set; }
        public Guid ProductoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int CantidadPedido { get; set; }
    }
}
