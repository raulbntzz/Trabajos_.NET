using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneoEsports.Models.Entidades
{
    [Table("jugador")]
    public class Jugador
    {
        [Key]
        [Column("id_jugador")]
        public int IdJugador { get; set; }

        [Required]
        [Column("nickname")]
        public string Nickname { get; set; } = null!;

        [Column("equipo")]
        public string? Equipo { get; set; }

        [Column("pais")]
        public string? Pais { get; set; }

        [Column("edad")]
        public int? Edad { get; set; }

        [Column("nivel")]
        public int Nivel { get; set; }

        [Column("victorias")]
        public int Victorias { get; set; }

        [Column("derrotas")]
        public int Derrotas { get; set; }

        public ICollection<Partida> Partidas { get; set; } = new List<Partida>();
    }
}
