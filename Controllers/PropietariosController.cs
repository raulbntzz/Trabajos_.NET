using Microsoft.AspNetCore.Mvc;
using Taller_AE4.Data;

namespace Taller_AE4.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly TallerContext TallerContext;

        public PropietariosController(TallerContext context)
        {
            TallerContext = context;
        }

        public ActionResult Index()
        {
            var propietarios = TallerContext.Propietarios.ToList();
            
            return View(propietarios);
        }


    }

}
