using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjercicioSupermercado.Models;

namespace EjercicioSupermercado.Controllers
{
    public class PedidosController : Controller
    {
        private readonly SupermercadoContext _context;

        public PedidosController(SupermercadoContext context)
        {
            _context = context;
        }

        // ✅ Muestra todos los pedidos con su cliente
        public IActionResult Index()
        {
            var pedidos = _context.Pedidos
                .Include(p => p.Cliente)
                .OrderByDescending(p => p.FechaPedido)
                .ToList();

            return View(pedidos);
        }

        // ✅ Muestra los detalles de un pedido concreto
        public IActionResult Detalle(int id)
        {
            var pedido = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Detalles)!
                    .ThenInclude(d => d.Producto)
                    .ThenInclude(prod => prod!.Categoria)
                .FirstOrDefault(p => p.IdPedido == id);

            if (pedido == null)
                return NotFound();

            return View(pedido);
        }
    }
}
