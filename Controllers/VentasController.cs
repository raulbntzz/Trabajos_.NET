using Microsoft.AspNetCore.Mvc;
using ExamenDWES.Models;

namespace ExamenDWES.Controllers
{
    public class HomeController : Controller
    {
        private readonly ExamenDWESContext _context;

        public HomeController(ExamenDWESContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? producto)
        {
            var ventas = string.IsNullOrEmpty(producto)
                ? _context.Ventas.ToList()
                : _context.Ventas.Where(v => v.Producto == producto).ToList();

            ViewBag.Productos = _context.Ventas
                .Select(v => v.Producto)
                .Distinct()
                .OrderBy(p => p)
                .ToList();

            ViewBag.ProductoSeleccionado = producto;

            return View(ventas);
        }





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Ventas.Add(venta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venta);
        }






        [HttpPost]
        public IActionResult Delete(int id)
        {
            var venta = _context.Ventas.Find(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}