using Microsoft.AspNetCore.Mvc;
using EjercicioSupermercado.Models;

namespace EjercicioSupermercado.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly SupermercadoContext _context;

        public CategoriasController(SupermercadoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }
    }
}
