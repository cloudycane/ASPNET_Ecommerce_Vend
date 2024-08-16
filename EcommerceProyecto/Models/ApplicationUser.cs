using Microsoft.AspNetCore.Identity;

namespace EcommerceProyecto.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre {  get; set; }
        public string Apellidos { get; set; }
        public string? Localidad {  get; set; }
        public string? Ciudad { get; set; }
        public string? Pais {  get; set; }
    }
}
