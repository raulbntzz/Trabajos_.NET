using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioSupermercado.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [Column("idpedido")]
        public int IdPedido { get; set; }

        [Column("idcliente")]
        [StringLength(5)]
        public string IdCliente { get; set; }

        [Column("fechapedido")]
        public DateTime FechaPedido { get; set; }

        [Column("fechaentrega")]
        public DateTime FechaEntrega { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }

        public ICollection<Detalle>? Detalles { get; set; }
    }
}
