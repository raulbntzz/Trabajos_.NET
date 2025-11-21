using ProyectoRaulBenitezOscarSaez.Models;

namespace ProyectoRaulBenitezOscarSaez.Services
{
    public class TestGlobalService
    {
        public List<PreguntaGlobal> Preguntas { get; }

        public TestGlobalService()
        {
            Preguntas = new List<PreguntaGlobal>
            {
                new PreguntaGlobal
                {
                    Id = 1,
                    Enunciado = "¿Cuánto es 2 + 2?",
                    Respuestas = new() { "1", "2", "3", "4" },
                    Correcta = 3 // índice 3 → “4”
                },
                new PreguntaGlobal
                {
                    Id = 2,
                    Enunciado = "Capital de Francia",
                    Respuestas = new() { "Roma", "Madrid", "París", "Lisboa" },
                    Correcta = 2 // índice 2 → “París”
                }
            };
        }
    }
}
