namespace IdentityDemo.Models
{
    public class EstadisticaUsuario
    {
        public string? Email { get; set; }
        public string? Roles { get; set; }
        public int TotalTareas { get; set; }
        public int TareasPendientes { get; set; }
        public int TareasEnProceso { get; set; }
        public int TareasCompletadas { get; set; }
    }
}
