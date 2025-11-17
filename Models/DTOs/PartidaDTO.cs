namespace TorneoEsports.Models.DTOs
{
    public class PartidaDTO
    {
        public int IdPartida { get; set; }
        public int IdJugador { get; set; }
        public DateTime FechaPartida { get; set; }
        public string? Mapa { get; set; }
        public int DuracionMin { get; set; }
        public int Puntuacion { get; set; }
        public int Asesinatos { get; set; }
        public int Muertes { get; set; }
        public int Asistencias { get; set; }
        public int DanoCausado { get; set; }
        public int DanoRecibido { get; set; }
        public int ObjetivosCapturados { get; set; }
        public int Curaciones { get; set; }
        public int ExperienciaObtenida { get; set; }

        public string? NicknameJugador { get; set; }
    }
}
