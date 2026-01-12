using System.ComponentModel.DataAnnotations;

namespace RecetasCocina_AE4.DTOs
{
    public class RecetaDto
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
        
        [Required(ErrorMessage = "La preparación es obligatoria")]
        [StringLength(2000, ErrorMessage = "La preparación no puede exceder 2000 caracteres")]
        [Display(Name = "Preparación")]
        [DataType(DataType.MultilineText)]
        public string Preparacion { get; set; } = string.Empty;
        
        [Range(1, 1000, ErrorMessage = "El tiempo debe estar entre 1 y 1000 minutos")]
        [Display(Name = "Tiempo de Preparación (minutos)")]
        public int TiempoPreparacionMinutos { get; set; }
        
        [Range(1, 100, ErrorMessage = "Las porciones deben estar entre 1 y 100")]
        [Display(Name = "Porciones")]
        public int Porciones { get; set; }
        
        [Display(Name = "URL de Imagen")]
        [DataType(DataType.Url)]
        public string? ImagenUrl { get; set; }
        
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }
        
        public List<IngredienteRecetaDto> Ingredientes { get; set; } = new List<IngredienteRecetaDto>();
    }
}
