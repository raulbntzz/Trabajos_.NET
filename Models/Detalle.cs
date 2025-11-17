using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioSupermercado.Models
{
    [Table("detalle")]
    public class Detalle
    {
        [Key]
        [Column("idpedido")]
        public int IdPedido { get; set; }

        [Key]
        [Column("idproducto")]
        public int IdProducto { get; set; }

        [Column("precio")]
        public float Precio { get; set; }

        [Column("unidades")]
        public int Unidades { get; set; }

        [Column("descuento")]
        public float Descuento { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido? Pedido { get; set; }

        [ForeignKey("IdProducto")]
        public Producto? Producto { get; set; }
    }
}
