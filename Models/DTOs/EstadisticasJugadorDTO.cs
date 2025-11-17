namespace TorneoEsports.Models.DTOs
{
    public class EstadisticasJugadorDTO
    {
        public int IdJugador { get; set; }
        public string Nickname { get; set; } = null!;
        public double PromedioAsesinatos { get; set; }
        public double PromedioMuertes { get; set; }
        public double PromedioAsistencias { get; set; }
        public double PromedioDanoCausado { get; set; }
        public double PromedioPuntuacion { get; set; }
    }
}
