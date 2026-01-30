namespace AE_RA8_RBM.Models
{
    public class ImagenGaleria
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string UrlImagen { get; set; } = null!;
        public string Categoria { get; set; } = null!;
    }
}
