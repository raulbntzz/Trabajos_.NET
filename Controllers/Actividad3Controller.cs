using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Actividad3.Controllers
{
    public class Actividad3Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ejercicio1()
        {
            return View("Ejercicio1");
        }

        [HttpPost]
        public IActionResult Ejercicio1(string equipoLocal, string equipoVisitante, int golLocal, int golVisitante)
        {
            string mensaje;

            if (golLocal > golVisitante)
            {
                mensaje = "El equipo " + equipoLocal + " es el ganador del torneo";
            }   else if (golLocal == golVisitante)
            {
                mensaje = "El torneo ha quedado empate.";
            }   else if (golLocal < golVisitante)
            {
                mensaje = "El equipo " + equipoVisitante + " es el ganador del torneo";
            }   else
            {
                mensaje = "Error, ha ocurrido un error inesperado";
            }


                ViewBag.mensaje = mensaje;
            return View();
        }

        public class Jugador
        {
            public string Nombre { get; set; }
            public int Dorsal { get; set; }

            public string Posicion { get; set; }

            public Jugador(string nombre, int dorsal, string posicion)
            {
                Nombre = nombre;
                Dorsal = dorsal;
                Posicion = posicion;
            }
        }

        public IActionResult Ejercicio2()
        {
            Jugador[] jugadores = {
                new Jugador("Thibaut Courtois", 1, "Portero"),
                new Jugador("Andriy Lunin", 13, "Portero"),
                new Jugador("Fran González", 30, "Portero"),

                new Jugador("Dani Carvajal", 2, "Lateral derecho"),
                new Jugador("Éder Militão", 3, "Defensa central"),
                new Jugador("David Alaba", 4, "Lateral izquierdo"),
                new Jugador("Trent Alexander-Arnold", 12, "Lateral derecho"),
                new Jugador("Antonio Rüdiger", 22, "Defensa central"),
                new Jugador("Ferland Mendy", 23, "Lateral izquierdo"),
                new Jugador("Álvaro Carreras", 18, "Lateral izquierdo"),
                new Jugador("Fran García", 20, "Lateral izquierdo"),
                new Jugador("Dean Huijsen", 24, "Defensa central"),

                new Jugador("Raúl Asencio", 17, "Delantero centro"),
                new Jugador("Gonzalo García", 16, "Extremo"),
                new Jugador("Eduardo Camavinga", 6, "Interior izquierdo"),
                new Jugador("Aurélien Tchouaméni", 14, "Mediocentro defensivo"),
                new Jugador("Fede Valverde", 8, "Mediocampista"),
                new Jugador("Dani Ceballos", 19, "Mediocentro"),
                new Jugador("Jude Bellingham", 5, "Mediapunta"),
                new Jugador("Arda Güler", 15, "Extremo derecho"),
                new Jugador("Fran Mastantuono", 30, "Extremo derecho"),

                new Jugador("Vinícius Júnior", 7, "Extremo izquierdo"),
                new Jugador("Rodrygo", 11, "Extremo derecho"),
                new Jugador("Kylian Mbappé", 10, "Delantero centro"),
                new Jugador("Endrick", 9, "Delantero centro"),
                new Jugador("Brahim Díaz", 21, "Extremo derecho")
            };




            ViewBag.jugadores = jugadores;
                return View("Ejercicio2");
            }

    }
}
