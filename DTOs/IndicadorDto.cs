using System.ComponentModel.DataAnnotations;

namespace AE_RA8_RBM.DTOs
{
    public class IndicadorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; } = null!;

        [Required(ErrorMessage = "La categoría es obligatoria")]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; } = null!;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [Display(Name = "Valor")]
        public string Valor { get; set; } = null!;

        [Display(Name = "Unidad")]
        public string? Unidad { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El ámbito es obligatorio")]
        [Display(Name = "Ámbito")]
        public string Ambito { get; set; } = null!;
    }
}
