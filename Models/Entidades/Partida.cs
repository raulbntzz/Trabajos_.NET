using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorneoEsports.Models.Entidades
{
    [Table("partida")]
    public class Partida
    {
        [Key]
        [Column("id_partida")]
        public int IdPartida { get; set; }

        [Column("id_jugador")]
        public int IdJugador { get; set; }

        public Jugador Jugador { get; set; } = null!;

        [Column("fecha_partida")]
        public DateTime FechaPartida { get; set; }

        [Column("mapa")]
        public string? Mapa { get; set; }

        [Column("duracion_min")]
        public int DuracionMin { get; set; }

        [Column("puntuacion")]
        public int Puntuacion { get; set; }

        [Column("asesinatos")]
        public int Asesinatos { get; set; }

        [Column("muertes")]
        public int Muertes { get; set; }

        [Column("asistencias")]
        public int Asistencias { get; set; }

        [Column("dano_causado")]
        public int DanoCausado { get; set; }

        [Column("dano_recibido")]
        public int DanoRecibido { get; set; }

        [Column("objetivos_capturados")]
        public int ObjetivosCapturados { get; set; }

        [Column("curaciones")]
        public int Curaciones { get; set; }

        [Column("experiencia_obtenida")]
        public int ExperienciaObtenida { get; set; }
    }
}
