using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioSupermercado.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        [Column("idproducto")]
        public int IdProducto { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = null!;

        [Column("idcategoria")]
        public int IdCategoria { get; set; }

        [Column("medida")]
        public string Medida { get; set; } = null!;

        [Column("precio")]
        public int Precio { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        public Categoria? Categoria { get; set; }

        public ICollection<Detalle>? Detalles { get; set; }
    }
}
