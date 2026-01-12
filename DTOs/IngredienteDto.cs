using System.ComponentModel.DataAnnotations;

namespace RecetasCocina_AE4.DTOs
{
    public class IngredienteDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(50, ErrorMessage = "La categoría no puede exceder 50 caracteres")]
        [Display(Name = "Categoría")]
        public string? Categoria { get; set; }
    }
}
