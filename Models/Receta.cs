using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecetasCocina_AE4.Models
{
    [Table("Receta")]
    public class Receta
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        [Column("descripcion")]
        public string? Descripcion { get; set; }
        
        [Required(ErrorMessage = "La preparación es obligatoria")]
        [StringLength(2000, ErrorMessage = "La preparación no puede exceder 2000 caracteres")]
        [Column("preparacion")]
        public string Preparacion { get; set; } = string.Empty;
        
        [Range(1, 1000, ErrorMessage = "El tiempo de preparación debe estar entre 1 y 1000 minutos")]
        [Column("tiempo_preparacion_minutos")]
        public int TiempoPreparacionMinutos { get; set; }
        
        [Range(1, 100, ErrorMessage = "Las porciones deben estar entre 1 y 100")]
        [Column("porciones")]
        public int Porciones { get; set; }
        
        [Column("imagen_url")]
        public string? ImagenUrl { get; set; }
        
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        
        [Required]
        [Column("user_id")]
        public string UsuarioId { get; set; } = string.Empty;
        
        public ApplicationUser? Usuario { get; set; }
        
        public ICollection<RecetaIngrediente> RecetaIngredientes { get; set; } = new List<RecetaIngrediente>();
    }
}
