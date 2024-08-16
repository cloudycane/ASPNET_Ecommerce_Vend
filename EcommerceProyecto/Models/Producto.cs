namespace EcommerceProyecto.Models
{
    public class Producto
    {
        public Guid ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public Guid VendedorId { get; set; }
        public string Descripcion {  get; set; }
        public string URLImagen {  get; set; }
        public int ValoracionProducto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool EsVerificado { get; set; }
        public bool ConIVA { get; set; }
        public bool ConDiscuento { get; set; }
        public bool ConPuntos { get; set; }
        public string PaisProducto { get; set; }
        public string LugarFabricacion { get; set; }
        public string Materiales {  get; set; }
        public float PrecioProducto {  get; set; }
    }
}
