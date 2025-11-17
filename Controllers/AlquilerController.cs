using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace alquiler.Controllers
{
    public class AlquilerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string zona, int metros, bool piscina)
        {
            decimal precioPorMetro = 0;

            switch (zona)
            {
                case "Getafe":
                    precioPorMetro = 10;
                    break;
                case "Fuenlabrada":
                    precioPorMetro = 9;
                    break;
                case "Móstoles":
                    precioPorMetro = 8;
                    break;
                case "Alcorcón":
                    precioPorMetro = 11;
                    break;
            }

            decimal Precio = metros * precioPorMetro;

            if (piscina)
            {
                Precio += 100;
                Debug.WriteLine("Paso por aquí");
            }

            ViewBag.Precio = Precio;
            return View();
        }
    }
}
