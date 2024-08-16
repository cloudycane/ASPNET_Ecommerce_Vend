using Microsoft.AspNetCore.Identity;

namespace EcommerceProyecto.Models
{
    public class Consumidor
    {
        public Guid ConsumidorId { get; set; }
        public string NombreConsumidor { get; set; }
        public string ApellidosConsumidor { get; set; }
        public string Direccion {  get; set; }
        public string NumTelefono { get; set; }
        public string TarjetCredito { get; set; }
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

        public int Valoracion { get; set; } // El que dará la valoración

        public bool EsVerificado { get; set; }
    }
}
