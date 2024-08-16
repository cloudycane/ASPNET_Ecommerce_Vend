namespace EcommerceProyecto.Models
{
    public class Transaccion
    {
        public Guid TransaccionId { get; set; }
        public Guid VendedorId { get; set; } // Llave fóranea - puedes obtener el nombre y apellidos del vendedor
        public Guid ConsumidorId { get; set; } // Llave fóranea - puedes obtener el nombre y appellidos del consumidor 
        public Guid OrdenId { get; set; } // Llave fóranea para obtener los detalles de orden
        public DateTime Fecha_Transaccion { get; set; }
        
    }
}
