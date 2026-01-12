using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecetasCocina_AE4.Models
{
    [Table("RecetaIngrediente")]
    public class RecetaIngrediente
    {
        [Column("receta_id")]
        public int RecetaId { get; set; }
        public Receta? Receta { get; set; }
        
        [Column("ingrediente_id")]
        public int IngredienteId { get; set; }
        public Ingrediente? Ingrediente { get; set; }
        
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [StringLength(50, ErrorMessage = "La cantidad no puede exceder 50 caracteres")]
        [Column("cantidad")]
        public string Cantidad { get; set; } = string.Empty;
    }
}
