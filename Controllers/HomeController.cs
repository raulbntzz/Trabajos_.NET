using AE_RA8_RBM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AE_RA8_RBM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Galeria()
        {
            // Imágenes relacionadas con Digitalización y Sostenibilidad
            var imagenes = new List<ImagenGaleria>
            {
                new ImagenGaleria
                {
                    Id = 1,
                    Titulo = "Infraestructura Cloud",
                    Descripcion = "Servidores en la nube que impulsan la transformación digital",
                    UrlImagen = "https://images.unsplash.com/photo-1544197150-b99a580bb7a8?w=800",
                    Categoria = "Digitalización"
                },
                new ImagenGaleria
                {
                    Id = 2,
                    Titulo = "Energías Renovables",
                    Descripcion = "Paneles solares para un futuro sostenible",
                    UrlImagen = "https://images.unsplash.com/photo-1509391366360-2e959784a276?w=800",
                    Categoria = "Sostenibilidad"
                },
                new ImagenGaleria
                {
                    Id = 3,
                    Titulo = "Big Data Analytics",
                    Descripcion = "Análisis de datos para decisiones inteligentes",
                    UrlImagen = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?w=800",
                    Categoria = "Digitalización"
                },
                new ImagenGaleria
                {
                    Id = 4,
                    Titulo = "Movilidad Sostenible",
                    Descripcion = "Vehículos eléctricos reduciendo emisiones de CO?",
                    UrlImagen = "https://images.unsplash.com/photo-1593941707882-a5bba14938c7?w=800",
                    Categoria = "Sostenibilidad"
                },
                new ImagenGaleria
                {
                    Id = 5,
                    Titulo = "Internet de las Cosas (IoT)",
                    Descripcion = "Dispositivos conectados mejorando la eficiencia",
                    UrlImagen = "https://images.unsplash.com/photo-1558346490-a72e53ae2d4f?w=800",
                    Categoria = "Digitalización"
                },
                new ImagenGaleria
                {
                    Id = 6,
                    Titulo = "Economía Circular",
                    Descripcion = "Reciclaje y reutilización de materiales",
                    UrlImagen = "https://images.unsplash.com/photo-1532996122724-e3c354a0b15b?w=800",
                    Categoria = "Sostenibilidad"
                },
                new ImagenGaleria
                {
                    Id = 7,
                    Titulo = "Inteligencia Artificial",
                    Descripcion = "Machine Learning transformando industrias",
                    UrlImagen = "https://images.unsplash.com/photo-1677442136019-21780ecad995?w=800",
                    Categoria = "Digitalización"
                },
                new ImagenGaleria
                {
                    Id = 8,
                    Titulo = "Conservación Ambiental",
                    Descripcion = "Protección de ecosistemas naturales",
                    UrlImagen = "https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=800",
                    Categoria = "Sostenibilidad"
                },
                new ImagenGaleria
                {
                    Id = 9,
                    Titulo = "Ciberseguridad",
                    Descripcion = "Protección de datos e infraestructura digital",
                    UrlImagen = "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?w=800",
                    Categoria = "Digitalización"
                },
                new ImagenGaleria
                {
                    Id = 10,
                    Titulo = "Agricultura Sostenible",
                    Descripcion = "Prácticas agrícolas respetuosas con el medio ambiente",
                    UrlImagen = "https://images.unsplash.com/photo-1625246333195-78d9c38ad449?w=800",
                    Categoria = "Sostenibilidad"
                },
                new ImagenGaleria
                {
                    Id = 11,
                    Titulo = "Smart Cities",
                    Descripcion = "Ciudades inteligentes con tecnología IoT",
                    UrlImagen = "https://images.unsplash.com/photo-1480714378408-67cf0d13bc1b?w=800",
                    Categoria = "Digitalización"
                },
                new ImagenGaleria
                {
                    Id = 12,
                    Titulo = "Eficiencia Energética",
                    Descripcion = "Edificios inteligentes que ahorran energía",
                    UrlImagen = "https://images.unsplash.com/photo-1497435334941-8c899ee9e8e9?w=800",
                    Categoria = "Sostenibilidad"
                }
            };

            return View(imagenes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
