using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjercicioSupermercado.Models;

namespace EjercicioSupermercado.Controllers
{
    public class ProductosController : Controller
    {
        private readonly SupermercadoContext _context;

        public ProductosController(SupermercadoContext context)
        {
            _context = context;
        }

        // GET: /Productos
        public IActionResult Index()
        {
            var productos = _context.Productos
                .Include(p => p.Categoria)
                .OrderBy(p => p.Nombre)
                .ToList();

            return View(productos);
        }

        // GET: /Productos/Filtrar
        public IActionResult Filtrar(int? idCategoria)
        {
            ViewBag.Categorias = _context.Categorias.OrderBy(c => c.Nombre).ToList();
            var productos = _context.Productos
                .Include(p => p.Categoria)
                .Where(p => idCategoria == null || p.IdCategoria == idCategoria)
                .OrderBy(p => p.Nombre)
                .ToList();

            ViewBag.IdCategoriaSeleccionada = idCategoria;
            return View(productos);
        }

        // GET: /Productos/PorCategoria
        public IActionResult PorCategoria()
        {
            var grupos = _context.Productos
                .Include(p => p.Categoria)
                .AsEnumerable()
                .GroupBy(p => p.Categoria)
                .ToList();

            return View(grupos);
        }
    }
}
