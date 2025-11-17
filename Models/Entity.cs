using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;


namespace Taller_AE4.Models.Entity
{
    [Table("propietario")]
    public class Propietarios
    {
        [Key]
        public int? id { get; set; }

        public string? nombre { get; set; }

        public string? email { get; set; }

        public string? telefono { get; set; }
    }

    [Table("marca")]
    public class Marcas
    {
        [Key]
        public int? id { get; set; }

        public string? nombre { get; set; }

        public string? paisOrigen { get; set; }
    }

    [Table("coche")]
    public class Coches
    {
        [Key]

        public int? id { get; set; }

        public string? modelo { get; set; }

        public int? ano { get; set; }

        public string? color { get; set; }

        [ForeignKey("marca")]
        public int marcaId { get; set; }
        public Marcas? marca { get; set; }
    }

    [Table("mantenimiento")]
    public class Mantenimientos
    {
        [Key]
        public int? id { get; set; }

        public string? fecha { get; set; }

        public string? descripcion { get; set; }

        public decimal? precio { get; set; }

        public int? cocheId { get; set; }
    }
}

