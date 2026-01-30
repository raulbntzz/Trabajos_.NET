namespace AE_RA8_RBM.Models
{
    public class ResumenIndicadores
    {
        public int TotalIndicadores { get; set; }
        public Dictionary<string, int> TotalPorTipo { get; set; } = new();
        public Dictionary<string, int> TotalPorAmbito { get; set; } = new();
        public Dictionary<string, int> TotalPorCategoria { get; set; } = new();
    }
}
