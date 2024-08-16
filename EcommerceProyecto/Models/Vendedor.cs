using Microsoft.AspNetCore.Identity;

namespace EcommerceProyecto.Models
{
    public class Vendedor
    {
        public Guid VendedorId { get; set; }
        public string NombreVendedor { get; set; }
        public string ApellidosVendedor { get; set; }
        public string Direccion {  get; set; }
        public string NumTelefono { get; set; }
        public string TarjetaDeCredito { get; set; }
        public string Correo_Electronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            {
                var today = DateTime.Today;
                var edad = today.Year - FechaNacimiento.Year;
                return edad;
            }
        }
        public int Valoracion { get; set; }
        public bool EsVerificado { get; set; }
        public Guid PostId { get; set; }

    }
}
