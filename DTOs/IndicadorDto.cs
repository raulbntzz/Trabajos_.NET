namespace AE_RA7_RBM.DTOs
{
    public class IndicadorDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Valor { get; set; } = null!;
        public string? Unidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Ambito { get; set; } = null!;
    }
}
