namespace TorneoEsports.Models.DTOs
{
    public class ComparativaDanoDTO
    {
        public string Nickname { get; set; } = null!;
        public int TotalDanoCausado { get; set; }
        public int TotalDanoRecibido { get; set; }
    }
}
