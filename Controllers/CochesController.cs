using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller_AE4.Data;

namespace Taller_AE4.Controllers
{
    public class CochesController : Controller
    {
        private readonly TallerContext TallerContext;

        public CochesController(TallerContext context)
        {
            TallerContext = context;
        }

        public IActionResult Index()
        {
            // Cargamos los coches con su marca relacionada
            var coches = TallerContext.Coches
                                 .Include(c => c.marca)
                                 .ToList();
            return View(coches);
        }

    }
}
