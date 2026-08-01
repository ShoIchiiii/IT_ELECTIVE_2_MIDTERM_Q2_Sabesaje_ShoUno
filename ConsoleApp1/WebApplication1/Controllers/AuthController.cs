using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDto());
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            if (dto.Username == "admin" && dto.Password == "password123")
            {
                HttpContext.Session.SetString("UserSession", dto.Username);
                return RedirectToAction("Index", "Playlist");
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View(dto);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}