using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioSupermercado.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Column("idcliente")]
        [StringLength(5)]
        public string IdCliente { get; set; }

        [Column("cia")]
        public string Cia { get; set; }

        [Column("contacto")]
        public string Contacto { get; set; }

        [Column("cargo")]
        public string Cargo { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("ciudad")]
        public string Ciudad { get; set; }

        [Column("region")]
        public string? Region { get; set; }

        [Column("cp")]
        public string? CP { get; set; }

        [Column("pais")]
        public string Pais { get; set; }

        [Column("tlf")]
        public string? Telefono { get; set; }

        [Column("fax")]
        public string? Fax { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
