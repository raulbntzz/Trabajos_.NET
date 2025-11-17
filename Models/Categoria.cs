using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioSupermercado.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("idcategoria")]
        public int IdCategoria { get; set; }

        [Column("categoria")]
        public string Nombre { get; set; } = null!;

        public ICollection<Producto>? Productos { get; set; }
    }
}
