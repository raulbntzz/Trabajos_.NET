using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionEscuela.Controllers
{
    public class CuentaController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string password)
        {
            string rolAsignado = "";
            string nombre = "";
            string apellidos = "";
            string email = "";
            string fechaNacimiento = "";
            string telefono = "";
            string id = "";

            // Validación simple (sin BD)
            if (usuario == "admin" && password == "1234")
            {
                rolAsignado = "admin";
                id = "1";
                nombre = "Ana";
                apellidos = "Admin Pérez";
                email = "admin@escuela.com";
                fechaNacimiento = "01/01/1990";
                telefono = "600000001";
            }
            else if (usuario == "profe" && password == "1234")
            {
                rolAsignado = "profesor";
                id = "2";
                nombre = "Pedro";
                apellidos = "Profesor Gómez";
                email = "profe@escuela.com";
                fechaNacimiento = "10/05/1985";
                telefono = "600000002";
            }
            else if (usuario == "alumno" && password == "1234")
            {
                rolAsignado = "alumno";
                id = "3";
                nombre = "Laura";
                apellidos = "Alumna Díaz";
                email = "alumno@escuela.com";
                fechaNacimiento = "20/03/2005";
                telefono = "600000003";
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }

            // Crear los claims (datos del usuario)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Name, usuario),
                new Claim(ClaimTypes.GivenName, nombre),
                new Claim(ClaimTypes.Surname, apellidos),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.DateOfBirth, fechaNacimiento),
                new Claim(ClaimTypes.MobilePhone, telefono),
                new Claim(ClaimTypes.Role, rolAsignado)
            };

            // Crear identidad
            var identidad = new ClaimsIdentity(claims, "cookieAuth");

            // Crear principal
            var principal = new ClaimsPrincipal(identidad);

            // Crear la cookie de autenticación
            HttpContext.SignInAsync("cookieAuth", principal).Wait();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync("cookieAuth").Wait();
            return RedirectToAction("Login");
        }

        public IActionResult Denegado()
        {
            return View();
        }

        [Authorize]
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
