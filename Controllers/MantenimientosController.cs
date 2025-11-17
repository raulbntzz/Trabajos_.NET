using Microsoft.AspNetCore.Mvc;
using Taller_AE4.Data;

namespace Taller_AE4.Controllers
{
    public class MantenimientosController : Controller
    {
        private readonly TallerContext TallerContext;

        public MantenimientosController(TallerContext context)
        {
            TallerContext = context;
        }

        public ActionResult Index()
        {
            var mantenimientos = TallerContext.Mantenimientos.ToList();
            
            return View(mantenimientos);
        }
    }

}
