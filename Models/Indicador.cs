using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AE_RA7_RBM.Models
{
    [Table("Indicador")]
    public class Indicador
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("tipo")]
        public string Tipo { get; set; } = null!;
        
        [Column("categoria")]
        public string Categoria { get; set; } = null!;
        
        [Column("nombre")]
        public string Nombre { get; set; } = null!;
        
        [Column("descripcion")]
        public string? Descripcion { get; set; }
        
        [Column("valor")]
        public string Valor { get; set; } = null!;
        
        [Column("unidad")]
        public string? Unidad { get; set; }
        
        [Column("fecha")]
        public DateTime Fecha { get; set; }
        
        [Column("ambito")]
        public string Ambito { get; set; } = null!;
    }
}
