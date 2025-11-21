namespace ProyectoRaulBenitezOscarSaez.Models
{
    public class PreguntaGlobal
    {
        public int Id { get; set; }
        public string Enunciado { get; set; } = "";
        public List<string> Respuestas { get; set; } = new();
        public int Correcta { get; set; }
        public int AciertosGlobales { get; set; } = 0;
    }
}
