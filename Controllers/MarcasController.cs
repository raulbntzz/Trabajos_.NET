using Microsoft.AspNetCore.Mvc;
using Taller_AE4.Data;

namespace Taller_AE4.Controllers
{
    public class MarcasController : Controller
    {
        private readonly TallerContext TallerContext;

        public MarcasController(TallerContext context)
        {
            TallerContext = context;
        }

        public ActionResult Index()
        {
            var marcas = TallerContext.Marcas.ToList();
            
            return View(marcas);
        }


    }

}
