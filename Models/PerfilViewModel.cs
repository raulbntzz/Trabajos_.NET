using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models
{
    public class PerfilViewModel
    {
        [Display(Name = "Correo electrónico")]
        public string? Email { get; set; }
        
        [Display(Name = "Nombre de usuario")]
        public string? UserName { get; set; }
        
        [Display(Name = "Teléfono")]
        [Phone(ErrorMessage = "El formato del teléfono no es válido")]
        public string? PhoneNumber { get; set; }
        
        [Display(Name = "Fecha de registro")]
        public DateTime? FechaRegistro { get; set; }
    }
}
