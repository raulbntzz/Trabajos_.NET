using IdentityDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityDemo.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public PerfilController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            
            if (user == null)
                return NotFound();
            
            var model = new PerfilViewModel
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(PerfilViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            var user = await userManager.GetUserAsync(User);
            
            if (user == null)
                return NotFound();
            
            user.PhoneNumber = model.PhoneNumber;
            
            var result = await userManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                ViewBag.Mensaje = "Perfil actualizado correctamente";
                return View(model);
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            
            return View(model);
        }
    }
}
