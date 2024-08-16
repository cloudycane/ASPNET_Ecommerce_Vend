namespace EcommerceProyecto.Models
{
    public class Reseña
    {
        public Guid ReseñaId { get; set; }
        public Guid ConsumidorId { get; set; }
        public Guid VendedorId { get; set; }
        public Guid ProductoId { get; set; }
        public DateTime FechaReseña { get; set; }
    }
}
