using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenDWES.Models
{
    [Table("VENTA")]
    public class Venta
    {
        [Key]
        [Column("ID_VENTA")]
        public int IdVenta { get; set; }

        [Column("PRODUCTO")]
        public string Producto { get; set; } = null!;

        [Column("CANTIDAD")]
        public int Cantidad { get; set; }

        [Column("PRECIO")]
        public double Precio { get; set; }
    }
}