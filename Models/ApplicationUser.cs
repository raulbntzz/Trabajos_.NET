using Microsoft.AspNetCore.Identity;

namespace RecetasCocina_AE4.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? NombreCompleto { get; set; }
        
        public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
    }
}
