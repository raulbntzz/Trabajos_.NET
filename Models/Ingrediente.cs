using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecetasCocina_AE4.Models
{
    [Table("Ingrediente")]
    public class Ingrediente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(50, ErrorMessage = "La categoría no puede exceder 50 caracteres")]
        [Column("categoria")]
        public string? Categoria { get; set; }
        
        [Required]
        [Column("user_id")]
        public string UsuarioId { get; set; } = string.Empty;
        
        public ApplicationUser? Usuario { get; set; }
        
        public ICollection<RecetaIngrediente> RecetaIngredientes { get; set; } = new List<RecetaIngrediente>();
    }
}
